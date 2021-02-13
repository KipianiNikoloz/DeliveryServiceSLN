using ErrorHandling_PCL.Abstraction.Model;
using Model_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services_PCL.Abstraction
{
    public interface IConsumer
    {
        Func<string, bool> GetOrderToDelivery { get; set; }
        Action<IErrorMessage> ErrorHandler { get; set; }
        Func<IProduct, bool> GetOrderToUser { get; set; }

        bool MakeOrder(string Name);
        bool GetOrder(IProduct NewProduct);
    }
}
