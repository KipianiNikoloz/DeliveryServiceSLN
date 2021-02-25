using ErrorHandling_PCL.Abstraction.Model;
using ErrorHandling_PCL.Implementation.Model;
using Model_PCL.Abstraction;
using Model_PCL.Imlementation;
using Services_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services_PCL.Implementation
{
    public class Shop : IShop
    {
        private List<IProduct> ProductList = new List<IProduct>();

        public Func<IProduct, bool> GetProductToDelivery { get; set; }
        public Action<IErrorMessage> ErrorHandler { get; set; }

        private static object _Root = new object();
        private static IShop _Instance = new Shop();

        public static IShop GetInstance
        {
            get
            {
                lock (_Root)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Shop();
                    }

                    return _Instance;
                }
            }
        }

        public bool GetOrderFromDelivery(IOrder NewOrder)
        {
            try
            {
                string tmpStr = NewOrder.Name;

                var Tmp = Search(tmpStr);
                Remove(tmpStr);
                GetProductToDelivery.Invoke(Tmp);
                
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

        public bool Add(string Name, double Price)
        {
            try
            {
                var Tmp = Create(Name, Price);

                ProductList.Add(Tmp);

                return ProductList.Any(o => o.Name == Name);
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

        public IProduct Create(string Name, double Price)
        {

            try
            {
                return new Product { Name = Name, Price = Price}; ;

            }
            catch (Exception ex)
            {
                IErrorMessage CustomEx = new ErrorMessage
                {
                    Message = ex.Message,
                    Location = "Consumer.cs"
                };

                ErrorHandler.Invoke(CustomEx);

                return default;
            }
        }


        public bool Read()
        {
            try
            {
                foreach(var item in ProductList)
                {
                    Console.WriteLine($"{item.Name} {item.Price}");
                }

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

        public bool Remove(string Name)
        {
            try
            {
                ProductList.Remove(Search(Name));

                return !ProductList.Any(o => o.Name == Name);
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

        public IProduct Search(string Name)
        {
            try
            {
                return ProductList.FirstOrDefault(o => o.Name.ToLower() == Name.ToLower());

            }
            catch (Exception ex)
            {
                IErrorMessage CustomEx = new ErrorMessage
                {
                    Message = ex.Message,
                    Location = "Consumer.cs"
                };

                ErrorHandler.Invoke(CustomEx);

                return default;
            }
        }

        public bool Update(string SearchName, string Name, double Price = 0)
        {
            try
            {
                var Tmp = Search(SearchName);

                Tmp.Name = Name != null ? Tmp.Name = Name : Tmp.Name = Tmp.Name;
                Tmp.Price = Price != 0 ? Tmp.Price = Price : Tmp.Price = Tmp.Price;

                bool Check = ProductList.Any(o => o == Tmp);

                return Check;
            }
            catch (Exception ex)
            {
                IErrorMessage CustomEx = new ErrorMessage
                {
                    Message = ex.Message,
                    Location = "Consumer.cs"
                };

                ErrorHandler.Invoke(CustomEx);

                return default;
            }
        }

        private Shop() { }
    }
}
