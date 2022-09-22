namespace PlaywrightSpecFlow.NET_SauceDemo.Interfaces;

public interface ErrorMessages_LoginPage
{
    public static string  invalidCredentialsErrorMessage =
        "Epic sadface: Username and password do not match any user in this service";
   
    public static string  emptyUsernameErrorMessage =
        "Epic sadface: Username is required"; 
    
    public static string  emptyPasswordErrorMessage =
        "Epic sadface: Password is required";
}