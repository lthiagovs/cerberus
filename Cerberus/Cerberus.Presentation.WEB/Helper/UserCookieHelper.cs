using Cerberus.Domain.Models.Person;
using Cerberus.Presentation.WEB.Inteface;
using Newtonsoft.Json;

namespace Cerberus.Presentation.WEB.Helper
{
    public class UserCookieHelper : IUserCookieHelper
    {

        private readonly IHttpContextAccessor _context;

        public UserCookieHelper(IHttpContextAccessor context)
        {
            this._context = context;
        }

        public void CreateUserCookie(User user)
        {

            if (this._context.HttpContext == null)
                throw new Exception("Something went wrong");

            var userJson = JsonConvert.SerializeObject(user);

            // Defina as opções do cookie
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7), // Defina a expiração do cookie (7 dias neste exemplo)
                HttpOnly = true, // Para evitar acesso ao cookie via JavaScript
                Secure = true, // Para usar apenas em conexões HTTPS
                SameSite = SameSiteMode.Strict // Para segurança adicional
            };

            this._context.HttpContext.Response.Cookies.Append("UserCookie", userJson, cookieOptions);
        }

        public User? GetUserCookie()
        {
            throw new NotImplementedException();
        }

        public void RemoveUserCookie()
        {
            throw new NotImplementedException();
        }
    }

}
