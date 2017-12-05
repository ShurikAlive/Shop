using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class DiscountsOnSupplement: BaceDiscount
    {
        private string[] mainsNamesProducts;
        private string[] discontNameProducts;
        private double discount;


        public DiscountsOnSupplement(string[] mainsNamesProducts, string[] discontNameProducts, double discount)
        {
            this.mainsNamesProducts = mainsNamesProducts;
            this.discontNameProducts = discontNameProducts;
            this.discount = discount;
        }

        public override double GetSumWithDiscount(List<IProduct> basket)
        {
            double sum = 0.0;

            // Заполняем список товаров, которые должны быть для получения скидки
            List<IProduct> mainsProducts = GetProductsObjects(basket, mainsNamesProducts);

            // Если хотябы один товар отсутствует, то скидка не работает
            for (int i = 0; i < mainsProducts.Count; i += 1)
                if (mainsProducts[i] == null) return 0.0;

            // Заполняем список товаров, по которым будет проводится скидка
            List<IProduct> discountProducts = GetProductsObjects(basket, discontNameProducts);

            // Вычисляем стоимость со скидкой
            for (int i = 0; i < discountProducts.Count; i += 1)
                if (discountProducts[i] != null)
                    sum += (discountProducts[i].GetCost() * discountProducts[i].GetCountInOrder()) * (1.0 - discount);

            // Убираем рассмотренный товар
            for (int i = 0; i < discountProducts.Count; i += 1)
                if (discountProducts[i] != null)
                    discountProducts[i].AddCountInOrder(-discountProducts[i].GetCountInOrder());

            return sum;
        }
    }
}
