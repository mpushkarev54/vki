using System;

namespace SearchForPrimeNumbersPro {
    class CrazyProgram {
        static void Main() {

            List<int> primesList = new List<int>();
            // приветствие
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine(RepeatString("~", 65));
            Console.WriteLine("Это программа для поиска всех простых чисел");
            Console.WriteLine("от 0 до введённого вами числа.");
            Console.WriteLine(RepeatString("~", 65));
            Console.Write("Введите ваше число:\n>> ");

            while (true) {
                // целевое число
                int target = int.Parse(Console.ReadLine());
                // пробегаем от 2 до целевого включительно
                for (int num = 2; num <= target; num++) {

                    int counter = 0;
                    // подсчёт количества делителей кроме 1 и целевого числа
                    for (int d = 2; d < num; d++) {
                        if (num % d == 0) {
                            counter++;
                        }
                    }
                    // если таковых не имеется - число простое
                    if (counter == 0) primesList.Add(num);
                }

                // создаём таблицу из списка простых чисел в ≤ 10 колонок
                CreateTable($"Простые числа от 0 до {target}", primesList, 10);
                // очищаем список простых чисел
                primesList.Clear();
                // спрашиваем, нужно ли ещё делать таблицу
                Console.WriteLine($"\n{RepeatString("~", 65)}");
                Console.WriteLine("Нужна ещё одна таблица?");
                Console.Write("Просто введите другое число:\n>> ");
            }
        }

        // внутренний метод для создания таблиц
        static void CreateTable(string tableTitle, List<int> primesList, int maxColumns) {

            // получаем максимально возможное кол-во цифр в числе
            int maxDigits = GetDigitsCountInNumber(primesList.Max());
            // считаем количество столбцов
            int columns = primesList.Count >= maxColumns ? maxColumns : primesList.Count();
            // и кол-во пустых ячеек
            int overflow = primesList.Count() % columns;
            // отступ от чисел в ячейке
            int maxSpace = columns * maxDigits + columns * 2 + (maxColumns + 1);
            // отступ у заголовка (и небольшой костыль)
            int titleMargin = (maxSpace - tableTitle.Length) / 2 >= 0 ? (maxSpace - tableTitle.Length) / 2 : 0;

            // выводим заголовок и печатаем верхнюю грань
            Console.WriteLine($"{RepeatString(" ", titleMargin)}{tableTitle}{RepeatString(" ", titleMargin)}");
            PrintTableEdge(0);
            // пробегаемся по списку чисел от начала до конца
            for (int i = 0; i <= primesList.Count(); i++) {
                // если список закончился
                if (i == primesList.Count()) {
                    // и есть пустые ячейки
                    if (overflow > 0) {
                        // дорисовать их
                        Console.Write(RepeatString(RepeatString(" ", maxDigits + 1) + " │", columns - overflow) + "\n");
                    } else {
                        // иначе просто перенести строку
                        Console.WriteLine();
                    }
                // во время прохождения списка
                // если ячейка не последняя
                } else if (i % columns != 0) {
                    // выводим ячейку
                    Console.Write(RepeatString(" ", maxDigits - GetDigitsCountInNumber(primesList[i]) + 1) + primesList[i] + " │");
                // если ячейка последняя
                } else if (i % columns == 0) {
                    // и элемент не первый
                    if (i != 0) {
                        // вывести грань таблицы между строками
                        Console.WriteLine();
                        PrintTableEdge(1);
                    }
                    // вывести начало следующей
                    Console.Write("\n│" + RepeatString(" ", maxDigits - GetDigitsCountInNumber(primesList[i]) + 1) + primesList[i] + " │");
                }
            }
            // вывести нижнюю границу
            PrintTableEdge(2);

            // внутренний метод печати рамок таблицы
            void PrintTableEdge(int type) {
                // всевозможные грани таблиц
                string[,] corners = new string[,] {{ "┌", "┬", "┐" },
                                                   { "├", "┼", "┤" },
                                                   { "└", "┴", "┘" },
                                                   { "┌", "─", "┐" },
                                                   { "├", "─", "┤" },
                                                   { "├", "┬", "┤" },
                                                   { "├", "┴", "┤" },
                                                   { "└", "─", "┘" }};
                // левый угол
                Console.Write(corners[type, 0]);
                // первая ячейка
                Console.Write(RepeatString("─", maxDigits + 2));
                // остальные ячейки
                Console.Write(RepeatString(corners[type, 1] + RepeatString("─", maxDigits + 2), columns - 1));
                // правый угол
                Console.Write(corners[type, 2]);
            }
        }

        // подсчёт цифр в числе
        static int GetDigitsCountInNumber(int num) {

            int digitsCount = 0;

            while (num > 0) {
                num /= 10;
                digitsCount++;
            }

            return digitsCount;
        }
        // повторение строки
        static string RepeatString(string str, int repeat) {
            return string.Join("", Enumerable.Repeat(str, repeat));
        }
    }
}