using SEDC.TimeTrackingApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.Interfaces
{
    public interface IUserService
    {
        void ChangePassword(long userId, string oldPassword, string newPassword);
        void ChangeInfo(long userId, string firstName, string lastName);
        User LogIn();
        User Register();
        void RemoveUser(long userId);
    }
}
