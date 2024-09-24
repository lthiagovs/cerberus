using Cerberus.API.Repository;
using Cerberus.Domain.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = this._userRepository.GetUsers();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);


        }

        [HttpGet("{ID}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByID(int ID)
        {

            var user = this._userRepository.GetUserByID(ID);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);

        }

        [HttpGet("{Name}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByName(string Name)
        {

            var user = this._userRepository.GetUserByName(Name);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);

        }

        [HttpGet("{Login}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByLogin(string Email, string Password)
        {
            var user = this._userRepository.GetUserByLogin(Email, Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);

        }

    }
}
