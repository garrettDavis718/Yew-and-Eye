using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PlansLib
{
    /// <summary>
    /// class for security operations.
    /// </summary>
    public static class SecurityOps
    {
        /// <summary>
        /// hash string using SHA256 algorithm.
        /// </summary>
        /// <param name="text">text to be hashed.</param>
        /// <param name="salt">random string of text, provides added security.</param>
        /// <returns>hash of text.</returns>
		public static string HashString(string text, string salt = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            using (SHA256Managed sha = new SHA256Managed())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", string.Empty);
                return hash;
            }
        }

        /// <summary>
        /// check hashes for equality.
        /// </summary>
        /// <param name="actualHash">first hash to be compared.</param>
        /// <param name="expectedHash">second hash to be compared.</param>
        /// <returns>true if hashes are equal, false otherwise.</returns>
        public static bool VerifyHash(string actualHash, string expectedHash)
        {
            return Equals(actualHash, expectedHash);
        }
    }
}
