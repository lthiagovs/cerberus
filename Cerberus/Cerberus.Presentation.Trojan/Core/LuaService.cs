using Cerberus.Presentation.Trojan.Interface;

namespace Cerberus.Presentation.Trojan.Core
{
    public class LuaService : ILuaService
    {
        public string Name { get; set;}

        public bool Get()
        {
            return false;
        }

        public bool Start()
        {
            return false;
        }

        public bool Stop()
        {
            return false;
        }

        private LuaService()
        {
            Name = "";
        }

    }

}
