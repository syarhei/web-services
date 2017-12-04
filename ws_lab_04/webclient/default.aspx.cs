using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webclient {
    public partial class _default : System.Web.UI.Page {
        private Simple proxyClient;

        protected void Page_Load(object sender, EventArgs e) {
            proxyClient = new Simple();
        }

        protected void sum_Click(object sender, EventArgs e) {
            int val1, val2;
            if (int.TryParse(x.Text.ToString(), out val1) && int.TryParse(y.Text.ToString(), out val2)) {
                result.Text = proxyClient.Add(val1, val2).ToString();
            } else {
                result.Text = "Error!";
            }
        }
    }
}