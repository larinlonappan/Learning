using InventoryManagement.Modules.DTO;
using InventoryManagement.Modules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Modules.Factory
{
    /// <summary>
    /// Interface for factory class
    /// </summary>
    public interface IManagementFactory
    {
        IManagement CreateManagementType(ManagementType managementtype);
    }
}
