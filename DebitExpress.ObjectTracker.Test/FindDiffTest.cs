using DebitExpress.ObjectTracker.Test.MemberData;
using Shouldly;
using System.Linq;
using Xunit;

namespace DebitExpress.ObjectTracker.Test
{
    public class FindDiffTest
    {
        [Theory]
        [MemberData(nameof(FindDiffMemberData.ResultData), MemberType = typeof(FindDiffMemberData))]
        public void WhenCalled_ShouldReturnExpectedResult(object current, object model, int added, int removed, int modified)
        {
            var diff = current.FindChanges(model);
            var addedCount = diff.Count(c => c.ChangeType == ChangeType.Added);
            var removedCount = diff.Count(c => c.ChangeType == ChangeType.Removed);
            var modifiedCount = diff.Count(c => c.ChangeType == ChangeType.Modified);

            addedCount.ShouldBe(added);
            removedCount.ShouldBe(removed);
            modifiedCount.ShouldBe(modified);
        }
    }
}