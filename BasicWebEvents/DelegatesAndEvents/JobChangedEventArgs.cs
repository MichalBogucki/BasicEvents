using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesAndEvents.Model;

namespace DelegatesAndEvents
{
    public class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}
