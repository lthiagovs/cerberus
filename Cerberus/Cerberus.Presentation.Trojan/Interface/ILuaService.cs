using NLua;

namespace Cerberus.Presentation.Trojan.Interface
{
    public interface ILuaService
    {

        public string Name { get; set; }
        public LuaFunction _luaFunction { get; set; }
        
        public void Start();

        public void Stop();

    }

}
