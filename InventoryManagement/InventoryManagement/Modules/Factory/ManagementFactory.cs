using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Interface;
using InventoryManagement.Modules.Order;
using InventoryManagement.Modules.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Modules.Factory
{
    /// <summary>
    /// Factory class which provide the instance of managementtype
    /// </summary>
    public class ManagementFactory: IManagementFactory, IFileReaderFactory
    {
        /// <summary>
        /// Method to get instance for file type
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public IFileReader CreateInstanceFileType(FileType fileType)
        {
            IFileReader fileReader = null;
            switch (fileType)
            {
                case FileType.Json:
                    fileReader= ReadJsonFile.Instance;
                    break;
                case FileType.XML:
                    fileReader = new ReadXMLFiles();
                    break;
                default:
                    break;
            }
            return fileReader;
        }
        /// <summary>
        /// Method to get instance for management type
        /// </summary>
        /// <param name="managementtype"></param>
        /// <returns></returns>
        public IManagement CreateManagementType(ManagementType managementtype)
        {
            IManagement InventoryObj = null;
            switch (managementtype)
            {
                case ManagementType.Schedule:
                    InventoryObj = new ScheduleManagement();
                    break;
                case ManagementType.Order:
                    InventoryObj= new OrderManagement();
                    break;
                default:
                    break;        
            }
            return InventoryObj;
        }

    }
}
