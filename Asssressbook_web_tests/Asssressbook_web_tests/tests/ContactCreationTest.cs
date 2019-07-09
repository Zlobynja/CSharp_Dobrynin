using System.Collections.Generic;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldcontact = app.Contact.GetContactList();
            ContactData contact = new ContactData("FirstName1", "LastName2");
            contact.Middlename = "MiddleName";
            contact.Nickname = "Nickname";
            contact.Email1 = "test1@test.ru";
            contact.HomeTel = "+7-496-123-45-67";
            app.Contact.Create(contact);
            List<ContactData> newcontact = app.Contact.GetContactList();
            oldcontact.Add(contact);
            oldcontact.Sort();
            newcontact.Sort();
            Assert.AreEqual(oldcontact, newcontact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            List<ContactData> oldcontact = app.Contact.GetContactList();
            ContactData contact = new ContactData("", "");
            app.Contact.Create(contact);
            List<ContactData> newcontact = app.Contact.GetContactList();
            oldcontact.Add(contact);
            oldcontact.Sort();
            newcontact.Sort();
            Assert.AreEqual(oldcontact.Count, newcontact.Count);
        }

    }
}