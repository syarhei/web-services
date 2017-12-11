using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace host {
    public partial class Form1 : Form {
        ServiceHost sh;

        public Form1() {
            InitializeComponent();
            sh = new ServiceHost(typeof(ws_lab_05.Service1));
            sh.Open();
        }
    }
}
