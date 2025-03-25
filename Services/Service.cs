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
        public List<Turrets> GetAllTurrets()
        {

            var repo = new Repository();
            return repo.GetAllTurrets();

        }
    }
}
