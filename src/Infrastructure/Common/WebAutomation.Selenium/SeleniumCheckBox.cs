﻿using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumCheckBox : BaseSeleniumElement, ICheckBox
    {
        public SeleniumCheckBox(IWebElement element) : base(element)
        {
        }
    }
}