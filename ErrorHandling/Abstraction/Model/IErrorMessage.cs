using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorHandling_PCL.Abstraction.Model
{
    public interface IErrorMessage
    {
        string Message { get; set; }
        string Location { get; set; }
        DateTime Time { get; set; }
    }
}
