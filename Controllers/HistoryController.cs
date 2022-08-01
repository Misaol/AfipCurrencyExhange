using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AfipCurrencyExhange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HistoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        [HttpGet("History")]
        public JsonResult History()
        {
            string query = @"select * from ExchangeHistory";
            DataTable Table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AfipDB");
            SqlDataReader MyRead;
            using (SqlConnection MyCon = new SqlConnection(sqlDataSource))
            {
                MyCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, MyCon))
                {
                    MyRead = myCommand.ExecuteReader();
                    Table.Load(MyRead);
                    MyRead.Close();
                    MyCon.Close();
                }
            }
            return new JsonResult(Table);
        }
    }
}
