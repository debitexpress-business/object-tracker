using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DebitExpress.ObjectTracker
{
    public static class TrackerExtensions
    {
        /// <summary>
        /// Find property changes of the current object based on object model
        /// </summary>
        /// <param name="current"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<ChangeResult> FindChanges(this object current, object model)
        {
            var currentProperties = current.GetType().GetProperties();
            var notTrackItems = currentProperties
                .Where(p => Attribute.IsDefined(p, typeof(UntrackAttribute)))
                .Select(p => p.Name)
                .ToList();

            var currentToken = JToken.FromObject(current);
            var modelToken = JToken.FromObject(model);
            var diff = FindDiff(currentToken, modelToken);

            foreach (var item in notTrackItems)
            {
                diff.RemoveAll(t => t.PropertyName == item);
            }

            return diff;
        }

        private static List<ChangeResult> FindDiff(JToken current, JToken model)
        {
            var diff = new List<ChangeResult>();
            if (JToken.DeepEquals(current, model)) return diff;

            if (current.Type != JTokenType.Object) return diff;
            
            var currentJObj = current as JObject;
            var modelJObj = model as JObject;
            var addedKeys = GetAddedKeys(currentJObj, modelJObj);
            var removedKeys = GetRemovedKeys(currentJObj, modelJObj);
            var unchangedKeys = GetUnchangedKeys(currentJObj, model);
            var modifiedKeys = GetModifiedKeys(currentJObj, addedKeys, unchangedKeys);

            AddKeysToDiffList(diff, addedKeys, ChangeType.Added);
            AddKeysToDiffList(diff, removedKeys, ChangeType.Removed);
            AddKeysToDiffList(diff, modifiedKeys, ChangeType.Modified);

            return diff;
        }

        private static List<string> GetAddedKeys(JObject current, JObject model)
        {
            var addedKeys = current?.Properties()
                .Select(c => c.Name)
                .Except(model?.Properties()
                            .Select(c => c.Name) ?? throw new ArgumentNullException(nameof(model)))
                .ToList();
            return addedKeys;
        }

        private static IEnumerable<string> GetRemovedKeys(JObject current, JObject model)
        {
            var removedKeys = model?.Properties()
                .Select(c => c.Name)
                .Except(current?.Properties()
                            .Select(c => c.Name) ?? throw new ArgumentNullException(nameof(current)))
                .ToList();
            return removedKeys;
        }

        private static IEnumerable<string> GetUnchangedKeys(JObject current, JToken model)
        {
            var unchangedKeys = current?.Properties()
                .Where(c => JToken.DeepEquals(c.Value, model[c.Name]))
                .Select(c => c.Name)
                .ToList();
            return unchangedKeys;
        }

        private static IEnumerable<string> GetModifiedKeys(JObject current, IEnumerable<string> addedKeys,
            IEnumerable<string> unchangedKeys)
        {
            var potentiallyModifiedKeys = current?.Properties()
                .Select(c => c.Name)
                .Except(addedKeys)
                .Except(unchangedKeys);
            return potentiallyModifiedKeys;
        }

        private static void AddKeysToDiffList(ICollection<ChangeResult> diff, IEnumerable<string> keys,
            ChangeType changeType)
        {
            foreach (var key in keys)
            {
                var added = diff.Count(item => item.PropertyName == key) > 0;
                if (!added) diff.Add(new ChangeResult { PropertyName = key, ChangeType = changeType });
            }
        }

        /// <summary>
        /// Create a full copy of an object using Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Copy<T>(this T obj) where T : new()
        {
            var str = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(str);
        }
    }
}