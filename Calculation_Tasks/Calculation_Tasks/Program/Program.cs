using Calculation_Tasks.Features.FileCalculations.Services;

namespace Calculation_Tasks.Program
{
    public static class Program
    {
        private static Task? _progressTask;
        private static Task? _calculationTask;
        
        private static readonly CancellationTokenSource CancelTokenSource = new(); 
        private static readonly CancellationToken CancellationToken = CancelTokenSource.Token;
        
        public static async Task Main()
        {
            var calculationHandler = new CalculationHandler();
            calculationHandler.OnCalculationCompleted += Complete;
            
            _progressTask = new Task(PrintProgress, CancellationToken);
            _calculationTask = new Task(calculationHandler.CalculationExecute, CancellationToken);

            _progressTask.Start();
            _calculationTask.Start();

            await _progressTask;
            await _calculationTask;
        }
        
        private static void PrintProgress()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"{DateTime.Now} In progress...");
                Task.Delay(TimeSpan.FromMilliseconds(100)).Wait();
            }
        }

        private static void Complete(string maxDistancePointId)
        {
            CancelTokenSource.Cancel();
            
            Console.WriteLine($"The further point is {maxDistancePointId}\nCompleting...");
            
            Thread.Sleep(10000);
            
            Console.WriteLine("Completed");
            
            Environment.Exit(0);
        }
    }
}