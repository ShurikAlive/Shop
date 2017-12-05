using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ProductInfo
    {
        public String name { get; set; }
        public double cost { get; set; }

        public ProductInfo(String name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}
