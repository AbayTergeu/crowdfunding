using System.Security.Cryptography;
using System.Text;

namespace crowdfunding.Services
{
    public class PasswordService : IPasswordService
    {
        public string MakeHash(string value)
        {
            var hash = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
            return hash;
        }

        public bool CompareHash(string plainString, string hashString)
        {
            if (MakeHash(plainString) == hashString)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CryptPassword(string password)
        {
            return MakeHash(password);
        }
    }
}
