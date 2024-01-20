﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Modules.DTO
{
    /// <summary>
    /// DTO class to hold OrderDetails
    /// </summary>
    public class OrderDTO
    {
        //Property to identify the id of the order
        public string Id { get; set; }
        //Property to identify the name of the order
        public string OrderName { get; set; }
        //Property to identify the name of the flight
        public int FlightNumber { get; set; }

        //Property to identify the arrival place
        public string Arrival { get; set; }

        //Property to identify the departure place
        public string Departure { get; set; }

        //Property to identify the number schedule days
        public int Day { get; set; }

        //Property to identify the ArrivalCity Code 
        public string ArrivalCityCode { get; set; }

        //Property to identify the DepartureCity Code 
        public string DepartureCityCode { get; set; }
    }
}
