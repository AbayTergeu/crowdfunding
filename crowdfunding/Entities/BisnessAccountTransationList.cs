namespace crowdfunding.Entities
{
    public class BisnessAccountTransationList
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }  = DateTime.Now;
        public Decimal? Dt { get; set; }
        public Decimal? Kt { get; set; }
        public Decimal? Saldo { get; set; }
    }
}
