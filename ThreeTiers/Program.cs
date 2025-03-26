using DAO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTiers
{
    public class Program
    {
        static void Main(string[] args)
        {

            Service service = new Service();

            var turrets = service.GetAllTurrets();
            StampaTurrets(turrets);


            //Creazione Service per Machine
            var machines = service.GetAllMachines();
            StampaMachine(machines);

            //Creazione Service per MachineTools
            var machineTools = service.GetMachineAllTools();
            StampaMachineTools(machineTools);


        }

        static void StampaTurrets(List<Turrets> turrets)
        {
            //Stampa intestazione tabella
            Console.WriteLine("{0, -10} {1, -20}", "TurretCode", "Description");
            Console.WriteLine(new string('-', 30));


            //Stampa in formato tabellare
            foreach (var turret in turrets)
            {
                Console.WriteLine("{0, -10} {1, -20}", turret.TurretCode, turret.Description);
            }

            Console.WriteLine();
        }

        static void StampaMachine(List<Machines> machine)
        {
            //Stampa intestazione tabella
            Console.WriteLine("{0, -10} {1, -20} {2, -20} {3, -20}", "MachineCode", "Description", "StoreToolsFileName", "Line");
            Console.WriteLine(new string('-', 30));

            //Calcolo max lunghezza campi



            //Stampa in formato tabellare
            foreach (var machines in machine)
            {
                Console.WriteLine("{0, -10} {1, -20} {2, -20} {3, -20}", machines.MachineCode.Length, machines.Description, machines.StoreToolsFileName, machines.Line);
            }


        }

        static void StampaMachineTools(List<MachineTools> machineTools)
        {
            //Stampa intestazione tabella
            Console.WriteLine("{0, -10} {1, -20} {2, -20} {3, -20} {4, -20}", "IdTool", "PositionCode", "PartNumber", "MachineCode", "PositionDescription");
            Console.WriteLine(new string('-', 30));

            //Stampa in formato tabellare
            foreach (var machine in machineTools)
            {
                Console.WriteLine("{0, -10} {1, -20} {2, -20} {3, -20} {4, -20}", machine.IdTool, machine.PositionCode, machine.PartNumber, machine.MachineCode, machine.PositionDescription);
            }
        }

    }
}
