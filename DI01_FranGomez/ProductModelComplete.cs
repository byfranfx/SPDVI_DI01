using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI01_FranGomez
{
    public class ProductModelComplete
    {
        public string ProductModel { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string color { get; set; }
        public double ListPrice { get; set; }
        public int Size { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubcategory { get; set; }

        public string info
        {
            get
            {
                return $"{ProductModel}, {Description}, {Name}, {ProductNumber}, {color} , {ListPrice}€, " +
                    $"{Size}, {ProductLine}, {Class}, {Style}, {Size}, {ProductCategory}, " +
                    $"{ProductSubcategory}";
            }
        }
    }
}
