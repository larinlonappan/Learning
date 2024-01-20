using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Modules.DTO
{
    /// <summary>
    /// DTOclass to consolidate all the details of order and schedule for all flights
    /// </summary>
    public class ManagementTypeDTO
    {
        public IList<OrderDTO> OrderDTOList { get; set; }
        public IList<ScheduleDTO> ScheduleDTOlist { get; set; }
    }
    /// <summary>
    /// Enum to determine management types
    /// </summary>
    public enum ManagementType
    {
        Schedule,
        Order
    }

    public enum FileType
    {
        Json,
        XML
    }
}
