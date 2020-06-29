using System; 
using System.Xml.Serialization;

namespace DTOLibrary
{
    [Serializable]
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

        public Question Clone()
        {
            return new Question()
            {
                Text = this.Text,
                TrueFalse = this.TrueFalse
            };
        }
    }

    public class Answer
    {
        public int QuestionNumber { get; set; } //номер вопроса
        public string Question { get; set; } //вопрос
        public bool TrueFalse { get; set; } //ответ

        public Answer() { }

        public Answer(int questionNumber, string question, bool trueFalse)
        {
            this.QuestionNumber = questionNumber;
            this.Question = question;
            this.TrueFalse = trueFalse;
        }
    }
}
