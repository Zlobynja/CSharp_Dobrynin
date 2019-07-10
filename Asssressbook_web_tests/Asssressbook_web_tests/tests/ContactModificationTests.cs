using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.Exists();
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];

            ContactData newData = new ContactData("1stName", "2ndName");
            app.Contact.Modify(oldData, newData);
            Assert.AreEqual(oldContact.Count, app.Contact.GetContactCount());


            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Firstname = newData.Firstname;
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            newContact.Sort();

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