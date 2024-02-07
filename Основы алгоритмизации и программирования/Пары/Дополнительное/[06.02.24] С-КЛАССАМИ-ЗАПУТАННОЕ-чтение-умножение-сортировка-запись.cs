namespace ConsoleApp2 {
    class Program {
        static void Main() {

            const string inputFile = "a.txt";
            const string outputFile = "b.txt";

            Console.Write($"Заполнить файл {inputFile} случайными числами? [y/n]: ");

            if (Console.ReadKey().Key == ConsoleKey.Y) {
                RandomUtilities randomUtilities = new RandomUtilities();
                int[] randomNums = randomUtilities.GetListOfRandNums(1, 100, 100);
                FileWriter.WriteAll(inputFile, DataWizard.ArrToString(randomNums));
            }

            string line = FileReader.ReadAll(inputFile);
            int[] numsInLine = DataWizard.SplitAndToInt(line);
            int[] multipliedNums = DataWizard.MultiplyEachNumInArr(numsInLine, 2);
            int[] sortedMultipliedNums = DataWizard.SortArrByAZ(multipliedNums);
            string result = DataWizard.ArrToString(sortedMultipliedNums);

            FileWriter.WriteAll(outputFile, result);
        }
    }

    class RandomUtilities {

        private Random rand = new Random();

        public int[] GetListOfRandNums(int min, int max, int length) {

            int[] nums = new int[length];

            for (int i = 0; i < nums.Length; i++) {
                nums[i] = rand.Next(min, max);
            }

            return nums;
        }
    }

    static class FileReader {
        public static string ReadAll(string path) {
            return File.ReadAllText(path).Trim();
        }
    }

    static class DataWizard {
        public static string ArrToString(int[] arr, string sep = " ") {
            return String.Join(sep, arr);
        }

        public static int[] SplitAndToInt(string str, string sep = " ") {

            string[] splittedString = str.Split(sep);
            int[] numsInStr = new int[splittedString.Length];

            for (int i = 0; i < numsInStr.Length; i++) {
                numsInStr[i] = int.Parse(splittedString[i]);
            }

            return numsInStr;
        }

        public static int[] MultiplyEachNumInArr(int[] arr, int multiplier) {

            int[] multipliedNums = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++) {
                multipliedNums[i] = arr[i] * multiplier;
            }

            return multipliedNums;
        }

        public static int[] SortArrByAZ(int[] arr) {

            Array.Sort(arr);

            return arr;
        }
    }

    static class FileWriter {
        public static void WriteAll(string path, string data) {
            File.WriteAllText(path, data);
        }
    }
}

