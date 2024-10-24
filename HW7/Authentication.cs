

using System.Reflection.Metadata;

namespace HW7;

public class Authentication : IAuthentication
{
    public bool LogIn (string username, string password)
    {

        foreach (var admin in Storage.admins)
        {
            if (admin.AdminUserName == username && admin.AdminPassword == password)
            {
                Storage.CurrentAdmin = admin;
                return true;
            }
        }

        foreach (var user in Storage.users)
        {
            if (user.UserName == username && user.Password == password)
            {
                Storage.CurrentUser = user;
                return true;
            }
        }

        return false;

    }

    public bool Register (User newuser)
    {
        foreach (var user in Storage.users)
        {
            if (user.UserName == newuser.UserName || user.Email == newuser.Email)
            {
                return false;
            }
        }

        newuser.Id = Storage.UserCounter++;
        Storage.users.Add(newuser);
        return true;

    }

}
