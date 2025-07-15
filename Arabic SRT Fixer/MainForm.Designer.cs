namespace Arabic_SRT_Fixer
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelInput = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonBrowseInput = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonBrowseOutput = new System.Windows.Forms.Button();
            this.labelPrefix = new System.Windows.Forms.Label();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(12, 15);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(80, 15);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "Input SRT File:";
            // 
            // textBoxInput
            // 
            this.textBoxInput.AllowDrop = true;
            this.textBoxInput.Location = new System.Drawing.Point(100, 12);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(500, 23);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.InputFieldDrop);
            this.textBoxInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.InputFieldDragEnter);
            // 
            // buttonBrowseInput
            // 
            this.buttonBrowseInput.Location = new System.Drawing.Point(610, 11);
            this.buttonBrowseInput.Name = "buttonBrowseInput";
            this.buttonBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseInput.TabIndex = 2;
            this.buttonBrowseInput.Text = "Browse...";
            this.buttonBrowseInput.UseVisualStyleBackColor = true;
            this.buttonBrowseInput.Click += new System.EventHandler(this.InputBrowseButtonClick);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(12, 50);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(82, 15);
            this.labelOutput.TabIndex = 3;
            this.labelOutput.Text = "Output SRT File:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(100, 47);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(500, 23);
            this.textBoxOutput.TabIndex = 4;
            // 
            // buttonBrowseOutput
            // 
            this.buttonBrowseOutput.Location = new System.Drawing.Point(610, 46);
            this.buttonBrowseOutput.Name = "buttonBrowseOutput";
            this.buttonBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOutput.TabIndex = 5;
            this.buttonBrowseOutput.Text = "Browse...";
            this.buttonBrowseOutput.UseVisualStyleBackColor = true;
            this.buttonBrowseOutput.Click += new System.EventHandler(this.OutputBrowseButtonClick);
            // 
            // labelPrefix
            // 
            this.labelPrefix.AutoSize = true;
            this.labelPrefix.Location = new System.Drawing.Point(100, 75);
            this.labelPrefix.Name = "labelPrefix";
            this.labelPrefix.Size = new System.Drawing.Size(120, 15);
            this.labelPrefix.TabIndex = 8;
            this.labelPrefix.Text = "Output file name suffix:";
            // 
            // textBoxPrefix
            // 
            this.textBoxSuffix.Location = new System.Drawing.Point(230, 72);
            this.textBoxSuffix.Name = "textBoxPrefix";
            this.textBoxSuffix.Size = new System.Drawing.Size(100, 23);
            this.textBoxSuffix.TabIndex = 9;
            this.textBoxSuffix.Text = "_RLE";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(100, 110);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(120, 30);
            this.buttonProcess.TabIndex = 6;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.ProcessButtonClick);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(230, 117);
            this.labelStatus.MaximumSize = new System.Drawing.Size(350, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 15);
            this.labelStatus.TabIndex = 7;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(100, 150);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 23);
            this.progressBar.TabIndex = 10;
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Location = new System.Drawing.Point(100, 180);
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.Size = new System.Drawing.Size(500, 80);
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.ReadOnly = true;
            this.textBoxSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSummary.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 280);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonBrowseInput);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonBrowseOutput);
            this.Controls.Add(this.labelPrefix);
            this.Controls.Add(this.textBoxSuffix);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Arabic SRT Fixer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonBrowseInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonBrowseOutput;
        private System.Windows.Forms.Label labelPrefix;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox textBoxSummary;
    }
}
