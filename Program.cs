using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void InitProducts()
        {
            ProductsInfo.getInstance().AddProductInfo("A", 10.0);
            ProductsInfo.getInstance().AddProductInfo("B", 20.0);
            ProductsInfo.getInstance().AddProductInfo("C", 30.0);
            ProductsInfo.getInstance().AddProductInfo("D", 40.0);
            ProductsInfo.getInstance().AddProductInfo("E", 50.0);
            ProductsInfo.getInstance().AddProductInfo("F", 60.0);
            ProductsInfo.getInstance().AddProductInfo("G", 70.0);
            ProductsInfo.getInstance().AddProductInfo("H", 80.0);
            ProductsInfo.getInstance().AddProductInfo("I", 90.0);
            ProductsInfo.getInstance().AddProductInfo("J", 100.0);
            ProductsInfo.getInstance().AddProductInfo("K", 110.0);
            ProductsInfo.getInstance().AddProductInfo("L", 120.0);
            ProductsInfo.getInstance().AddProductInfo("M", 130.0);
        }

        static void InitDiscounts(StandartSummerCost standartSummer)
        {
            standartSummer.AddDiscount(CreatorDiscounts.getInstance().CreateDiscountOnAB());

            standartSummer.AddDiscount(CreatorDiscounts.getInstance().CreateDiscountOnSet(new string[] { "A", "B" }, 0.1));
            standartSummer.AddDiscount(CreatorDiscounts.getInstance().CreateDiscountOnSet(new string[] { "D", "E" }, 0.05));
            standartSummer.AddDiscount(CreatorDiscounts.getInstance().CreateDiscountOnSet(new string[] { "E", "F", "G" }, 0.05));

            standartSummer.AddDiscount(CreatorDiscounts.getInstance().CreateDiscountOnSupplement(new string[] { "A" }, new string[] { "K", "L", "M" }, 0.05));

            Dictionary<int, double> discountRanges = new Dictionary<int, double> ();
            discountRanges.Add(3, 0.05);
            discountRanges.Add(4, 0.1);
            discountRanges.Add(5, 0.2);
            standartSummer.AddDiscount(CreatorDiscounts.getInstance().CreateDiscountOnAll(new string[] { "A", "C" }, discountRanges));
        }

        static void AddProductInBatscet(CalculeterCost Batsceta)
        {
            Batsceta.AddProduct("A", 10);
            Batsceta.AddProduct("B", 6);
        }

        static void Main(string[] args)
        {


            InitProducts();

            StandartSummerCost standartSummer = new StandartSummerCost();
            InitDiscounts(standartSummer);

            CalculeterCost a = new CalculeterCost(standartSummer);
            AddProductInBatscet(a);
            Console.WriteLine(a.GetSumCost());

            Console.Read();
        }
    }
}
