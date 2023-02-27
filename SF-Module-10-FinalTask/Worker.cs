using System;
using System.Threading;

namespace SF_Module_10_FinalTask
{
	public class Worker : IWorker
	{
        ILogger Logger { get; }

        public Worker(ILogger logger)
        {
            Logger = logger;
        }

        public void Work(int num)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Logger.Event($"Entered: {num}");
        }

        public void ErrorMessage(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Logger.Error(ex.Message);
        }
    }
}

