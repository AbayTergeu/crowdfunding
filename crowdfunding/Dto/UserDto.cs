using System.ComponentModel.DataAnnotations;

namespace crowdfunding.Dto
{
    public class UserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? InvestorId { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Mobile { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }        
        public bool? IsAcceptedContract { get; set; } = false;        
        public int? CountryId { get; set; }
    }
}
