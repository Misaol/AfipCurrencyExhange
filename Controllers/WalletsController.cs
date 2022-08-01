using Business.Dto.Request;
using Business.Dto.Response;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfipCurrencyExhange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _wallets;
        public WalletsController(IWalletService symbols)
        {
            _wallets = symbols;
        }
        [HttpPost("GetWallets")]
        public async Task<WalletResponse> GetWallets(WalletRequest walletRequest)
        {
            try
            {
                WalletResponse currencyResponse = await _wallets.GetWallets(walletRequest);
                return currencyResponse;
            }
            catch (Exception e)
            {
                return new WalletResponse { Estado = 502, Message = "error al hacer el request" + e.Message };
            }
        }
        [HttpPost("CreateWallets")]
        public async Task<WalletResponse> CreateWallets(WalletRequest walletRequest)
        {
            try
            {
                WalletResponse currencyResponse = await _wallets.CreateWallet(walletRequest);
                return currencyResponse;
            }
            catch (Exception e)
            {
                return new WalletResponse { Estado = 502, Message = "error al hacer el request" + e.Message };
            }
        }
        [HttpPut("UpdateWallets")]
        public async Task<WalletResponse> UpdateWallets(WalletRequest walletRequest)
        {
            try
            {
                WalletResponse currencyResponse = await _wallets.UpdateWallets(walletRequest);
                return currencyResponse;
            }
            catch (Exception e)
            {
                return new WalletResponse { Estado = 502, Message = "error al hacer el request" + e.Message };
            }
        }
    }
}
