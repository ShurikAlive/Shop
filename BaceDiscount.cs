using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    abstract class BaceDiscount
    {
        abstract public double GetSumWithDiscount(List<IProduct> basket);

        protected List<IProduct> GetProductsObjects(List<IProduct> basket, string[] names)
        {
            List<IProduct> products = new List<IProduct>();

            for (int i = 0; i < names.Length; i += 1)
            {
                products.Add(FindProduct(basket, names[i]));
            }

            return products;
        }

        protected IProduct FindProduct(List<IProduct> basket, string nameProduct)
        {
            for (int i = 0; i < basket.Count; i += 1)
            {
                if (basket[i].GetName() == nameProduct) return basket[i];
            }

            return null;
        }
    }
}
