
namespace HW7;

public interface IAuthentication
{
    public bool LogIn (string username , string password);
    public bool Register (User newuser);
}
