using Microsoft.Extensions.Configuration;

namespace SpecFlowSauceDemo_.NET.Drivers;

public class ReadProperties
{
   private static ReadProperties instance;
   protected static IConfiguration properties;
   
   private ReadProperties()
   {
      properties = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json")
         .Build();
   }

   public static ReadProperties GetInstance()
   {
      if (instance == null)
      {
         instance = new ReadProperties();
      }
      return instance;
   }

   public string GetUsername() { return properties["username"]; }
   public string GetPassword() { return properties["password"]; }
   public string GetBaseURL() { return properties["baseURL"]; }
   public string GetBrowserName() { return properties["browser"]; }
   public string GetBBaseApiUrl() { return properties["baseApiUrl"]; }
}
