namespace BubbleSort {
    class Program {

        private const int ARR_MIN = 1;
        private const int ARR_MAX = 99;
        private const int ARR_LENGTH = 15;

        static void Main() {

            RandomTools randomTools = new RandomTools();

            int[] arr = randomTools.GetArrWithRandNums(ARR_MIN, ARR_MAX, ARR_LENGTH);
            int[] sortedArr = BubbleSort.Sort(arr);

            Console.WriteLine("* Сортировка случайного списка пузырьком");
            Console.WriteLine($"- Неотсортированный список: [{String.Join(", ", arr)}]");
            Console.WriteLine($"- Отсортированный список:   [{String.Join(", ", sortedArr)}]");
        }
    }

    class BubbleSort {

        public static int[] Sort(int[] originalArr) {

            int[] arr = originalArr.ToArray();
            int shiftFromEnd = 0;

            while (shiftFromEnd < arr.Length - 1) {

                for (int idInList = 0; idInList < (arr.Length - 1 - shiftFromEnd); idInList++) {

                    if (arr[idInList] > arr[idInList + 1]) {

                        int firstElement = arr[idInList + 1];
                        int secondElement = arr[idInList];

                        arr[idInList] = firstElement;
                        arr[idInList + 1] = secondElement;
                    }
                }

                shiftFromEnd++;
            }

            return arr;
        }
    }

    class RandomTools {

        private Random rand = new Random();

        public int[] GetArrWithRandNums(int min, int max, int length) {

            int[] arrOfNums = new int[length];

            for (int i = 0; i < arrOfNums.Length; i++) {
                arrOfNums[i] = rand.Next(min, max);
            }

            return arrOfNums;
        }
    }
}