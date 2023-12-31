using GreenTowers.Data;
using GreenTowers.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GreenTowers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualWarningController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IndividualWarningController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IndividualWarning
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<IndividualWarning>>> GetIndividualWarnigns()
        {
            return await _context.IndividualWarnigns.ToListAsync();
        }

        // GET: api/IndividualWarning/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IndividualWarning>> GetIndividualWarning(int id)
        {
            var warning = await _context.IndividualWarnigns.FindAsync(id);

            if (warning == null)
            {
                return NotFound();
            }

            return warning;
        }

        [HttpGet("my")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<IndividualWarning>>> GetUserIndividualWarnings()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var individualWarnings = await _context.IndividualWarnigns
                                        .Where(t => t.UserId == userId)
                                        .ToListAsync();

            return Ok(individualWarnings);
        }


        // POST: api/IndividualWarning
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IndividualWarning>> PostIndividualWarning(IndividualWarningCreateDto warningDto)
        {
            var warning = new IndividualWarning
            {
                Title = warningDto.Title,
                Description = warningDto.Description,
                UserId = warningDto.UserId
            };

            _context.IndividualWarnigns.Add(warning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndividualWarning", new { id = warning.Id }, warning);
        }

        // PUT: api/IndividualWarning/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutIndividualWarning(int id, IndividualWarningUpdateDto warningDto)
        {
            var warning = await _context.IndividualWarnigns.FindAsync(id);
            if (warning == null)
            {
                return NotFound();
            }

            warning.Title = warningDto.Title;
            warning.Description = warningDto.Description;
            warning.UpdatedAt = DateTime.UtcNow;

            _context.Entry(warning).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualWarningExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(warning);
        }

        // DELETE: api/IndividualWarning/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIndividualWarning(int id)
        {
            var warning = await _context.IndividualWarnigns.FindAsync(id);
            if (warning == null)
            {
                return NotFound("Falha ao excluir");
            }

            _context.IndividualWarnigns.Remove(warning);
            await _context.SaveChangesAsync();

            return Ok("Removido com sucesso");
        }

        private bool IndividualWarningExists(int id) => _context.IndividualWarnigns.Any(e => e.Id == id);
    }

    public class IndividualWarningCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }

    public class IndividualWarningUpdateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }

        // Normalmente, UserId não é incluído no DTO de atualização,
        // a menos que a atualização permita mudar o usuário associado ao aviso.
    }
}
