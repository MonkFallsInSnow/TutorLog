using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorLog
{
    //TODO: handle add tutor save and cancel events
    //TODO: bind tutor campus data to list box
    public partial class AddTutorForm : Form
    {
        public AddTutorForm()
        {
            InitializeComponent();
        }

        private void saveTutorBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tutorCancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
