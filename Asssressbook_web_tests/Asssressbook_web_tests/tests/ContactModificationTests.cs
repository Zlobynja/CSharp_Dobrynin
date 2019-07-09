using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.Exists();
            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData oldData = oldContact[0];

            ContactData newData = new ContactData("1stName", "2ndName");
            app.Contact.Modify(0, newData);
            Assert.AreEqual(oldContact.Count, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, oldData.Firstname);
                    Assert.AreEqual(newData.Lastname, oldData.Lastname);
                }
            }

        }
    }
}