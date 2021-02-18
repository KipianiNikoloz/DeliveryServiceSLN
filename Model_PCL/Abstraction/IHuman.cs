using Model_PCL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Abstraction
{
    public interface IHuman
    {
        string FullName { get; set; }
        int Age { get; set; }
        GenderType Gender { get; set; }
    }
}
