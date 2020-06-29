using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udvoitel
{
    public sealed class Udvoitel
    {
        int current = 1;//текущей число
        int count = 0;//количество шагов 
        bool stop = false;//достигли максимального кол-ва шагов или числа
        int countCommand = 0;//количество отданных команд
        Random random = new Random();
        Stack<int> history = new Stack<int>();
        public int Finish { get; private set; }
                       
        public int Current
        {
            get { return current; }
        }

        public event Action StartNewEvent;
        public event Action FinishEvent;
        public event Action RunStepEvent;

        public int Count
        {
            get { return count; }
        }

        public int CountCommand
        {
            get { return countCommand; }
        }

        //минимальное кол-во ходов
        public int Steps
        {
            get
            {
                int f = Finish;
                int i = 0;
                while (f != 1)
                {
                    f = f % 2 == 0 ? f / 2 : f - 1;
                    i++;
                }
                return i;
            }
        }
                
        public Udvoitel()
        {             
        } 

        public void Start(int min = 10, int max = 100)
        {
            Finish = random.Next(min, max + 1);
            current = 1;
            history.Clear();
            count = 0;
            stop = false;
            countCommand = 0;
            StartNewEvent?.Invoke();
        }

        private void RunStep()
        {
            RunStepEvent?.Invoke();
            stop = current >= Finish || count >= Steps;

            if (stop) FinishEvent?.Invoke(); 
        }

        public void Plus()
        {
            if (stop) return;
            count++;
            history.Push(current);
            current++;
            countCommand++;

            RunStep();
        }

        public void Multi()
        {
            if (stop) return;

            count++;
            history.Push(current);
            current *= 2;
            countCommand++;

            RunStep(); 
        }

        public void Reset()
        {
            current = 1;
            history.Clear();
            count = 0;
            countCommand++;

            RunStep();
        }

        public void Back()
        {
            int prev = history.Count != 0? history.Pop() : 1;
            current = prev;
            count -= count > 1 ? 1 : 0;
            countCommand++;

            RunStep(); 
        }

        public override string ToString()
        {
            return current.ToString();
        }
               
    }
}
