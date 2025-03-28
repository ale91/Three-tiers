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
        List<Machines> GetAllMachines();
        Machines GetMachineById(int id);
        void InsertMachine(Machines machine);
        void UpdateMachine(Machines machine);
        void DeleteMachine(string machineCode);
    }
}
