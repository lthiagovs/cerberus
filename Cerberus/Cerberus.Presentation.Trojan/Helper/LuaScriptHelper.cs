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

    }
}
