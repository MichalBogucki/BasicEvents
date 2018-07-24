using System;
using System.ComponentModel;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class DirectorySearcher : Control
    {
        public event EventHandler SearchComplete;

        private delegate void FileListDelegate(string[] files, int startIndex, int count);

        private ListBox _listBox;
        public string SearchCriteria { get; }
        public bool Searching { get; set; }
        public bool DeferSearch { get; set; }
        public Thread SearchThread { get; set; }
        private FileListDelegate _fileListDelegate;
        private EventHandler _onSearchComplete;
        public DirectorySearcher()
        {
            _listBox = new ListBox();
            _listBox.Dock = DockStyle.Fill;

            Controls.Add(_listBox);

            _fileListDelegate = new FileListDelegate(AddFiles);
            _onSearchComplete = new EventHandler(OnSearchComplete);

        }

        private void AddFiles(string[] files, int startindex, int count)
        {
            while (count-- > 0)
            {
                _listBox.Items.Add(files[startindex + count]);
            }
        }

        public void BeginSearch()
        {
            if (Searching) return;

            if (IsHandleCreated)
            {
                SearchThread = new Thread(new ThreadStart(ThreadProcedure));
                Searching = true;
                SearchThread.Start();
            }
            else
            {
                DeferSearch = true;
            }
        }

        private void ThreadProcedure()
        {
            try
            {
                string localSearch = SearchCriteria;
                RecurseDirectory(localSearch);
            }
            finally
            {
                Searching = false;
                BeginInvoke(_onSearchComplete, new object[] {this, EventArgs.Empty});
            }
        }

        private void OnSearchComplete(object sender, EventArgs e)
        {
            if (SearchComplete != null)
            {
                SearchComplete(sender, e);
            }
        }

        public void StopSearch()
        {
            if (!Searching)
            {
                return;
            }

            if (SearchThread.IsAlive)
            {
                SearchThread.Abort();
                SearchThread.Join();
            }

            SearchThread = null;
            Searching = false;
        }

        private void RecurseDirectory(string searchPath)
        {
            string directory = Path.GetDirectoryName(searchPath);
            string search = Path.GetFileName(searchPath);

            if (directory == null || search == null)
            {
                return;
            }

            string[] files;

            try
            {
                files = Directory.GetFiles(directory, search);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            int startingIndex = 0;

            while (startingIndex < files.Length)
            {
                int count = 20;
                if (count + startingIndex >= files.Length)
                {
                    count = files.Length - startingIndex;
                }

                IAsyncResult r = BeginInvoke(_fileListDelegate, new object[] { files, startingIndex, count });
                startingIndex += count;
            }

            string[] directories = Directory.GetDirectories(directory);
            foreach (string d in directories)
            {
                RecurseDirectory(Path.Combine(d, search));
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (!RecreatingHandle)
            {
                StopSearch();
            }
            base.OnHandleDestroyed(e);
        }

        protected override void OnHandleCreated(EventArgs e) { }
    }
}
