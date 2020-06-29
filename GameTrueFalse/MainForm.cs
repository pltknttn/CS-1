using GameTrueFalse.Model;
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
    /*Домашняя работа № 8
Задача 2. 
    Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».
          
Автор: Полятыкина Татьяна
     */
    public partial class MainForm : Form
    {
        private readonly TrueFalse trueFalse;
        private string filename = $"{Application.StartupPath}\\{Properties.Settings.Default.DbFileName}";

        public MainForm()
        {
            InitializeComponent();
                        
            trueFalse = new TrueFalse(filename);
            trueFalse.NextQuestion += TrueFalse_NextQuestion;
            trueFalse.Finish += TrueFalse_Finish;
        }

        private void TrueFalse_Finish()
        {
            this.Hide();
            using (ResultForm resultForm = new ResultForm(trueFalse.GetWrongAnswers(), trueFalse.QuestionCount))
            {
                resultForm.ShowDialog();
            }
            this.Close();
        }

        private void UpdateInfo()
        {
            tbQuestion.Text = trueFalse.GetQuestion()?.Text;
            cbFalse.Checked = false;
            cbTrue.Checked = false;
        }

        private void TrueFalse_NextQuestion()
        {
            UpdateInfo();
        }

        private void btnCloseGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (!cbTrue.Checked && !cbFalse.Checked || cbTrue.Checked && cbFalse.Checked)
                MessageBox.Show("Выберите вариант ответа Верю или Не верю!", "Внимание");
            else
            {  
                trueFalse?.ToAnswer(cbTrue.Checked);
            }
        }

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrue.Checked && cbFalse.Checked)
                cbFalse.Checked = false;
        }

        private void cbFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFalse.Checked && cbTrue.Checked)
                cbTrue.Checked = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trueFalse?.IsFinished() == false)
                e.Cancel = MessageBox.Show(this, "Вы уверены, что хотите закончить игру?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
