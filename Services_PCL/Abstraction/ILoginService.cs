using Model_PCL.Abstraction;
using Model_PCL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services_PCL.Abstraction
{
    public interface ILoginService
    {
        IUser LoginUserIntoSession(string Email, string Password);
        IUser Search(string Name);
        IUser Create(string FullName, string Email, string ID, string Password, int Age, GenderType Gender, double Balance);
        bool Add(string FullName, string Email, string ID, string Password, int Age, GenderType Gender, double Balance);
        bool Read();
        bool Update(string SearchName, string FullName, string Email, string ID, string Password, int Age, GenderType Gender, double Balance);
        bool Remove(string FullName);
    }
}
