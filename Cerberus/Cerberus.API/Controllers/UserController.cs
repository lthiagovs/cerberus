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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User user)
        {

            if (user == null)
                return BadRequest(ModelState);

            var userVerify = this._userRepository.GetUsers().Where(usr => usr.Email == user.Email).FirstOrDefault();

            if(userVerify != null)
            {
                ModelState.AddModelError("", "a user with this email already exist.");
                return StatusCode(402, ModelState);
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this._userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");

        }



        [HttpPut("{userID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(int userID, [FromBody]User user)
        {

            if (user == null)
                return BadRequest(ModelState);

            if (userID != user.Id)
                return BadRequest(ModelState);

            if(!this._userRepository.UserExist(userID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while updating user");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}
