using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Fault_Logger
{
    class encryptPassword//password hashing class
    {
        public String sha256_hash(String value) //hashing function written using LINQ
        {
            using (SHA256 hash = SHA256Managed.Create())//use SHA 256 algorithm
            {
                return String.Join("", hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        } 
    }
}
