namespace Lesson4
{
    using System;
    using ClassLibraryLesson4;

    partial class Lesson4
    {

        static void StartMenu()
        {

            string Welcome = "Добрый день, пользователь!\n";
            Welcome = Welcome + "Выберите чем бы Вы хотели заняться:\n";
            Welcome = Welcome + "Меню на сегодня:\n";
            Welcome = Welcome + "1 - Работа массивом\n";
            Welcome = Welcome + "2 - Подсчет числа знаков в числе\n";
            Welcome = Welcome + "3 - Работа с дробями\n";

            Welcome = Welcome + "0 - Выход из программы\n";

            while (true)
            {

                ClassLibraryLesson4.PrintTaskWelcomeScreen(Welcome);

                ConsoleKeyInfo userChooseKey = Console.ReadKey(true);

                switch (userChooseKey.Key)
                {

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Task1();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ClassLibraryLesson4.Print("Делал в ДЗ №2");
                        ClassLibraryLesson4.Pause("Нажмите любую клавишу.");
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //Task3();
                        break;

                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        Environment.Exit(0); // на выход
                        break;

                }
            }

        }

    }

}