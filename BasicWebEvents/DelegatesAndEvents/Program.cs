using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            var custList = CustomerRepsitory.Retrive();
            var phxCustomers =  custList
                .Where(c => c.City.Equals("Phoenix"))
                .OrderByDescending(c => c.FirstName);

            foreach (var singleCust in phxCustomers)
            {
                Console.WriteLine($"{singleCust.FirstName}");
            }


            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, addDel);
            data.Process(2, 3, multiplyDel);

            Action<int, int> myAddAction = (x, y) => Console.WriteLine($"\n{x + y}");
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine($"\n{x * y}");

            data.ProcessAction(2, 3, myAddAction);
            data.ProcessAction(2, 3, myMultiplyAction);

            data.ProcessFunc(3, 2, funcAddDel);
            data.ProcessFunc(3, 2, funcMultiplyDel);

            // WorkPerformedHandler delegate1 = new WorkPerformedHandler(WorkPerformed1);
            // WorkPerformedHandler delegate2 = new WorkPerformedHandler(WorkPerformed2);
            // WorkPerformedHandler delegate3 = new WorkPerformedHandler(WorkPerformed3);

            //delegateHandler1(5, WorkType.Golf);
            //delegateHandler2(10, WorkType.GenerateReports);


            //DoWork(delegateHandler1);
            //DoWork(delegateHandler2);


            //delegate1 += delegate2 + delegate3;
            //
            //delegate1(10, WorkType.GenerateReports);
            //DoWork(delegate1);

            var worker = new Worker();
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        
        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Hours worked {e.Hours} {e.WorkType}");
        }
        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Worker is done");
        }


        //static void DoWork(WorkPerformedHandler delegateHandler)
        //{
        //    delegateHandler(5, WorkType.GoToMeetings);
        //}

        //static void WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformed1 called {hours.ToString()}");
        //}
        //static void WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformed2 called {hours.ToString()}");
        //}
        //static void WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformed3 called {hours.ToString()}");
        //}
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
