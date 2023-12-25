using System;

namespace BinarySearch {
    class CrazyProgram {
        static void Main() {

            int[] nums = new int[40] { 3, 124, 22, 181, 170,
                                       152, 50, 70, 172, 180,
                                       64, 148, 171, 137, 167,
                                       28, 80, 195, 118, 16,
                                       193, 115, 185, 144, 30,
                                       112, 82, 9, 106, 162,
                                       4, 104, 176, 169, 186,
                                       1, 13, 54, 21, 52 };

            int q = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(nums, q));
        }

        static int BinarySearch(int[] nums, int q) {

            int[] sortedNums = nums.OrderBy(x => x).ToArray();
            int start = 0;
            int end = sortedNums.Length - 1;
            
            while (end - start != 1) {

                int cursor = (end - start) / 2 + start;

                if (sortedNums[cursor] == q) {
                    return cursor;
                } else if (sortedNums[cursor] < q) {
                    start = cursor;
                } else if (sortedNums[cursor] > q) {
                    end = cursor;
                }
            }
            return -1;
        }
    }
}