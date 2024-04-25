using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_Racing_F1
{
    internal class Car
    {
        public static int RaceTrackDistance = 1000;
        public int Speed = 33;
        public string Name { get; set; }
        public int Distance = 0;

        public Car (string name)
        {
            Name = name;
        }
        
        public void Race()
        {
            bool racing = true;

            while (racing)
            {
                for (int i = 0; i < 31; i++)
                {
                    if (i == 10)
                    {
                        Event(this);
                        i = 0;
                    }
                    Thread.Sleep(1000);
                    Distance = Distance + Speed;

                    if (!(Distance <= RaceTrackDistance))
                    {
                        Console.WriteLine($"[{Name}] Crosses the line!!!");
                        Console.WriteLine("-------------------------------------------------");
                        racing = false;
                        i = 100;
                    }
                }
            }
        }
        static int Event(Car car)
        {
            
            Random random = new Random();
            int randomNumber = random.Next(1, 51);

            if (randomNumber == 1) // 1 in 50 chance (2%)
            {
                Console.WriteLine($"Low on fuel (2% Chance), [{car.Name}] Refueling... 30 Seconds");
                Console.WriteLine("-------------------------------------------------");
                Thread.Sleep(30000);
                return 0;
            }
            else if (randomNumber <= 3) // 2 in 50 chance (4%)
            {
                Console.WriteLine($"Nails On The Track (4% Chance), [{car.Name}] Changing tires... 20 Seconds");
                Console.WriteLine("-------------------------------------------------");
                Thread.Sleep(20000);
                return 0;
            }
            else if (randomNumber <= 8) // 5 in 50 chance (10%)
            {
                Console.WriteLine($"Engine truble (10% Chance), [{car.Name}] making pitstop... 10 Seconds");
                Console.WriteLine("-------------------------------------------------");
                Thread.Sleep(10000);
                return 0;
            }
            else if (randomNumber <= 18) // 10 in 50 chance (20%)
            {
                Console.WriteLine($"Tire degradation (20% Chance), [{car.Name}] is slowing down");
                Console.WriteLine("-------------------------------------------------");
                return car.Speed -= 1;
            }
            else
            {
                Console.WriteLine($"Avoiding other driver, [{car.Name}] Breaks");
                Console.WriteLine("-------------------------------------------------");
                Thread.Sleep(500);
                return 0;
            }

        }
    }

}
