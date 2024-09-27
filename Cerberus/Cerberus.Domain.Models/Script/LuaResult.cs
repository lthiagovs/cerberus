using Cerberus.Domain.Models.Static;

namespace Cerberus.Domain.Models.Script
{
    public class LuaResult
    {

        public int ID {  get; set; }

        public string Script {  get; set; }

        public string IP {  get; set; }

        public DateTime Time {  get; set; }

        public LuaResultType Type { get; set; }

        public string Json {  get; set; }

    }

}
