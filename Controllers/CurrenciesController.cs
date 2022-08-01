using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AfipCurrencyExhange.Models;
using Newtonsoft.Json.Linq;
using Business.Dto.Request;
using Business.Dto.Response;
using Business.Services;

namespace AfipCurrencyExhange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ISymbolsServices _symbols;
        public CurrenciesController(ISymbolsServices symbols)
        {
            _symbols = symbols;
        }
        [HttpGet("GetSymbols")]
        public async Task<SymbolsResponse> GetSymbols()
        {
            try {
                SymbolsResponse currencyResponse = await _symbols.GetCurrencies();
                return currencyResponse;
            }
            catch (Exception e)
            {
                return new SymbolsResponse { Estado = 502, Message = "error al hacer el request" + e.Message };
            }
        }
        [HttpGet("GetCurrencyAmount")]

        public CurrencyResponse Currency(CurrencyRequest request)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {
                return new CurrencyResponse { Estado = -1, Message = "error al hacer el request" };
            }
        }
    }
}
