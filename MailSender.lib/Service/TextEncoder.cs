using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Service
{
    public static class TextEncoder
    {
        public static string Encode(string str, int key = 1)
        {
            return new string(str.Select(c => (char)(c + key)).ToArray());
        }

        public static string Decode(string str, int key = 1)
        {
            return new string(str.Select(c => (char)(c - key)).ToArray());
        }
    }
}
