using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly DataContext _context;

        public PlayerController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<Player>>> Get()
        {
            return Ok(await _context.Players.ToListAsync());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
                return BadRequest("Player not found.");
            return Ok(player);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<List<Player>>> AddPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return Ok(await _context.Players.ToListAsync());
        }


        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<List<Player>>> UpdatePlayer(Player request)
        {
            var dbPlayer = await _context.Players.FindAsync(request.Id);
            if (dbPlayer == null)
                return BadRequest("Player Not Found.");

            dbPlayer.Id = request.Id;
            dbPlayer.FirstName = request.FirstName;
            dbPlayer.LastName = request.LastName;
            dbPlayer.Club = request.Club;
            dbPlayer.Position = request.Position;
            dbPlayer.DateOfBirth = request.DateOfBirth;
            dbPlayer.LastModified = request.LastModified;

            await _context.SaveChangesAsync();

            return Ok(await _context.Players.ToListAsync());
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Player>> Delete(int id)
        {
            var dbPlayer = await _context.Players.FindAsync(id);
            if (dbPlayer == null)
                return BadRequest("Player not found.");

            _context.Players.Remove(dbPlayer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Players.ToListAsync());
        }
    }
}
