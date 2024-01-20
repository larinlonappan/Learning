using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace InventoryManagement.Modules.Order
{
    /// <summary>
    /// Class to get details of JsonFile
    /// </summary>
    public sealed class ReadJsonFile : IFileReader
    {
        private static IFileReader readJsonFileInstance =null;
        private static readonly object lockObj = new object();

        /// <summary>
        /// Private constructor to avoid the instance creation
        /// </summary>
        private ReadJsonFile()
        {

        }
        /// <summary>
        /// Implementing in singleton patten since instance should be created only once during the entire application
        /// </summary>
        public static IFileReader Instance
        {
            get
            {
                if (readJsonFileInstance == null)
                {
                    //For thread safety
                    lock (lockObj)
                    {
                        readJsonFileInstance = new ReadJsonFile();
                    }
                }
                return readJsonFileInstance;
            }
        }

        /// <summary>
        /// Method to read Json file and extract the details
        /// </summary>
        /// <returns></returns>
        public object GetFileDetails()
        {
            string jsonTextFromFile = File.ReadAllText(Directory.GetCurrentDirectory() + "//coding-assigment-orders.json");
            //Serilization is need when we send the data through network.Hence we Deserialize the json data. 
            var parametrosObject = JsonConvert.DeserializeObject<object>(jsonTextFromFile);
           IList<OrderAssignment> orderAssignmentList = new List<OrderAssignment>();
            foreach ( var item in ((Newtonsoft.Json.Linq.JObject)parametrosObject)) 
            {
                OrderAssignment orderAssignment = new OrderAssignment();
                orderAssignment.OrderName = item.Key;
                orderAssignment.destination=Convert.ToString(((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)
                    ((Newtonsoft.Json.Linq.JContainer)item.Value).First).Value).Value);
                orderAssignmentList.Add(orderAssignment);
            }
            return orderAssignmentList;
        }

        
    }
}
   
