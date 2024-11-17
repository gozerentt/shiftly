using Microsoft.AspNetCore.Mvc;
using vpn.Models;
using vpn.Data.Data;
using Microsoft.EntityFrameworkCore;


namespace vpn.Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("get_username/{vpn_id}")]
        public async Task<ActionResult<string>> GetUsernameAsync(int vpn_id)
        {
            var profile = await _context.VpnProfiles.FindAsync(vpn_id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile.Username);
        }

        [HttpGet("get_vpn_list")]
        public async Task<ActionResult<List<VpnProfile>>> GetVpnListAsync()
        {
            var profiles = await _context.VpnProfiles.ToListAsync();
            return Ok(profiles);
        }

        [HttpGet("get_vpn_string/{vpn_id}")]
        public async Task<ActionResult<string>> GetVpnStringAsync(int vpn_id)
        {
            var profile = await _context.VpnProfiles.FindAsync(vpn_id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile.VpnString);
        }

    }
}