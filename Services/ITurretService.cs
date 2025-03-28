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
        List<Turrets> GetAllTurrets();
        Turrets GetTurretsById(int id);
        void InsertTurrets(Turrets turret);
        void UpdateTurrets(Turrets turret);
        void DeleteTurrets(string turretCode);
    }
}
