using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyAlert.Models
{
    public class AlertData
    {
        public int AlertDataID { get; set; }

        public string Email { get; set; }
        public string currency { get; set; }
        public string alert_price { get; set; }
    }
}
