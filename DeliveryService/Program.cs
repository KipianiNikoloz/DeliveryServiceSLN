using ErrorHandling_PCL.Abstraction.Service;
using ErrorHandling_PCL.Implementation.Service;
using Model_PCL.Abstraction;
using Model_PCL.Enums;
using Model_PCL.Imlementation;
using Services_PCL.Abstraction;
using Services_PCL.Implementation;
using System;

namespace DeliveryService
{
    class Program
    {
        static void Main()
        {
            IConsumer ConsumerService = new Consumer();
            IDelivery DeliveryService = new Delivery();
            IShop ShopService = new Shop();

            IErrorService ErrorServices = new ErrorService();

            ConsumerService.GetOrderToDelivery = DeliveryService.GetOrderFromCustomer;
            DeliveryService.GetOrderToShop = ShopService.GetOrderFromDelivery;
            ShopService.GetProductToDelivery = DeliveryService.GetOrderFromShop;
            DeliveryService.GetProductToCustomer = ConsumerService.GetOrder;

            ConsumerService.ErrorHandler = ErrorServices.AddError;
            DeliveryService.ErrorHandler = ErrorServices.AddError;
            ShopService.ErrorHandler = ErrorServices.AddError;

            ShopService.Add("Sushi", 23);

            IUser NewUser = new User
            {
                FirstName = "Nikoloz",
                LastName = "Kipiani",
                Email = "nikolozkipiani2005@gmail.com",
                ID = "1",
                Gender = GenderType.Male,
                Balance = 30
            };

            ConsumerService.GetOrderToUser = NewUser.GetOrder;
            NewUser.MakeOrderToCustomer = ConsumerService.MakeOrder;
            NewUser.ErrorHandler = ErrorServices.AddError;

            bool test = NewUser.MakeOrderToCustomer("Sushi"); 

            Console.WriteLine("Test finished!");
        }
    }
}
