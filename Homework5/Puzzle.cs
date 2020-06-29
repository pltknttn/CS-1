using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Puzzle
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public Puzzle(string question, string answer)
        { 
            Question = question;
            Answer = answer;
        }

        public bool CheckAnswer(string answer)
        {
            return Answer.ToLower().CompareTo(answer.ToLower()) == 0;
        }

        public override string ToString()
        {
            return Question;
        }
    }
}
