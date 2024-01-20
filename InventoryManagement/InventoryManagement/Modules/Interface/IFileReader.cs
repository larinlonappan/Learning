using InventoryManagement.Modules.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InventoryManagement.Modules.Interface
{
    /// <summary>
    /// Interface for FileReader which is used in XML and Json
    /// </summary>
    public interface IFileReader
    {
        object GetFileDetails();
    }
}
