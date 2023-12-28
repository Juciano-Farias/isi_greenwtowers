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
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserReadDto
                {
                    Id = u.Id,
                    Email = u.Email
                    // Mapear outros campos conforme necessário
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")] // Permite que qualquer usuário autenticado possa acessar este método
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
                Email = user.Email
                // Mapear outros campos conforme necessário
            };
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDto userUpdateDto)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            user.Email = userUpdateDto.Email;
            // Atualizar outros campos conforme necessário

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        // Incluir outros campos conforme necessário, excluindo a senha
    }

    public class UserCreateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        // Incluir outros campos conforme necessário
    }
    public class UserUpdateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Não inclua a senha aqui se você quiser que ela seja atualizada em um processo separado
        // Incluir outros campos conforme necessário
    }
}
