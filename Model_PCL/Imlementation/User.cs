using ErrorHandling_PCL.Abstraction.Model;
using ErrorHandling_PCL.Implementation.Model;
using Model_PCL.Abstraction;
using Model_PCL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_PCL.Imlementation
{
    public class User : IUser
    {
        private List<IProduct> ProductList = new List<IProduct>();

        public Func<string, bool> MakeOrderToCustomer { get; set; }
        public Action<IErrorMessage> ErrorHandler { get; set; }

        public string FirstName;
        public string LastName;

        public string Email { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public double Balance { get; set; }
        public string FullName { 
            set 
            {
                value = FirstName + LastName; 
            } 
        }

        public bool GetOrder(IProduct NewProduct)
        {
            try
            {
                if(NewProduct.Price <= Balance)
                {
                    ProductList.Add(NewProduct);

                    return true;
                }

                return false;
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
