using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class AsyncGood : Form
    {
        delegate void StartProcessDelegate(int val);
        delegate void ShowProgressDelegate(int val);
        public AsyncGood()
        {
            InitializeComponent();
        }
        

        public static void Main2()
        {
            Application.Run(new AsyncGood());
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            var progDel = new StartProcessDelegate(StartProcess);
            progDel.BeginInvoke(100, null, null);
            MessageBox.Show($"Done with operation!");
        }

        /// <summary>
        /// Called Asynchronously. GoodWay
        /// </summary>
        /// <param name="">true if managed resources should be disposed; otherwise, false.</param>
        private void StartProcess(int max)
        {
            this.pbStatus.Maximum = max;
            for (int i = 0; i <= max; i++)
            {
                Thread.Sleep(10);
                ShowProgress(i);
            }
        }

        private void ShowProgress(int i)
        {
            //This is hit if a backgroud thread calls ShowProgress()
            if (lblOutput.InvokeRequired == true)
            {
                var del = new ShowProgressDelegate(ShowProgress);
                this.BeginInvoke(del, new object[] {i});
            }
            else
            {
                lblOutput.Text = i.ToString();
                this.pbStatus.Value = i;
            }
        }


    }
}
