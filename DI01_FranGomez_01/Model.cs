using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI01_FranGomez_01
{
    class Model
    {
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }

        public override string ToString()
        {
            return $"{ProductModelID}, {Name}, {Description}";
        }
    }
}
