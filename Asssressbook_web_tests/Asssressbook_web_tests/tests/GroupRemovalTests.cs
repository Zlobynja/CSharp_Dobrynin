using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Exists();
            app.Groups.Remove(0);
        }

    }
}