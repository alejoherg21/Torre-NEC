using coinmarketcap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coinmarketcap.Services
{
    public interface IServiceAPI
    {
        Task<Cryptos.Root> CryptosList(string symbol, string CMC_PRO_API_KEY);
        Task<PriceConversion.Root> CryptoPriceConversion(string symbol, string convert, string amount, string CMC_PRO_API_KEY);
    }
}
