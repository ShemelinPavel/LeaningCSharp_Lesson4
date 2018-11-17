/*

Shemelin Pavel

2. Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)**Добавьте обработку ситуации отсутствия файла на диске.

*/

namespace Lesson4
{

    using System;
    using System.IO;
    using ClassLibraryLesson4;

    partial class Lesson4
    {

        public class StaticClass
        {

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

        }

        public static void Task2()
        {

            string welcome = "Вы выбрали демонстрацию работы с массивом в виде статического класса.\n";
            welcome = welcome + "Давайте начнем\n";

            ClassLibraryLesson4.PrintTaskWelcomeScreen(welcome);

            int[] arrayNumbers = new int[20];

            //заполнение массива оставим старым из Task1
            Random rand = new Random();
            for (int counter = 0; counter < arrayNumbers.Length; counter++) arrayNumbers[counter] = rand.Next(-10000, 10000);

            //вывод массива на экран
            ClassLibraryLesson4.Print("Содержимое массива:");
            StaticClass.PrintArray(arrayNumbers);

            //перебор пар
            ClassLibraryLesson4.Print("Анализируем пары...");
            const int denominator = 3;

            uint counterPairs = StaticClass.CountArrayPairs(arrayNumbers, denominator);

            ClassLibraryLesson4.Print("");
            ClassLibraryLesson4.Print($"Найдено {counterPairs} пар, где только одно из значений делится на  {denominator}");

            string file = Path.GetTempPath() + "array.txt";

            ClassLibraryLesson4.Print($"Сохранение массива в файл: {file}");

            bool saveStatus = StaticClass.SafeArrayToDisk(arrayNumbers, file);

            if (saveStatus) ClassLibraryLesson4.Print("Запись успешна.");

            ClassLibraryLesson4.Pause("Нажмите любую клавишу.");

        }

    }

}
