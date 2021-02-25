using ErrorHandling_PCL.Abstraction.Model;
using ErrorHandling_PCL.Implementation.Model;
using Model_PCL.Abstraction;
using Model_PCL.Imlementation;
using Services_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services_PCL.Implementation
{
    public class Delivery : IDelivery
    {
        public Func<IOrder, bool> GetOrderToShop { get; set; }
        public Action<IErrorMessage> ErrorHandler { get; set; }
        public Func<IProduct, bool> GetProductToCustomer { get; set; }

        private static object _Root = new object();
        private static IDelivery _Instance = null;

        public static IDelivery GetInstance
        {
            get
            {
                lock (_Root)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Delivery();
                    }

                    return _Instance;
                }
            }
        }

        public bool GetOrderFromCustomer(string Name)
        {
            try
            {
                IOrder Tmp = new Order
                {
                    Name = Name
                };

                GetOrderToShop.Invoke(Tmp);
                return true;
            }
            catch(Exception ex)
            {
                IErrorMessage CustomEx = new ErrorMessage
                {
                    Message = ex.Message,
                    Location = "Consumer.cs"
                };

                ErrorHandler.Invoke(CustomEx);
                
                return false;
            }
        }

        public bool GetOrderFromShop(IProduct NewProduct)
        {
            try
            {
                GetProductToCustomer.Invoke(NewProduct);

                return true;
            }
            catch(Exception ex)
            {
                IErrorMessage CustomEx = new ErrorMessage
                {
                    Message = ex.Message,
                    Location = "Consumer.cs"
                };

                ErrorHandler.Invoke(CustomEx);
                
                return false;
            }
        }

        private Delivery() { }
    }
}
