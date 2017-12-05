using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ProductsInfo
    {
        private Dictionary<String, ProductInfo> ProductInfo;
        private static ProductsInfo instance;

        public void AddProductInfo(String name, double cost)
        {
            ProductInfo.Add(name, new ProductInfo(name, cost));
        }

        private ProductsInfo()
        {
            ProductInfo = new Dictionary<string, ProductInfo>();
        }

        public static ProductsInfo getInstance()
        {
            if (instance == null)
                instance = new ProductsInfo();
            return instance;
        }

        public ProductInfo GetProductInfo(String name)
        {
            return ProductInfo[name];
        }
    }
}
