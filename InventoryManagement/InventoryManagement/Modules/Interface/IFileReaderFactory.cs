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
    /// Interface for FileReaderFactory 
    /// </summary>
    public interface IFileReaderFactory
    {
        IFileReader CreateInstanceFileType(FileType fileType);
    }
}
