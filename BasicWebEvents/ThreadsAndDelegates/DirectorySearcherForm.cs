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
    public partial class DirectorySearcherForm : Form
    {
        public DirectorySearcherForm()
        {
            InitializeComponent();
        }

        static void Main()
        {
            Application.Run(new DirectorySearcherForm());
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            directorySearcher.SearchCriteria = searchText.Text;
            SearcherLabel.Text = @"Searching";
            directorySearcher.BeginSearch();
        }
    }
}
