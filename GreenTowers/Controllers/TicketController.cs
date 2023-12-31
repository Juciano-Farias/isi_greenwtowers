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
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Ticket
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return Ok(await _context.Tickets.ToListAsync());
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        [HttpGet("my")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetUserTickets()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var tickets = await _context.Tickets
                                        .Where(t => t.UserId == userId)
                                        .ToListAsync();

            return Ok(tickets);
        }


        // POST: api/Ticket
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<Ticket>> PostTicket(TicketCreateDto ticketDto)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var ticket = new Ticket
            {
                Name = ticketDto.Name,
                Description = ticketDto.Description,
                UserId = userId
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            // Retorna o ticket criado com o status HTTP 201 (Created)
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutTicket(int id, TicketUpdateDto TicketUpdateDto)
        {
            if (!TicketExists(id))
            {
                return BadRequest();
            }

            try
            {
                var ticket = await _context.Tickets.FindAsync(id);

                ticket.Name = TicketUpdateDto.Name;
                ticket.Description = TicketUpdateDto.Description;
                ticket.Reply = TicketUpdateDto.Reply;
                ticket.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(TicketUpdateDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // DELETE: api/Ticket/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return Ok("Ticket removido com sucesso.");
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
    public class TicketCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
    public class TicketUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string Reply { get; set; }
    }
}

