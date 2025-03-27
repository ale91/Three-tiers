using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Machines
    {

        public virtual string MachineCode { get; set; }

        public virtual string Description { get; set; }

        public virtual string StoreToolsFileName { get; set; }

        public virtual string Line { get; set; }

    }
}
