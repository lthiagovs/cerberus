using Newtonsoft.Json;

namespace Cerberus.Presentation.Trojan.Observer
{
    public class LuaObserver
    {

        public event EventHandler<string>? LuaCompleted;

        public async Task<string> ExecuteScript(Func<Task<object[]>> luaTask)
        {

            object[] result = await luaTask();
            return OnLuaCompleted(result);
        }

        protected virtual string OnLuaCompleted(object[] result)
        {
            return JsonConvert.SerializeObject(result);
        }

    }

}
