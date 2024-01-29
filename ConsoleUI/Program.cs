using System.Diagnostics.Metrics;

namespace ConsoleUI
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var tea = await MakeTeaAsync();
        }

        // synchronious
        static void MakeTea()
        {
            var water = BoilWater();
            Console.WriteLine("take the cups out");

            Console.WriteLine("put tea in cups");
            var tea = $"pour {water} in cups";
            Console.WriteLine(tea);
            
        }
        static string BoilWater()
        {
            Console.WriteLine("start the kettle");
            Console.WriteLine("waiting for the kettle");
            Task.Delay(2000);
            Console.WriteLine("kettle finished boiling"); 
            return "water";
        }

        //asynchronious
        static async Task<string> MakeTeaAsync()
        {
            var bolingWater = BoilWaterAsync();
            Console.WriteLine("take the cups out");
            Thread.Sleep(2000);
            Console.WriteLine("put tea in cups");
            Thread.Sleep(2000);
            var water = await bolingWater; // wait until await mark in BoilWaterAsync() is executed
            var tea = $"pour {water} in cups";
            Console.WriteLine(tea);
            return tea;
        }
        static async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("start the kettle");
            Console.WriteLine("waiting for the kettle");
            await Task.Delay(8000);
            Console.WriteLine("kettle finished boiling");
            return "water";
        }
    }
}