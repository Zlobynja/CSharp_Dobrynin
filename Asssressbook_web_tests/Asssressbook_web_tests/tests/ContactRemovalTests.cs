using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.Exists();
            List<ContactData> oldcontacts = app.Contact.GetContactList();
            app.Contact.Remove(0);
            List<ContactData> newcontacts = app.Contact.GetContactList();
            oldcontacts.RemoveAt(0);
            Assert.AreEqual(oldcontacts, newcontacts);
        }

    }
}