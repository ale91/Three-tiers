using DAO;
using Microsoft.SqlServer.Server;
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

            //Creazione Service per Turrets
            var turrets = service.GetAllTurrets();
            StampaTurrets(turrets);


            //Creazione Service per Machine
            var machines = service.GetAllMachines();
            StampaMachines(machines);

            //Creazione Service per MachineTools
            var machineTools = service.GetAllMachineTools();
            StampaMachineTools(machineTools);

            //Creazione Service per Tools
            var tools = service.GetAllTools();
            StampaTools(tools);


            //Test metodi Turrets
            var turret = new Turrets { TurretCode = "0001", Description = "Nuovo Turret" };
            service.InsertTurret(turret);
            Console.WriteLine("Inserito nuovo Turret");



            turret.Description = "Aggiorna il Turret 4";
            service.UpdateTurret(turret);
            Console.WriteLine("Turret Aggiornato");

            service.DeleteTurrets(turret.TurretCode);
            Console.WriteLine("Turret Eliminato");


            // Test metodi per Machines
            var machine = new Machines { MachineCode = "M001", Description = "MOG 1" };
            service.InsertMachine(machine);
            Console.WriteLine("Nuova Macchina Inserita.");

            service.DeleteMachine(machine.MachineCode);
            Console.WriteLine("Macchina Eliminata");


            // Test metodi per MachineTools
            var machineTool = new MachineTools { IdTool = "5614", PositionCode = "T2", PartNumber = "F01M100714", MachineCode = "EMAG 1", PositionDescription = "Position 3" };
            service.InsertMachineTools(machineTool);
            Console.WriteLine("Nuovo MachineTool Inserito");

            machineTool.PositionDescription = "Aggiornata Posizione 10";
            service.UpdateMachineTools(machineTool);
            Console.WriteLine("MachineTool Aggiornata");

            service.DeleteMachineTools(machineTool.IdTool);
            Console.WriteLine("MachineTool Eliminata");


            // Test metodi per Tools
            var tool = new Tools { IdTool = "T10", BoschCode = "HW70719LB0", Description = "Generics", PrimarySupplier = "Special", Quantity = 1 };
            service.InsertTools(tool);
            Console.WriteLine("Nuovo Tool Inserito");
            StampaTools(tools);

            tool.Description = "Aggiornato Tool 2";
            service.UpdateTools(tool);
            Console.WriteLine("Tool Aggiornato");
            StampaTools(tools);

            service.DeleteTools(tool.IdTool);
            Console.WriteLine("Tool Eliminato");
            StampaTools(tools);
        }

        static void StampaTurrets(List<Turrets> turrets)
        {
            //Calcolo della lunghezza massima per ogni colonna
            int turretCodeWidth = Math.Max("TurretCode".Length, turrets.Max(t => t.TurretCode.Length));
            int descriptionWidth = Math.Max("Description".Length, turrets.Max(t => t.Description.Length));

            //Creazione della stringa di formattazione dinamica
            string format = string.Format("{{0, -{0}}} {{1, -{1}}}",
                turretCodeWidth, descriptionWidth);

            //Stampa dell'intestazione con le larghezze calcolate
            Console.WriteLine(format, "TurretCode", "Description");

            //Stampa di una linea separatrice
            int totalWidth = turretCodeWidth + descriptionWidth + 1; //1 spazio fra le colonne
            Console.WriteLine(new string('-', totalWidth));

            //Stampa in formato tabellare per ogni riga
            foreach (var turret in turrets)
            {
                Console.WriteLine(format, turret.TurretCode, turret.Description);
            }

            //Aggiunta di una riga vuota per separare le tabelle
            Console.WriteLine();
        }

        static void StampaMachines(List<Machines> machines)
        {
            // Calcolo della larghezza massima per ogni colonna
            int machineCodeWidth = Math.Max("MachineCode".Length, machines.Max(m => m.MachineCode.Length));
            int descriptionWidth = Math.Max("Description".Length, machines.Max(m => m.Description.Length));
            int storeToolsFileNameWidth = Math.Max("StoreToolsFileName".Length, machines.Where(m => m.StoreToolsFileName != null).Max(m => m.StoreToolsFileName.Length));
            int lineWidth = Math.Max("Line".Length, machines.Where(m => m.Line != null).Max(m => m.Line.Length));

            // Creazione della stringa di formattazione dinamica
            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}}",
                machineCodeWidth, descriptionWidth, storeToolsFileNameWidth, lineWidth);

            // Stampa dell'intestazione con le larghezze calcolate
            Console.WriteLine(format, "MachineCode", "Description", "StoreToolsFileName", "Line");

            // Stampa di una linea separatrice
            int totalWidth = machineCodeWidth + descriptionWidth + storeToolsFileNameWidth + lineWidth + 3; // 3 spazi fra le colonne
            Console.WriteLine(new string('-', totalWidth));

            // Stampa in formato tabellare per ogni riga
            foreach (var machine in machines)
            {
                Console.WriteLine(format, machine.MachineCode, machine.Description, machine.StoreToolsFileName, machine.Line);
            }
        }

        static void StampaMachineTools(List<MachineTools> machineTools)
        {
            //Calcolo della larghezza massima per ogni colonna
            int idToolWidth = Math.Max("IdTool".Length, machineTools.Max(m => m.IdTool.ToString().Length));
            int positionCodeWidth = Math.Max("PositionCode".Length, machineTools.Max(m => m.PositionCode.Length));
            int partNumberWidth = Math.Max("PartNumber".Length, machineTools.Max(m => m.PartNumber.Length));
            int machineCodeWidth = Math.Max("MachineCode".Length, machineTools.Max(m => m.MachineCode.Length));
            int positionDescriptionWidth = Math.Max("PositionDescription".Length, machineTools.Max(m => m.PositionDescription.Length));

            //Creazione della stringa di formattazione dinamica
            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}} {{4, -{4}}}",
                idToolWidth, positionCodeWidth, partNumberWidth, machineCodeWidth, positionDescriptionWidth);

            //Stampa dell'intestazione con le larghezze calcolate
            Console.WriteLine(format, "IdTool", "PositionCode", "PartNumber", "MachineCode", "PositionDescription");

            //Stampa di una linea separatrice
            int totalWidth = idToolWidth + positionCodeWidth + partNumberWidth + machineCodeWidth + positionDescriptionWidth + 4; //4 spazi fra le colonne
            Console.WriteLine(new string('-', totalWidth));

            //Stampa in formato tabellare per ogni riga
            foreach (var machine in machineTools)
            {
                Console.WriteLine(format, machine.IdTool, machine.PositionCode, machine.PartNumber, machine.MachineCode, machine.PositionDescription);
            }

            //Aggiunta di una riga vuota per separare le tabelle
            Console.WriteLine();
        }

        /*
        static void StampaTools(List<Tools> tools)
        {
            //Calcolo della larghezza massima per ogni colonna
            int idToolWidth = Math.Max("IdTool".Length, tools.Max(t => t.IdTool.ToString().Length));
            int boschCodeWidth = Math.Max("BoschCode".Length, tools.Max(t => t.BoschCode.Length));
            int descriptionWidth = Math.Max("Description".Length, tools.Max(t => t.Description.Length));
            int primarySupplierWidth = Math.Max("PrimarySupplier".Length, tools.Max(t => t.PrimarySupplier.Length));
            int secondarySupplierWidth = Math.Max("SecondarySupplier".Length, tools.Max(t => t.SecondarySupplier.Length));
            int primarySharpenerWidth = Math.Max("PrimarySharpener".Length, tools.Max(t => t.PrimarySharpener.Length));
            int secondarySharpenerWidth = Math.Max("SecondarySharpener".Length, tools.Max(t => t.SecondarySharpener.Length));
            int quantityWidth = Math.Max("Quantity".Length, tools.Max(t => t.Quantity.ToString().Length));
            int turretCodeWidth = Math.Max("TurretCode".Length, tools.Max(t => t.TurretCode != null ? t.TurretCode.Length : 0));


            //Creazione della stringa di formattazione dinamica
            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}} {{4, -{4}}} {{5, -{5}}} {{6, -{6}}} {{7, -{7}}} {{8, -{8}}}",
                idToolWidth, boschCodeWidth, descriptionWidth, primarySupplierWidth, secondarySupplierWidth, primarySharpenerWidth, secondarySharpenerWidth, quantityWidth, turretCodeWidth);

            //Stampa dell'intestazione con le larghezze calcolate
            Console.WriteLine(format, "IdTool", "BoschCode", "Description", "PrimarySupplier", "SecondarySupplier", "PrimarySharpener", "SecondarySharpener", "Quantity", "TurretCode");

            //Stampa di una linea separatrice
            int totalWidth = idToolWidth + boschCodeWidth + descriptionWidth + primarySupplierWidth + secondarySupplierWidth + primarySharpenerWidth + secondarySharpenerWidth + quantityWidth + turretCodeWidth + 8; //8 spazi fra le colonne
            Console.WriteLine(new string('-', totalWidth));

            //Stampa in formato tabellare per ogni riga
            foreach (var t in tools)
            {
                Console.WriteLine(format, t.IdTool, t.BoschCode, t.Description, t.PrimarySupplier, t.SecondarySupplier, t.PrimarySharpener, t.SecondarySharpener, t.Quantity, t.TurretCode);
            }

            Console.WriteLine();
        }

        */

        //Metodo per richiamare format
        static string GetToolsFormat(List<Tools> tools)
        {
            //Calcolo della larghezza massima per ogni colonna
            int idToolWidth = Math.Max("IdTool".Length, tools.Max(t => t.IdTool.ToString().Length));
            int boschCodeWidth = Math.Max("BoschCode".Length, tools.Max(t => t.BoschCode.Length));
            int descriptionWidth = Math.Max("Description".Length, tools.Max(t => t.Description.Length));
            int primarySupplierWidth = Math.Max("PrimarySupplier".Length, tools.Max(t => t.PrimarySupplier.Length));
            int secondarySupplierWidth = Math.Max("SecondarySupplier".Length, tools.Max(t => (t.SecondarySupplier ?? "").Length));  //?? sostituisce null con una stringa vuota
            int primarySharpenerWidth = Math.Max("PrimarySharpener".Length, tools.Max(t => (t.PrimarySharpener ?? "").Length));
            int secondarySharpenerWidth = Math.Max("SecondarySharpener".Length, tools.Max(t => (t.SecondarySharpener ?? "").Length));
            int quantityWidth = Math.Max("Quantity".Length, tools.Max(t => t.Quantity.ToString().Length));
            int turretCodeWidth = Math.Max("TurretCode".Length, tools.Max(t => t.TurretCode != null ? t.TurretCode.Length : 0));


            //Creazione della stringa di formattazione dinamica
            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}} {{4, -{4}}} {{5, -{5}}} {{6, -{6}}} {{7, -{7}}} {{8, -{8}}}",
                idToolWidth, boschCodeWidth, descriptionWidth, primarySupplierWidth, secondarySupplierWidth, primarySharpenerWidth, secondarySharpenerWidth, quantityWidth, turretCodeWidth);

            return format;
        }
        
        static void StampaTools(List<Tools> tools)
        {
            string format = GetToolsFormat(tools);

            //Stampa intestazione
            Console.WriteLine(format, "IdTool", "BoschCode", "Description", "PrimarySupplier", "SecondarySupplier", "PrimarySharpener", "SecondarySharpener", "Quantity", "TurretCode");

            int totalWidth = format.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length + 8;
            Console.WriteLine(new string('-', totalWidth * 10)); //linea separatrice

            //Stampa ogni riga
            foreach (var t in tools)
            {
                StampaTool(t);
            }
        }

        //Creare metodo per stampare un singolo Tool
        static void StampaTool(Tools t)
        {
            //Lista contenente singolo elemento da riutilizzare
            var singleTool = new List<Tools> { t };
            string format = GetToolsFormat(singleTool);

            Console.WriteLine(format, t.IdTool, t.BoschCode, t.Description, t.PrimarySupplier, t.SecondarySupplier, t.PrimarySharpener, t.SecondarySharpener, t.Quantity, t.TurretCode);
        }

        //Usare questo metodo sia in stampa lista tool sia nel program
    }
}
