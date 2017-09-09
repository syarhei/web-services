using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ws_lab_01.App_Code {
    public class DeleteHandlerMSU : IHttpHandler {
        public bool IsReusable {
            get {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context) {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpRequest req = context.Request;
            HttpResponse res = context.Response;

            res.ContentType = "application/json";

            try {
                Result.stack.Pop();
                int top = Result.stack.Peek();
                res.Write(js.Serialize(new { result = Result.result + top, stack = Result.stack }));
            } catch (InvalidOperationException) {
                res.Write(js.Serialize(new { result = Result.result, stack = "Stack is empty" }));
            }

        }
    }
}