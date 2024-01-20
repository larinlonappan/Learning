using InventoryManagement.Modules.Constants;
using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Factory;
using InventoryManagement.Modules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Start
    {
        //Schedule days should get from database. Here assigning 2 directly
        private static int _sheduledDays = 2;
        
        static void Main(string[] args)
        {
            try
            {
                //Factory instance for management type
                IManagementFactory inventoryFactory = new ManagementFactory();

                //Factory instance for File type
                IFileReaderFactory fileReaderFactory = new ManagementFactory();

                //DTO class with contain the details of schedule and orders of the flight
                ManagementTypeDTO managementTypeDTO = new ManagementTypeDTO();

                IManagement managementTypeobj = inventoryFactory.CreateManagementType(ManagementType.Schedule);
                //Collect details of the flight schedule on each day

                managementTypeDTO.ScheduleDTOlist = managementTypeobj.GetManagementTypeDetails(_sheduledDays, managementTypeDTO, fileReaderFactory).ScheduleDTOlist;
                Console.ForegroundColor = ConsoleColor.Blue;
                //Headers
                Console.WriteLine("USER STORY #1");
                Console.ResetColor();
                Console.WriteLine("\n");

                foreach (ScheduleDTO scheduleDTO in managementTypeDTO.ScheduleDTOlist)
                {
                    Console.WriteLine(string.Format(ManagementConstants.Flight + ":" + scheduleDTO.FlightNumber + ", " + ManagementConstants.Departure
                    + ":" + scheduleDTO.DepartureCityCode + ", " + ManagementConstants.Arrival + ":" +
                    scheduleDTO.ArrivalCityCode + ", " + ManagementConstants.Day + ":" + scheduleDTO.Day));
                }
                Console.WriteLine("\n");
                managementTypeobj = inventoryFactory.CreateManagementType(ManagementType.Order);
                //Collect details of the orders of flight on each day

                managementTypeDTO.OrderDTOList = managementTypeobj.GetManagementTypeDetails(_sheduledDays, managementTypeDTO, fileReaderFactory).OrderDTOList;
                Console.ForegroundColor = ConsoleColor.Blue;
                //Headers
                Console.WriteLine("USER STORY #2");
                Console.ResetColor();
                Console.WriteLine("\n");

                //Details of flight which received orders on each day
                foreach (OrderDTO orderDTO in managementTypeDTO.OrderDTOList.Where(t => t.OrderName != null))
                {
                    Console.WriteLine(string.Format(ManagementConstants.Order + ":" + orderDTO.OrderName + ", " + ManagementConstants.FlightNumber + ":" +
                    orderDTO.FlightNumber + ", " + ManagementConstants.Departure + ":" + orderDTO.DepartureCityCode + ", " + ManagementConstants.Arrival + ":" +
                    orderDTO.ArrivalCityCode + ", " + ManagementConstants.Day + ":" + orderDTO.Day));
                }
                Console.WriteLine("\n");


                Console.ForegroundColor = ConsoleColor.Blue;
                //Headers
                Console.WriteLine("Flight which didnt get any orders");
                Console.ResetColor();
                Console.WriteLine("\n");

                //Details of flight which didnt get orders on a particular day
                foreach (OrderDTO orderDTO in managementTypeDTO.OrderDTOList.Where(t => t.OrderName == null))
                {
                    Console.WriteLine(string.Format(ManagementConstants.Order + ": No Order" + ", " + ManagementConstants.FlightNumber + ":" +
                    orderDTO.FlightNumber + ", " + ManagementConstants.Departure + ":" + orderDTO.DepartureCityCode + ", " + ManagementConstants.Arrival + ":" +
                    orderDTO.ArrivalCityCode + ", " + ManagementConstants.Day + ":" + orderDTO.Day));
                }
                
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error message : {0}" ,ex.Message);
                Console.ReadKey();
            }
        }
    }
}
