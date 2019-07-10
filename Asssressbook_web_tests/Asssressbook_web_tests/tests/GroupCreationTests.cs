using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)
                 new XmlSerializer(typeof(List<GroupData>))
                 .Deserialize(new StreamReader(@"groups.xml"));

        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));

        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]

        public void GroupCreationTest(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        /*  [Test]
             public void EmptyGroupCreationTest()
             {               
                 List<GroupData> oldgroups = app.Groups.GetGroupList();
                 GroupData group = new GroupData("");
                 app.Groups.Create(group);
                 Assert.AreEqual(oldgroups.Count+1, app.Groups.GetGroupCount());
                 List<GroupData> newgroups = app.Groups.GetGroupList();
                 oldgroups.Add(group);
                 oldgroups.Sort();
                 newgroups.Sort();
                 Assert.AreEqual(oldgroups, newgroups);
             }*/

        [Test]

        public void BadGroupCreationTest()
        {
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            GroupData group = new GroupData("a'a");
            app.Groups.Create(group);
            Assert.AreEqual(oldgroups.Count + 1, app.Groups.GetGroupCount());
        }

        [Test]

        public void TestDBConnectivity()

        {

            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));




        }

    }
}