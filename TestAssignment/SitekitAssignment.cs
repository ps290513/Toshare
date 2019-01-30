using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;




namespace TestAssignment
{
    class SitekitAssignment    {

        /// <summary>
        /// variables  
        /// </summary>
        IWebDriver webDriver;
        private string siteUrl = "https://www.sitekit.net";
        private string contactToAssert = "0845 299 0900";  
        
        
        /// <summary>
        /// Function to Intiate Chrome Browser
        /// </summary>
        private void IntiateBrowser()
        {
            try
            {
                webDriver = new ChromeDriver();
                webDriver.Navigate().GoToUrl(siteUrl);
                webDriver.Manage().Window.Maximize();
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                IWebElement webElement = webDriver.FindElement(By.LinkText("Continue"));
                if (webElement.Displayed) {
                    Console.Write("cookies button done \n");
                    webElement.Click();                    
                }
               
                TestToGoToContact();              

                
                  
            }
            catch(Exception e)
            {
                Console.Write(e.Message.ToString());
                Console.Write("Could not load browser, please try again.");
                webDriver.Close();
                
            }
        }
      
        /// <summary>
        /// This function to find contact Link   
        /// </summary>
        private void TestToGoToContact()
        {
           
               IWebElement webElement = webDriver.FindElement(By.XPath("//ul[@class='small-nav']//a[contains(text(),'contact')]"));          
            if (webElement.Displayed)
            {               
                webElement.Click();
                Console.Write("Testcase2 is passed. \n");
                TestCaseVerifyContact();
               
            }
        }
        /// <summary>
        /// Function to verify contact
        /// </summary>
        private void TestCaseVerifyContact()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//h3[contains(text(),"+"'"+contactToAssert+"')]"));
            if (webElement.Displayed)            
                Console.WriteLine("testcase contact verification is passed. \n");            
            else 
                Console.WriteLine("testcase contact verification is Failed. \n");           

            TestCaseVerifyAddress();
        }
        /// <summary>
        /// Function to verify address
        /// </summary>
        private void TestCaseVerifyAddress()
        {
            string address1 = webDriver.FindElement(By.XPath("//strong[contains(text(),'Oxford,')]")).Text;
            string address2 = webDriver.FindElement(By.XPath("//strong[contains(text(),'London,')]")).Text;
            //Console.WriteLine(address1);
            if(address1.Contains("Oxford") && address2.Contains("London"))
                Console.WriteLine( "Testcase address verification is Passed. \n");  
            else
                Console.WriteLine("Testcase address verification is failed. \n");
                webDriver.Close();
           
        }


        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SitekitAssignment sitekit = new SitekitAssignment();
            sitekit.IntiateBrowser();

        }
    }
}
