using Cerberus.Presentation.Trojan.Core;

public class Program
{

    //[DllImport("Cerberus.Malicious.dll", CallingConvention = CallingConvention.Cdecl)]
    //public static extern int testMan();

    private static void Main(string[] args)
    {

        LuaScriptManager _scriptManager = new LuaScriptManager();

        _scriptManager.LoadScripts();

    }
}