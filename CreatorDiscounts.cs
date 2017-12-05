using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class CreatorDiscounts
    {
        private static CreatorDiscounts instance;

        private CreatorDiscounts()
        {

        }

        public static CreatorDiscounts getInstance()
        {
            if (instance == null)
                instance = new CreatorDiscounts();
            return instance;
        }

        public BaceDiscount CreateDiscountOnSet(string[] nameProducts, double discount)
        {
            return new DiscountsOnSets(nameProducts, discount);
        }

        public BaceDiscount CreateDiscountOnSupplement(string[] mainsNamesProducts, string[] discontNameProducts, double discount)
        {
            return new DiscountsOnSupplement(mainsNamesProducts, discontNameProducts, discount);
        }

        public BaceDiscount CreateDiscountOnAll(string[] exceptions, Dictionary<int, double> discountRanges)
        {
            return new DiscountsOnAll(exceptions, discountRanges);
        }
    }
}
