namespace ThreadsAndDelegates
{
    partial class DirectorySearcherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearcherLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.directorySearcher = new System.DirectoryServices.DirectorySearcher();
            this.searchText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(12, 25);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(120, 50);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearcherLabel
            // 
            this.SearcherLabel.AutoSize = true;
            this.SearcherLabel.Location = new System.Drawing.Point(283, 9);
            this.SearcherLabel.Name = "SearcherLabel";
            this.SearcherLabel.Size = new System.Drawing.Size(0, 13);
            this.SearcherLabel.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 83);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(430, 342);
            this.listBox1.TabIndex = 3;
            // 
            // directorySearcher
            // 
            this.directorySearcher.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(159, 41);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(283, 20);
            this.searchText.TabIndex = 1;
            // 
            // DirectorySearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 439);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.SearcherLabel);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.SearchButton);
            this.Name = "DirectorySearcherForm";
            this.Text = "DirectorySearcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label SearcherLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.DirectoryServices.DirectorySearcher directorySearcher;
        private System.Windows.Forms.TextBox searchText;
    }
}