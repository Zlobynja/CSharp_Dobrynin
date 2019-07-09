using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newdata = new ContactData("1stName");
            newdata.Middlename = "2Name";
            newdata.Lastname = "3Name";
            newdata.Nickname = "4name";
            app.Contact.Modify(1, newdata);
        }
    }
}