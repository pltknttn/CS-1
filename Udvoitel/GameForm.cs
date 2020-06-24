using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Udvoitel
{
    /* Домашняя работа № 7
         * Автор: Полятыкина Татьна
         * Задание:
         * 
        1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
           б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. Игрок должен постараться получить это число за минимальное количество ходов.
           в) Добавить кнопку «Отменить», которая отменяет последние ходы. 
        */

    public partial class GameForm : Form
    {        
        private Udvoitel udvoitel;

        public GameForm()
        {
            InitializeComponent(); 
        }
               
        private void NewGame()
        {
            if (udvoitel == null)
            {
                udvoitel = new Udvoitel();
                udvoitel.RunStepEvent += Udvoitel_RunStepEvent;
                udvoitel.StartNewEvent += Udvoitel_StartNewEvent;
                udvoitel.FinishEvent += Udvoitel_FinishEvent;
            }
            udvoitel.Start();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();             
        }

        private void Udvoitel_FinishEvent()
        {
            string message = "Вы проиграли!";
            if (udvoitel.Finish == udvoitel.Current)
                message = $"{(udvoitel.Count < udvoitel.Steps ? "Браво! " : "")}Вы выиграли!";

            MessageBox.Show(message, "Стоп", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void Udvoitel_StartNewEvent()
        {
            MessageBox.Show($"Начинаем игру. \n\rНужно достигнуть числа {udvoitel.Finish} за {udvoitel.Steps} шагов.", "Старт", MessageBoxButtons.OK, MessageBoxIcon.None);

            UpdateInfo();
        }

        private void Udvoitel_RunStepEvent()
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (udvoitel == null) return;

            lblCurrent.Text = udvoitel.Current.ToString();
            lblFinish.Text = udvoitel.Finish.ToString();
            lblSteps.Text = udvoitel.Steps.ToString();
            lblCount.Text = udvoitel.Count.ToString();
            lCoundClick.Text = udvoitel.CountCommand.ToString();

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            udvoitel?.Plus(); 
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            udvoitel?.Multi(); 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            udvoitel?.Reset();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            udvoitel?.Back(); 
        } 

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();

            newToolStripMenuItem.Visible = true;
            startToolStripMenuItem.Visible = false;
        }
    }
}
