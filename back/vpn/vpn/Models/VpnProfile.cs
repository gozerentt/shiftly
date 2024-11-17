
namespace vpn.Models
{
    public class VpnProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string VpnString { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        
    }
}


