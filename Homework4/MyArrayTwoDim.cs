using System;
using System.IO;

namespace Homework4
{
    public class MyArrayTwoDim
    {
        int[,] intArray;
        Random random = new Random();

        public MyArrayTwoDim(int n, int el)
        {
            intArray = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    intArray[i, j] = el;
        }

        public MyArrayTwoDim(int n, int min, int max)
        {
            intArray = new int[n, n]; 
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    intArray[i, j] = random.Next(min, max);
        }

        public MyArrayTwoDim(int n1, int n2, int min, int max)
        {
            intArray = new int[n1, n2]; 
            for (int i = 0; i < n1; i++)
                for (int j = 0; j < n2; j++)
                    intArray[i, j] = random.Next(min, max);
        }

        public MyArrayTwoDim(string fileName)
        {
            intArray = ReadToFile(fileName);
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get { return intArray[i, j]; }
            set { intArray[i, j] = value; }
        }

        public int Min
        {
            get
            {
                int min = intArray[0, 0]; 
                for (int i = 0; i < intArray.GetLength(0); i++)
                    for (int j = 0; j < intArray.GetLength(1); j++)
                        if (intArray[i, j] < min) min = intArray[i, j];
                return min;
            }
        }
                

        public int Max
        {
            get
            {
                int max = intArray[0, 0];
                for (int i = 0; i < intArray.GetLength(0); i++)
                    for (int j = 0; j < intArray.GetLength(1); j++)
                        if (intArray[i, j] > max) max = intArray[i, j];
                return max;
            }
        }

        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < intArray.GetLength(0); i++)
                    for (int j = 0; j < intArray.GetLength(1); j++)
                        if (intArray[i, j] > 0) count++;
                return count;
            }
        }

        public double Average()
        {
            double sum = 0;
            for (int i = 0; i < intArray.GetLength(0); i++)
                for (int j = 0; j < intArray.GetLength(1); j++)
                    sum += intArray[i, j];
            return sum / intArray.GetLength(0) / intArray.GetLength(1);
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < intArray.GetLength(0); i++)
                for (int j = 0; j < intArray.GetLength(1); j++)
                    sum += intArray[i, j];
            return sum;
        }

        public int Sum(int val)
        {
            int sum = 0;
            int el = 0;
            for (int i = 0; i < intArray.GetLength(0); i++)
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    el = intArray[i, j];
                    if (el > val)
                        sum += el;
                }
                return sum; 
        }

        public void MaxElementIndex(out int index1, out int index2)
        {
            int max = intArray[0, 0];
            index1 = 0;
            index2 = 0;
            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for (int j = 0; j < intArray.GetLength(1); j++)
                    if (intArray[i, j] > max)
                    {
                        index1 = i;
                        index2 = j;
                        max = intArray[i, j];
                    }
            }
        }

        public int[,] GetArray()
        {
            return intArray;
        }

        /// <summary>
        /// Получить элементы массива
        /// </summary> 
        /// <param name="separator"></param>
        /// <returns></returns>
        public string GetElements(char separator = ';')
        {
            string str = string.Empty;

            // Вывод элементов, оставшихся в массиве
            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                string row = string.Empty;

                for (int j = 0; j < intArray.GetLength(1); j++)
                    row += $"{separator} {intArray[i, j]}";

                row = row.TrimStart(new char[] { separator, ' ' });
                str += $"{row}\n";
            }
            return str.TrimEnd('\n');
        }

        public static string GetElements(int[,] array, char separator = ';')
        {
            string str = string.Empty;

            // Вывод элементов, оставшихся в массиве
            for (int i = 0; i < array.GetLength(0); i++)
            {
                string row = string.Empty;

                for (int j = 0; j < array.GetLength(1); j++)
                    row += $"{separator} {array[i, j]}";

                row = row.TrimStart(new char[] { separator, ' ' });
                str += $"{row}\n";
            }
            return str.TrimEnd('\n');
        }

        public static int[,] ReadToFile(string fileName, char separator = ';')
        {
            string[] ss = File.ReadAllLines(fileName);
            if (ss.Length == 0) throw new Exception("Пустой файл");
             
            int[,] array = new int[ss.Length, ss[0].Split(separator).Length];
            for (int i = 0; i < ss.Length; i++)
            {
                string[] temp = ss[i].Split(separator);
                for (int j = 0; j < temp.Length; j++)
                    if (!int.TryParse(temp[j], out array[i, j]))
                        array[i, j] = 0;
            }
            return array;
        }

        public static void WriteToFile(string fileName, int[,] array, char separator = ';')
        {

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fileName);
                if (array.Length == 0) return;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    string row = string.Empty;
                    for (int j = 0; j < array.GetLength(1); j++)
                        row += $"{separator}{array[i, j]}"; 
                    sw.WriteLine(row.TrimStart(separator));
                }
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }

        public override string ToString()
        {             
            return GetElements();
        }

    }
}
