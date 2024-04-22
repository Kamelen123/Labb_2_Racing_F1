namespace Labb_2_Racing_F1
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            Car car = new Car("ferrari");
            Car car2 = new Car("RedBull");

            Thread thread = new Thread(car.Race);
            Thread thread2 = new Thread(car2.Race);
            thread2.Start();
            thread.Start();
            //thread2.Join();
            //thread.Join();
            bool ferrari = car.IsFinished();
            bool RedBull = car.IsFinished();

            if (ferrari == true)
            {
                thread.Join();
            }
            else
            {
                thread2.Join();
            }
            
            //while (!car.Finnished || !car2.Finnished)
            //{
            //    string input = Console.ReadLine();
            //    Console.WriteLine($"{car.Name} Distance traveled: {car.Distance} / {Car.RaceTrackDistance} Speed: {car.Speed} m/s");
            //    Console.WriteLine($"{car2.Name} Distance traveled: {car2.Distance} / {Car.RaceTrackDistance} Speed: {car2.Speed} m/s");
            //}


            //if (car.IsFinished() && !car2.IsFinished())
            //{
            //    Console.WriteLine($"GZ {car.Name}");
            //    Console.WriteLine($"Sorry {car2.Name}");
            //}
            //if (!car.IsFinished() && car2.IsFinished())
            //{
            //    Console.WriteLine($"GZ {car2.Name}");
            //    Console.WriteLine($"Sorry {car.Name}");
            //}
            //if (car.IsFinished() && car2.IsFinished())
            //{
            //    Console.WriteLine("Hej");
            //}
            //if (car.IsFinished() && !car2.IsFinished())
            //{
            //    Console.WriteLine($"GZ {car.Name}");
            //    Console.WriteLine($"Sorry {car2.Name}");
            //}
            //else if (!car.IsFinished() && car2.IsFinished())
            //{
            //    Console.WriteLine($"GZ {car2.Name}");
            //    Console.WriteLine($"Sorry {car.Name}");
            //}
            //else if (car.IsFinished() && car2.IsFinished())
            //{
            //    Console.WriteLine("Hej");
            //}
            if (ferrari && !RedBull)
            {
                Console.WriteLine($"Congratulations {car.Name}!");
                Console.WriteLine($"Sorry {car2.Name}");
            }
            else if (!ferrari && RedBull)
            {
                Console.WriteLine($"Congratulations {car2.Name}!");
                Console.WriteLine($"Sorry {car.Name}");
            }
            else if (ferrari && RedBull)
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
