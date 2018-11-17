/*
 
Shemelin Pavel

4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.

*/

namespace Lesson4
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using ClassLibraryLesson4;

    partial class Lesson4
    {

        public struct Account
        {

            public string Login;
            public string Password;

            public Account(string log, string pass)
            {
                if (log == "") throw new ArgumentException("Логин не может быть пустым!");

                Login = log;
                Password = pass;
            }

            //получение хэш-кода не перегружаем - сложно, сложно, не понятно!
            public override bool Equals(Object obj)
            {
                bool result = false;

                try
                {
                    Account curObj = (Account)obj;

                    result = (this.Login == curObj.Login && this.Password == curObj.Password) ? true : false;
                }
                catch
                {
                    throw new ArgumentException("Ошибка операции сравнения - неверный тип!");
                }
                return result;
            }
            public override string ToString()
            {
                return $"Login: {this.Login} Password: {this.Password}";
            }
        }

        public static List<Account> ReadAccountsFromFile(string fileName)
        {
            List<Account> result = new List<Account> { };

            StreamReader stream = null;
            try
            {
                stream = new StreamReader(fileName);
                while (!(stream.EndOfStream))
                {
                    string textLine = stream.ReadLine();
                    string[] logPass = ClassLibraryLesson4.SplitString(textLine, ",");
                    try
                    {
                        Account acc;
                        acc.Login = logPass[0];
                        acc.Password = (logPass.Length > 1) ? logPass[1] : "";

                        result.Add(acc);
                    }
                    catch (Exception ex)
                    {
                        ClassLibraryLesson4.Print($"Ошибка преобразования строки: {textLine} в структуру Account {ex.Message}");
                    }
                }
                //пустые строки игнорируем
                stream.Close();
            }
            catch (Exception ex)
            {
                ClassLibraryLesson4.Print($"Что-то пошло не так! {ex.Message}");
            }
            return result;
        }

        public static void Task4()
        {

            string Welcome = "Вы выбрали задачу подбора логина и пароля из файла\n";
            Welcome = Welcome + "Давайте начнем.\n";

            ClassLibraryLesson4.PrintTaskWelcomeScreen(Welcome);

            //string file = @"C:\Temp\p.txt";
            string file = ClassLibraryLesson4.MakeQuestion("имя файла");

            List<Account> accounts = ReadAccountsFromFile(file);

            if (accounts.Count == 0)
            {
                ClassLibraryLesson4.Print("Чтение файла с данными паролей неудачно!");
            }
            else
            {
                bool successFlag = false;

                //главный логин
                Account rootAccount;
                rootAccount.Login = "root";
                rootAccount.Password = "GeekBrains";

                foreach (var item in accounts)
                {
                    if (item.Equals(rootAccount))
                    {
                        ClassLibraryLesson4.Print($"Подошло: {item.ToString()}");
                        successFlag = true;
                    }
                }

                if (!(successFlag)) ClassLibraryLesson4.Print("Ничего из файла не подошло!");
            }
            ClassLibraryLesson4.Pause("Нажмите любую клавишу.");
        }
    }
}