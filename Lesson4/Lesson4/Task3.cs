/*

Shemelin Pavel

а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки - не делал
е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)

*/

namespace Lesson4
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using ClassLibraryLesson4;

    partial class Lesson4
    {

        public class StaticClass_Task3
        {

            private int[] innerArray;

            public StaticClass_Task3()
            {
                innerArray = new int[1];
            }

            public StaticClass_Task3(uint size, int min, int max)
            {

                innerArray = new int[size];

                Random rand = new Random();

                for (int counter = 0; counter < innerArray.Length; counter++) innerArray[counter] = rand.Next(min, max);

            }

            public int[] Array
            {
                get {return innerArray; }
            }

            /// <summary>
            /// подсчитывает число "пар" в массив
            /// </summary>
            /// <param name="arrayPairs">массив</param>
            /// <param name="denom"></param>
            /// <returns>количество пар</returns>
            public static uint CountArrayPairs(int[] arrayPairs, uint denom)
            {

                if (denom < 1) throw new ArgumentException("Делитель для поиска пар не может быть равен 0!");

                ushort countPairs = 0;
                for (int counter = 0; counter < arrayPairs.Length - 1; counter++)
                {

                    ClassLibraryLesson4.Print($"{arrayPairs[counter]} {arrayPairs[counter + 1]}");

                    if (arrayPairs[counter] % denom == 0 ^ arrayPairs[counter + 1] % denom == 0) countPairs++;

                }

                return countPairs;

            }

            /// <summary>
            /// вывод на экран консоли в одну строку содержимого массива
            /// </summary>
            /// <param name="curArray">массив</param>
            public static void PrintArray(int[] curArray)
            {

                foreach (var item in curArray) ClassLibraryLesson4.Print(item.ToString() + " ", false);

                ClassLibraryLesson4.Print("\n");

            }

            /// <summary>
            /// записать массив на диск
            /// </summary>
            /// <param name="curArray">массив</param>
            /// <param name="fileName">имя файла</param>
            /// <returns>результат записи</returns>
            public static bool SafeArrayToDisk(int[] curArray, string fileName)
            {

                StreamWriter stream = null;

                bool flag = true;

                try
                {

                    stream = new StreamWriter(fileName, false);
                    foreach (var item in curArray) stream.WriteLine(item);
                    stream.Close();

                }
                catch (DirectoryNotFoundException ex)
                {

                    ClassLibraryLesson4.Print($"Каталог не обнаружен! {ex.Message}");
                    flag = false;
                }
                catch (Exception ex)
                {

                    ClassLibraryLesson4.Print($"Что-то пошло не так! {ex.Message}");
                    flag = false;

                }

                return flag;

            }

            public int Sum
            {

                get
                {

                    int summ = 0;
                    foreach (var item in this.innerArray) summ = summ + item;
                    return summ;

                }
            }

            public int[] Inverse()
            {

                int[] newArray = new int[this.innerArray.Length];
                for (int i = 0; i < this.innerArray.Length; i++) newArray[i] = -this.innerArray[i];

                return newArray;

            }

            public void Multi(int multiplicator)
            {
                for (int i = 0; i < this.innerArray.Length; i++) this.innerArray[i] = this.innerArray[i] * multiplicator;
            }

            public uint MaxCount
            {
                get
                {

                    uint count = 0;
                    int max = int.MinValue;

                    foreach (var item in this.innerArray)
                    {

                        if(item > max)
                        {

                            max = item;
                            count = 1;

                        }
                        else if(item == max)
                        {
                            count++;
                        }


                    }
                    return count;
                }
            }

            public Dictionary<int, int> DictFrequency
            {

                get
                {

                    Dictionary<int, int> dict = new Dictionary<int, int>(this.innerArray.Length);

                    foreach (var item in this.innerArray)
                    {

                        if (dict.ContainsKey(item))
                        {
                            dict[item] = dict[item] + 1;
                        }
                        else
                        {
                            dict.Add(item, 1);
                        }

                    }
                    return dict;
                }

            }

        }

        public static void Task3()
        {

            string welcome = "Вы выбрали демонстрацию работы с массивом в виде статического класса (продолжение).\n";
            welcome = welcome + "Давайте начнем\n";

            ClassLibraryLesson4.PrintTaskWelcomeScreen(welcome);

            // 10000 большой разбег не будет "показательно" работать частотный словарь
            //StaticClass_Task3 objectStaticClass_Task3 = new StaticClass_Task3(20, -10000, 10000);

            StaticClass_Task3 objectStaticClass_Task3 = new StaticClass_Task3(20, 1, 10);

            //вывод массива на экран
            ClassLibraryLesson4.Print("Содержимое массива:");
            StaticClass_Task3.PrintArray(objectStaticClass_Task3.Array);

            //перебор пар
            ClassLibraryLesson4.Print("Анализируем пары...");
            const int denominator = 3;

            uint counterPairs = StaticClass_Task3.CountArrayPairs(objectStaticClass_Task3.Array, denominator);

            ClassLibraryLesson4.Print("");
            ClassLibraryLesson4.Print($"Найдено {counterPairs} пар, где только одно из значений делится на  {denominator}");

            string file = Path.GetTempPath() + "array.txt";

            //запись на диск
            ClassLibraryLesson4.Print($"Сохранение массива в файл: {file}");

            bool saveStatus = StaticClass_Task3.SafeArrayToDisk(objectStaticClass_Task3.Array, file);

            if (saveStatus) ClassLibraryLesson4.Print("Запись успешна.");

            //сумма элементов
            ClassLibraryLesson4.Print($"Сумма элементов массива: {objectStaticClass_Task3.Sum}");

            //умножение
            int multi = 5;
            ClassLibraryLesson4.Print($"Умножение массива на {multi}:");

            objectStaticClass_Task3.Multi(multi);

            ClassLibraryLesson4.Print("Содержимое массива:");
            StaticClass_Task3.PrintArray(objectStaticClass_Task3.Array);

            //инверсия

            ClassLibraryLesson4.Print("Инверсия массива:");

            int[] inverseArray = objectStaticClass_Task3.Inverse();

            ClassLibraryLesson4.Print("Содержимое массива:");
            StaticClass_Task3.PrintArray(inverseArray);

            //поиск количества максимальных значений
            ClassLibraryLesson4.Print($"Количество максимальных значений: {objectStaticClass_Task3.MaxCount}");

            ClassLibraryLesson4.Print("\n");

            //частотный словарь

            ClassLibraryLesson4.Print("Частотный словарь");
            Dictionary<int, int> dictFreq = objectStaticClass_Task3.DictFrequency;

            foreach(KeyValuePair<int, int> item in dictFreq)
            {
                ClassLibraryLesson4.Print($"Значение: {item.Key} частота: {item.Value}");
            }

            ClassLibraryLesson4.Pause("Нажмите любую клавишу.");

        }

    }

}
