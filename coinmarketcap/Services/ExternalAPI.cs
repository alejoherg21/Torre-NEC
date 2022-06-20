using coinmarketcap.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace coinmarketcap.Services
{
    public class ExternalAPI : IServiceAPI
    {
        static HttpClient client = new HttpClient();
        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());

        public async Task<Cryptos.Root> CryptosList(string symbol, string CMC_PRO_API_KEY)
        {
            Cryptos.Root Crypto = null;
            string path = conf["ExternalAPI:latest"].ToString();
            HttpResponseMessage response = await client.GetAsync(path+"?symbol="+symbol+"&CMC_PRO_API_KEY="+ CMC_PRO_API_KEY);
            if (response.IsSuccessStatusCode)
            {
                Crypto = await response.Content.ReadAsAsync<Cryptos.Root>();
            }
            return Crypto;
        }

        public async Task<PriceConversion.Root> CryptoPriceConversion(string symbol, string convert, string amount, string CMC_PRO_API_KEY)
        {
            PriceConversion.Root PriceConversion = null;
            string path = conf["ExternalAPI:price-conversion"].ToString();
            HttpResponseMessage response = await client.GetAsync(path + "?convert=" + convert + "&symbol=" + symbol + "&amount=" + amount + "&CMC_PRO_API_KEY=" + CMC_PRO_API_KEY);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                PriceConversion = await response.Content.ReadAsAsync<PriceConversion.Root>();
            }
            return PriceConversion;
        }
    }
}
