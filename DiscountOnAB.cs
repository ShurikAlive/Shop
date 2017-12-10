using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class DiscountOnAB: BaceDiscount
    {
        public DiscountOnAB()
        {
        }

        public override double GetSumWithDiscount(List<IProduct> basket)
        {
            double sum = 0.0;

            // Заполняем лист товаров учавствующих в скидке
            List<IProduct> discountProducts = GetProductsObjects(basket, new string[] { "A", "B"});

            // Проверяем, все ли значения нашлись и есть ли хотя бы 1 нерассмотрешшая штука товара данного типа в корзине
            for (int i = 0; i < discountProducts.Count; i += 1)
            {
                if (discountProducts[i] == null) return 0.0;
                if (discountProducts[i].GetCountInOrder() <= 0) return 0.0;
            }

            int ACountOrder = FindProduct(discountProducts, "A").GetCountInOrder();
            int BCountOrder = FindProduct(discountProducts, "B").GetCountInOrder();

            // Ищем количество пары
            int countCouple = 0;
            if ((ACountOrder / 5) > (BCountOrder / 3))
                countCouple = BCountOrder / 3;
            else
                countCouple = ACountOrder / 5;

            if (countCouple == 0)
                return 0;

            // Получаем цену со скидкой
            sum += (FindProduct(discountProducts, "A").GetCost() * countCouple * 5) * 0.97;
            sum += (FindProduct(discountProducts, "B").GetCost() * countCouple * 3) * 0.97;

            // Убираем рассмотренные товары
            FindProduct(discountProducts, "A").AddCountInOrder(-countCouple * 5);
            FindProduct(discountProducts, "B").AddCountInOrder(-countCouple * 3);

            return sum;
        }
    }
}
