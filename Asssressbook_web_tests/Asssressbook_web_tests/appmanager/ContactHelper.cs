using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            this.driver = driver;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };

        }



        public ContactHelper IsContactExists(ContactData contact)
        {
            if (contact == null)
            {
                ContactData newcontact = new ContactData("Firstname12", "Lastname12");
                Create(newcontact);
            }
            return this;
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SetGroupFilter(group.Name);
            SelectContact(contact.Id);

            RemoveFromGroup(group.Name);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void SetGroupFilter(string group)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(group);
        }

        public ContactHelper RemoveFromGroup(string groupname)
        {
            driver.FindElement(By.XPath("//input[@name='remove']")).Click();
            return this;
        }

        private void ClickToGroupLink(string name)
        {

            driver.FindElement(By.LinkText(name)).Click();
        }

        public void AddContactToGrooup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            ClickDetails();
            string detailsInfo = driver.FindElement(By.XPath("//*[@id='content']")).Text;
            return detailsInfo;
        }

        public string PreparedContactInformationFromEditForm(ContactData contact)
        {
            string preparedData;
            string allPhones = "";
            string fullName = contact.Firstname.Trim() + " "
                           + contact.Middlename.Trim() + " "
                           + contact.Lastname.Trim() + "\r\n";
            if (CleanData(contact.HomePhone) != "")
            {
                allPhones += "H: " + CleanData(contact.HomePhone);
            }
            if (CleanData(contact.MobilePhone) != "")
            {
                allPhones += "M: " + CleanData(contact.MobilePhone);
            }
            if (CleanData(contact.WorkPhone) != "")
            {
                allPhones += "W: " + CleanData(contact.WorkPhone);
            }
            if (CleanData(contact.Fax) != "")
            {
                allPhones += "F: " + CleanData(contact.Fax);
            }

            //проверка только на Middlename, предполагается что фамилия и имя указаны
            if (contact.Middlename == "" || contact.Middlename == null)
            {
                fullName = contact.Firstname.Trim() + " "
                  + contact.Lastname.Trim() + "\r\n";
            }
            preparedData = fullName
                + CleanData(contact.Nickname)
                + CleanData(contact.Title)
                + CleanData(contact.Company)
                + CleanData(contact.Address)
                + allPhones
                + contact.AllEmails;
            return preparedData;
        }



        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            InitContactModification();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Middlename = middleName,
                Nickname = nickName,
                Title = title,
                Fax = fax,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                Homepage = homePage,
                Company = company
            };

        }

        public ContactHelper InitContactCreation()
        {

            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.XPath(".//tr[@name='entry']")).Count;
        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCashe.Add(new ContactData(element.FindElement(By.XPath(".//td[3]")).Text, element.FindElement(By.XPath(".//td[2]")).Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<ContactData>(contactCashe);
        }


        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.Name("selected[]"));
            SelectContact(v);
            RemoveContact();
            return this;
        }


        public ContactHelper Remove(ContactData toBeRemoved)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.Name("selected[]"));
            SelectContact(toBeRemoved.Id);
            RemoveContact();
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactModification();
            FillContactForm(newdata);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Modify(ContactData oldData, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(oldData.Id);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }



        public ContactHelper FillContactForm(ContactData contact)
        {
            if (contact.Firstname != null)
            {
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            }
            if (contact.Lastname != null)
            {
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            }

            if (contact.Middlename != null)
            {
                driver.FindElement(By.Name("middlename")).Clear();
                driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            }

            if (contact.Nickname != null)
            {
                driver.FindElement(By.Name("nickname")).Clear();
                driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            }

            if (contact.Title != null)
            {
                driver.FindElement(By.Name("title")).Clear();
                driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            }
            if (contact.Company != null)
            {
                driver.FindElement(By.Name("company")).Clear();
                driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            }
            if (contact.Address != null)
            {
                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            }
            if (contact.HomePhone != null)
            {
                driver.FindElement(By.Name("home")).Clear();
                driver.FindElement(By.Name("home")).SendKeys(contact.HomePhone);
            }

            if (contact.WorkPhone != null)
            {
                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(contact.WorkPhone);
            }
            if (contact.MobilePhone != null)
            {
                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            }
            if (contact.Fax != null)
            {
                driver.FindElement(By.Name("fax")).Clear();
                driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            }
            if (contact.Email1 != null)
            {
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(contact.Email1);
            }
            if (contact.Email2 != null)
            {
                driver.FindElement(By.Name("email2")).Clear();
                driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            }
            if (contact.Email3 != null)
            {
                driver.FindElement(By.Name("email3")).Clear();
                driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            }
            if (contact.Homepage != null)
            {
                driver.FindElement(By.Name("homepage")).Clear();
                driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            }


            /*   // fill birth date=14.06.1984
               new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("14");
               driver.FindElement(By.XPath("//option[16]")).Click();
               driver.FindElement(By.Name("bmonth")).Click();
               new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("June");
               driver.FindElement(By.XPath("//option[@value='June']")).Click();
               driver.FindElement(By.Name("byear")).Click();
               driver.FindElement(By.Name("byear")).Clear();
               driver.FindElement(By.Name("byear")).SendKeys("1984");
               driver.FindElement(By.Name("aday")).Click();*/

            return this;

        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();

            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();

            return this;
        }



        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])")).Click();

            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }


        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCashe = null;
            return this;
        }
        public ContactHelper Exists()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData newcontact = new ContactData("NewFirstN", "NewLastN");
                Create(newcontact);
            }
            return this;
        }

        public ContactHelper ClickDetails()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }

        public string CleanData(string somedata)
        {
            if (somedata == "" || somedata == null)
            {
                return "";
            }
            return somedata.Trim() + "\r\n";
        }

        public ContactHelper IsContactExists()
        {
            List<ContactData> contacts = ContactData.GetAll();

            if (contacts.Count == 0)
            {
                ContactData contactToGroup = new ContactData("newf", "newn");
                Create(contactToGroup);
            }

            return this;
        }
    }
}