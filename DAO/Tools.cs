using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Tools
    {

        public virtual string IdTool { get; set; }
        public virtual string BoschCode { get; set; }

        public virtual string Description { get; set; }

        public virtual string PrimarySupplier { get; set; }
        
        public virtual string SecondarySupplier { get; set; }

        public virtual string PrimarySharpener { get; set; }

        public virtual string SecondarySharpener { get; set; }

        public virtual int Quantity { get; set; }

        public virtual string TurretCode { get; set; }
    }
}
