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
            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData contact = new ContactData("FirstName1", "LastName2");
            app.Contact.Create(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData contact = new ContactData("", "");
            app.Contact.Create(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

    }
}