namespace Cerberus.Presentation.Trojan.Helper
{
    public static class LuaScriptHelper
    {

        public static ICollection<string> GetAllScripts()
        {
            ICollection<string> scripts = new List<string>();

            if (Directory.Exists("scripts"))
            {

                scripts = Directory.GetFiles("scripts", "*.lua");

            }

            return scripts;
        }

        public static List<string> GetAllScriptNames()
        {

            List<string> scripts = LuaScriptHelper.GetAllScripts().ToList();

            for (int i = 0; i < scripts.Count; i++)
            {

                scripts[i] = scripts[i].Replace(".lua", "").Replace("scripts\\", "");

            }

            return scripts;
        }
    }
    
}
