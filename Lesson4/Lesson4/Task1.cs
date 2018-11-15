namespace Lesson4
{

    using System;
    using ClassLibraryLesson4;

    partial class Lesson4
    {

        public static void Task1()
        {

            string welcome = "Вы выбрали демонстрацию работы с массивом.\n";
            welcome = welcome + "Это интересно!\n";
            welcome = welcome + "Давайте начнем\n";

            ClassLibraryLesson4.PrintTaskWelcomeScreen(welcome);

            int[] arrayNumbers = new int[20];

            //рандом генератор
            Random rand = new Random();

            //заполнение массива
            for (int counter = 0; counter < arrayNumbers.Length; counter++)
            {

                arrayNumbers[counter] = rand.Next(-10000, 10000);

            }

            //вывод массива на экран
            ClassLibraryLesson4.Print("Содержимое массива:");
            foreach (var item in arrayNumbers)
            {

                ClassLibraryLesson4.Print(item.ToString() + " ", false);

            }

            ClassLibraryLesson4.Print("\n");

            //перебор пар

            ClassLibraryLesson4.Print("Анализируем пары...");

            ushort counterPairs = 0;
            const int denominator = 3;

            for (int counter = 0; counter < arrayNumbers.Length - 1; counter++)
            {

                ClassLibraryLesson4.Print($"{arrayNumbers[counter]} {arrayNumbers[counter + 1]}");

                if (arrayNumbers[counter] % denominator == 0 ^ arrayNumbers[counter + 1] % denominator == 0)
                {

                    counterPairs++;

                }

            }

            ClassLibraryLesson4.Print("");
            ClassLibraryLesson4.Print($"Найдено {counterPairs} пар, где только одно из значений делится на  {denominator}");
            ClassLibraryLesson4.Pause("Нажмите любую клавишу.");

        }

    }

}
