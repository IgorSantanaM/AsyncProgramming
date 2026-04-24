using System.Diagnostics;

namespace StockAnalyzer.AdvancedTopics;

internal class Program
{
    static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        Lock lockObject = new();
        int total = 0;
        Parallel.For(0, 100, (i) =>
        {
            var result = Compute(i);
            Interlocked.Add(ref total, (int)result);
            
            //lock (lockObject)
            //    total += result;
        });

        //var task2 = Task.Run(() =>
        //{
        //    Parallel.For(50, 100, (i) =>
        //    {
         //        int result = Compute(i);
        //        lock (lockObject)
        //            total += result;
        //    });
        //});

        //await Task.WhenAll(task1, task2);
        Console.WriteLine(total);

        Console.WriteLine($"It took: {stopwatch.ElapsedMilliseconds}ms to run");
        Console.ReadLine();
    }

    static Random random = new();
    static int Compute(int value)
    {
        var randomMilliseconds = random.Next(10, 50);
        var end = DateTime.Now + TimeSpan.FromMilliseconds(randomMilliseconds);

        // This will spin for a while...
        while (DateTime.Now < end) { }

        return value;
    }
}