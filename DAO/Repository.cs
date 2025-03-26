using System;
using System.Collections.Generic;
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
