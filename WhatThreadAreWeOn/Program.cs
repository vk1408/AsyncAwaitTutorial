namespace WhatThreadAreWeOn
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Step 1, Thread:" + Thread.CurrentThread.ManagedThreadId);
            var client = new HttpClient();
            Console.WriteLine("Step 2, Thread:" + Thread.CurrentThread.ManagedThreadId);
            var task = client.GetStringAsync("http://google.com");
            Console.WriteLine("Step 3, Thread:" + Thread.CurrentThread.ManagedThreadId);
            var a = 0;
            for (int i = 0; i < 1000000; i++) 
            {
                a += i;
            }
            Console.WriteLine("Step 4, Thread:" + Thread.CurrentThread.ManagedThreadId);
            var page = await task;
            Console.WriteLine("Step 5, Thread:" + Thread.CurrentThread.ManagedThreadId);



        }
    }
}