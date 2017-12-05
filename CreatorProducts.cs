using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{

    class CreatorProducts
    {
        private static CreatorProducts instance;

        private CreatorProducts()
        {
            
        }

        public static CreatorProducts getInstance()
        {
            if (instance == null)
                instance = new CreatorProducts();
            return instance;
        }

        public IProduct CreateProduct(String nameProduct)
        {
            ProductInfo pi = ProductsInfo.getInstance().GetProductInfo(nameProduct);
            return new Product(pi.name, pi.cost);
        }
    }
}
