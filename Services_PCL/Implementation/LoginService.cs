using ErrorHandling_PCL.Abstraction.Model;
using ErrorHandling_PCL.Implementation.Model;
using Model_PCL.Abstraction;
using Model_PCL.Enums;
using Model_PCL.Imlementation;
using Services_PCL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services_PCL.Implementation
{
    public class LoginService : ILoginService
    {
        private List<IUser> UserList = new List<IUser>();
        public Action<IErrorMessage> ErrorHandler { get; set; }

        private static object _Root = new object();
        private static ILoginService _Instance = null;

        public static ILoginService GetInstance
        {
            get
            {
                lock (_Root)
                {
                    if(_Instance == null)
                    {
                        _Instance = new LoginService();
                    }

                    return _Instance;
                }
            }
        }

        public bool Add(string FullName, string Email, string ID, string Password, int Age, GenderType Gender, double Balance)
        {
            try
            {
                var Tmp = Create(FullName, Email, ID, Password, Age, Gender, Balance);

                UserList.Add(Tmp);

                return UserList.Any(o => o.FullName == FullName);
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

        public IUser Create(string FullName, string Email, string ID, string Password, int Age, GenderType Gender, double Balance)
        {
            try
            {
                return new User { FullName = FullName, Email = Email, ID = ID, Password = Password, Age = Age, Gender = Gender, Balance = Balance }; ;

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

        public IUser LoginUserIntoSession(string Email, string Password)
        {
            try
            {
                return UserList.Find(o => o.Email == Email && o.Password == Password);
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
                foreach (var item in UserList)
                {
                    Console.WriteLine($"{item.FullName} {item.Email} {item.ID} {item.Balance}");
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

        public bool Remove(string FullName)
        {
            try
            {
                UserList.Remove(Search(FullName));

                return !UserList.Any(o => o.FullName == FullName);
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

        public IUser Search(string FullName)
        {
            try
            {
                return UserList.FirstOrDefault(o => o.FullName.ToLower() == FullName.ToLower());

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

        public bool Update(string SearchName, string FullName = null, string Email = null, string ID = null, string Password = null, int Age = 0, GenderType Gender = GenderType.Default, double Balance = 0)
        {
            try
            {
                var Tmp = Search(SearchName);

                Tmp.FullName = FullName != null ? Tmp.FullName = FullName : Tmp.FullName = Tmp.FullName;
                Tmp.Email = Email != null ? Tmp.Email = Email : Tmp.Email = Tmp.Email;
                Tmp.ID = ID != null ? Tmp.ID = ID : Tmp.ID = Tmp.ID;
                Tmp.Password = Password != null ? Tmp.Password = Password : Tmp.Password = Tmp.Password;
                Tmp.Age = Age != 0 ? Tmp.Age = Age : Tmp.Age = Tmp.Age;
                Tmp.Gender = Gender != GenderType.Default ? Tmp.Gender = Gender : Tmp.Gender = Tmp.Gender;
                Tmp.Balance = Balance != 0 ? Tmp.Balance = Balance : Tmp.Balance = Tmp.Balance;

                return UserList.Any(o => o == Tmp);
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

        private LoginService() { }
    }
}
