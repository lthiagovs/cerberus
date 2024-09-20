using Cerberus.Presentation.Trojan.Core;
using Cerberus.Presentation.Trojan.Helper;
using NLua;
using System.Runtime.InteropServices;

public class Program
{

    [DllImport("Cerberus.Malicious.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int testMan();

    private static void Main(string[] args)
    {
        #region
        //using (Lua lua = new Lua())
        //{
        //    try
        //    {
        //        // Executa o script Lua
        //        lua.DoFile("scripts\\keylogger.lua");
        //        LuaFunction keylogger = lua["Keylogger"] as LuaFunction;
        //        // Recupera o resultado da execução do script Lua
        //        object[] result = keylogger.Call();

        //        LuaTable resultTable = result[0] as LuaTable;

        //        foreach(var key in resultTable.Values)
        //        {
        //            Console.WriteLine(key);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // Exibe qualquer erro que possa ocorrer
        //        Console.WriteLine("Erro: " + ex.Message);
        //    }
        //}
        #endregion

        foreach(string a in LuaScriptHelper.GetAllScripts())
        {

            Console.WriteLine(a);
        }

        using (Lua lua = new Lua()) {

            //LuaService lService = new LuaService(lua, "luaok", true);

            //_ = lService.StartAsync();

            while (true)
            {

                if (Console.ReadLine() == "end")
                {
                    //lService.Stop();
                    break;
                }

            }

        }

    }
}