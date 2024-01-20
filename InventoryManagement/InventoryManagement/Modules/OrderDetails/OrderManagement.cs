using InventoryManagement.Modules.Constants;
using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Factory;
using InventoryManagement.Modules.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace InventoryManagement.Modules.Order
{
    /// <summary>
    /// Class to get details about order and its flight
    /// </summary>
    public class OrderManagement : IManagement
    {
        /// <summary>
        /// Method to get details about the order depends upon the number of schedule days
        /// </summary>
        /// <param name="days"></param>
        /// <param name="managementTypeDTO"></param>
        /// <returns></returns>
        public ManagementTypeDTO GetManagementTypeDetails(int sheduledDays, ManagementTypeDTO managementTypeDTO, IFileReaderFactory FileReaderFactory)
        {
            try
            {
                IFileReader readJsonFile = FileReaderFactory.CreateInstanceFileType(FileType.Json);
                IList<OrderAssignment> orderAssignmentList = (IList<OrderAssignment>)readJsonFile.GetFileDetails();
                IList<OrderAssignment> temporderAssignmentList = orderAssignmentList.ToList();
                List<OrderDTO> orderDTOlist = new List<OrderDTO>();
                temporderAssignmentList = orderAssignmentList;
                int dayCount = 1;
                int dailyTotalParcel = 0;
                var flightSyncdaycount = managementTypeDTO.ScheduleDTOlist.Where(t => t.Day == dayCount).Select(t => t).ToList();
                for (int i = 0; sheduledDays > i; i++)
                {
                    flightSyncdaycount = managementTypeDTO.ScheduleDTOlist.Where(t => t.Day == dayCount).Select(t => t).ToList();
                    dailyTotalParcel = 0;
                    foreach (ScheduleDTO sheduleDTO in flightSyncdaycount)
                    {

                        if (temporderAssignmentList.Count >= 20)
                        {

                            var tmpAssignmentListlist = temporderAssignmentList.OrderBy(t => t.OrderName).ToList().Take(20);


                            foreach (var tmpDatalist in tmpAssignmentListlist)
                            {
                                dailyTotalParcel++;
                                FillOrderDTOList(orderDTOlist, sheduleDTO, tmpDatalist);

                            }
                            temporderAssignmentList = temporderAssignmentList.OrderBy(t => t.OrderName).ToList().Skip(20).ToList();
                        }
                        else if (temporderAssignmentList.Any())
                        {
                            foreach (var tmp in temporderAssignmentList)
                            {
                                dailyTotalParcel++;
                                FillOrderDTOList(orderDTOlist, sheduleDTO, tmp);
                            }
                            temporderAssignmentList = temporderAssignmentList.OrderBy(t => t.OrderName).ToList().Skip(temporderAssignmentList.Count).ToList();
                        }
                        else
                        {
                            FillOrderDTOList(orderDTOlist, sheduleDTO, null);
                        }
                        if ((flightSyncdaycount.Count * (ManagementConstants.AllowedDailyParcel)) == dailyTotalParcel)
                        {
                            dayCount++;
                            break;
                        }
                    }
                }
                managementTypeDTO.OrderDTOList = orderDTOlist;
                return managementTypeDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Method to fill order data
        /// Extracted a new method inorder to avoid repetation
        /// </summary>
        /// <param name="orderDTOlist"></param>
        /// <param name="sheduleDTO"></param>
        /// <param name="tmp"></param>
        /// <returns></returns>
        private static void FillOrderDTOList(List<OrderDTO> orderDTOlist, ScheduleDTO sheduleDTO, OrderAssignment tmp)
        {
            Guid g = Guid.NewGuid();
            orderDTOlist.Add(new OrderDTO
            {
                Id = System.Guid.NewGuid().ToString(),
                OrderName =tmp==null?null: tmp.OrderName,
                ArrivalCityCode = sheduleDTO.ArrivalCityCode,
                DepartureCityCode = sheduleDTO.DepartureCityCode,
                FlightNumber = sheduleDTO.FlightNumber,
                Day = sheduleDTO.Day
            });
           
        }
    }
}
