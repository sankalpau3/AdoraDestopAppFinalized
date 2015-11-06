using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class Encryption
    {
        /*public method used to encrypt passwords*/
        public string encryptPassword(string input)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(input); //passing input to a bite code
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data); //compute hash of the bite code
            String hash = System.Text.Encoding.ASCII.GetString(data); //encrypt byte code

            return hash; //return encrypted string
        }

    }
}
