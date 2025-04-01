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

            /*
            // Esempi per altri metodi
            var turrets = service.GetAllTurrets();
            StampaTurrets(turrets);

            var machines = service.GetAllMachines();
            StampaMachines(machines);

            var machineTools = service.GetAllMachineTools();
            StampaMachineTools(machineTools);
            */

            // Test metodi per Tools

            try
            {
                // Creazione e stampa nuovo Tool
                Random rdn = new Random();
                var tool = new Tools
                {
                    IdTool = "T10",
                    BoschCode = "HW70719LB0",
                    Description = "Generics",
                    PrimarySupplier = "Special",
                    Quantity = 1,

                    // Valorizzazione casuale del ToolType da 1 a 3
                    ToolType = rdn.Next(1, 4)
                };
                StampaTool(tool);

                // Inserimento, lettura e stampa del tool
                service.InsertTools(tool);
                var insertedTool = service.GetToolsById(tool.IdTool);
                Console.WriteLine("Nuovo Tool Inserito");

                // Aggiornamento del tool
                tool.Description = "Aggiornato Tool 2";
                service.UpdateTools(tool);
                var updatedTool = service.GetToolsById(tool.IdTool);
                Console.WriteLine("Tool Aggiornato");
                StampaTool(updatedTool); // Stampa il tool aggiornato

                // Cancellazione del tool
                service.DeleteTools(tool.IdTool);
                var deletedTool = service.GetToolsById(tool.IdTool);
                Console.WriteLine("Tool Eliminato");
                StampaTool(deletedTool);
            }
            catch(Exception ex)
            {
                //Imposta il testo rosso e lo sfondo giallo
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"Errore: {ex.Message}");
            }
           
        }

        static void StampaTurrets(List<Turrets> turrets)
        {
            if (turrets == null || !turrets.Any())
            {
                Console.WriteLine("Nessun turret da stampare.\n");
                return;
            }

            int turretCodeWidth = Math.Max("TurretCode".Length, turrets.Select(t => t?.TurretCode?.Length ?? 0).DefaultIfEmpty(0).Max());
            int descriptionWidth = Math.Max("Description".Length, turrets.Select(t => t?.Description?.Length ?? 0).DefaultIfEmpty(0).Max());

            string format = string.Format("{{0, -{0}}} {{1, -{1}}}", turretCodeWidth, descriptionWidth);

            Console.WriteLine(format, "TurretCode", "Description");
            int totalWidth = turretCodeWidth + descriptionWidth + 1;
            Console.WriteLine(new string('-', totalWidth));

            foreach (var turret in turrets)
            {
                Console.WriteLine(format, turret.TurretCode, turret.Description);
            }
            Console.WriteLine();
        }

        static void StampaMachines(List<Machines> machines)
        {
            if (machines == null || !machines.Any())
            {
                Console.WriteLine("Nessuna macchina da stampare.\n");
                return;
            }

            int machineCodeWidth = Math.Max("MachineCode".Length, machines.Select(m => m?.MachineCode?.Length ?? 0).DefaultIfEmpty(0).Max());
            int descriptionWidth = Math.Max("Description".Length, machines.Select(m => m?.Description?.Length ?? 0).DefaultIfEmpty(0).Max());
            int storeToolsFileNameWidth = Math.Max("StoreToolsFileName".Length, machines
                .Where(m => m?.StoreToolsFileName != null)
                .Select(m => m.StoreToolsFileName.Length)
                .DefaultIfEmpty(0)
                .Max());
            int lineWidth = Math.Max("Line".Length, machines
                .Where(m => m?.Line != null)
                .Select(m => m.Line.Length)
                .DefaultIfEmpty(0)
                .Max());

            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}}",
                machineCodeWidth, descriptionWidth, storeToolsFileNameWidth, lineWidth);

            Console.WriteLine(format, "MachineCode", "Description", "StoreToolsFileName", "Line");
            int totalWidth = machineCodeWidth + descriptionWidth + storeToolsFileNameWidth + lineWidth + 3;
            Console.WriteLine(new string('-', totalWidth));

            foreach (var machine in machines)
            {
                Console.WriteLine(format, machine.MachineCode, machine.Description, machine.StoreToolsFileName, machine.Line);
            }
            Console.WriteLine();
        }

        static void StampaMachineTools(List<MachineTools> machineTools)
        {
            if (machineTools == null || !machineTools.Any())
            {
                Console.WriteLine("Nessun MachineTool da stampare.\n");
                return;
            }

            int idToolWidth = Math.Max("IdTool".Length, machineTools.Select(m => m?.IdTool?.ToString().Length ?? 0).DefaultIfEmpty(0).Max());
            int positionCodeWidth = Math.Max("PositionCode".Length, machineTools.Select(m => m?.PositionCode?.Length ?? 0).DefaultIfEmpty(0).Max());
            int partNumberWidth = Math.Max("PartNumber".Length, machineTools.Select(m => m?.PartNumber?.Length ?? 0).DefaultIfEmpty(0).Max());
            int machineCodeWidth = Math.Max("MachineCode".Length, machineTools.Select(m => m?.MachineCode?.Length ?? 0).DefaultIfEmpty(0).Max());
            int positionDescriptionWidth = Math.Max("PositionDescription".Length, machineTools.Select(m => m?.PositionDescription?.Length ?? 0).DefaultIfEmpty(0).Max());

            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}} {{4, -{4}}}",
                idToolWidth, positionCodeWidth, partNumberWidth, machineCodeWidth, positionDescriptionWidth);

            Console.WriteLine(format, "IdTool", "PositionCode", "PartNumber", "MachineCode", "PositionDescription");
            int totalWidth = idToolWidth + positionCodeWidth + partNumberWidth + machineCodeWidth + positionDescriptionWidth + 4;
            Console.WriteLine(new string('-', totalWidth));

            foreach (var machineTool in machineTools)
            {
                Console.WriteLine(format, machineTool.IdTool, machineTool.PositionCode, machineTool.PartNumber, machineTool.MachineCode, machineTool.PositionDescription);
            }
            Console.WriteLine();
        }

        // Metodo per ottenere il formato per stampare i Tools
        static string GetToolsFormat(List<Tools> tools)
        {
            int idToolWidth = Math.Max("IdTool".Length, tools.Where(t => t?.IdTool != null).Select(t => t.IdTool.ToString().Length).DefaultIfEmpty(0).Max());
            int boschCodeWidth = Math.Max("BoschCode".Length, tools.Where(t => t?.BoschCode != null).Select(t => t.BoschCode.Length).DefaultIfEmpty(0).Max());
            int descriptionWidth = Math.Max("Description".Length, tools.Where(t => t?.Description != null).Select(t => t.Description.Length).DefaultIfEmpty(0).Max());
            int primarySupplierWidth = Math.Max("PrimarySupplier".Length, tools.Where(t => t?.PrimarySupplier != null).Select(t => t.PrimarySupplier.Length).DefaultIfEmpty(0).Max());
            int secondarySupplierWidth = Math.Max("SecondarySupplier".Length, tools.Select(t => (t?.SecondarySupplier ?? string.Empty).Length).DefaultIfEmpty(0).Max());
            int primarySharpenerWidth = Math.Max("PrimarySharpener".Length, tools.Select(t => (t?.PrimarySharpener ?? string.Empty).Length).DefaultIfEmpty(0).Max());
            int secondarySharpenerWidth = Math.Max("SecondarySharpener".Length, tools.Select(t => (t?.SecondarySharpener ?? string.Empty).Length).DefaultIfEmpty(0).Max());
            int quantityWidth = Math.Max("Quantity".Length, tools.Select(t => t?.Quantity.ToString().Length ?? 0).DefaultIfEmpty(0).Max());
            int turretCodeWidth = Math.Max("TurretCode".Length, tools.Where(t => t?.TurretCode != null).Select(t => t.TurretCode.Length).DefaultIfEmpty(0).Max());

            // Stampa del ToolType
            int toolTypeWidth = Math.Max("ToolType".Length, tools.Select(t => t.ToolType.ToString().Length).DefaultIfEmpty(0).Max());

            string format = string.Format("{{0, -{0}}} {{1, -{1}}} {{2, -{2}}} {{3, -{3}}} {{4, -{4}}} {{5, -{5}}} {{6, -{6}}} {{7, -{7}}} {{8, -{8}}}",
                idToolWidth, boschCodeWidth, descriptionWidth, primarySupplierWidth, secondarySupplierWidth, primarySharpenerWidth, secondarySharpenerWidth, quantityWidth, turretCodeWidth);

            return format;
        }

        static void StampaTools(List<Tools> tools)
        {
            if (tools == null || !tools.Any())
            {
                Console.WriteLine("Nessun tool da stampare.\n");
                return;
            }

            string format = GetToolsFormat(tools);

            // Stampa intestazione
            Console.WriteLine(format, "IdTool", "BoschCode", "Description", "PrimarySupplier", "SecondarySupplier", "PrimarySharpener", "SecondarySharpener", "Quantity", "TurretCode", "ToolType"); // È stato aggiunto ToolType

            // Calcolo della larghezza totale in modo più affidabile
            int totalWidth = format.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Sum(x => int.Parse(x.Trim('{', '}', '-', ','))) + 8;
            Console.WriteLine(new string('-', totalWidth));

            // Stampa ogni riga
            foreach (var t in tools)
            {
                StampaTool(t);
            }
            Console.WriteLine();
        }

        // Metodo per stampare un singolo Tool
        static void StampaTool(Tools t)
        {
            if (t == null)
            {
                Console.WriteLine("Tool non trovato.");
                return;
            }

            var singleTool = new List<Tools> { t };
            string format = GetToolsFormat(singleTool);
            Console.WriteLine(format, t.IdTool, t.BoschCode, t.Description, t.PrimarySupplier, t.SecondarySupplier, t.PrimarySharpener, t.SecondarySharpener, t.Quantity, t.TurretCode, t.ToolType);
        }
    }
}
