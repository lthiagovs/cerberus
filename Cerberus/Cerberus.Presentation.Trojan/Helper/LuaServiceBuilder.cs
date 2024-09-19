using Cerberus.Presentation.Trojan.Exceptions;
using Cerberus.Presentation.Trojan.Interface;

namespace Cerberus.Presentation.Trojan.Helper
{
    public static class LuaServiceBuilder
    {

        private static bool StartService(ILuaService service)
        {
            if (service.Start())
            {
                return true;
            }

            throw new LuaNotFoundException();

        }

    }

}
