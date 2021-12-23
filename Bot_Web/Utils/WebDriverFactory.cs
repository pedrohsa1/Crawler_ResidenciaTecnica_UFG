using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class WebDriverFactory
    {
        /*
         Já no modo headless, não é disponibilizada a interface gráfica do navegador durante a execução dos testes.
         É como se eles executassem em background
         */
        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxOptions optionsFF = new FirefoxOptions();
                    if (headless)
                        optionsFF.AddArgument("--headless");

                    webDriver = new FirefoxDriver(pathDriver, optionsFF);

                    break;
                case Browser.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    if (headless)
                        options.AddArgument("--headless");

                    webDriver = new ChromeDriver(pathDriver, options);

                    break;
            }

            return webDriver;
        }
    }
}
