
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            ContactData contact = new ContactData("FirstName");
            contact.Middlename = "MiddleName";
            contact.Lastname = "LastName";
            contact.Nickname = "Nickname";
            contact.Email1 = "test1@test.ru";
            contact.HomeTel = "+7-496-123-45-67";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            loginHelper.Logout();
        }


    }
}