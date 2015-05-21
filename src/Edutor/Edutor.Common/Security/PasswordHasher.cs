using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Common.Security
{
    public static class PasswordHasher
    {
        public static string HashAndSaltPassword(string password)
        {

            System.Security.Cryptography.SHA256 sha = System.Security.Cryptography.SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString().ToUpper();

        }
    }
}
