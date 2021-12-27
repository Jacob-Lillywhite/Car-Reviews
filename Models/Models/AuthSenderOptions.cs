using System;
using System.Collections.Generic;
using System.Text;

namespace CarCollection.Models
{
    public class AuthSenderOptions
    {
        private string user = "Jacob Lillywhite"; // The name you want to show up on your email
                                          // Make sure the string passed in below matches your API Key
        private string key = "";
        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }

}
