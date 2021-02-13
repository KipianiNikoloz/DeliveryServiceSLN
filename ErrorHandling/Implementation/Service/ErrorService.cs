using ErrorHandling_PCL.Abstraction.Model;
using ErrorHandling_PCL.Abstraction.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorHandling_PCL.Implementation.Service
{
    public class ErrorService : IErrorService
    {
        private List<IErrorMessage> ErrorList = new List<IErrorMessage>();

        public void AddError(IErrorMessage ex)
        {
            ErrorList.Add(ex);
        }
    }
}
