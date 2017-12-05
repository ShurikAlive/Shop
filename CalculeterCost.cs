using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class CalculeterCost
    {

        private SummerCostBehavior SumCostBehavior;

        List<IProduct> basket;

        public CalculeterCost(SummerCostBehavior sumCostBehavior)
        {
            this.SumCostBehavior = sumCostBehavior;
            basket = new List<IProduct>();
        }

        public void AddProduct(String name, int count)
        {
            int pos = FindPositionProductInBasket(name);
            if (pos == -1)
            {
                basket.Add(CreatorProducts.getInstance().CreateProduct(name));
                basket[basket.Count - 1].AddCountInOrder(count);
            }
            else
            {
                basket[pos].AddCountInOrder(count);
            }
        }

        private int FindPositionProductInBasket(String name)
        {
            int pos = -1;

            for (int i = 0; i < basket.Count; i += 1)
            {
                if (basket[i].GetName() == name)
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        public void SetSumCostBehavior(SummerCostBehavior costBehavior)
        {
            SumCostBehavior = costBehavior;
        }

        public double GetSumCost()
        {
            return SumCostBehavior.GetSumCost(basket);
        }
    }
}
