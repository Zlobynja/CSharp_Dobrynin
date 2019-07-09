
using NUnit.Framework;



namespace Addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            // app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}