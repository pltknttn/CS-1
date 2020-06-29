using DTOLibrary;
using System;
using System.Collections.Generic; 
using System.IO;  
using System.Xml.Serialization;

namespace GameTrueFalse.Model
{
    class TrueFalse
    {
        public event Action Finish;
        public event Action NextQuestion;

        private static Random random = new Random();
        private List<Question> _list = new List<Question>();
        private Dictionary<int, Question> _questions = new Dictionary<int, Question>();
        private List<int> _questionsNumbers = new List<int>();
        private Dictionary<Answer, bool> _answers = new Dictionary<Answer, bool>();

        private int _current = -1; 
        private int _questionCount = 0;

        public TrueFalse(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException("Файл БД не существует!");

            Load(filename);

            _questionCount = random.Next(5, 11);

            if (_questionCount > _list.Count) throw new InvalidDataException("Некорректная БД. Список вопросов не менее 10.");

            for (int i = 0; i < _questionCount; i++)
            {
                int num;
                do
                {
                    num = random.Next(0, _list.Count);
                }
                while (_questions.ContainsKey(num));
                 
                _questions[num] = _list[num].Clone();
                _questionsNumbers.Add(num);
            }

            _current = 0;
        }

        public int QuestionCount { get { return _questionCount; } private set { _questionCount = value; } }
        public int Current
        {
            get { return _current; }
            private set
            {
                _current = value;

                if (_current >= 0 && _current < _questionCount) NextQuestion?.Invoke();
                if (_current >= 0 && _current == _questionCount) Finish?.Invoke();
            }
        }
        public Question GetQuestion()
        {
            if (_current < 0 || _current > QuestionCount) return null;

            int questionNumber = _questionsNumbers[_current];

            if (!_questions.ContainsKey(questionNumber)) return null;

            return _questions[questionNumber];
        }

        public List<Answer> GetWrongAnswers()
        {
            List<Answer> wrongAnswers = new List<Answer>();

            foreach (KeyValuePair<Answer, bool> keyPair in _answers)
            {
                if (keyPair.Value) continue;

                wrongAnswers.Add(keyPair.Key);
            }

            return wrongAnswers;
        }

        public bool IsFinished()
        {
            return _current == _questionCount;
        }

        private void Load(string filename)
        {
            Stream fStream = null;
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                _list = (List<Question>)xmlFormat.Deserialize(fStream);
            }
            finally
            {
                fStream?.Close();
            }
        }

        public bool ToAnswer(bool trueFalse)
        {
            if (Current > QuestionCount) return false;

            int questionNumber = _questionsNumbers[_current];
            if (!_questions.ContainsKey(questionNumber)) return false;

            Question question = _questions[questionNumber];

            _answers[new Answer(questionNumber, question.Text, trueFalse)] = question.TrueFalse == trueFalse;

            Current++;

            return question.TrueFalse == trueFalse;
        } 
    }
}
