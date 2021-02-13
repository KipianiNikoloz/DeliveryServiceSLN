using ErrorHandling_PCL.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorHandling_PCL.Implementation.Model
{
    public class ErrorMessage : IErrorMessage
    {
        public string Message { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
