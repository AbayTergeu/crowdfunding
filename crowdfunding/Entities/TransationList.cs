namespace crowdfunding.Entities
{
    public class TransationList
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Dt { get; set; }
        public Decimal Kt { get; set; }
        public Decimal Saldo { get; set; }
    }
}
