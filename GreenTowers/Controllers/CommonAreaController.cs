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
    public class CommonAreaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CommonAreaController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CommonArea>>> GetCommonAreas()
        {
            return Ok(await _context.CommonAreas.ToListAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CommonArea>> GetCommonArea(int id)
        {
            var area = await _context.CommonAreas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CommonArea>> PostCommonArea(CommonAreaCreateDto areaDto)
        {
            var area = new CommonArea
            {
                Name = areaDto.Name
            };

            _context.CommonAreas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCommonArea), new { id = area.Id }, area);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCommonArea(int id, CommonAreaUpdateDto areaDto)
        {
            var area = await _context.CommonAreas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            area.Name = areaDto.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommonAreaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(areaDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCommonArea(int id)
        {
            var area = await _context.CommonAreas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.CommonAreas.Remove(area);
            await _context.SaveChangesAsync();

            return Ok("Removido com sucesso");
        }

        private bool CommonAreaExists(int id) =>
            _context.CommonAreas.Any(e => e.Id == id);
    }
    public class CommonAreaCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
    public class CommonAreaUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}