using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coinmarketcap.Entities
{
    public class PriceConversion
    {
        public class Data
        {
            public int id { get; set; }
            public string symbol { get; set; }
            public string name { get; set; }
            public int amount { get; set; }
            public DateTime last_updated { get; set; }
            public Quote quote { get; set; }
        }

        public class BTC
        {
            public double? price { get; set; }
            public DateTime last_updated { get; set; }
        }

        public class ETH
        {
            public double? price { get; set; }
            public DateTime last_updated { get; set; }
        }

        public class BNB
        {
            public double? price { get; set; }
            public DateTime last_updated { get; set; }
        }

        public class USDT
        {
            public double? price { get; set; }
            public DateTime last_updated { get; set; }
        }

        public class ADA
        {
            public double? price { get; set; }
            public DateTime last_updated { get; set; }
        }

        public class Quote
        {
            public BTC BTC { get; set; }
            public ETH ETH { get; set; }
            public BNB BNB { get; set; }
            public USDT USDT { get; set; }
            public ADA ADA { get; set; }
        }

        public class Root
        {
            public Status status { get; set; }
            public List<Data> data { get; set; }
        }

        public class Status
        {
            public DateTime timestamp { get; set; }
            public int error_code { get; set; }
            public string error_message { get; set; }
            public int elapsed { get; set; }
            public int credit_count { get; set; }
            public string notice { get; set; }
        }
    }
}
