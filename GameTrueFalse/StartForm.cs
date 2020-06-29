using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTrueFalse
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        } 

        private DialogResult ShowQuestion(string msg = "Вы уверены?")
        {
            return MessageBox.Show(this, msg, "Внимание!", MessageBoxButtons.YesNo);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = ShowQuestion() == DialogResult.No;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = null;
            try
            {
                main = new MainForm();
                main.FormClosed += Main_FormClosed;
                main.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Внимание!");

                if (!this.Visible)
                    this.Show();
            }
            finally
            {
                main?.Dispose();
                main = null;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
