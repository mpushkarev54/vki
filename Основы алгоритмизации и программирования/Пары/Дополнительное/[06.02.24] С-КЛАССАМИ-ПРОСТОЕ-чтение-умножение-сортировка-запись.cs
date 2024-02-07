namespace ConsoleApp2 {
    class Program {
        static void Main() {

            const string inputFile = "a.txt";
            const string outputFile = "b.txt";

            string line = FileReader.ReadAll(inputFile);

            string result = DataProcessor.MakesEverythingWonderful(line);

            FileWriter.WriteAll(outputFile, result);
        }
    }

    static class FileReader {
        public static string ReadAll(string path) {
            return File.ReadAllText(path).Trim();
        }
    }

    static class DataProcessor {
        public static string MakesEverythingWonderful(string line) {

            string[] numsInLine = line.Split();

            int[] multipliedNums = new int[numsInLine.Length];

            for (int i = 0; i < numsInLine.Length; i++) {
                multipliedNums[i] = int.Parse(numsInLine[i]) * 2;
            }

            Array.Sort(multipliedNums);

            return String.Join(" ", multipliedNums);
        }
    }

    static class FileWriter {
        public static void WriteAll(string path, string data) {
            File.WriteAllText(path, data);
        }
    }
}

