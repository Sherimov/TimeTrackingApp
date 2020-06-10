using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Abs_Int.Logic.Interfaces
{
    public interface IUser
    {
        int Id  { get; set; }

        string Name { get; set; }

        string UserName { get; set; }

        int Password { get; set; }

        void PrintUser();
    }
}
