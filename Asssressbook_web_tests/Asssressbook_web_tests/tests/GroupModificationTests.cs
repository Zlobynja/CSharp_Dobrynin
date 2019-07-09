using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newdata = new GroupData("gr6");
            newdata.Header = "gr6header";
            newdata.Footer = "gr6footer";
            app.Groups.Modify(1, newdata);
        }
    }
}