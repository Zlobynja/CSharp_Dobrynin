using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {

            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verifiaction
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {

            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            //verifiaction
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}