using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace UIAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                try
                {
                    string userid = "Chandimal78940" + i;

                    IWebDriver driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("https://order.postmates.com/");
                    Thread.Sleep(3000);

                    driver.FindElement(By.ClassName("login")).Click();
                    Thread.Sleep(3000);

                    driver.FindElement(By.ClassName("toggle")).Click();
                    Thread.Sleep(3000);

                    driver.FindElement(By.XPath("//input[@placeholder='Email Address']")).SendKeys(userid + "@gmail.com");
                    Thread.Sleep(3000);

                    driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys(userid);
                    Thread.Sleep(3000);

                    driver.FindElement(By.ClassName("content")).Click();
                    Thread.Sleep(3000);

                    driver.FindElement(By.ClassName("arrow-down ")).Click();
                    Thread.Sleep(3000);

                    driver.FindElement(By.XPath("//*[contains(text(), 'Account Settings')]")).Click();

                    driver.FindElement(By.XPath("//input[@placeholder='Add Promo Code']")).SendKeys("DADROCKS"); ;
                    Thread.Sleep(3000);

                    driver.FindElement(By.XPath("//*[contains(text(), 'Apply')]")).Click();
                    Thread.Sleep(5000);

                    driver.Close();

                    WriteToFile("Success : " + i + ", UserID : " + userid);
                }
                catch (Exception exp)
                {
                    WriteToFile("Error : " + i + " Message : " + exp);
                }
            }

        }
        public static void WriteToFile(string message)
        {
            using (StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(message + "\n");
            }

        }
    }
}


