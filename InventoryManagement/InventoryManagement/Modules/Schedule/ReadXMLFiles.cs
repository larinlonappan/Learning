using InventoryManagement.Modules.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InventoryManagement.Modules.Schedule
{
    /// <summary>
    /// Class to get details of XML file
    /// </summary>
    public class ReadXMLFiles : IFileReader
    {
       /// <summary>
       /// Method to retrive details of XML file
       /// </summary>
       /// <returns></returns>
        public object GetFileDetails()
        {
            
                XmlDocument xdc = new XmlDocument();
                string path = Directory.GetCurrentDirectory() + "//FlightSchedule.xml";
                xdc.Load(path);
                XmlNodeList xnlNodes = xdc.SelectNodes("Schedules");
                return xnlNodes;
            
        }
    }
}
