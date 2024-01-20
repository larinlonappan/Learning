using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Modules.Interface
{
    /// <summary>
    /// Interface for managing order and schedule
    /// </summary>
    public interface IManagement
    {
        ManagementTypeDTO GetManagementTypeDetails(int sheduledDays, ManagementTypeDTO managementTypeDTO,
        IFileReaderFactory fileReaderFactory);
    }
}
