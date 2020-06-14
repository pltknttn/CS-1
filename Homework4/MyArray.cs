using System;
using System.IO;

namespace Homework4
{    
    public class MyArray
    {
        Random random = new Random();
        int[] intArray;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MyArray()
        {
            intArray = new int[0];
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n">Размерность</param> 
        /// <param name="el">Значение элементов</param>  
        public MyArray(int n, int el)
        {
            intArray = new int[n];
            for (int i = 0; i < n; i++)
                intArray[i] = el;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n">Размерность</param> 
        public MyArray(int n) : this(n, 0)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n">Размерность</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public MyArray(int n, int min, int max): this(n, min, max, 1)
        {            
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n">Размерность</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="step">Шаг заполнения элементов массива</param>
        public MyArray(int n, int min, int max, int step)
        {
            intArray = new int[n];

            for (int i = 0; i < n && n > step; i += step)
            {
                intArray[i] = random.Next(min, max + 1);
            }
        }

        public MyArray(string fileName)
        {
            intArray = ReadToFile(fileName);
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i]
        {
            get { return intArray[i]; }
            set { intArray[i] = value; }
        }

        /// <summary>
        /// Длина массива
        /// </summary>
        public int Length
        {
            get
            {
                return intArray.Length;
            }
        }

        /// <summary>
        /// Сумма элементов
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int element in intArray)
                    sum += element;
                return sum;
            }
        }

        /// <summary>
        /// Максимальный элемент в массиве
        /// </summary>
        public int Max
        {
            get
            {
                // Находим максимальный элемент
                int max = intArray[0];

                for (int i = 1; i < intArray.Length; i++)
                    if (intArray[i] > max) max = intArray[i];
                return max;
            }
        }

        /// <summary>
        /// Минимальный элемент в массиве
        /// </summary>
        public int Min
        {
            get
            {
                // Находим минимальный элемент
                int min = intArray[0];
                for (int i = 1; i < intArray.Length; i++)
                    if (intArray[i] < min) min = intArray[i];
                return min;
            }
        }

        /// <summary>
        /// Среднеарифметическая сумма элементов
        /// </summary>
        public double Average
        {
            get
            {
                double sum = 0;
                int count = 0;

                foreach (int element in intArray)
                {
                    sum += element;
                    count++;
                }
                return count > 0 ? sum / count : 0;
            }
        }

        /// <summary>
        /// Кол-во максимальных элементов в массиве
        /// </summary>
        public int MaxCount
        {
            get
            {
                int maxElement = Max;
                int count = 0;
                for (int i = 0; i < intArray.Length; i++)
                    if (intArray[i] == maxElement) count++;
                return count;
            }
        }

        /// <summary>
        /// Умножить на число
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] Multi(int num)
        {
            int[] result = new int[intArray.Length];
            for (int i = 0; i < intArray.Length; i++)
            {
                result[i] = num * intArray[i];
            }
            return result;
        }

        /// <summary>
        /// Умножить на число
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static MyArray Multi(MyArray array, int num)
        {
            MyArray myArray = new MyArray(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                myArray[i] = num * array[i];
            }

            return myArray;
        }

