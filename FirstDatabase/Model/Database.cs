﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FirstDatabase.Model
{
    public class Question
    {
        public string Text { get; set; }//Текст вопроса
        public bool TrueFalse { get; set; }//Правда или нет

        public Question() { }

        public Question(string text, bool trueFalse)
        {
            this.Text = text;
            this.TrueFalse = trueFalse;
        }
    }

    class Database
    {
        public const int MaxFileSize = 200000;//байт
        public const string FileFilter = "XML files|*.XML|All files|*.*";

        //уведомление об изменении текущего элемента
        public Action ChangeCurrent { get; private set; } 

        List<Question> _list;
        public List<Question> List => _list;
        public BindingSource Source => new BindingSource() { DataSource = _list };

        int _current = -1;
        public int Current
        {
            get
            {
                return _current;
            }
            private set
            {
                _current = value;
                ChangeCurrent?.Invoke();
            }
        }

        string _fileName;
        public string FileName {
            get { return _fileName; }
            private set
            {
                _fileName = value;
            }
        }
        public Database()
        {
            _list = new List<Question>();
            Current = -1;
        }

        public Database(Action updateInfo): this()
        {
            ChangeCurrent = updateInfo;
        } 

        public void Add(Question question)
        {
            _list.Add(question);
            Current = _list.Count - 1; 
        }

        public void RemoveCurrent()
        {
            if (_current == -1 || _list.Count == 0) return;

            _list.RemoveAt(Current);

            if (Current > 0 || _list.Count == 0) Current--;
        }

        public void Next()
        {
            if (_current + 1 < _list.Count) Current++;
        }

        public void Prev()
        {
            if (_current > 0) Current--;
        }

        public Question GetCurrent
        {
            get
            {
                 if (_current >= 0 && _list.Count > _current) return _list[_current];
                 return null;
            }
        }

        public void SetCurrent(int index)
        {
            if (index >= 0 && index <_list.Count)
            {
               _current = index;
            }
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void Save(string filename)
        {
            Stream fStream = null;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                fStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, _list);
                FileName = filename;
            }
            finally
            {
                fStream?.Close();
            }
        }

        public void Load(string filename)
        {            
            Stream fStream = null;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                _list = (List<Question>)xmlFormat.Deserialize(fStream);
                Current = 0;
                FileName = filename;
            }
            finally
            {
                fStream?.Close();
            }
        }

        public static bool ShowOpenFileDialog(out string filename)
        {
            filename = string.Empty;
            bool isSuccessful = false; 

            using (OpenFileDialog dialog = new OpenFileDialog { Filter = Database.FileFilter })
            { 
                while (!isSuccessful)
                {
                    if (dialog.ShowDialog() != DialogResult.OK) break;

                    FileInfo fi = new FileInfo(dialog.FileName);
                    isSuccessful = fi.Length <= Database.MaxFileSize;
                    if (!isSuccessful)
                    {
                        MessageBox.Show($"Выберите файл меньшего размера. Максимальный объем загружаемого файла {Database.MaxFileSize} (байт).", "Внимание!", MessageBoxButtons.OK);
                    }
                    else filename = dialog.FileName;
                } 
            }

            return isSuccessful;
        }

        public static bool ShowSaveFileDialog(out string filename)
        {
            filename = string.Empty;
            bool isSuccessful = false;

            using (SaveFileDialog dialog = new SaveFileDialog { Filter = Database.FileFilter })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    isSuccessful = true;
                    filename = dialog.FileName;
                }
            }

            return isSuccessful;
        }
    }
}