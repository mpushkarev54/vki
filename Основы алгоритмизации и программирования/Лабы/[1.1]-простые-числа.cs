using System;

namespace SearchForPrimeNumbers {
    class CrazyProgram {
        static void Main() {

            List<int> primesList = new List<int>();
            
            int target = int.Parse(Console.ReadLine());

            for (int num = 2; num <= target; num++) {
                int counter = 0;
                for (int d = 2; d < num; d++) {
                    if (num % d == 0) {
                        counter++;
                    }
                }
                if (counter == 0) primesList.Add(num);
            }

            foreach (int num in primesList) {
                Console.Write($"> {num} ");
            }
        }
    }
}