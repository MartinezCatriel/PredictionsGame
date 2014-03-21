using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class FacebookInformation
    {
        public static string GetEmailByTokenAuth(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new FacebookException();

            return token + "@" + token + ".com";
        }
    }

    public class FacebookException : Exception
    {
    }
}
