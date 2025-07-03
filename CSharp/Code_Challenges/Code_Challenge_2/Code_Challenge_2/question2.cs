//2.Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    class Products
    {
        //int Productid;
        //string ProductName;
        static float[] PriceofProd = new float[10];
        public static void Display()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Product {0}  Id:", i + 1);
                int Productid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Product {0}  Name:", i + 1);
                string ProductName = Console.ReadLine();

                Console.WriteLine("Enter price of product {0} :", i + 1);
                PriceofProd[i] = Convert.ToSingle(Console.ReadLine());
            }
            Array.Sort(PriceofProd);
            Console.WriteLine("Prices of 10 Products after sorting:");
            foreach (float price in PriceofProd)
            {
                Console.WriteLine(price);
            }
        }
    }
    class question2
    {
        static void Main()
        {
            Products.Display();
            Console.Read();
        }
    }
}
