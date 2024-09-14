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
                LuaFunction test = lua["test"] as LuaFunction;
                // Recupera o resultado da execução do script Lua
                object[] result = test.Call();

                // Exibe o resultado
                Console.WriteLine("Resultado do Lua: " + result[0]);
            }
            catch (Exception ex)
            {
                // Exibe qualquer erro que possa ocorrer
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

    }
}