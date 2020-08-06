using System;
using System.Collections.Generic;
using System.Linq;

namespace AeonLabs.tasksManager
{
    public class tasksManagerClass
    {
        public const int TO_START = -1;
        public const int BUSY = 1;
        public const int FINISHED = 0;

        public event tasksCompletedEventHandler tasksCompleted;

        public delegate void tasksCompletedEventHandler(object sender);

        private Dictionary<string, int> tasks;
        private System.Timers.Timer atimer = new System.Timers.Timer();
        private bool taskEnded = false;

        public tasksManagerClass()
        {
            tasks = new Dictionary<string, int>();
        }

        public void registerTask(string name, int status)
        {
            tasks.Add(name, status);
        }

        public void startListening()
        {
            taskEnded = false;
            atimer.AutoReset = true;
            atimer.Interval = 100;
            atimer.Elapsed += tick;
            atimer.Start();
        }

        public void unload()
        {
            if (atimer is object)
            {
                atimer.Stop();
            }
        }

        private void tick(object sender, EventArgs e)
        {
            if (getTasksStatus().Equals(FINISHED) & !taskEnded)
            {
                taskEnded = true;
                tasksCompleted?.Invoke(this);
                atimer.Stop();
            }
        }

        public void setStatus(string name, int status)
        {
            tasks[name] = status;
        }

        public int getTasksStatus()
        {
            for (int i = 0, loopTo = tasks.Count - 1; i <= loopTo; i++)
            {
                if (tasks.ElementAt(i).Value.Equals(TO_START) | tasks.ElementAt(i).Value.Equals(BUSY))
                {
                    return BUSY;
                }
            }

            return FINISHED;
        }
    }
}