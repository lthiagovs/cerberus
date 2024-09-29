using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("GetUsers")]
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

        [HttpGet("GetUserByID")]
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

        [HttpGet("GetUserByName")]
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

        [HttpGet("GetUserByLogin")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByLogin([FromQuery]string Email, [FromQuery] string Password)
        {
            var user = this._userRepository.GetUserByLogin(Email, Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);

        }

        [HttpPost("CreateUser")]
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



        [HttpPut("UpdateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(int ID, [FromBody]User user)
        {

            if (user == null)
                return BadRequest(ModelState);

            if (ID != user.ID)
                return BadRequest(ModelState);

            if(!this._userRepository.UserExist(ID))
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

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteUser(int ID)
        {

            var user = this._userRepository.GetUserByID(ID);

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (this._userRepository.DeleteUser(user))
                ModelState.AddModelError("", "Something went wrong deleting user.");

            return NoContent();

        }

    }
}
