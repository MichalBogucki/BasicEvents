using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesAndEvents.Model;

namespace DelegatesAndEvents
{
    public sealed class Mediator
    {
        //static members
        private static readonly Mediator _InstanceSingleton = new Mediator();
        private Mediator() { }

        public static Mediator GetInstanceSingleton()
        {
            return _InstanceSingleton;
        }

        //Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
            {
                jobChangedDelegate(sender, new JobChangedEventArgs {Job = job});
            }
        }
    }
}
