using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class DiscountsOnAll: BaceDiscount
    {
        private string[] exceptions;
        private Dictionary<int, double> discountRanges;// Список диапазонов для скидок Key - минимальное значение, Value - значение скидки
                                                             
        public DiscountsOnAll(string[] exceptions, Dictionary<int, double> discountRanges)
        {
            this.discountRanges = discountRanges;
            this.exceptions = exceptions;
        }

        public override double GetSumWithDiscount(List<IProduct> basket)
        {
            double sum = 0.0;

            // Определяем, какое кол-во продуктов в корзине учавствует в скидке
            int countProductsInThisDiscount = 0;
            for (int i = 0; i < basket.Count; i += 1)
                if (!FaindNameInExeption(basket[i].GetName()))
                    countProductsInThisDiscount += 1;

            // Ищем подходящую скидку для выбранных товаров
            double discount = 0.0;
            int tmpRange = 0;
            foreach (var discountRange in discountRanges)
                if ((discountRange.Key <= countProductsInThisDiscount) & (tmpRange < discountRange.Key))
                {
                    tmpRange = discountRange.Key;
                    discount = discountRange.Value;
                }

            // Проверка, есть ли такая скидка, если нет то выходим
            if (discount == 0.0) return sum;

            // Рассчитываем сумму и убираем рассмотренные записи
            for (int i = 0; i < basket.Count; i += 1)
                if (!FaindNameInExeption(basket[i].GetName()))
                {
                    sum += (basket[i].GetCost() * basket[i].GetCountInOrder()) * (1.0 - discount);
                    basket[i].AddCountInOrder(-basket[i].GetCountInOrder());
                }

            return sum;
        }

        private bool FaindNameInExeption(string name)
        {
            for (int i = 0; i < exceptions.Length; i += 1)
                if (exceptions[i] == name) return true;
            return false;
        }
    }
}
