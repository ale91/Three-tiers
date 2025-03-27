using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Repository
    {
        public List<Turrets> GetAllTurrets()
        {
            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.Turrets.ToList();

            }
        }

        //Metodo Get By Id (aggiunto)
        public Turrets GetTurretById(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Turrets.Find(id);
            }
        }

        //Metodo Insert (aggiunto)
        public void InsertTurret(Turrets turret)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Turrets.Add(turret);
                myDb.SaveChanges();
            }
        }

        //Metodo Update (aggiunto)
        public void UpdateTurret(Turrets turret)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Turrets.AddOrUpdate(turret);
                myDb.SaveChanges();
            }
        }

        //Metodo Delete per Id (aggiunto)
        public void DeleteTurrets(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var turret = myDb.Turrets.Find(id);
                if (turret != null)
                {
                    myDb.Turrets.Remove(turret);
                    myDb.SaveChanges();
                }
            }
        }

        public List<Machines> GetAllMachine()
        {
            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.Machines.ToList();

            }
        }

        //Metodo Get By Id (aggiunto)
        public Machines GetMachineById(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Machines.Find(id);
            }
        }

        //Metodo Insert (aggiunto)
        public void InsertMachine(Machines machine)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Machines.Add(machine);
                myDb.SaveChanges();
            }
        }

        //Metodo Update (aggiunto)
        public void UpdateMachine(Machines machine)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Machines.AddOrUpdate(machine);
                myDb.SaveChanges();
            }
        }

        //Metodo Delete per Id (aggiunto)
        public void DeleteMachine(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var machine = myDb.Machines.Find(id);
                if (machine != null)
                {
                    myDb.Machines.Remove(machine);
                    myDb.SaveChanges();
                }
            }
        }

        public List<MachineTools> GetAllMachineTools()
        {

            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.MachineTools.ToList();

            }

        }

        //Metodo Get By Id (aggiunto)
        public MachineTools GetMachineToolsById(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.MachineTools.Find(id);
            }
        }

        //Metodo Insert (aggiunto)
        public void InsertMachineTools(MachineTools machineTool)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.MachineTools.Add(machineTool);
                myDb.SaveChanges();
            }
        }

        //Metodo Update (aggiunto)
        public void UpdateMachineTools(MachineTools machineTool)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.MachineTools.AddOrUpdate(machineTool);
                myDb.SaveChanges();
            }
        }

        //Metodo Delete per id (aggiunto)
        public void DeleteMachineTools(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var machineTool = myDb.MachineTools.Find(id);
                if (machineTool != null)
                {
                    myDb.MachineTools.Remove(machineTool);
                    myDb.SaveChanges();
                }
            }
        }

        public List<Tools> GetAllTools()
        {
            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.Tools.ToList();

            }
        }

        //Metodo Get By Id (aggiunto)
        public Tools GetToolsById(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.Find(id);
            }
        }

        //Metodo Insert (aggiunto)
        public void InsertTools(Tools tool)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Tools.Add(tool);
                myDb.SaveChanges();
            }
        }

        //Metodo Update (aggiunto)
        public void UpdateTools(Tools tool)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Tools.AddOrUpdate(tool);
                myDb.SaveChanges();
            }
        }

        //Metodo Delete per id (aggiunto)
        public void DeleteTools(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var tool = myDb.Tools.Find(id);
                if (tool != null)
                {
                    myDb.Tools.Remove(tool);
                    myDb.SaveChanges();
                }
            }
        }

        public List<Machines> GetAllMachine()
        {
            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.Machines.ToList();

            }
        }

        public List<MachineTools> GetAllMachineTools()
        {

            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.MachineTools.ToList();

            }

        }


    }
}