        /// <summary>
        /// Умножить на число
        /// </summary>
        /// <param name="num"></param> 
        public static void Multi(ref MyArray array, int num)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = num * array[i];
            }
        }

        /// <summary>
        /// Умножить на число
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static MyArray operator *(MyArray array, int num)
        {
            return Multi(array, num);
        }

        /// <summary>
        /// Изменить знак всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            return Multi(-1);
        }

        /// <summary>
        /// Изменить знак всех элементов массива MyArray
        /// </summary> 
        public static MyArray Inverse(MyArray array)
        {
            return Multi(array, -1);
        }

        /// <summary>
        /// Изменить знак всех элементов массива MyArray
        /// </summary> 
        public static void Inverse(ref MyArray array)
        {
            Multi(array, -1);
        }

        /// <summary>
        /// Копия массива
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int[] Copy(int low, int high)
        {
            int[] result = new int[high - low + 1];

            for (int i = low; i <= high; ++i)
            {
                result[i] = intArray[i];
            }

            return result;
        }

        /// <summary>
        /// Копия массива
        /// </summary>
        /// <returns></returns>
        public int[] Copy()
        {
            return Copy(0, intArray.Length - 1);
        }

        /// <summary>
        /// Копия MyArray
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static MyArray Copy(MyArray array)
        {
            MyArray myArray = new MyArray(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                myArray[i] = array[i];
            }

            return myArray;
        }

        /// <summary>
        /// Изменить размер массива
        /// </summary>
        /// <param name="newSize"></param>
        public void Resize(int newSize)
        {
            if (newSize == 0) return;

            int[] newArray = new int[newSize];

            for (int i = 0; i < newSize; i++)
            {
                newArray[i] = intArray[i];
            }

            intArray = newArray;
        }

        /// <summary>
        /// Изменить размер массива
        /// </summary>
        /// <param name="array"></param>
        /// <param name="newSize"></param>
        public static void Resize(ref MyArray array, int newSize)
        {
            if (newSize == 0) return;

            MyArray newArray = new MyArray(newSize);

            for (int i = 0; i < newSize; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        /// <summary>
        /// Объединить с массивом
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] Merge(int[] array)
        {
            int[] result = new int[Length + array.Length];
            int j = 0;

            for (int i = 0; i < intArray.Length; i++, j++)
            {
                result[j] = intArray[i];
            }

            for (int i = 0; i < array.Length; i++, j++)
            {
                result[j] = array[i];
            }

            return result;
        }

        /// <summary>
        /// Объединить 2 массива
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static MyArray Merge(MyArray array1, MyArray array2)
        {
            MyArray result = new MyArray(array1.Length + array2.Length);
            int j = 0;

            for (int i = 0; i < array1.Length; i++, j++)
            {
                result[j] = array1[i];
            }

            for (int i = 0; i < array2.Length; i++, j++)
            {
                result[j] = array2[i];
            }

            return result;
        }

        /// <summary>
        /// Обмен значениями
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Swap(int i, int j)
        {
            int el_i = intArray[i];
            intArray[i] = intArray[j];
            intArray[j] = el_i; 
        }

        public void Sort()
        {
            Array.Sort(intArray);
        }

        /// <summary>
        /// Сортируем методом пузырька
        /// </summary>
        public void BubbleSort()
        { 
            for (int i = 0; i < intArray.Length; i++)
                for (int j = 0; j < intArray.Length - 1; j++)
                    if (intArray[j] > intArray[j + 1])//Сравниваем соседние элементы
                    {
                        // Обмениваем элементы местами
                        int t = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = t;
                    }
        }

        /// <summary>
        /// Бинарный поиск в данных
        /// </summary>
        /// <param name="searchElement"></param>
        /// <returns></returns>
        public int BinarySearch(int searchElement)
        {
            int low = 0; // Нижняя граница области поиска
            int high = intArray.Length - 1; // Верхняя граница области поиска
            int middle = (low + high + 1) / 2; // Средний элемент
            int location = -1; // Возвращаемое значение; -1, если ключ не найден

            do // Цикл поиска элемента массива
            {    
                // Если элемент найден в середине диапазона
                if (searchElement == intArray[middle])
                    location = middle; // Ключ найден в текущей середине

                // Средний элемент слишком велик
                else if (searchElement < intArray[middle])
                    high = middle - 1; // Исключить верхнюю половину
                else // Средний элемент слишком мал
                    low = middle + 1; // Исключить нижнюю половину

                middle = (low + high + 1) / 2; // Вычисление середины
            } while ((low <= high) && (location == -1));

            return location; // Вернуть позицию ключа поиска
        }

        /// <summary>
        /// Получить элементы массива
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string GetElements(int low, int high, char separator = ';')
        {
            string str = string.Empty;
            
            // Вывод элементов, оставшихся в массиве
            for (int i = low; i <= high; ++i)
                str += $"{separator} {intArray[i]}";

            return str.TrimStart(new char[] { separator, ' ' });
        }

        /// <summary>
        /// Получить ссылку на массив
        /// </summary>
        /// <returns></returns>
        public int[] GetArray()
        {
            return intArray;
        }
                
        public MyArray GetMyArray()
        {
            return this;
        }

        public static int[] ReadToFile(string fileName)
        {
            string[] ss = File.ReadAllLines(fileName);
            if (ss.Length == 0) throw new Exception("Пустой файл");

            int[] array = new int[ss.Length];
            string s;
            int el;
            for (int i = 0; i < ss.Length; i++)
            {
                s = ss[i];
                if (!int.TryParse(s, out array[i]))
                    array[i] = 0;
            }

            return array;
        }

        public static void WriteToFile(string fileName, int[] array)
        {
            
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fileName);                
                if (array.Length == 0) return;

                for (int i = 0; i < array.Length; i++)
                    sw.WriteLine(array[i]); 
            } 
            finally
            {
                if (sw != null) sw.Close();
            }
        }

        public override string ToString()
        {
            return GetElements(0, intArray.Length - 1);
        }
    }
}
