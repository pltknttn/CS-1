using DTOLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CsvToXmlConverter
{
    /* Домашняя работа № 8
Задача 3. 
    Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
     
Автор: Полятыкина Татьяна
     */

    public partial class MainForm : Form
    {
        private int MaxSize = 100000;
        private string XmlFilter = "XML files|*.xml";
        private string CsvFilter = "CSV files|*.csv|All text files|*.txt";

        public MainForm()
        {
            InitializeComponent();

            tbInfoCSV.Text = string.Empty;
            tbInfoXML.Text = string.Empty;

            HideControls();

            cbCSV.Checked = true;
        }


        private bool LoadStudents(string filename, out List<Student> list, out string file)
        {
            file = string.Empty;
            list = new List<Student>();
            StreamReader sr = null;
            StringBuilder builder = new StringBuilder();
            try
            {
                sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string str = sr.ReadLine();
                        string[] s = str.Split(';');
                        Student t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                        list.Add(t);
                        builder.AppendLine(str);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            catch
            {
                list.Clear();
                return false;
            }
            finally
            {
                sr?.Close();
            }

            if(list.Count == 0)
            {
                MessageBox.Show("Некорректные данные", "Внимание!");
                file = string.Empty;                
                list = null; 
                return false;
            }
            

            file = builder.ToString();
            return true;
        }
                
        public bool ShowOpenFileDialog(string filter, out string filename)
        {
            filename = string.Empty; 

            using (OpenFileDialog dialog = new OpenFileDialog { Filter = filter })
            {
                 if (dialog.ShowDialog() != DialogResult.OK) return false;

                    filename = dialog.FileName; 
            }

            return true;
        }

        public static bool ShowSaveFileDialog(string filter, out string filename)
        {
            filename = string.Empty; 

            using (SaveFileDialog dialog = new SaveFileDialog { Filter = filter })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return false;

                filename = dialog.FileName;
            }

            return true;
        }

        private List<Student> students = null;

        private void LoadCsv(string filename)
        {
            if (!File.Exists(filename)) return;

            if (!LoadStudents(filename, out students, out string file)) return;

            tbInfoCSV.Text = file;
        }

        private void tbFileCsv_TextChanged(object sender, EventArgs e)
        {
            LoadCsv(tbFileCsv.Text);
            tbInfoXML.Text = string.Empty;
        }

        private void buttonOpenFileCsv_Click(object sender, EventArgs e)
        {
            if(ShowOpenFileDialog(CsvFilter, out string filename))
            {
                tbFileCsv.Text = filename;
            }
        }

        private void buttonOpenFileXml_Click(object sender, EventArgs e)
        {
            if (ShowOpenFileDialog(XmlFilter, out string filename))
            {
                tbFileXml.Text = filename;
            }
        }

        private void LoadXml(string filename)
        {
            if (!File.Exists(filename)) return;

            Load(filename);
            tbInfoXML.Text = File.ReadAllText(filename);
        }

        private void tbFileXml_TextChanged(object sender, EventArgs e)
        {
            LoadXml(tbFileXml.Text);
            tbInfoCSV.Text = string.Empty;
        }

        private void HideControls()
        {
            panelFileXML.Visible = cbXML.Checked;
            panelFileCSV.Visible = cbCSV.Checked;

            buttonConvertXmlToCsv.Visible = cbXML.Checked;
            buttonConvertCsvToXml.Visible = cbCSV.Checked;

            buttonConvertXmlToCsv.Top = panelConvert.Height / 2 - buttonConvertXmlToCsv.Height / 2;
            buttonConvertCsvToXml.Top = panelConvert.Height / 2 - buttonConvertCsvToXml.Height / 2;

            tbFileCsv.Text = string.Empty;
            tbFileXml.Text = string.Empty;
            tbInfoCSV.Text = string.Empty;
            tbInfoXML.Text = string.Empty;
        }

        private void cbXML_CheckedChanged(object sender, EventArgs e)
        {

            if (cbXML.Checked && cbCSV.Checked)
                cbCSV.Checked = false;
            else if (!cbXML.Checked && !cbCSV.Checked)
                cbCSV.Checked = true;

            HideControls();
        }

        private void cbCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXML.Checked && cbCSV.Checked)
                cbXML.Checked = false;
            else if (!cbXML.Checked && !cbCSV.Checked)
                cbXML.Checked = true;

            HideControls();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            HideControls();
        } 

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (cbCSV.Checked && string.IsNullOrEmpty(tbInfoXML.Text) || cbXML.Checked && string.IsNullOrEmpty(tbInfoCSV.Text))
            {
                MessageBox.Show("Сконвертируйте данные и нажмите сохранить", "Внимание");
                return;
            }
        }

        void WriteStudent(string fileName, List<Student> students)
        {
            StreamWriter sr = null;
            try
            {
                sr = new StreamWriter(fileName);
                foreach (Student student in students)
                {
                    sr.WriteLine(student.GetRow());
                }
            }
            finally
            {
                sr?.Close();
            }
        }

        bool Save(string filename)
        {            

            Stream fStream = null;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                fStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, students); 
            }
            finally
            {
                fStream?.Close();
            }

            return true;
        }

        void Load(string filename)
        {
            Stream fStream = null;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                students = (List<Student>)xmlFormat.Deserialize(fStream); 
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Внимание!");
                students = null;
            }
            finally
            {
                fStream?.Close();
            }
        }

        private void buttonConvertCsvToXml_Click(object sender, EventArgs e)
        {
            if (students == null || students.Count == 0)
            {
                MessageBox.Show("Нет данных для конвертации", "Внимание");
                return;
            }

            if (ShowSaveFileDialog(XmlFilter, out string filename))
            {
                Save(filename);
                LoadXml(filename);
            }
        }

        private void buttonConvertXmlToCsv_Click(object sender, EventArgs e)
        {            
            if (ShowSaveFileDialog(CsvFilter, out string filename))
            {
                WriteStudent(filename, students);
                LoadCsv(filename);
            }
        }
    }
}
