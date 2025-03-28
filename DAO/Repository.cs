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
    }
}
