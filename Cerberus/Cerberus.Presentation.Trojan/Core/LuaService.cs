using Cerberus.Presentation.Trojan.Exceptions;
using Cerberus.Presentation.Trojan.Interface;
using Cerberus.Presentation.Trojan.Observer;
using NLua;

namespace Cerberus.Presentation.Trojan.Core
{
    public class LuaService : ILuaService
    {

        public string Name { get; set;}

        private readonly Lua _lua;
        public LuaFunction _luaFunction { get; set; }
        private LuaObserver _luaObserver;
        private CancellationTokenSource? _ctsToken;
        private string? Result {  get; set; }

        private LuaService(Lua lua)
        {
            this.Name = "";
            this._lua = lua;
            Init();
        }

        private void Init()
        {

            this._lua.DoFile("scripts\\"+this.Name);
            this._luaFunction = this._lua.GetFunction(this.Name);

            if (this._luaFunction == null)
                throw new LuaNotFoundException();

            this._ctsToken = new CancellationTokenSource();
            this._luaObserver.LuaCompleted += this.Send;

        }

        public async void Start()
        {
            if (this._luaObserver != null)
            {

                string result = await this._luaObserver.ExecuteScript(() => Task.Run(() => this._luaFunction.Call()));

            }

        }

        public void Send(object sender, string result) 
        {

            Console.WriteLine("Sending: " + result);
        }

        public void Stop()
        {
            if (this._ctsToken!=null)
                this._ctsToken.Cancel();

        }

    }

}
