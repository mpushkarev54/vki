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
                int convertedToDecimalBase = ConvertToDecimal(initalNum, fromBase);
                string convertedToNewBase = ConvertFromDecimal(convertedToDecimalBase, toBase);
                return convertedToNewBase;
            } else {
                return "error";
            }
        }

        static int ConvertToDecimal(string initalNum, int fromBase) {

            initalNum = initalNum.ToUpper();

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] inDigits = new int[initalNum.Length];

            for (int symbID = initalNum.Length - 1; symbID >= 0; symbID--) {

                char symb = initalNum[symbID];

                if (symb <= '9') {
                    inDigits[symbID] = int.Parse(symb.ToString());
                } else {
                    int letterID = alphabet.IndexOf(symb.ToString());
                    inDigits[symbID] = alphabet[letterID];
                }
            }

            double result = 0;
            double pow = inDigits.Length - 1;

            foreach (int digit in inDigits) {
                result += digit * Math.Pow(Convert.ToDouble(fromBase), pow);
                pow--;
            }

            return Convert.ToInt32(result);
        }

        static string ConvertFromDecimal(int initalNum, int toBase) {

            List<int> inDigitsReverse = new List<int>();

            int quotient = initalNum;

            while (quotient >= toBase) {
                int remainder = quotient % toBase;
                inDigitsReverse.Add(remainder);
                quotient /= toBase;
            }

            inDigitsReverse.Add(quotient);

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";

            for (int digID = inDigitsReverse.Count - 1; digID >= 0; digID--) {

                int digit = inDigitsReverse[digID];

                if (digit < 10) {
                    result += Convert.ToString(digit);
                } else {
                    result += alphabet[digit - 10];
                }
            }

            return result;
        }
    }
}