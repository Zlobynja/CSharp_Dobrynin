using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Groups.Exists();
            List<GroupData> oldgroups = app.Groups.GetGroupList();

            GroupData newdata = new GroupData("gr6edited");
            newdata.Header = "editedheader";
            newdata.Footer = "editedfooter";
            app.Groups.Modify(0, newdata);
            List<GroupData> newgroups = app.Groups.GetGroupList();

            oldgroups[0].Name = newdata.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}