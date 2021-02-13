using ErrorHandling_PCL.Abstraction.Model;
using Model_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services_PCL.Abstraction
{
    public interface IDelivery
    {
        Func<IOrder, bool> GetOrderToShop { get; set; }
        Func<IProduct, bool> GetProductToCustomer { get; set; }
        Action<IErrorMessage> ErrorHandler { get; set; }

        bool GetOrderFromCustomer(string Name);
        bool GetOrderFromShop(IProduct NewProduct);
    }
}
