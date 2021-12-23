using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using Utils;

namespace Bot_Web
{
    /*
     *
     *Referências
     *https://github.com/nurullahguc/charpSeleniumInstagramFollowers/blob/master/seleniumInstagramFollowers/Program.cs
     *https://github.com/nurullahguc/charpSeleniumInstagramFollowers
     */
    class Program
    {
        public static IConfigurationRoot _configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"D:\Projetos_C#\Pedro_Proj_Curso\Bot_Selenium\Drive_Chrome_Selenium",false);

            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(50), "https://www.instagram.com/accounts/login/");
                Thread.Sleep(TimeSpan.FromSeconds(50));
                Console.WriteLine(By.Name("username"));
                Console.WriteLine(By.Name("password"));
                webDriver.SetText(By.Name("username"), _configuration["Selenium:Username"]);
                webDriver.SetText(By.Name("password"), _configuration["Selenium:Password"]);
                webDriver.Submit(By.TagName("button"));

                Thread.Sleep(TimeSpan.FromSeconds(50));

                string nomePerfil = string.Empty;
                Console.WriteLine("Digite o nome do perfil alvo: ");
                nomePerfil = Console.ReadLine();

                webDriver.LoadPage(TimeSpan.FromSeconds(40), @"https://www.instagram.com/" + nomePerfil + "/");
                webDriver.FindElement(By.XPath(@"/html/body/div[1]/section/main/div/header/section/ul/li[2]/a")).Click();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            /*
             * Esse modo utiliza o Selenium sem métodos e abstrações do Utils
             * 
             * IWebDriver webDriver = new ChromeDriver(@"D:\Projetos_C#\Pedro_Proj_Curso\Bot_Selenium\Bot_Web\Drive_Browser");
            try
            {
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                webDriver.Navigate().GoToUrl(@"https://www.instagram.com/accounts/login/");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
            Console.ReadKey();
            */
        }
    }
}
