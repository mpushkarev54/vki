using System;

namespace SieveOfEratosthenes {
    class CrazyProgram {
        static void Main() {
            
            int maxNum = int.Parse(Console.ReadLine());

            int[] numsList = new int[maxNum - 1];

            for (int num = 2; num <= maxNum; num++) {
                numsList[num - 2] = num;
            }

            for (int numId = 0; numId < numsList.Length; numId++) {

                if (numsList[numId] != -1) {

                    for (int num = numsList[numId] * 2; num - 2 < numsList.Length; num += numsList[numId]) {
                        numsList[num - 2] = -1;
                    }
                }
            }

            for (int numId = 0; numId < numsList.Length; numId++) {

                if (numsList[numId] != -1) {
                    Console.Write($"{numsList[numId]} ");
                }
            }
        }
    }
}