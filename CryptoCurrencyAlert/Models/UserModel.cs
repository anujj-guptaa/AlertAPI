﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyAlert.Models
{
    public class UserModel
    {
        public int UserModelID { get; set; }
        public string Username{ get; set; }
        public string EmailAddress { get; set; }
        public string password { get; set; }
    }
}
