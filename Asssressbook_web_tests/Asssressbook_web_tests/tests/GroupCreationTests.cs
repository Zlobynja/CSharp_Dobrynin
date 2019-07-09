
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {


            GroupData group = new GroupData("gr4");
            group.Header = "gr4header";
            group.Footer = "gr4footer";
            app.Groups.Create(group);
        }
                [Test]

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
        }


    }
}