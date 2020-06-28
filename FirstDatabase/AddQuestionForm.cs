using FirstDatabase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstDatabase
{
    public partial class AddQuestionForm : Form
    {
        public Question Question { get; private set; } = new Question();

        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Question.Text = tbQuestion.Text;
            Question.TrueFalse = cbYes.Checked;
        }
    }
}
