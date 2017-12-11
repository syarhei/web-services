using client.BASICMSU;
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
    public partial class Form1 : Form {
        BASICMSU.Service1Client client1;
        TCPMSU.Service1Client client2;

        public Form1() {
            InitializeComponent();
            client1 = new BASICMSU.Service1Client();
            client2 = new TCPMSU.Service1Client();
            client1.Open();
            client2.Open();
        }

        private void add_Click(object sender, EventArgs e) {
            z1.ForeColor = Color.Black;
            int val1, val2;
            if (int.TryParse(x1.Text.ToString(), out val1) && int.TryParse(y1.Text.ToString(), out val2)) {
                z1.Text = client1.Add(val1, val2).ToString();
            } else {
                z1.ForeColor = Color.Red;
                z1.Text = "Error!";
            }
        }

        private void concat_Click(object sender, EventArgs e) {
            z2.ForeColor = Color.Black;
            int val1;
            string val2 = y2.Text;
            if (int.TryParse(x2.Text, out val1)) {
                z2.Text = client2.Concat(val2, val1);
            } else {
                z2.ForeColor = Color.Red;
                z2.Text = "Error!";
            }
        }

        private void sum_Click(object sender, EventArgs e) {
            MSU msu1 = new MSU();
            msu1.s = s1.Text;
            msu1.k = int.Parse(i1.Text);
            msu1.f = float.Parse(d1.Text);

            MSU msu2 = new MSU();
            msu2.s = s2.Text;
            msu2.k = int.Parse(i2.Text);
            msu2.f = float.Parse(d2.Text);

            MSU result = client1.Sum(msu1, msu2);

            s3.Text = result.s;
            i3.Text = result.k.ToString();
            d3.Text = result.f.ToString();
        }
    }
}
