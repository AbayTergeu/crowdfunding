namespace crowdfunding.Helpers.Auth
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int JwtLifespan { get; set; }
    }
}
