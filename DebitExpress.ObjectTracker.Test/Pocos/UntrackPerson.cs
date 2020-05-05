using System.Collections.Generic;

namespace DebitExpress.ObjectTracker.Test.Pocos
{
    public class UntrackPerson : Person
    {
        [Untrack]
        public string Address { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}