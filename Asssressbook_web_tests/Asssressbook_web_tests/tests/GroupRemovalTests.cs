using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {

            app.Groups.Remove(1);
        }

    }
}