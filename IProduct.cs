using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface IProduct
    {
        IProduct ShallowCopy();
        string GetName();
        int GetCountInOrder();
        void AddCountInOrder(int count);
        double GetCost();
    }
}
