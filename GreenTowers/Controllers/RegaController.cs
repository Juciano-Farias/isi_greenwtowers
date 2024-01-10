using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Authorize(Roles = "Rec")]
    public class RegaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public RegaController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rega>>> GetAllRegas()
        {
            return await _context.Regas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rega>> GetRegaById(int id)
        {
            var rega = await _context.Regas.FindAsync(id);

            if (rega == null)
            {
                return NotFound();
            }

            return rega;
        }

        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<IndividualWarning>>> GetRegaByToken()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var rega = await _context.Regas
                                        .Where(t => t.UserId == userId)
                                        .ToListAsync();

            return Ok(rega);
        }

        [HttpPost]
        public async Task<ActionResult<Rega>> PostRega(RegaCreateDto regaDto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);
            var rega = new Rega
            {
                InitialDate = DateTime.UtcNow,
                UserId = userId,
                Temperature = regaDto.Temperature,
            };

            _context.Regas.Add(rega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRega", new { id = rega.Id }, rega);
        }

        public class RegaCreateDto
        {
            [StringLength(100)]
            public string? Temperature { get; set; }
        }
    }
}