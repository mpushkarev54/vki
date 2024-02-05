namespace CrazyConsoleApp3 {
    class Program {
        static void Main() {

            const string path = "text.txt";
            const string q = "FINAL HEAT OF FORMATION =";

            string[] linesInFile = File.ReadAllLines(path);
            int lineCounter = 0;

            foreach (string line in linesInFile) {
                
                lineCounter++;
                string trimmedLine = line.Trim();

                if (trimmedLine.Length >= q.Length && trimmedLine.Substring(0, q.Length) == q) {

                    string result = trimmedLine.Substring(q.Length).Trim();

                    Console.WriteLine($"[{lineCounter}] {result}");
                }
            }
        }
    }
}

