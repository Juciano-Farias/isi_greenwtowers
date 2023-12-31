using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GreenTowers.Data;
using GreenTowers.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenTowers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalWarningController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public GlobalWarningController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GlobalWarning>>> GetGlobalWarnings()
        {
            return Ok(await _context.GlobalWarnigns.ToListAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GlobalWarning>> GetGlobalWarning(int id)
        {
            var warning = await _context.GlobalWarnigns.FindAsync(id);

            if (warning == null)
            {
                return NotFound();
            }

            return warning;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GlobalWarning>> PostGlobalWarning(GlobalWarningCreateDto warningDto)
        {
            var warning = new GlobalWarning
            {
                Title = warningDto.Title,
                Description = warningDto.Description
            };

            _context.GlobalWarnigns.Add(warning);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGlobalWarning), new { id = warning.Id }, warning);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutGlobalWarning(int id, GlobalWarningUpdateDto warningDto)
        {
            var warning = await _context.GlobalWarnigns.FindAsync(id);

            if (warning == null)
            {
                return NotFound();
            }

            warning.Title = warningDto.Title;
            warning.Description = warningDto.Description;
            warning.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Alterações confirmadas");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlobalWarningExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGlobalWarning(int id)
        {
            var warning = await _context.GlobalWarnigns.FindAsync(id);
            if (warning == null)
            {
                return NotFound("Não encontrado");
            }

            _context.GlobalWarnigns.Remove(warning);
            await _context.SaveChangesAsync();

            return Ok("Aviso global excluído com sucesso");
        }


        private bool GlobalWarningExists(int id) => _context.GlobalWarnigns.Any(e => e.Id == id);

    }

    public class GlobalWarningCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
    }

    public class GlobalWarningUpdateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
    }
}