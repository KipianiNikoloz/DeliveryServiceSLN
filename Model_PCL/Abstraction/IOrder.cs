using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Abstraction
{
    public interface IOrder
    {
        string Name { get; set; }
        DateTime Time { get; set; }
    }
}
