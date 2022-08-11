using System.ComponentModel.DataAnnotations;

namespace crowdfunding.Dto
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string InvestorId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }        
        public bool IsAcceptedContract { get; set; } = false;
        [Required]
        public int CountryId { get; set; }
    }
}
