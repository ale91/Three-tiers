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
        //Istanza di Random per generare numeri casuali da 1 a 3
        private static readonly Random random = new Random();

        //Metodo per generare numero casuale da 1 a 3
        private int GeneraNumero()
        {
            //random.Next resistuisce i valori da 1 a 3
            return random.Next(1, 4);
        }

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

        public int UpdateAllToolsType()
        {
           var tools = _repository.GetAllTools().Where(tool => tool.ToolType == null).ToList();

            var Count = 0;

            //controllo se tooltype è null
            foreach (var tool in tools)
            {
                tool.ToolType = GeneraNumero();
                _repository.UpdateTools(tool);  //restituire numero e salvare

                //incrementare la variabile Count aggiungendo valore restituito da _repository.UpdateTools(tool)

            }

            /*
            foreach (var tool in tools)
            {
                tool.ToolType = GeneraNumero();

                _repository.UpdateTools(tool);
            }
            */

            //return numero dei tool aggiornati
            return Count;

        }

        //Aggiunta endpoint GetToolsByToolType
        public List<Tools> GetToolsByToolType(int toolType)
        {
            return _repository.GetToolsByToolType(toolType);
        }


    }
}
