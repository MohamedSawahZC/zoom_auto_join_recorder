

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Web;
using System;
using System.Diagnostics;


namespace SeleniumTestProject
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {


                Console.Write("Enter Meeting url : ");
                string url = Console.ReadLine();
                Console.Write("Enter Meeting length(min) : ");
                string length = Console.ReadLine();
                int lengthMill = int.Parse(length) * 60 * 1000;

                
              
                Thread.Sleep(3000);
                var uri = new Uri(url??"");
                var wcValue = uri.Segments[2];
                var pwdValue = HttpUtility.ParseQueryString(uri.Query).Get("pwd");
                // Create a Chrome Driver object to open the browser 
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = @"C:\\Program Files\\obs-studio\\bin\\64bit\\obs64.exe",

                    ArgumentList = { "--startrecording", "--minimize-to-tray", "--scene \"screen\"", "--multi" },
                    WorkingDirectory = @"C:\\Program Files\\obs-studio\\bin\\64bit"
                };
                Process.Start(startInfo);
                IWebDriver driver = new ChromeDriver();
                if (pwdValue != null)
                {
                    pwdValue = pwdValue.Replace("/join", "");
                    // Navigate to the URL 
                    driver.Navigate().GoToUrl($"https://us06web.zoom.us/wc/{wcValue}/join");
                    driver.Manage().Window.FullScreen();
                    IWebElement NameField = driver.FindElement(By.Id("inputname"));
                    NameField.SendKeys("BitBang");
                    IWebElement PassField = driver.FindElement(By.Id("inputpasscode"));
                    PassField.SendKeys(pwdValue);
                    IWebElement JoinButton = driver.FindElement(By.Id("joinBtn"));
                    JoinButton.Click();
                    Thread.Sleep(1000);
                    IWebElement JoinButton2 = driver.FindElement(By.ClassName("preview-join-button"));
                    JoinButton2.Click();
                    driver.Manage().Window.FullScreen();

                    Process obsProcess = Process.GetProcessesByName("obs64")[0];
                    Process chromeProcess = Process.GetProcessesByName("chrome")[0];

                    Thread.Sleep(lengthMill);
                    obsProcess.Kill();
                    chromeProcess.Kill();
                }
                else
                {
                    // Navigate to the URL 
                    driver.Navigate().GoToUrl($"https://us06web.zoom.us/wc/{wcValue}/join");
                    driver.Manage().Window.FullScreen();
                    IWebElement NameField = driver.FindElement(By.Id("inputname"));
                    NameField.SendKeys("BitBang");
                    IWebElement JoinButton = driver.FindElement(By.Id("joinBtn"));
                    JoinButton.Click();
                    Thread.Sleep(1000);
                    IWebElement JoinButton2 = driver.FindElement(By.ClassName("preview-join-button"));
                    JoinButton2.Click();
                    driver.Manage().Window.FullScreen();

                    Process obsProcess = Process.GetProcessesByName("obs64")[0];
                    Process chromeProcess = Process.GetProcessesByName("chrome")[0];

                    Thread.Sleep(lengthMill);
                    obsProcess.Kill();
                    chromeProcess.Kill();
                }


               
               



            }
            catch (WebDriverException err)
            {
                Console.WriteLine("========================");
                Console.WriteLine(err.Message);
                Console.WriteLine("========================");

            }

        }


       

    }
}





/*
using System.Diagnostics;

string zoomDirectory = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Zoom\bin");
Console.Write("Please enter url : ");
string input = Console.ReadLine();
ProcessStartInfo startInfo = new ProcessStartInfo
{
    FileName = $@"{zoomDirectory}\Zoom.exe",
    Arguments = $"--url={input}",
    WorkingDirectory = zoomDirectory
};
Process.Start(startInfo);
*/