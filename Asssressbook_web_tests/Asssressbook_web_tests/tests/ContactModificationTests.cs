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
            List<ContactData> oldcontact = app.Contact.GetContactList();

            ContactData newdata = new ContactData("1stName", "2ndName");
            app.Contact.Modify(0, newdata);


            List<ContactData> newcontact = app.Contact.GetContactList();
            oldcontact[0].Firstname = newdata.Firstname;
            oldcontact[0].Lastname = newdata.Lastname;
            oldcontact.Sort();
            newcontact.Sort();
            Assert.AreEqual(oldcontact, newcontact);

        }
    }
}