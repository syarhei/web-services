using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing.Code.Models;

namespace client {
    public partial class StartPage : Form {
        SOAPWS.SimpleSoapClient refClient;
        Simple proxyClient;

        public StartPage() {
            InitializeComponent();
            refClient = new SOAPWS.SimpleSoapClient();
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

        private void MSU_Click(object sender, EventArgs e) {
            MSU msu1 = new MSU();
            msu1.s = s1.Text;
            msu1.k = int.Parse(i1.Text);
            msu1.f = float.Parse(d1.Text);

            MSU msu2 = new MSU();
            msu2.s = s2.Text;
            msu2.k = int.Parse(i2.Text);
            msu2.f = float.Parse(d2.Text);

            MSU result = proxyClient.Sum(msu1, msu2);

            result_1.Text = result.s;
            result_2.Text = result.k.ToString();
            result_3.Text = result.f.ToString();
        }
    }
}
