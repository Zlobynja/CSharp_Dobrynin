using System.Collections.Generic;
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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]

        public void EmptyGroupCreationTest()
        {
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            GroupData group = new GroupData("");
            app.Groups.Create(group);
            Assert.AreEqual(oldgroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }

        [Test]

        public void BadGroupCreationTest()
        {
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            GroupData group = new GroupData("a'a");
            app.Groups.Create(group);
            Assert.AreEqual(oldgroups.Count + 1, app.Groups.GetGroupCount());
        }
    }
}