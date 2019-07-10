using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Groups.Exists();
            List<GroupData> oldGroups = GroupData.GetAll(); //app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            GroupData newData = new GroupData("gr6edited");
            newData.Header = "editedheader";
            newData.Footer = "editedfooter";
            app.Groups.Modify(oldData, newData);

            // app.Groups.Modify(0, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll(); //app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, oldData.Name);
                }
            }

        }
    }
}