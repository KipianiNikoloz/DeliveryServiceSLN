using ErrorHandling_PCL.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorHandling_PCL.Abstraction.Service
{
    public interface IErrorService
    {
        void AddError(IErrorMessage ex);
    }
}
