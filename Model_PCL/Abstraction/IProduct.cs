using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Abstraction
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
    }
}
