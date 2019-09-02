using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustumerApi.Controllers
{
    [Route("Esb/TaxId")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        // GET api/values
        [HttpGet, Route("")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hans", "Torres", "Vive" };
        }

    }
}