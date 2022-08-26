namespace crowdfunding.Entities
{
    public class Investments
    {
        public int Id { get; set; }
        public string InvestmentNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysCountry { get; set; }
        public Decimal InvestmentAmount { get; set; }
        public string Currency { get; set; }

        public string CountryAvatar { get; set; }
        public string CountryCode { get; set; }
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public Decimal InterestRate { get; set; }
    }
}
