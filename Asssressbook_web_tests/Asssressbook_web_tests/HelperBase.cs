﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}