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
            InitContactModification(v);
            FillContactForm(newdata);
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
            if (contact.CompanyAddress != null)
            {
                driver.FindElement(By.Name("address")).Clear();
                driver.FindElement(By.Name("address")).SendKeys(contact.CompanyAddress);
            }
            if (contact.HomeTel != null)
            {
                driver.FindElement(By.Name("home")).Clear();
                driver.FindElement(By.Name("home")).SendKeys(contact.HomeTel);
            }

            if (contact.WorkTel != null)
            {
                driver.FindElement(By.Name("work")).Clear();
                driver.FindElement(By.Name("work")).SendKeys(contact.WorkTel);
            }
            if (contact.MobileTel != null)
            {
                driver.FindElement(By.Name("mobile")).Clear();
                driver.FindElement(By.Name("mobile")).SendKeys(contact.MobileTel);
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


        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();

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
    }
}