using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Modules.DTO
{
    /// <summary>
    /// Class to hold json file details
    /// </summary>
    public class OrderAssignment
    {
        //Order name of json file
        public string OrderName { get; set; }
        //Destination of json file
        public string destination { get; set; }

    }
}
