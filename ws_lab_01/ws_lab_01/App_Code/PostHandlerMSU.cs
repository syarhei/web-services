using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ws_lab_01.App_Code {
    public class PostHandlerMSU : IHttpHandler {
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

            int number;

            if (int.TryParse(req.Params["result"], out number)) {
                try {
                    Result.result += number;
                    int top = Result.stack.Peek();
                    res.Write(js.Serialize(new { result = Result.result + top, stack = Result.stack }));
                } catch (InvalidOperationException) {
                    res.Write(js.Serialize(new { result = Result.result, stack = "Stack is empty" }));
                }
            } else {
                res.Write(js.Serialize(new { error = new { message = "Type of Params['rusult'] is not Integer", result = req.Params["result"] } }));
            }

        }
    }
}