namespace DvdCollection.ImportUi
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.ImdbIdTextBox = new System.Windows.Forms.TextBox();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileButton.Location = new System.Drawing.Point(713, 11);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UploadButton.Location = new System.Drawing.Point(713, 102);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 23);
            this.UploadButton.TabIndex = 1;
            this.UploadButton.Text = "Import";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ImdbIdTextBox
            // 
            this.ImdbIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImdbIdTextBox.Location = new System.Drawing.Point(12, 41);
            this.ImdbIdTextBox.Name = "ImdbIdTextBox";
            this.ImdbIdTextBox.Size = new System.Drawing.Size(695, 23);
            this.ImdbIdTextBox.TabIndex = 2;
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePathTextBox.Location = new System.Drawing.Point(12, 12);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(695, 23);
            this.FilePathTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 137);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.ImdbIdTextBox);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.SelectFileButton);
            this.Name = "MainForm";
            this.Text = "Upload Media";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.TextBox ImdbIdTextBox;
        private System.Windows.Forms.TextBox FilePathTextBox;
    }
}

