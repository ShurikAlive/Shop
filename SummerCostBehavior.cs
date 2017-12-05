using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface SummerCostBehavior
    {
        double GetSumCost(List<IProduct> basket);
    }
}
