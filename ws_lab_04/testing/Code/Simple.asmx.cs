using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using testing.Code.Models;
using Newtonsoft.Json;

namespace testing.Code {
    /// <summary>
    /// Сводное описание для Simple
    /// </summary>
    [WebService(Namespace = "http://msu/", Description = "Simple web service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [ScriptService]
    public class Simple : WebService {

        [WebMethod(MessageName = "sum_1", Description = "Sum of 2 int")]
        public int Add(int x, int y) {
            return x + y;
        }

        [WebMethod(MessageName = "sum_2", Description = "Concatination of string and double")]
        public string Concat(string s, double d) {
            return s + " " + d.ToString();
        }

        [WebMethod(MessageName = "sum_3", Description = "Sum of fileds of two [MSU] objects. Return [MSU] object")]
        public MSU Sum(MSU msu1, MSU msu2) {
            NameValueCollection t = Context.Request.Params;
            return new MSU(msu1.s + msu2.s, msu1.k + msu2.k, msu1.f + msu2.f);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat=ResponseFormat.Json)]
        [WebMethod(MessageName = "sum_4", Description = "Sum of 2 int. Response JSON")]
        public int Adds(int x, int y) {
            return x + y;
        }
    }
}
