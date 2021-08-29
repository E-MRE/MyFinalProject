using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = GetCustomSaltKey(hmac.Key);
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(GetCustomSaltKey(passwordSalt)))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        private static byte[] GetCustomSaltKey(byte[] passwordSalt)
        {
            var firstSalt = Encoding.UTF8.GetBytes("EMRE");
            var lastSalt = Encoding.UTF8.GetBytes("GLTKR");

            List<byte> saltList = new List<byte>();
            saltList.AddRange(firstSalt);
            saltList.AddRange(passwordSalt);
            saltList.AddRange(lastSalt);

            return saltList.ToArray();
        }
    }
}
