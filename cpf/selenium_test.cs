using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

[TestFixture]
public class TestProgram {
    private IWebDriver driver;
    [SetUp]
    public void SetupTest () {
        driver = new FirefoxDriver ();
        driver.Manage ().Timeouts ().ImplicitWait = TimeSpan.FromSeconds (30);
        driver.Url = "https://igorescobar.github.io/jQuery-Mask-Plugin/";
    }

    [TearDown]
    public void TeardownTest () {
        driver.Quit ();
    }

    [Test]
    public void testMethod () {
        String cpf = "96757825872";
        String title = driver.Title;
        System.Console.WriteLine ("title of site is: " + title);
        IWebElement field_cpf = driver.FindElement (By.Id ("cpf"));
        foreach (char c in cpf) {
            field_cpf.SendKeys (c.ToString ());
        }
        // Validando o resultado esperado!
        IWebElement field_cpf_after = driver.FindElement (By.Id ("cpf"));
        Assert.AreEqual ("967.578.258-72", field_cpf_after.GetAttribute ("value"));
    }
}
