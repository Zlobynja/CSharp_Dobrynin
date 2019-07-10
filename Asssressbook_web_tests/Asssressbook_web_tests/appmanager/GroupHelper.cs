using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace Addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {


        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            this.driver = driver;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            driver.FindElement(By.Name("selected[]"));
            SelectGroup(v);
            RemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            driver.FindElement(By.Name("selected[]"));
            SelectGroup(group.Id);
            RemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCash = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCash.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCash);
        }

        public GroupHelper Modify(int v, GroupData newdata)
        {
            manager.Navigator.GoToGroupsPage();
            driver.FindElement(By.Name("selected[]"));
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newdata);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }


        public GroupHelper Modify(GroupData oldData, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            driver.FindElement(By.Name("selected[]"));
            SelectGroup(oldData.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }


        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            if (group.Header != null)
            {
                driver.FindElement(By.Name("group_name")).Clear();
                driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            }

            if (group.Header != null)
            {
                driver.FindElement(By.Name("group_header")).Clear();
                driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            }
            if (group.Footer != null)
            {
                driver.FindElement(By.Name("group_footer")).Clear();
                driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            }
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.Id("header"));
            groupCash = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCash = null;
            return this;
        }


        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }
        public GroupHelper Exists()
        {

            if (!IsElementPresent(By.Name("selected[]")))
            {
                GroupData newgroup = new GroupData("newgroup1");
                Create(newgroup);
            }
            return this;
        }

        public GroupHelper IsGroupExists()
        {
            List<GroupData> groupsList = GroupData.GetAll();

            if (groupsList.Count == 0)
            {
                GroupData groupWithContact = new GroupData("newgr");
                Create(groupWithContact);
            }
            return this;
        }

    }
}