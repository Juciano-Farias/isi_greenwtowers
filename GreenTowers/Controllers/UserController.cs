using GreenTowers.Data;
using GreenTowers.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserReadDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                    Floor = u.Floor,
                    Birth = u.Birth,
                    Role = u.Role
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null || (user.Id != id && !User.IsInRole("Admin")))
            {
                return NotFound();
            }

            return new UserReadDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Floor = user.Floor,
                Birth = user.Birth,
                Role = user.Role
            };
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDto userUpdateDto)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);

            user.Email = userUpdateDto.Email;
            user.Name = userUpdateDto.Name;
            user.Floor = userUpdateDto.Floor;
            user.Birth = userUpdateDto.Birth.ToUniversalTime();
            user.Role = userUpdateDto.Role;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(userUpdateDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário excluído com sucesso.");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Floor { get; set; }
        public DateTime Birth { get; set; }
        public Role Role { get; set; }
    }

    public class UserCreateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        [Required]
        public Role Role { get; set; }

    }
    public class UserUpdateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }
        public string Floor { get; set; }
        public DateTime Birth { get; set; }
        public Role Role { get; set; }
    }
}
