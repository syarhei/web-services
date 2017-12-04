using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ws_lab_04.App_Code {
    /// <summary>
    /// Сводное описание для Simple
    /// </summary>
    [WebService(Namespace = "http://msu2/", Description = "Simple web service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Simple : System.Web.Services.WebService {
        [WebMethod(MessageName = "", Description = "Sum of 2 int")]
        public int Add(int x, int y) {
            return x + y;
        }

        [WebMethod(Description = "Concatination of string and double")]
        public string Concat(string s, double d) {
            return string.Format(s, d);
        }

        [WebMethod(Description = "Sum of fileds of two [A] objects. Return [A] object")]
        public A Sum(A a1, A a2) {
            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }
    }
}
