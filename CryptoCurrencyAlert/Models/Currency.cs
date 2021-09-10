using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrencyAlert.Models
{
    public class Currency
    {
        public int CurrencyID { get; set; }
        public string name { get; set; }
        public string current_price { get; set; }
    }
}
