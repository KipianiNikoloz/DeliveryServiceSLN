using ErrorHandling_PCL.Abstraction.Model;
using Model_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services_PCL.Abstraction
{
    public interface IShop
    {
        Func<IProduct, bool> GetProductToDelivery { get; set; }
        Action<IErrorMessage> ErrorHandler { get; set; }

        bool GetOrderFromDelivery(IOrder NewOrder);

        IProduct Search(string Name);
        IProduct Create(string Name, double Price);
        bool Add(string Name, double Price);
        bool Read();
        bool Update(string SearchName, string Name, double Price);
        bool Remove(string Name);
    }
}
