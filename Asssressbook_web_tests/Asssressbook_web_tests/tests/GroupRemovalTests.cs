using System.Collections.Generic;
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
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newgroups);
        }

    }
}