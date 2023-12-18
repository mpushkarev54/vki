using System;

namespace SumOfNumbersInALine {
    class CrazyProgram {
        static void Main() {

            List<string> numbersList = new List<string>();
            bool wasDigit = false;

            string inputString = Console.ReadLine();

            for (int i = 0; i < inputString.Length; i++) {
                if (inputString[i] >= '0' && inputString[i] <= '9') {
                    string inputDigit = Convert.ToString(inputString[i]);
                    if (wasDigit) {
                        string lastNumber = numbersList[numbersList.Count - 1];
                        numbersList[numbersList.Count - 1] = lastNumber + inputDigit;
                    } else {
                        numbersList.Add(inputDigit);
                    }
                    wasDigit = true;
                } else {
                    wasDigit = false;
                }
            }

            int sumOfNumbers = 0;

            foreach (string element in numbersList) {
                int number = int.Parse(element);
                sumOfNumbers += number;
                Console.WriteLine(number);
            }

            Console.WriteLine(sumOfNumbers);
        }
    }
}