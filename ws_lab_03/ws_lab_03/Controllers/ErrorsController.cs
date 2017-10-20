using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ws_lab_03.Controllers
{
    public class ErrorsController : ApiController
    {

        // GET: api/Errors/5
        public object Get(int id)
        {
            switch (id) {
                case 400:
                    return Ok(new { id = 400, message = "Bad request" });
                case 404:
                    return Ok(new { id = 404, message = "Student is not found" });
                default:
                    return Ok(new { id = 500, message = "Server error" });
            }
        }
    }
}
