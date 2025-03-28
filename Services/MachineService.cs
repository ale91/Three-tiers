using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public partial class Service 
    {
        //Metodi per Machines
        public List<Machines> GetAllMachines()
        {
            return _repository.GetAllMachines();
        }

        public Machines GetMachineById(int id)
        {
            return _repository.GetMachineById(id);
        }

        public void InsertMachine(Machines machine)
        {
            _repository.InsertMachine(machine);
        }

        public void UpdateMachine(Machines machine)
        {
            _repository.UpdateMachine(machine);
        }

        public void DeleteMachine(string machineCode)
        {
            _repository.DeleteMachine(machineCode);
        }

        public void DeleteMachine(Machines machine)
        {
            _repository.DeleteMachine(machine);
        }

    }
}
