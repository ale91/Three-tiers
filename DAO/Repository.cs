using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public partial class Repository
    {
        private readonly MyDBContext _context;

        public Repository()
        {
            _context = new MyDBContext();
        }

        public void RandomizeToolsType()
        {
            var random = new Random();
            var tools = _context.Tools.ToList();

            foreach (var tool in tools)
            {
                tool.ToolType = random.Next(1, 4); // Valori da 1 a 3
            }

            _context.SaveChanges();
        }
    }
}
