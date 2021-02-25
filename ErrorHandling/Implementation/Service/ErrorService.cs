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

        private static object _Root = new object();
        private static IErrorService _Instance = new ErrorService();

        public static IErrorService GetInstance
        {
            get
            {
                lock (_Root)
                {
                    if (_Instance == null)
                    {
                        _Instance = new ErrorService();
                    }

                    return _Instance;
                }
            }
        }

        public void AddError(IErrorMessage ex)
        {
            ErrorList.Add(ex);
        }

        private ErrorService() { }
    }
}
