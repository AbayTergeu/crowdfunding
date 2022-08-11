namespace crowdfunding.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
