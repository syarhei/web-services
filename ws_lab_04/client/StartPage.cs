using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client {
    public partial class StartPage : Form {
        SimpleSoapService.SimpleSoapClient refClient;
        Simple proxyClient;

        public StartPage() {
            InitializeComponent();
            refClient = new SimpleSoapService.SimpleSoapClient();
            proxyClient = new Simple();
        }

        private void getSum_Click(object sender, EventArgs e) {
            result.ForeColor = Color.Black;
            int val1, val2;
            if (int.TryParse(x.Text.ToString(), out val1) && int.TryParse(y.Text.ToString(), out val2)) {
                result.Text = refClient.Add(val1, val2).ToString();
            } else {
                result.ForeColor = Color.Red;
                result.Text = "Error!";
            }
        }

        private void getSumByProxy_Click(object sender, EventArgs e) {
            result.ForeColor = Color.Black;
            int val1, val2;
            if (int.TryParse(x.Text.ToString(), out val1) && int.TryParse(y.Text.ToString(), out val2)) {
                result.Text = proxyClient.Add(val1, val2).ToString();
            } else {
                result.ForeColor = Color.Red;
                result.Text = "Error!";
            }
        }
    }
}
