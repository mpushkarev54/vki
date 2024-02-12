namespace ClassCar {
    class Program {
        static void Main() {
            // без данных
            Car car1 = new Car();
            car1.PrintData();
            car1.SaveToFile("car1.txt");

            // с данными
            Car car2 = new Car(154, "Toyota", "FunСargo", "н054ск154", "зеленый");
            car2.PrintData();
            car2.SaveToFile("car2.txt");
        }
    }

    class Car {

        public int id;
        public string manufacturer;
        public string model;
        public string number;
        public string color;

        public Car() {
            this.id = -1;
            this.manufacturer = "N/A";
            this.model = "N/A";
            this.number = "N/A";
            this.color = "N/A";
        }
        public Car(int id, string manufacturer, string model, string number, string color) {
            this.id = id;
            this.manufacturer = manufacturer;
            this.model = model;
            this.number = number;
            this.color = color;
        }

        public void PrintData() {
            Console.WriteLine($"{id}\t{manufacturer}\t{model}\t{number}\t{color}");
        }

        public void SaveToFile(string filename) {
            File.WriteAllText(filename, $"{id}\t{manufacturer}\t{model}\t{number}\t{color}");
        }
    }
}