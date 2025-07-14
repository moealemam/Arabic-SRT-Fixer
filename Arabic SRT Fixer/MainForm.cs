using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Arabic_SRT_Fixer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void inputBrowseButtonClick(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "SRT files (*.srt)|*.srt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxInput.Text = ofd.FileName;
                    SetDefaultOutputPath();
                }
            }
        }

        private void outputBrowseButtonClick(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "SRT files (*.srt)|*.srt|All files (*.*)|*.*";
                sfd.FileName = textBoxOutput.Text;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    textBoxOutput.Text = sfd.FileName;
                }
            }
        }

        private void processButtonClick(object sender, EventArgs e)
        {
            string inputPath = textBoxInput.Text;
            string outputPath = textBoxOutput.Text;
            if (string.IsNullOrWhiteSpace(inputPath) || !File.Exists(inputPath))
            {
                labelStatus.Text = "Please select a valid input SRT file.";
                return;
            }
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                labelStatus.Text = "Please specify an output file path.";
                return;
            }
            try
            {
                ProcessSrtFile(inputPath, outputPath);
                labelStatus.Text = "Processing complete!";
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void inputFieldDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && Path.GetExtension(files[0]).ToLower() == ".srt")
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void inputFieldDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                textBoxInput.Text = files[0];
                SetDefaultOutputPath();
            }
        }

        private void SetDefaultOutputPath()
        {
            string inputPath = textBoxInput.Text;
            if (!string.IsNullOrWhiteSpace(inputPath) && File.Exists(inputPath))
            {
                string dir = Path.GetDirectoryName(inputPath);
                string name = Path.GetFileNameWithoutExtension(inputPath);
                string ext = Path.GetExtension(inputPath);
                textBoxOutput.Text = Path.Combine(dir, name + "_RLE" + ext);
            }
        }

        private void ProcessSrtFile(string inputPath, string outputPath)
        {
            var arabicRegex = new Regex("[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB50-\uFDFF\uFE70-\uFEFF]");
            var timecodeRegex = new Regex(@"^\d{2}:\d{2}:\d{2},\d{3} --> ");
            char rleChar = '\u202B';
            var lines = File.ReadAllLines(inputPath);
            var outLines = new List<string>(lines.Length);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || timecodeRegex.IsMatch(line))
                {
                    outLines.Add(line);
                }
                else if (arabicRegex.IsMatch(line))
                {
                    // Add RLE (U+202B) if not already present
                    if (!line.StartsWith(rleChar))
                        outLines.Add(rleChar + line);
                    else
                        outLines.Add(line);
                }
                else
                {
                    outLines.Add(line);
                }
            }
            File.WriteAllLines(outputPath, outLines);
        }
    }
}
