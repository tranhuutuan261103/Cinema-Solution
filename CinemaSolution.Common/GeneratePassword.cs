using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CinemaSolution.Common
{
    public class GeneratePassword
    {
        private string _password;
        private string _salt;
        private string _passwordHash;

        public GeneratePassword(string password)
        {
            _password = password;
            _salt = GenerateSalt();
            _passwordHash = HashPassword();
        }

        private string GenerateSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            return Convert.ToBase64String(salt);
        }

        private string HashPassword()
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                   password: _password,
                                   salt: Convert.FromBase64String(_salt),
                                   prf: KeyDerivationPrf.HMACSHA256,
                                   iterationCount: 10000,
                                   numBytesRequested: 256 / 8));
            return hashed;
        }

        public string GetSalt()
        {
            return _salt;
        }

        public string GetPasswordHash()
        {
            return _passwordHash;
        }

        public bool VerifyPassword(string salt, string hashPassword)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: _password,
                            salt: Convert.FromBase64String(salt),
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8));
            return hashed == hashPassword;
        }
    }
}