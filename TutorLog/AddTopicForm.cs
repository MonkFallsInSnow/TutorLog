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
    //TODO: handle add topic save and cancel events
    //TODO: bind campus data to list box
    public partial class AddTopicForm : Form
    {
        public AddTopicForm()
        {
            InitializeComponent();
        }

        private void saveTopicBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancelTopicBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
    }
}
