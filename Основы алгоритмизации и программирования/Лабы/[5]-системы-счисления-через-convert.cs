using System;

namespace BaseToBase {
    class CrazyProgram {
        static void Main() {

            Console.Write("Ваше число: ");
            string initalNum = Console.ReadLine();
            Console.Write("Его с/сч: ");
            int initalNumBase = int.Parse(Console.ReadLine());
            Console.Write("Перевод в с/сч: ");
            int targetNumBase = int.Parse(Console.ReadLine());

            string result = ConvertBaseToBase(initalNum, initalNumBase, targetNumBase);

            if (result != "error") {
                Console.WriteLine($"Число {initalNum} в {initalNumBase}-ной системе счисления - это {result} в {targetNumBase}-ной системе счисления.");
            } else {
                Console.WriteLine("Что-то пошло не так или не туда :(");
            }
        }

        static string ConvertBaseToBase(string initalNum, int fromBase, int toBase) {
            
            if (fromBase >= 2 && toBase >= 2) {
                int convertedToDecimalBase = Convert.ToInt32(initalNum, fromBase);
                string convertedToNewBase = Convert.ToString(convertedToDecimalBase, toBase);
                return convertedToNewBase;
            } else {
                return "error";
            }
        }
    }
}