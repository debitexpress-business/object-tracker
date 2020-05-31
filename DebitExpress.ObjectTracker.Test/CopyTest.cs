using AutoFixture;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DebitExpress.ObjectTracker.Test
{
    public class CopyTest
    {
        private class CopyObject
        {
            public string Name { get; set; }
            public List<string> Contacts { get; set; }
        }
        
        [Fact]
        public void WhenCalled_ShouldReturnACopyOfObject()
        {
            var fixture = new Fixture();
            var obj = fixture.Create<CopyObject>();

            var oldObj = obj.Copy();
            
            oldObj.Contacts.Count.ShouldBe(obj.Contacts.Count);
            oldObj.Name.ShouldBe(obj.Name);

            oldObj.ShouldNotBeSameAs(obj);
        }
        
        [Fact]
        public async Task WhenCalled_ShouldReturnACopyOfObjectAsynchronously()
        {
            var fixture = new Fixture();
            var obj = fixture.Create<CopyObject>();

            var oldObj = await obj.CopyAsync();
            
            oldObj.Contacts.Count.ShouldBe(obj.Contacts.Count);
            oldObj.Name.ShouldBe(obj.Name);

            oldObj.ShouldNotBeSameAs(obj);
        }
    }
}