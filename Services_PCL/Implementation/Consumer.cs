﻿using ErrorHandling_PCL.Abstraction.Model;
using ErrorHandling_PCL.Implementation.Model;
using Model_PCL.Abstraction;
using Services_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services_PCL.Implementation
{
    public class Consumer : IConsumer
    {
        public Func<string, bool> GetOrderToDelivery { get; set; }
        public Func<IProduct, bool> GetOrderToUser { get; set; }
        public Action<IErrorMessage> ErrorHandler { get; set; }

        private static object _Root = new object();
        private static IConsumer _Instance = new Consumer();

        public static IConsumer GetInstance
        {
            get
            {
                lock (_Root)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Consumer();
                    }

                    return _Instance;
                }
            }
        }

        public bool GetOrder(IProduct NewProduct)
        {
            try
            {
                GetOrderToUser.Invoke(NewProduct);

                return true;
            }
            catch (Exception ex)
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

        public bool MakeOrder(string Name)
        {
            try
            {
                GetOrderToDelivery.Invoke(Name);

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
    }
}
