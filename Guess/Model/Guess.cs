using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess 
{
    public sealed class Guess
    {
        int steps = 3;
        int count = 0;
        int number = 1;
        bool guessed = false;

        Random random = new Random();

        public Guess()
        {

        }

        public event Action StartNewEvent;
        public event Action FinishEvent;
        public event Action<string> AskEvent;

        public int Steps => steps;
        public int Count => count;
        public bool Guessed => guessed;
        public int Number => number;

        public void Start(int min = 1, int max = 100)
        {
            count = 0; 
            number = random.Next(min, max + 1);
            guessed = false;
            StartNewEvent?.Invoke();
        }

        public void GiveAnswer(int answer)
        {
            count++;
            guessed = number == answer;

            if (guessed || count >= steps)
            {
                FinishEvent.Invoke();
                return;
            }

            string message = number > answer ? $"Загаданное число больше {answer}." : $"Загаданное число меньше {answer}.";
            AskEvent?.Invoke(message);
        }

    }
}
