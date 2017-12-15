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
    public partial class StartForm : Form {
        MSUWS.WSEntities entity;

        public StartForm() {

            entity = new MSUWS.WSEntities(new Uri("http://localhost:54570/MSUService.svc/"));

            InitializeComponent();
        }

        private void getStudents_Click(object sender, EventArgs e) {
            result.Text = "";
            foreach (MSUWS.student student in entity.students.AsEnumerable()) {
                result.Text += string.Format("Student: '{0}' (id:{1})\n", student.name, student.id);
            }
        }

        private void getNotes_Click(object sender, EventArgs e) {
            List<MSUWS.note> notes = entity.notes.Where(n => n.notes >= 4).ToList();

            result.Text = "";
            foreach (MSUWS.note note in notes) {
                result.Text += string.Format("Note: {0} on exam {1} (id student:{2})\n", note.notes, note.subject, note.id);
            }
        }
    }
}
