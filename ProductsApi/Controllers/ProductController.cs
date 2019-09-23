using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ProductsApi.Controllers
{
    [Route("Esb/Custumerid")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet, Route("")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Producto1", "Producto2" };
        }

   
    }
}
