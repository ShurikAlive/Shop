using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Product: IProduct
    {
        private string name = "";
        private int countInOrder = 0;
        private double cost = 0.0;

        public Product(string name, double cost)
        {
            this.name = name;
            this.countInOrder = 0;
            this.cost = cost;
        }

        public IProduct ShallowCopy()
        {
            return (IProduct)this.MemberwiseClone();
        }

        public string GetName()
        {
            return name;
        }

        public int GetCountInOrder()
        {
            return countInOrder;
        }

        public void AddCountInOrder(int count)
        {
            countInOrder += count;

        }

        public double GetCost()
        {
            return cost;
        }
    }
}
