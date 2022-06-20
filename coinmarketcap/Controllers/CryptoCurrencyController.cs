using coinmarketcap.Entities;
using coinmarketcap.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coinmarketcap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly IServiceAPI _serviceAPI;

        public CryptoCurrencyController(IServiceAPI serviceAPI)
        {
            _serviceAPI = serviceAPI;
        }

        [HttpGet("GetCryptos/{symbol}/{CMC_PRO_API_KEY}")]
        public async Task<ActionResult> GetCryptos(string symbol, string CMC_PRO_API_KEY)
        {
            Cryptos.Root CryptosList = await _serviceAPI.CryptosList(symbol, CMC_PRO_API_KEY);
            return Ok(CryptosList);
        }

        [HttpGet("GetPriceConversion/{symbol}/{convert}/{amount}/{CMC_PRO_API_KEY}")]
        public async Task<ActionResult> GetPriceConversion(string symbol, string convert, string amount, string CMC_PRO_API_KEY)
        {
            PriceConversion.Root PriceConversionList = await _serviceAPI.CryptoPriceConversion(symbol, convert, amount, CMC_PRO_API_KEY);
            return Ok(PriceConversionList);
        }
    }
}
