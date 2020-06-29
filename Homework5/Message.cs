using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework5
{
    public static class Message
    {
        public static string[] GetWords(string input, int countLetter)
        {
            if (string.IsNullOrWhiteSpace(input?.Trim()) || countLetter <= 0) return new string[0];
                      
            Regex regex = new Regex($@"\b\w{{1,{countLetter}}}\b", RegexOptions.Compiled | RegexOptions.CultureInvariant); 
            MatchCollection matches = regex.Matches(input);
            if (matches.Count == 0) return new string[0]; 

            string[] words = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
                words[i] = matches[i].Value;

            return words;
        }

        public static string Clear(string input, char ivalidChar)
        {
            if (string.IsNullOrWhiteSpace(input?.Trim())) return input;

            Regex regex = new Regex($@"\b(\w+)?[{ivalidChar}]\b", RegexOptions.Compiled | RegexOptions.CultureInvariant);
             
            return regex.Replace(input, "");
        }

        private static char[] wordSeparators = new char[] { ' ', '\n', ',', '.', '?', '!', ';', ':', '\r', '\t'};

        public static string MaxWord(string input)
        {
            if (string.IsNullOrWhiteSpace(input?.Trim())) return input;

            string[] words = input.Split(wordSeparators);
            string word = words[0];

            for(int i = 1; i < words.Length; i++ )
            {
                if (words[i].Length > word.Length)
                    word = words[i];
            }

            return word;
        }

        public static int LengthMaxWord(string input)
        {
            if (string.IsNullOrWhiteSpace(input?.Trim())) return 0;

            string[] words = input.Split(wordSeparators);
            int length = words[0].Length;
            int newlength = 0;
            for (int i = 0; i < words.Length; i++ )
            {
                newlength = words[i].Length;
                if (newlength > length)
                    length = newlength;
            }

            return length;
        }

        public static string GetRowMaxWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input?.Trim())) return input;

            string[] words = input.Split(wordSeparators);
            int length = LengthMaxWord(input);
            StringBuilder builder = new StringBuilder(length * words.Length);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == length)
                    builder.AppendLine(words[i]);
            }

            return builder.ToString();
        }
         
    }
}
