
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitContactCreation();
            ContactData contact = new ContactData("FirstName");
            contact.Middlename = "MiddleName";
            contact.Lastname = "LastName";
            contact.Nickname = "Nickname";
            contact.Email1 = "test1@test.ru";
            contact.HomeTel = "+7-496-123-45-67";
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Auth.Logout();
        }


    }
}