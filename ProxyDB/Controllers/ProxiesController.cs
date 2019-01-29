using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProxyDB.Database;
using ProxyDB.Enums;
using ProxyDB.Models;

namespace ProxyDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxiesController : ControllerBase
    {
        private DatabaseManager _manager = new DatabaseManager();

        // GET api/proxies
        [HttpGet]
        public ActionResult<IEnumerable<Proxy>> Get()
        {
            return new Proxy[] {
                new Proxy()
                {
                    ID = 0,
                    IP = "127.0.0.1",
                    Port = 1337,
                    Anonymity = Anonymity.Elite,
                    Protocol = Protocol.SOCKS5,
                    Country = "US"
                }
            };
        }

        // GET api/proxies/{id}
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/proxies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
