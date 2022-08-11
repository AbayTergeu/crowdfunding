namespace crowdfunding.Services
{
    public interface IPasswordService
    {
        string MakeHash(string value);
        bool CompareHash(string plainString, string hashString);
        string CryptPassword(string password);
    }
}
