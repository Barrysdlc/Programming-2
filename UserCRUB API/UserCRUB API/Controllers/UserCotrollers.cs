using Microsoft.AspNetCore.Mvc;
using AppUsersAPI.DTOs;
using AppUsersAPI.Domain.Entities;
using AppUsersAPI.Domain.Repository;

namespace SystemAdminAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _db;

        public UsersController(IUserRepository context)
        {
            _db = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users = await _db.GetUsers();
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var user = await _db.GetUser(id); 

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        
        [HttpPost]
        public async Task<ActionResult<UsersDTOs>> CreateUser([FromBody] UsersDTOs userDTO)
        {
            var user = new Users
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Phone = userDTO.Phone,
                Address = userDTO.Address
            };

            await _db.AddUser(user);

            var response = new UsersDTOs
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Address = user.Address
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, response);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UsersDTOs userDTO)
        {
            var existingUser = await _db.GetUser(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = userDTO.Name;
            existingUser.Email = userDTO.Email;
            existingUser.Password = userDTO.Password;
            existingUser.Phone = userDTO.Phone;
            existingUser.Address = userDTO.Address;

            await _db.UpdateUser(existingUser, id);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _db.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            await _db.DeleteUser(id);

            return NoContent();
        }
    }
}