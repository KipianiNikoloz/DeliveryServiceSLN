using Model_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Imlementation
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public static bool operator ==(Product a, Product b)
        {
            if(a.Name == b.Name && a.Price == b.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Product a, Product b)
        {
            if (a.Name != b.Name || a.Price != b.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
