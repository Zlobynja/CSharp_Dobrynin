using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);
            //verifications
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void DetailsContactInformation()
        {
            ContactData fromEditForm = app.Contact.GetContactInformationFromEditForm(0);
            string fromDetails = app.Contact.GetContactInformationFromDetails(0);
            string fromForm = app.Contact.PreparedContactInformationFromEditForm(fromEditForm);
            //verifications
            Assert.AreEqual(fromDetails.Replace("\r\n\r\n", "\r\n"), fromForm);
        }
    }
}