using System;

namespace DirectSearch {
    class CrazyProgram {
        static void Main() {
            
            string str = Console.ReadLine();
            string q = Console.ReadLine();

            Console.WriteLine(DirectSearch(str, q));
        }

        static int DirectSearch(string str, string q) {

            for (int start = 0; start <= str.Length - q.Length; start++) {
                
                if (str.Substring(start, q.Length) == q) {
                    return start;
                }
            }
            return -1;
        }
    }
}