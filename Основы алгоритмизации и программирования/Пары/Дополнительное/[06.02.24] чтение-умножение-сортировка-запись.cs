namespace ConsoleApp2 {
    class Program {
        static void Main() {

            string line = File.ReadAllText("a.txt").Trim();
            string[] numsInLine = line.Split();

            int[] multipliedNums = new int[numsInLine.Length];

            for (int i = 0; i < numsInLine.Length; i++) {
                multipliedNums[i] = int.Parse(numsInLine[i]) * 2;
            }

            Array.Sort(multipliedNums);
            string result = "";

            foreach (int num in multipliedNums) {
                result += $"{num} ";
            }

            File.WriteAllText("b.txt", result);
        }
    }
}

