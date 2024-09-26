using Cerberus.Presentation.Trojan.Helper;
using NLua;
using System.Security;

namespace Cerberus.Presentation.Trojan.Core
{
    public class LuaScriptManager
    {

        public List<string> _scripts;
        private List<LuaService> _services;

        public LuaScriptManager()
        {
            this._scripts = new List<string>();
            this._services = new List<LuaService>();

        }

        public void LoadScripts()
        {

            this._scripts = LuaScriptHelper.GetAllScriptNames();

            foreach (string script in this._scripts)
                _services.Add(new LuaService(new Lua(), script, false));

        }

        public List<string> GetAllScripts()
        {

            List<string> names = new List<string>();

            foreach(LuaService service in this._services)
                names.Add(service.Name);

            return names;

        }

        private LuaService? GetScript(string scriptName)
        {
            return _services.FirstOrDefault(script => script.Name == scriptName);
        }

        public async Task<LuaService?> StartScriptAsync(string scriptName)
        {

            LuaService? luaService = GetScript(scriptName);

            if (luaService != null)
                await luaService.StartAsync();

            return luaService;
        }

        public LuaService? StartScript(string scriptName)
        {

            LuaService? luaService = GetScript(scriptName);

            if (luaService != null)
                luaService.Start();

            return luaService;
        }

        public LuaService? StopScript(string scriptName)
        {

            LuaService? luaService = GetScript(scriptName);

            if (luaService != null)
                luaService.Stop();

            return luaService;

        }

    }

}



