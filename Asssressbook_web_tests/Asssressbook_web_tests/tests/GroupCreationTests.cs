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
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }

        [Test]

        public void EmptyGroupCreationTest()
        {
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            GroupData group = new GroupData("");
            app.Groups.Create(group);
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
            List<GroupData> newgroups = app.Groups.GetGroupList();
            // oldgroups.Add(group); не надо добавлять, т.к.не создается запись
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}