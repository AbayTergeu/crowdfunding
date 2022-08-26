namespace crowdfunding.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? CodeIso { get; set; }

        public string? FlagImage { get; set; }
    }
}
