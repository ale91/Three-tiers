using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Service
    {

        private readonly Repository _repository;

        public Service()
        {
            _repository = new Repository();
        }

        //Metodi per Turrets
        public List<Turrets> GetAllTurrets()
        {
            return _repository.GetAllTurrets();
        }

        public Turrets GetTurretById(int id)
        {
            return _repository.GetTurretById(id);
        }

        public void InsertTurret(Turrets turret)
        {
            _repository.InsertTurret(turret);
        }

        public void UpdateTurret(Turrets turret)
        {
            _repository.UpdateTurret(turret);
        }

        public void DeleteTurrets(int id)
        {
            _repository.DeleteTurrets(id);
        }

        //Metodi per Machines
        public List<Machines> GetAllMachines()
        {
            return _repository.GetAllMachine();
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

        public void DeleteMachine(int id)
        {
            _repository.DeleteMachine(id);
        }

        //Metodi per MachineTools
        public List<MachineTools> GetAllMachineTools()
        {
            return _repository.GetAllMachineTools();
        }

        public MachineTools GetMachineToolsById(int id)
        {
            return _repository.GetMachineToolsById(id);
        }

        public void InsertMachineTools(MachineTools machineTool)
        {
            _repository.InsertMachineTools(machineTool);
        }

        public void UpdateMachineTools(MachineTools machineTool)
        {
            _repository.UpdateMachineTools(machineTool);
        }

        public void DeleteMachineTools(int id)
        {
            _repository.DeleteMachineTools(id);
        }

        //Metodi per Tools
        public List<Tools> GetAllTools()
        {
            return _repository.GetAllTools();
        }

        public Tools GetById(int id)
        {
            return _repository.GetToolsById(id);
        }

        public void InsertTools(Tools tool)
        {
            _repository.InsertTools(tool);
        }

        public void UpdateTools(Tools tool)
        {
            _repository.UpdateTools(tool);
        }

        public void DeleteToos(int id)
        {
            _repository.DeleteTools(id);
        }
    }
}
