using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ws_lab_02.Models;

namespace ws_lab_02.Controllers
{
    public class ResultController : ApiController
    {
        // GET: api/Result
        public object Get()
        {
            int top;
            if (Result.stack.TryPeek(out top))
                return new { result = Result.result + top, stack = Result.stack };
            else
                return new { result = Result.result, stack = "Stack is empty" };
        }

        // POST: api/Result
        [HttpPost]
        public object Post([FromBody] string result)
        {
            int number;
            if (int.TryParse(result, out number)) {
                Result.result = number;
                int top;
                if (Result.stack.TryPeek(out top))
                    return new { result = Result.result + top, stack = Result.stack };
                else
                    return new { result = Result.result, stack = "Stack is empty" };
            } else
                return new { error = new { message = "Type of Params is not Integer", result = result } };
        }

        // PUT: api/Result
        [HttpPut]
        public object Put([FromBody] string add) {
            int number;
            if (int.TryParse(add, out number)) {
                Result.stack.Push(number);
                int top;
                if (Result.stack.TryPeek(out top))
                    return new { result = Result.result + top, stack = Result.stack };
                else
                    return new { result = Result.result, stack = "Stack is empty" };
            } else
                return new { error = new { message = "Type of Params is not Integer", result = add } };
        }

        // DELETE: api/Result/5
        [HttpDelete]
        public object Delete() {
            int top;
            if (Result.stack.TryPop(out top) && Result.stack.TryPeek(out top))
                return new { result = Result.result + top, stack = Result.stack };
            else
                return new { result = Result.result, stack = "Stack is empty" };
        }
    }
}
