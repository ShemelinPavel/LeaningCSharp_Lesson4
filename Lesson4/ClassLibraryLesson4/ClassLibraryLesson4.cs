using System;
using System.Text.RegularExpressions;

namespace ClassLibraryLesson4
{
    public class ClassLibraryLesson4
    {
        /// <summary>
        /// пауза в консоли
        /// </summary>
        public static void Pause()
        {

            Console.ReadKey();

        }

        /// <summary>
        /// пауза в консоли c текстовым сообщением
        /// </summary>
        /// <param name="message">текст сообщения</param>
        public static void Pause(string message)
        {

            Console.WriteLine(message);
            Console.ReadKey();

        }
        
        /// <summary>
        /// вывод строки сообщения в консоль
        /// </summary>
        /// <param name="Text">текст сообщения</param>
        /// <param name="EndOfString"> true - добавляет в конец возврат каретки (по умолчанию)</param>
        public static void Print(string Text, bool EndOfString = true)
        {

            if (EndOfString)
            {
                Console.WriteLine(Text);
            }
            else
            {
                Console.Write(Text);
            }

        }

        /// <summary>
        /// вывод строки сообщения в консоль
        /// </summary>
        /// <param name="Text">текст сообщения</param>
        /// <param name="arg"> массив параметров</param>
        public static void Print(string Text, params object[] arg)
        {

            Console.WriteLine(Text, arg);

        }

        /// <summary>
        /// вывести в консоль текст вопроса и получить ответ
        /// </summary>
        /// <param name="questionText"> текст вопроса в формате "Введите " + questionText + " :"</param>
        /// <returns>возвратщает введенный в консоли текст ответа</returns>
        public static string MakeQuestion(string questionText)
        {

            Print("Введите " + questionText + " : ", false);

            return Console.ReadLine();

        }

        /// <summary>
        /// очистка экрана
        /// </summary>
        public static void ClearScreen()
        {

            Console.Clear();

        }

        /// <summary>
        /// разбить строку на массив подстрок
        /// </summary>
        /// <param name="s">исходная строка</param>
        /// <param name="splitter">разделитель</param>
        /// <returns>массив подстрок после разделения</returns>
        public static string[] SplitString(string s, string splitter = " ")
        {

            return Regex.Split(s, splitter);

        }

        /// <summary>
        /// очистить экран консоли и вывести сообщение (приветственное)
        /// </summary>
        /// <param name="textMessage"></param>
        public static void PrintTaskWelcomeScreen(string textMessage = "")
        {

            ClearScreen();
            Print(textMessage);

        }
    }

}