using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess
{
    /* Домашняя работа № 7
         * Автор: Полятыкина Татьна
         * Задание:
         * 
        2. Используя Windows Forms, разработать игру «Угадай число». 
           Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
           Для ввода данных от человека используется элемент TextBox.
        */

    public partial class GameForm : Form
    {
        private Guess guess;

        public GameForm()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            btnAnswer.Enabled = true;
            textBox.Enabled = true;
            labelInfo.ForeColor = Color.SteelBlue;
            labelInfo.Text = "Введите число";
            textBox.Text = null;
            textBox.Focus();

            if (guess == null)
            {
                guess = new Guess();
                guess.StartNewEvent += Guess_StartNewEvent;
                guess.AskEvent += Guess_AskEvent;
                guess.FinishEvent += Guess_FinishEvent;
            }

            guess.Start();
        }

        private void UpdateInfo()
        {
            if (guess == null) return;

            lblFinish.Text = guess.Steps.ToString();
            lblCurrent.Text = guess.Count.ToString();
        }

        private void Guess_AskEvent(string msg)
        {
            UpdateInfo();

            labelInfo.Text = $"Вы не угадали. {msg} Попробуйте еще раз.";
            labelInfo.ForeColor = Color.OrangeRed;
            textBox.Text = null;
            textBox.Focus();
        }

        private void Guess_FinishEvent()
        {
            UpdateInfo();

            labelInfo.ForeColor = Color.IndianRed;
            btnAnswer.Enabled = false;
            textBox.Enabled = false;

            if (guess.Guessed)
            {
                labelInfo.Text = "Число угадано!!! Поздравляем!!!";
                return;
            }

            labelInfo.Text = $"Вы проиграли!!! Количество попыток исчерпано. Правильный ответ {guess.Number}."; 
        }

        private void Guess_StartNewEvent()
        {
            UpdateInfo();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox.Text, out int answer);
            guess?.GiveAnswer(answer);
        }
    }
}
