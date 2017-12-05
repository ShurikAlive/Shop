using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class DiscountsOnSets: BaceDiscount
    {
        private string[] nameProducts;
        private double discount;

        public DiscountsOnSets(string[] nameProducts, double discount)
        {
            this.nameProducts = nameProducts;
            this.discount = discount;
        }

        public override double GetSumWithDiscount(List<IProduct> basket)
        {
            double sum = 0.0;

            // Заполняем лист товаров учавствующих в скидке
            List<IProduct> discountProducts = GetProductsObjects(basket, nameProducts);

            // Проверяем, все ли значения нашлись и есть ли хотя бы 1 нерассмотрешшая штука товара данного типа в корзине
            for (int i = 0; i < discountProducts.Count; i += 1)
            {
                if (discountProducts[i] == null) return 0.0;
                if (discountProducts[i].GetCountInOrder() <= 0) return 0.0;
            }

            // Ищем минимальное значение, которое можем вычесть из каждого товара
            int minCount = discountProducts[0].GetCountInOrder();
            for (int i = 1; i < discountProducts.Count; i += 1)
                if (minCount > discountProducts[i].GetCountInOrder())
                    minCount = discountProducts[i].GetCountInOrder();

            // Вычисляем стоимость со скидкой
            for (int i = 0; i < discountProducts.Count; i += 1)
                sum += (discountProducts[i].GetCost() * minCount) * (1.0 - discount);

            // Убираем рассмотренные товары
            for (int i = 0; i < discountProducts.Count; i += 1)
                discountProducts[i].AddCountInOrder(-minCount);

            return sum;
        }
    }
}
