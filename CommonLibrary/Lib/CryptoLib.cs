using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Digests;

namespace CommonLibrary.Lib
{
    public class CryptoLib
    {
        public static string Hash(string text)
        {
            var h26 = new Dstu7564Digest(256);
            h26.BlockUpdate(System.Text.Encoding.UTF8.GetBytes(text), 0, text.Length);
            var hash26 = new byte[h26.GetDigestSize()];
            h26.DoFinal(hash26, 0);
            return Convert.ToHexString(hash26);
        }
    }
}