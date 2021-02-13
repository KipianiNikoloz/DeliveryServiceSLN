using ErrorHandling_PCL.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Abstraction
{
    public interface IUser : IHuman
    {
        Func<string, bool> MakeOrderToCustomer { get; set; }
        Action<IErrorMessage> ErrorHandler { get; set; }

        string Email { get; set; }
        string ID { get; set; }
        double Balance { get; set; }

        bool GetOrder(IProduct NewProduct);
    }
}
