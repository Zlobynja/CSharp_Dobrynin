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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

    }
}