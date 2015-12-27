﻿using System.Threading.Tasks;
using static System.Console;

namespace SynchronizatonSamples
{
    public class Program
    {
        public static void Main()
        {
            int numTasks = 20;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            for (int i = 0; i < numTasks; i++)
            {
                tasks[i] = Task.Run(() => new Job(state).DoTheJob());
            }

            Task.WaitAll(tasks);

            WriteLine($"summarized {state.State}");

        }
    }
}