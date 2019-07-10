﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.Exists();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact.Remove(toBeRemoved);
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

    }
}