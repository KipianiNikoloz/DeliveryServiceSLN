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
            ILoginService LoginServices = new LoginService();

            IErrorService ErrorServices = new ErrorService();

            ConsumerService.GetOrderToDelivery = DeliveryService.GetOrderFromCustomer;
            DeliveryService.GetOrderToShop = ShopService.GetOrderFromDelivery;
            ShopService.GetProductToDelivery = DeliveryService.GetOrderFromShop;
            DeliveryService.GetProductToCustomer = ConsumerService.GetOrder;

            ConsumerService.ErrorHandler = ErrorServices.AddError;
            DeliveryService.ErrorHandler = ErrorServices.AddError;
            ShopService.ErrorHandler = ErrorServices.AddError;

            ShopService.Add("Sushi", 23);
            LoginServices.Add("Nikoloz Kipiani", "nikolozkipiani2005@gmail.com", "1", "123456789", 15, GenderType.Male, 30);

            IUser CurrentUser = LoginServices.LoginUserIntoSession("nikolozkipiani2005@gmail.com", "123456789");

            ConsumerService.GetOrderToUser = CurrentUser.GetOrder;
            CurrentUser.MakeOrderToCustomer = ConsumerService.MakeOrder;
            CurrentUser.ErrorHandler = ErrorServices.AddError;

            bool test = CurrentUser.MakeOrderToCustomer("Sushi"); 

            Console.WriteLine("Test finished!");
        }
    }
}
