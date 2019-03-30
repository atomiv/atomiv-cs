﻿using FluentAssertions;
using OpenQA.Selenium.Chrome;
using Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumPageTest
    {
        [Fact]
        public void TestFindTextBoxByName()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (var driver = new ChromeDriver(currentDir))
            {
                driver.Url = "https://www.toolsqa.com/automation-practice-form/";

                var page = new ToolsQAAutomationPracticeFormPage(driver);

                // TODO: VC: Link text & partial link text

                page.FirstNameTextBox.SetText("John");
                var firstName = page.FirstNameTextBox.GetText();

                firstName.Should().Be("John");

                // TODO: VC: Check if this should be via textbox?



                Assert.False(page.SexRadioGroup.HasSelected());

                page.SexRadioGroup.Select(Sex.Male);

                // TODO: VC: Automatic matching between name and enum

                Assert.Equal(Sex.Male, page.SexRadioGroup.GetSelected());

                Assert.False(page.YearsOfExperienceRadioGroup.HasSelected());

                page.YearsOfExperienceRadioGroup.Select(3);

                Assert.Equal(3, page.YearsOfExperienceRadioGroup.GetSelected());

                Assert.False(page.ProfessionCheckBoxGroup.HasSelected());

                page.ProfessionCheckBoxGroup.Select(Profession.AutomationTester);

                Assert.Single(page.ProfessionCheckBoxGroup.GetSelected());

                Assert.Equal(Profession.AutomationTester, page.ProfessionCheckBoxGroup.GetSelected().Single());

                // TODO: VC: Upload file

                // TODO: VC: Download file

                Assert.False(page.AutomationToolCheckBoxGroup.HasSelected());

                page.AutomationToolCheckBoxGroup.Select(AutomationTool.SeleniumIde);

                Assert.Single(page.AutomationToolCheckBoxGroup.GetSelected());

                Assert.Equal(AutomationTool.SeleniumIde, page.AutomationToolCheckBoxGroup.GetSelected().Single());

                // TODO: VC: Testing multi select



                // TODO: VC: Checkboxes


                Assert.True(page.ContinentComboBox.HasSelected());
                Assert.Equal(Continent.Asia, page.ContinentComboBox.GetSelected());
                page.ContinentComboBox.Select(Continent.Europe);
                Assert.Equal(Continent.Europe, page.ContinentComboBox.GetSelected());


                // TODO: VC: fluent assertions, e.g. pageProfessionCheckBox.SelectedValueShouldBe(), ShouldNotHaveSelection, ShouldHaveSingleSelection, ShouldHaveSelectedItems(items)
                // TODO: VC: textBox - InputText(""), ShouldBeEmpty, ShouldHaveValue, ValueShouldBe(), ShouldBeNonEmpty

                // TODO: VC: Assert messages
            }
        }


    }
}