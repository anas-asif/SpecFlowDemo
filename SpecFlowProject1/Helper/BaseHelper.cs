using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using SpecFlowProject1.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using TechTalk.SpecRun;

namespace SpecFlowProject1.Helper
{
    class BaseHelper
    {
        public WebClient client;
        public XrmApp xrmApp;
        public String formcsv, datacsv, pathToWrite;
        StringBuilder formEntryCSV;
        public SeleniumWaits waiting;
        public Random random;
        public Dictionary<String, String> savedData;
        public BaseHelper() {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT bin directory (ie ../bin/)
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;

            datacsv = projectDirectory + "\\SpecFlowProject1\\DataCSV\\";
            formcsv = projectDirectory + "\\SpecFlowProject1\\FormsCSV\\";
            pathToWrite = "formEntryCSV.csv";
            formEntryCSV = new StringBuilder();
            random = new Random();
        }

        public void csvOutgoing(String key, String value) {

            var newLine = string.Format("{0},{1}", key, value);
            formEntryCSV.AppendLine(newLine);
            
        }

        public void saveCSVFile() {
            File.WriteAllText(pathToWrite, formEntryCSV.ToString());

        }

        public String retrieveValueFromCSV(String p1) {


            var data = File.ReadLines(pathToWrite).Select(x => x.Split(',')).ToArray();

            for (int i = 1; i < data.GetLength(0); i++) {

                if (data[i][0] == p1)
                {
                    return data[i][1];
                }
            }

            return null;
        }
    }
}
