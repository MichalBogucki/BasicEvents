using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class BackgroundWorker : Form
    {
        public BackgroundWorker()
        {
            InitializeComponent();
        }
        public static void Main3()
        {
            Application.Run(new BackgroundWorker());
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            CancelButton.Enabled = true;
            OutputLabel.Text = "";
            MyBackgroundWorker.RunWorkerAsync();
        }
        private long Calculate(System.ComponentModel.BackgroundWorker instance, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (instance.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    instance.ReportProgress(i);
                }
            }

            return 0L;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MyBackgroundWorker.CancelAsync();
            CancelButton.Enabled = true;
        }

        private void MyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Not on a UI Thread
            e.Result = Calculate(sender as System.ComponentModel.BackgroundWorker, e);
        }

        private void MyBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            OutputLabel.Text = e.ProgressPercentage.ToString();
        }

        private void MyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartButton.Enabled = true;
            progressBar1.Value = 0;
            if (!e.Cancelled)
            {
                OutputLabel.Text = @"BackgroundWorker Completed";
            }
            else
            {
                OutputLabel.Text = @"Camcelled";
            }
            
        }
    }
}
