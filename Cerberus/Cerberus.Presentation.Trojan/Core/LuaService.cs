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
                this._luaTask.Start();
                object[] result = this._luaTask.Result;
                Send();
                if (this.LoopScript)
                {
                    Init();
                    Start();
                }
            }

        }

        public async Task StartAsync()
        {

            if (this._luaTask != null)
            {
                this._luaTask.Start();
                object[] result = await this._luaTask;
                Send();
                //Send(JsonConvert.SerializeObject(result));
                if (this.LoopScript)
                {
                    Init();
                    await StartAsync();
                }

            }

        }

        public void Send() 
        {
            
        }

        public void Stop()
        {
            if(this._luaToken != null)
                this._luaToken.Cancel();
        }

    }

}
