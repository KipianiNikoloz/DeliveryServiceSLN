using Model_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Imlementation
{
    public class Order : IOrder
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
