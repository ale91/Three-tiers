using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    partial interface IService
    {
        List<Tools> GetAllTools();
        Tools GetToolsById(string idTool);
        void InsertTools(Tools tool);
        void UpdateTools(Tools tool);
        void DeleteTools(string tool);
    }
}
