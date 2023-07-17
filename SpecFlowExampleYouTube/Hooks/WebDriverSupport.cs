using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace WebDriverExample3.Hooks
{
    [Binding]
    public sealed class WebDriverSupport
    {
        private IWebDriver driver;
        private readonly IObjectContainer _objectContainer;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer= objectContainer;
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<IWebDriver>().Close();
            _objectContainer.Resolve<IWebDriver>().Dispose();

        }
    }
}