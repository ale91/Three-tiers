using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public partial class Service   //La classe Service implementa l'interfaccia IService
    {
        //Metodi per Tools
        public List<Tools> GetAllTools()
        {
            return _repository.GetAllTools();
        }

        public Tools GetToolsById(string idTool)
        {
            return _repository.GetToolsById(idTool);
        }

        public void InsertTools(Tools tool)
        {
            _repository.InsertTools(tool);
        }

        public void UpdateTools(Tools tool)
        {
            _repository.UpdateTools(tool);
        }

        public void DeleteTools(string idTool)
        {
            _repository.DeleteTools(idTool);
        }
    }
}
