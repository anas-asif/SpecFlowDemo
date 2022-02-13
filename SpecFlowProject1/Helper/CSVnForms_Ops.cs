using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using SpecFlowProject1.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpecFlowProject1.Helper
{
    class CSVnForms_Ops : BaseHelper
    {

        private String message;
        Random random;
        SeleniumWaits waits;
        public string Message { get => message; set => message = value; }


        public CSVnForms_Ops(WebClient client, XrmApp xrmApp)
        {
            waits = new SeleniumWaits();
            this.client = client;
            this.xrmApp = xrmApp;
            random = new Random();
        }
        public bool validateAllFields(String filename) {


            String fieldname = "No Field Value";

            try
            {
                var data = File.ReadLines(formcsv + filename +".csv").Select(x => x.Split(',')).ToArray();
            
            int row = data.GetLength(0);
            int columnLength = 4;            

                for (int i = 1; i < row; i++) {
                    fieldname= data[i][0];
                    waits.specifiedElementText(client, fieldname);
                }
                return true;
            } catch (Exception e) {
                Message = fieldname + " field was not found";
                return false;  }

        }

        public bool checkMandatoryValidation(String filename)
        {
            String fieldname = "No Field Value";
            int validationcount = 0;
            

                save();
                xrmApp.ThinkTime(2000);

                if (client.Browser.Driver.HasElement(By.XPath("//span[contains(text(),'notifications. Select to view.')]"))) {

                    client.Browser.Driver.FindElement(By.XPath("//span[contains(text(),'notifications. Select to view.')]/..")).Click();
                }

                    
                String mandatory;
                var data = File.ReadLines(formcsv + filename + ".csv").Select(x => x.Split(',')).ToArray();
                int row = data.GetLength(0);
                for (int i = 1; i < row; i++)
                {
                    fieldname = data[i][0];
                    mandatory = data[i][2];
                    if (mandatory == "T")
                {
                    try { 
                        waits.withXpath(client, "//span[contains(text(),'" + fieldname +" : Required fields')]");
                        } catch (Exception e)
                        {
                            Message = fieldname + "mentioned as Mandatory field in CSV but not found mandatory in actual";
                            return false;
                        }
                }
                }
                return true;
            
        
        }
        public bool fillAllFields(String filename)
        {

            String fieldname = "No Field Value";

            try
            {
                var data = File.ReadLines(formcsv + filename + ".csv").Select(x => x.Split(',')).ToArray();


                int row = data.GetLength(0);
                int columnLength = 4;


                String type, mandatory, specifics;


                for (int i = 1; i < row; i++)
                {
                    fieldname = data[i][0];
                    type = data[i][1];
                    mandatory = data[i][2];
                    specifics = data[i][3];

                    if (type == "String" && specifics != "F")
                    {

                        fillString(fieldname, specifics);
                    }
                    else if (type == "String" && specifics == "F")
                    {
                        
                        fillString(fieldname);
                    }
                    else if (type == "Number" && specifics != "F") { fillString(fieldname, specifics); }
                    else if (type == "Number" && specifics == "F") { fillNumber(fieldname, 100000,999999); }
                    else if (type == "Email" && specifics != "F") { fillString(fieldname, specifics); }
                    else if (type == "Email" && specifics == "F") { fillEmail(fieldname); }

                }

                saveCSVFile();
                return true;
            }
            catch (Exception e)
            {
                Message = fieldname + " field was not found \n" + e.Message;
                return false;
            }
           
        }

        public String getString(String stringType) {

            String value;

            var data = File.ReadLines(datacsv + stringType + ".csv").Select(x => x.Split(',')).ToArray();
            int range = data.GetLength(0) -1;
            int randomNum = random.Next(0,range);
            value = data[randomNum][0];

            return value;

        }

        private bool fillString(String field) {

            String input = getString("Names") + random.Next(10, 500);
            
            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).Click();
            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).SendKeys(input);
            csvOutgoing(field, input);
            return true;

        }

        private bool fillEmail(String field) {
            String input = getString("Names") + random.Next(10, 500);
            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).Click();
            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).SendKeys(input+"@gmail.com");
            csvOutgoing(field, input);
            return true;
        }

        private bool fillString(String field, String specificText) {

            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='"+field+"']")).Click();
            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).SendKeys(specificText);
            csvOutgoing(field, specificText);
            return true;
        }


        private bool fillNumber(String field, int min, int max) {

            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).Click();
            client.Browser.Driver.FindElement(By.XPath("//input[@aria-label='" + field + "']")).SendKeys(random.Next(min,max).ToString());
            return true;
        }

        public bool search(String searchKey) {

            
            client.Browser.Driver.FindElement(By.XPath("//input[contains(@id,'quickFind')]")).Click();
            client.Browser.Driver.FindElement(By.XPath("//input[contains(@id,'quickFind')]")).SendKeys(retrieveValueFromCSV(searchKey));
            client.Browser.Driver.FindElement(By.XPath("//input[contains(@id,'quickFind')]")).SendKeys(Keys.Enter);

            return true;
        }

        public bool verifySearch(String searchKey) {

            
            try {

                waits.withXpath(client, "//span[contains(text(),'" + retrieveValueFromCSV(searchKey) + "')]");
                client.Browser.Driver.FindElement(By.XPath("//span[contains(text(),'" + retrieveValueFromCSV(searchKey) + "')]")).Click();


                return true;
            } catch {

                return false;
            }            
        }

        public void duplicateIgnore() {
            if (client.Browser.Driver.HasElement(By.XPath("//h1[contains(text(),'exists')]")))
            {
                client.Browser.Driver.FindElement(By.XPath("//span[contains(text(),'Ignore')]/..")).Click();

                xrmApp.ThinkTime(2000);
            }
            else
            {
                Message = "No 'Stay Signed In' Dialog appeared";
            }

        }

        public bool save() {

            try {

                client.Browser.Driver.FindElement(By.XPath("//span[text()='Save & Close']")).Click();

                duplicateIgnore();
                return true;
            
            } catch {
                Message = "Save button not found";
                return false;
            }
        
        }

    }
}
