namespace PascalsTriangle {
    class CrazyProgram {
        static void Main() {
            
            int neededLine = int.Parse(Console.ReadLine());

            int[][] triangle = new int[neededLine][];
            
            for (int line = 0; line < neededLine; line++) {
                triangle[line] = new int[line + 1];
                triangle[line][0] = 1;
                triangle[line][line] = 1;
            }

            for (int line = 2; line < neededLine; line++) {
                for (int cursor = 1; cursor < line; cursor++) {
                    triangle[line][cursor] = triangle[line - 1][cursor - 1] + triangle[line - 1][cursor];
                }
            }

            for (int line = 0; line < neededLine; line++) {
                for (int cursor = 0; cursor <= line; cursor++) {
                    Console.Write($" {triangle[line][cursor]} ");
                }
                Console.WriteLine();
            }
        }
    }
}