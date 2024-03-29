﻿namespace crowdfunding.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int? ClientId { get; set; }
        public string CurrencyCode   { get; set; }
        public DateTime? DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; }
        public Decimal Saldo { get; set; }
    }
}
