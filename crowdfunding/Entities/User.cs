namespace crowdfunding.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InvestorId { get; set; }
        public string Email { get; set; }

        public string Mobile { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAcceptedContract { get; set; } = false;
        public int CountryId { get; set; }
    }
}
