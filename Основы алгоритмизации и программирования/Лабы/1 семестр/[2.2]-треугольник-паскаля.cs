using System;

namespace PascalsTriangle {
    class CrazyProgram {
        static void Main() {
            
            int neededLine = int.Parse(Console.ReadLine());
            int neededLines = neededLine + 1;

            int[][] triangle = new int[neededLines][];
            
            for (int line = 0; line < neededLines; line++) {
                triangle[line] = new int[line + 1];
                triangle[line][0] = 1;
                triangle[line][line] = 1;
            }

            for (int line = 2; line < neededLines; line++) {
                
                for (int cursor = 1; cursor < line; cursor++) {
                    triangle[line][cursor] = triangle[line - 1][cursor - 1] + triangle[line - 1][cursor];
                }
            }

            for (int cursor = 0; cursor <= neededLine; cursor++) {
                Console.Write($" {triangle[neededLine][cursor]} ");
            }
        }
    }
}