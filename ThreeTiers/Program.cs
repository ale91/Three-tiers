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

            Service turretService = new Service();

            var turrets = turretService.GetAllTurrets();
            StampaTurrets(turrets);

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
        }
    }
}
