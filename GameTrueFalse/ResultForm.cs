using DTOLibrary;
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
    public partial class ResultForm : Form
    {
        public ResultForm(List<Answer> wrongAnswers, int questionCount)
        {
            InitializeComponent();
                        
            StringBuilder builder = new StringBuilder((wrongAnswers.Count + 1) * 2);
            builder.AppendLine("Результаты:");
            builder.AppendLine("");
            builder.AppendLine($"Вы ответили верно на {questionCount - wrongAnswers.Count} вопрос(ов) из {questionCount}.");
            builder.AppendLine("");
            foreach (var answer in wrongAnswers)
            {
                builder.AppendLine($"Вопрос {answer.QuestionNumber}");
                builder.AppendLine(answer.Question);
                builder.AppendLine($"Ответ {(answer.TrueFalse ? "Верю" : "Не верю")}");
                builder.AppendLine("");
            }
            tbInfo.Text = builder.ToString();
        }

        private void ResultForm_SizeChanged(object sender, EventArgs e)
        {
            btnCloseGame.Left = this.Width / 2 - btnCloseGame.Width / 2;
        }

        private void btnCloseGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
