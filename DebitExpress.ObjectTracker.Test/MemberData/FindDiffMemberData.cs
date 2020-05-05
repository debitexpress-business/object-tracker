using DebitExpress.ObjectTracker.Test.Pocos;
using System.Collections.Generic;

namespace DebitExpress.ObjectTracker.Test.MemberData
{
    public class FindDiffMemberData
    {
        public static IEnumerable<object[]> ResultData = new List<object[]>
        {
            new object[]
            {
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                0, 0, 0
            },
            new object[]
            {
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                new Person() { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1" },
                0, 0, 1
            },
            new object[]
            {
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                new AnotherPerson()
                    { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1", Address = "Address1" },
                0, 1, 1
            },
            new object[]
            {
                new AnotherPerson()
                    { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1", Address = "Address1" },
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                1, 0, 1
            },
            new object[]
            {
                new UntrackPerson()
                    { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1", Address = "Address1" },
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                1, 0, 1
            },
            new object[]
            {
                new Person() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                new UntrackPerson()
                    { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1", Address = "Address1" },
                0, 2, 1
            },
            new object[]
            {
                new AnotherPerson() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                new UntrackPerson()
                    { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1", Address = "Address1" },
                0, 1, 2
            },
            new object[]
            {
                new UntrackPerson()
                    { Id = 1, FirstName = "FN2", MiddleName = "MN1", LastName = "LN1", Address = "Address1" },
                new AnotherPerson() { Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1" },
                1, 0, 1
            },
            new object[]
            {
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"}
                    },
                },
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"},
                    },
                },
                0, 0, 0
            },
            new object[]
            {
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"}
                    },
                },
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline2"},
                    },
                },
                0, 0, 1
            },
            new object[]
            {
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"}
                    },
                },
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline2"},
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline2"},
                    },
                },
                0, 0, 1
            },
            new object[]
            {
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"},
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"}
                    },
                },
                new UntrackPerson()
                {
                    Id = 1, FirstName = "FN1", MiddleName = "MN1", LastName = "LN1", Address = "Address1",
                    Contacts = new List<Contact>()
                    {
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline1"},
                        new Contact() { Mobile = "Mobile1", Email = "Email1", Landline = "Landline2"},
                    },
                },
                0, 0, 1
            },
        };
    }
}