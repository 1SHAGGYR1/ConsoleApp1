using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MerkulovMLITA
{
    class Program
    {
        private static bool ok;
        private static int position;
        private static char ch;
        private static string enter;
        private static void Read()
        {
            char[] symbols = new char[] { '(', ')', '+', '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', 'x' };
            if (position > enter.Length)
                throw new ArgumentException("Чтение после конца строки.");
            else if (position == enter.Length)
            {
                ch = ' ';
                return;
            }
            if (enter[position] == 's')
            {
                if (enter.Substring(position, 3) == "sin")
                    ch = 's';
                else
                    Error();
                position += 3;
            }
            else if (symbols.Contains(enter[position]))
                ch = enter[position++];
            else
                Error();
        }
        private static void Error()
        {
            Console.WriteLine("Something is wrong!");
            ok = false;
        }
        private static void BeginString()
        {
            if (ok)
            {
                Sinus();
                Stringus();
            }
        }
        private static void Arguments()
        {
            if (ch == 'x') {
                Read();
                SecondArgument();
            }
        }
        private static void SecondArgument()
        {
            if (ok)
            {
                Sign();
                Number();
            }
        }

        private static void Stringus()
        {
            if (ok)
            {
                if (ch == '+')
                {
                    Read();
                    Sinus();
                    Stringus();
                }
            }
        }
        private static void Sinus()
        {
            if (ok)
            {
                if (ch == 's')
                {
                    Read();
                    if (ch == '(')
                    {
                        Read();
                        Minus();
                        Number();
                        Arguments();
                       if (ch == ')')
                            Read();
                        else Error();
                    }
                    else Error();
                }
                else Error();
            }
        }

        private static void Number()
        {
            if (ok)
            {
                char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                if (ch == '0')
                {
                    Read();
                    Fraction();
                }
                else if (numbers.Contains(ch))
                {
                    NedoNumber();
                    Number();
                    Fraction();
                }
            }
        }
        private static void Digits()
        {
            char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            if (ok)
            {
                if (numbers.Contains(ch))
                {
                    Digit();
                    Digits();
                }
            }
        }
        private static void Minus()
        {
            if (ch =='-'){
                Read();
            }
        }
        private static void Sign()
        {
            if (ch =='-'){
                Read();
            }else if (ch =='+'){
                Read();
            }
else Error();
        }
        private static void Digit()
        {
            if (ok)
            {
                char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                if (numbers.Contains(ch))
                {
                    Read();
                }
                else Error();
            }
        }
        private static void NedoNumber()
        {
            if (ok)
            {
                char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                if (numbers.Contains(ch))
                {
                    Read();
                }
                else Error();
            }
        }
        private static void Fraction()
        {
            if (ok)
            {
                if (ch == ',')
                {
                    Read();
                    Digits();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание номер 17. Сумма синусов. \r\nПример: sin(2310x+23,05)+sin(-x+1004)+sin(2,34x-0,1023)");
            while (true)
            {
                ok = true;
                position = 0;
                enter = Console.ReadLine();
                if (enter == "exit")
                    break;
                else if (enter != "")
                {
                    Read();
                    BeginString();
                }
                if (ok)
                    Console.WriteLine("Всё верно!");
                Console.WriteLine("Введите строку снова или напишите exit");
            }
            Console.WriteLine("Нажмите какую-нибудь клавишу.");
            Console.ReadKey();
        }
    }
}