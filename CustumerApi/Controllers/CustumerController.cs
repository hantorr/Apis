using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CustumerApi.Controllers
{
    [Route("Esb/TaxId")]
    [Authorize]
    public class CustumerController : ControllerBase
    {
        // GET api/values
        [HttpGet, Route("")]
        //[Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hans", "Torres", "Vive" };
        }

    }
}