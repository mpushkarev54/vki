namespace Double1 {
    class Program {
        static void Main() {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());

            double sum = a + b;
            int total = Convert.ToInt32(sum);
            double dec = Math.Round(sum - total, 2);

            Console.WriteLine($"{sum}\n{total}\n{dec}");
        }
    }
}