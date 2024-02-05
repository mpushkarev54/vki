namespace FindInString {
    class Program {
        static void Main() {

            const string text = "abc 71 d9f";

            List<string> numsInString = new List<string>();
            int wordsCounter = 0;
            int lettersCounter = 0;

            for (int symbId = 0; symbId < text.Length; symbId++) {

                if (char.IsLetter(text[symbId])) {
                    lettersCounter++;
                } else if (text[symbId] == ' ' && lettersCounter != 0) {
                    wordsCounter++;
                    lettersCounter = 0;
                }

                if (char.IsDigit(text[symbId])) {
                    numsInString.Add(text[symbId].ToString());
                }
            }

            Console.WriteLine($"[{wordsCounter}] [{ListToString(numsInString)}]");
        }

        static string ListToString(List<string> list) {

            string result = "";

            foreach (string el in list) {
                result += $"{el} ";
            }

            return result;
        }
    }
}