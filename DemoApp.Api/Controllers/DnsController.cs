using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DnsController : ControllerBase
    {
        public DnsController()
        {
        }

        record ApiResult(int A, int B, int Res);

        public IActionResult AccessDatabase()
        {
            var addressesString = new StringBuilder();
            var addresses = Dns.GetHostAddresses($"sql-a56tu4bzkgjjw.database.windows.net");
            return Ok(string.Join(", ", addresses.ToArray().Select(x => x.ToString())));
        }
    }
}
