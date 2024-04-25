namespace Labb_2_Racing_F1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Car car = new Car("ferrari");
            Car car2 = new Car("RedBull");

            Task t1 = Task.Run(() => car.Race());
            Task t2 = Task.Run(() => car2.Race());
            Task result = Task.Run(() => Result(t1, t2, car, car2));
            

            while (!(t1.IsCompleted && t2.IsCompleted && result.IsCompleted))
            {

                Console.WriteLine("Press Enter to get race info...");
                Console.WriteLine("-------------------------------------------------");
                string input = Console.ReadLine();
                //if (input == "status")
                //{
                Console.WriteLine($"{car.Name} Distance traveled: {car.Distance} / {Car.RaceTrackDistance} Speed: {car.Speed} m/s");
                Console.WriteLine($"{car2.Name} Distance traveled: {car2.Distance} / {Car.RaceTrackDistance} Speed: {car2.Speed} m/s");
                Console.WriteLine("-------------------------------------------------");
                //}


            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        static async Task<bool> Result(Task t1, Task t2, Car car, Car car2)
        {
            while (true)
            {
                if (t1.IsCompleted && !t2.IsCompleted)
                {
                    Console.WriteLine($"GZ {car.Name}");
                    Console.WriteLine($"Sorry {car2.Name}");
                    Console.WriteLine("-------------------------------------------------");
                    return true;
                }
                else if (!t1.IsCompleted && t2.IsCompleted)
                {
                    Console.WriteLine($"GZ {car2.Name}");
                    Console.WriteLine($"Sorry {car.Name}");
                    Console.WriteLine("-------------------------------------------------");
                    return true;
                }
                else if (t1.IsCompleted && t2.IsCompleted)
                {
                    Console.WriteLine("It's a tie!");
                    Console.WriteLine("-------------------------------------------------");
                    return true;
                }
            }
        }
    }
}
