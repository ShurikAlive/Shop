using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class StandartSummerCost: SummerCostBehavior
    {
        private List<BaceDiscount> discounts;

        public StandartSummerCost()
        {
            discounts = new List<BaceDiscount>();
        }

        public void AddDiscount(BaceDiscount discount)
        {
            discounts.Add(discount);
        }

        public double GetSumCost(List<IProduct> basket)
        {
            double sum = 0.0;
            List<IProduct> copyBasket = CopyBasket(basket);

            // Применяем скидки
            for (int i = 0; i < discounts.Count; i += 1)
            {
                sum += discounts[i].GetSumWithDiscount(copyBasket);
            }

            // Суммируем остатки
            sum += SumOfResidues(copyBasket);

            return sum;
        }

        private List<IProduct> CopyBasket(List<IProduct> basket)
        {
            List<IProduct> copyBasket = new List<IProduct>();

            for (int i = 0; i < basket.Count; i += 1)
            {
                copyBasket.Add(basket[i].ShallowCopy());
            }

            return copyBasket;
        }

        private double SumOfResidues(List<IProduct> basket)
        {
            double sum = 0.0;

            for (int i = 0; i < basket.Count; i += 1)
            {
                sum += basket[i].GetCost() * basket[i].GetCountInOrder();
            }

            return sum;
        }
    }
}
