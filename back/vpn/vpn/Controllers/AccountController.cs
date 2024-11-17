using Microsoft.AspNetCore.Mvc;
using vpn.Models;
using vpn.Data.Data;



namespace vpn.Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VpnController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VpnController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("delete_profile/{vpn_id}")]
        public async Task<ActionResult<bool>> DeleteProfileAsync(int vpn_id)
        {
            var profile = await _context.VpnProfiles.FindAsync(vpn_id);
            if (profile == null)
            {
                return NotFound();
            }
            _context.Remove(profile);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPut("update_date/{vpn_id}/{months}")]
        public async Task<ActionResult<bool>> UpdateDateAsync(int vpn_id, int months)
        {
            var profile = await _context.VpnProfiles.FindAsync(vpn_id);
            if (profile == null)
            {
                return NotFound();
            }
            profile.ExpirationDate = DateTime.UtcNow.AddMonths(months);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpGet("get_vpn_string/{vpn_id}")]
        public string GetVpnStringAsync(int vpn_id)
        {
            var profile = _context.VpnProfiles.Find(vpn_id);
            if (profile == null)
            {
                throw new Exception("Профиль VPN не найден.");
            }
            return profile.VpnString;
        }

    }
}
