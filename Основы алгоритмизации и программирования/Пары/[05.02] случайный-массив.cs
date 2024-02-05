namespace RandomArray {
    class Program {
        static void Main() {

            const int arrLength = 10;
            const int arrRandMax = 10;
            const int arrRandMin = -10;

            int[] arr = new int[arrLength];
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++) {
                arr[i] = rand.Next(arrRandMin, arrRandMax);
            }

            int sumOfEven = 0;
            int minInArr = arrRandMax;

            for (int i = 0; i < arr.Length; i++) {

                if (arr[i] < minInArr) {
                    minInArr = arr[i];
                }

                if (arr[i] % 2 == 0) {
                    sumOfEven += arr[i];
                }
            }

            Console.WriteLine($"[{minInArr}] [{sumOfEven}]");
        }
    }
}

