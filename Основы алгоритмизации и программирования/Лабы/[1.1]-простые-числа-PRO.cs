using System;

namespace SearchForPrimeNumbersPro {
    class CrazyProgram {
        static void Main() {

            List<int> primesList = new List<int>();

            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine(RepeatString("~", 65));
            Console.WriteLine("Это программа для поиска всех простых чисел");
            Console.WriteLine("от 0 до введённого вами числа.");
            Console.WriteLine(RepeatString("~", 65));
            Console.Write("Введите ваше число:\n>> ");

            while (true) {

                int target = int.Parse(Console.ReadLine());

                for (int num = 2; num <= target; num++) {

                    int counter = 0;

                    for (int d = 2; d < num; d++) {

                        if (num % d == 0) {
                            counter++;
                        }
                    }

                    if (counter == 0) {
                        primesList.Add(num);
                    }
                }

                CreateTable($"Простые числа от 0 до {target}", primesList, 10);

                primesList.Clear();

                Console.WriteLine($"\n{RepeatString("~", 65)}");
                Console.WriteLine("Нужна ещё одна таблица?");
                Console.Write("Просто введите другое число:\n>> ");
            }
        }

        static void CreateTable(string tableTitle, List<int> primesList, int maxColumns) {

            int maxDigits = GetDigitsCountInNumber(primesList.Max());
            int columns = primesList.Count >= maxColumns ? maxColumns : primesList.Count();
            int overflow = primesList.Count() % columns;
            int maxSpace = columns * maxDigits + columns * 2 + (maxColumns + 1);
            int titleMargin = (maxSpace - tableTitle.Length) / 2 >= 0 ? (maxSpace - tableTitle.Length) / 2 : 0;

            Console.WriteLine($"{RepeatString(" ", titleMargin)}{tableTitle}{RepeatString(" ", titleMargin)}");
            PrintTableEdge(0);

            for (int i = 0; i <= primesList.Count(); i++) {

                if (i == primesList.Count()) {

                    if (overflow > 0) {
                        Console.Write(RepeatString(RepeatString(" ", maxDigits + 1) + " │", columns - overflow) + "\n");
                    } else {
                        Console.WriteLine();
                    }
                } else if (i % columns != 0) {
                    Console.Write(RepeatString(" ", maxDigits - GetDigitsCountInNumber(primesList[i]) + 1) + primesList[i] + " │");
                } else if (i % columns == 0) {

                    if (i != 0) {
                        Console.WriteLine();
                        PrintTableEdge(1);
                    }
                    Console.Write("\n│" + RepeatString(" ", maxDigits - GetDigitsCountInNumber(primesList[i]) + 1) + primesList[i] + " │");
                }
            }

            PrintTableEdge(2);


            void PrintTableEdge(int type) {

                string[,] corners = new string[,] {{ "┌", "┬", "┐" },
                                                   { "├", "┼", "┤" },
                                                   { "└", "┴", "┘" },
                                                   { "┌", "─", "┐" },
                                                   { "├", "─", "┤" },
                                                   { "├", "┬", "┤" },
                                                   { "├", "┴", "┤" },
                                                   { "└", "─", "┘" }};

                Console.Write(corners[type, 0]);
                Console.Write(RepeatString("─", maxDigits + 2));
                Console.Write(RepeatString(corners[type, 1] + RepeatString("─", maxDigits + 2), columns - 1));
                Console.Write(corners[type, 2]);
            }
        }

        static int GetDigitsCountInNumber(int num) {

            int digitsCount = 0;

            while (num > 0) {
                num /= 10;
                digitsCount++;
            }

            return digitsCount;
        }

        static string RepeatString(string str, int repeat) {
            return string.Join("", Enumerable.Repeat(str, repeat));
        }
    }
}