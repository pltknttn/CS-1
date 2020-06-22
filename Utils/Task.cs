using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Utils
{
    public delegate void TaskCommand();

    public sealed class Task
    {
        public ConsoleKey[] ConsoleKeys { get; set; }

        public string Text { get; set; }

        public TaskCommand Command { get; set; }

        public Task (TaskCommand command, string text, ConsoleKey[] consoleKeys)
        {
            Command = command;
            Text = text;
            ConsoleKeys = consoleKeys;
        }

        public bool CanExecution(ConsoleKey key)
        {
            return ConsoleKeys?.Contains(key) ?? false;
        }
               
        public void Execution()
        {
            Command?.Invoke();
        }
    }
}
