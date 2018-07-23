using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public virtual void DoWork(int hours, WorkType workType)
        {
            // Do work here and notify consumer that work has been performed
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null) // Listeners are attached
            {
                del(this, new WorkPerformedEventArgs(hours, workType)); //Raise Event
            }
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null) // Listeners are attached
            {
                del(this, EventArgs.Empty); //Raise Event
            }
        }
    }
}
