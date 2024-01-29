namespace AsyncAwaitExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            var worker = new Worker();
            worker.DoWork();
            while (!worker.IsComplete) 
            {
                Console.WriteLine(".");
                Thread.Sleep(500);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
    public class Worker
    { 
        public bool IsComplete { get; private set; }
        public async void DoWork() 
        { 
            IsComplete = false;
            Console.WriteLine("Doing work.");
            await LongOperation();
            Console.WriteLine("Work completed.");
            IsComplete = true;
        }
        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Working");
                Thread.Sleep(5000);
            });
        }

    }
}
