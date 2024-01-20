using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Factory;
using InventoryManagement.Modules.Interface;
using InventoryManagement.Modules.Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InventoryManagement.Modules.Schedule
{/// <summary>
/// Class will give the details about flight and its schedule
/// </summary>
    public class ScheduleManagement : IManagement
    {
        /// <summary>
        /// Method to get details about flight and its schedule
        /// </summary>
        /// <param name="days"></param>
        /// <param name="managementTypeDTO"></param>
        /// <returns></returns>
        public ManagementTypeDTO GetManagementTypeDetails(int days, ManagementTypeDTO managementTypeDTO, IFileReaderFactory FileReaderFactory)
        {
            try
            {
                List<ScheduleDTO> scheduleDTOlist = new List<ScheduleDTO>();
            IFileReader readJsonFile = FileReaderFactory.CreateInstanceFileType(FileType.XML);
            XmlNodeList xnlNodes =(XmlNodeList) readJsonFile.GetFileDetails();
            int flightNumber = 0;
            //Extracting the flight schedule depends upon the days
            for (int i = 1; i <= days; i++)
            {
                foreach (XmlNode xnlNode in xnlNodes[0].ChildNodes)
                {
                    XmlElement element = (XmlElement)xnlNode;
                    flightNumber++;
                    Guid g = Guid.NewGuid();
                    scheduleDTOlist.Add(new ScheduleDTO
                    {
                        Id = System.Guid.NewGuid().ToString(),
                        DepartureCityCode = element.FirstChild.Attributes["CityCode"].Value,
                        Departure = element.FirstChild.Attributes["CityName"].Value,
                        ArrivalCityCode = element.FirstChild.NextSibling.Attributes["CityCode"].Value,
                        Arrival = element.FirstChild.NextSibling.Attributes["CityName"].Value,
                        Day = i,
                        FlightNumber = flightNumber
                    });

                }
            }
            managementTypeDTO.ScheduleDTOlist = scheduleDTOlist;
            return managementTypeDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
