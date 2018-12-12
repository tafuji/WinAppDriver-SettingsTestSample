using System;
using System.Linq;
using OpenQA.Selenium.Appium.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SettingsTest
{
    [TestClass]
    public class ScenarioPersonarization : SettingsSession
    {
        /// <summary>
        /// Change the background to navy blue color.
        /// </summary>
        [TestMethod]
        public void ChangeBackGroundTest()
        {
            session.FindElementByAccessibilityId("SettingsPageGroupPersonalization").Click();
            var combobox = session.FindElementByAccessibilityId("SystemSettings_Personalize_Background_ChooseBackground_ComboBox");
            combobox.Click();
            var solidColor = combobox.FindElementsByClassName("TextBlock").Where(p => p.Text == "Solid color").FirstOrDefault();
            Assert.IsNotNull(solidColor);
            solidColor.Click();
            var colorGrid = session.FindElementByAccessibilityId("SystemSettings_Personalize_Background_SuggestedColors_PersonalizeColorGrid");
            var navyBlue = colorGrid.FindElementsByClassName("GridViewItem").Where(p => p.Text == "Navy blue").FirstOrDefault();
            Assert.IsNotNull(navyBlue);
            navyBlue.Click();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
