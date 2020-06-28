using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstDatabase.Model;

namespace FirstDatabase
{
    /* Домашняя работа № 8
Задача 1. 
а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия,авторские права и др.).
г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).
     
Автор: Полятыкина Татьяна
     */

    public partial class MainForm : Form
    {
        readonly Timer timer = new Timer();
        Database database;
        PrintDocument printDocument;
        PrintPreviewDialog previewDialog;
        

        public MainForm()
        {
            InitializeComponent();

            database = new Database(UpdateInfo);

            printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument_PrintPage;
            previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                ShowIcon = false
            };                       
            tsslCurrentTime.Text = DateTime.Now.ToLongTimeString();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            
            InitializeGridView(); 
        }

        void InitializeGridView()
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate ()
                {
                    InitializeGridView();
                });
            }
            else
            {
                dataGridView.DataSource = database.Source;
                database.Source.ResetBindings(false);
                dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Beige,
                    Font = new Font("Verdana", 10, FontStyle.Bold)
                }; ;
                dataGridView.Columns[0].HeaderText = "Вопрос";
                dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[1].HeaderText = "Истина";
                dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.ShowEditingIcon = false; 
            }
        }

        bool canChangeCurrent = false;
        void RefreshGridView()
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate ()
                {
                    RefreshGridView();
                });
            }
            else
            {
                canChangeCurrent = false;
                try
                {
                    (dataGridView.DataSource as BindingSource)?.ResetBindings(false);
                     
                    dataGridView.ClearSelection();
                    dataGridView.Focus();
                    
                    if (database.Current >= 0 && database.Current < dataGridView.Rows.Count && dataGridView.Rows.Count > 0)
                    {    
                        dataGridView.CurrentCell = dataGridView.Rows[database.Current].Cells[0];
                    }
                }
                finally
                {
                    canChangeCurrent = true; 
                }
            }
        }

        void RefreshInfo()
        {
            if (database.GetCurrent == null)
            {
                tbText.Text = "";
                cbYes.Checked = false;
                cbYes.CheckState = CheckState.Indeterminate;
                tstbCurrentIndex.Text = database.Current.ToString();
            }
            else
            {
                tbText.Text = database.GetCurrent.Text;
                cbYes.Checked = database.GetCurrent.TrueFalse;
                cbYes.CheckState = database.GetCurrent.TrueFalse ? CheckState.Checked : CheckState.Unchecked;
                tstbCurrentIndex.Text = database.Current.ToString();                
            }
        }

        void UpdateInfo()
        {
            RefreshGridView();
            RefreshInfo(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tsslCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DialogResult ShowQuestion(string msg = "Вы уверены?")
        {
            return MessageBox.Show(this, msg, "Внимание!", MessageBoxButtons.YesNo);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = ShowQuestion() == DialogResult.No;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            using (AddQuestionForm frmAddQuestion = new AddQuestionForm())
            {
                if (frmAddQuestion.ShowDialog() != DialogResult.OK) return;
                
                database.Add(frmAddQuestion.Question); 
            }
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            database.Prev();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            database.Next();
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (ShowQuestion() == DialogResult.Yes)
                database.RemoveCurrent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database = new Database(UpdateInfo);

            InitializeGridView();
            UpdateInfo();
        }

        private void SaveAs(string fileName)
        {
            if (database.List == null || database.List.Count == 0)
            {
                MessageBox.Show(this, $"Не создана база данных!", "Внимание!", MessageBoxButtons.OK);
                return;
            }
            bool canSave = string.IsNullOrWhiteSpace(fileName);
            if (!canSave && Database.ShowSaveFileDialog(out fileName))
            {
                database.Save(fileName);
            }
            else if (canSave) database.Save(fileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs(null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (Database.ShowOpenFileDialog(out string fileName))
            {
                database.Load(fileName);
                InitializeGridView();
                UpdateInfo();
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.PerformClick();
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!canChangeCurrent || database.Count == 0) return;

            int index = (sender as DataGridView)?.CurrentRow?.Index??-1;
            database?.SetCurrent(index);

            RefreshInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Question question = database.GetCurrent;
            question.Text = tbText.Text;
            question.TrueFalse = cbYes.Checked;

            UpdateInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs(database.FileName);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dataGridView.Width, dataGridView.Height);
            dataGridView.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView.Width, this.dataGridView.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.SelectAll();
        }

        private void tstbCurrentIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (number == '\r')//Enter
            {
                if (int.TryParse(tstbCurrentIndex.Text, out int index))
                {
                    database?.SetCurrent(index);
                    RefreshGridView();
                }

                e.Handled = true;
                return;
            }
            
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Программа \"База данных\" \n\r \n\rВерсия: {Application.ProductVersion} \n\rАвторы: GeekBrains, Полятыкина Татьяна", "Информация");
        }
    }
}
