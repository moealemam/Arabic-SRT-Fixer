using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Arabic_SRT_Fixer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InputBrowseButtonClick(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "SRT files (*.srt)|*.srt|All files (*.*)|*.*";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxInput.Text = string.Join(";", ofd.FileNames);
                    SetDefaultOutputPath();
                }
            }
        }

        private void OutputBrowseButtonClick(object sender, EventArgs e)
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

        private async void ProcessButtonClick(object sender, EventArgs e)
        {
            var inputPaths = textBoxInput.Text.Split(';').Where(f => !string.IsNullOrWhiteSpace(f)).ToArray();
            string suffix = textBoxSuffix.Text;
            if (inputPaths.Length == 0 || !inputPaths.All(File.Exists))
            {
                labelStatus.Text = "Please select valid input SRT file(s).";
                return;
            }
            if (string.IsNullOrWhiteSpace(suffix))
            {
                labelStatus.Text = "Please specify an output file name suffix.";
                return;
            }
            labelStatus.Text = "Processing...";
            progressBar.Value = 0;
            textBoxSummary.Clear();
            int totalFiles = inputPaths.Length;
            int totalLinesWithRLE = 0;
            int processedFiles = 0;
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string dir = Path.GetDirectoryName(inputPath);
                string name = Path.GetFileNameWithoutExtension(inputPath);
                string ext = Path.GetExtension(inputPath);
                string outputPath = Path.Combine(dir, name + suffix + ext);
                int linesWithRLE = await Task.Run(() => ProcessSrtFileWithEncoding(inputPath, outputPath));
                totalLinesWithRLE += linesWithRLE;
                processedFiles++;
                int percent = (int)(((i + 1) / (float)totalFiles) * 100);
                progressBar.Value = percent;
                textBoxSummary.AppendText($"Processed {processedFiles}/{totalFiles}: {Path.GetFileName(inputPath)} - Lines with RLE added: {linesWithRLE}\r\n");
            }
            labelStatus.Text = $"Done! Files processed: {totalFiles}. Lines with RLE added: {totalLinesWithRLE}";
            textBoxSummary.AppendText($"\r\nDone! Files processed: {totalFiles}. Lines with RLE added: {totalLinesWithRLE}\r\n");
        }

        private void InputFieldDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var srtFiles = files.Where(f => Path.GetExtension(f).ToLower() == ".srt").ToArray();
                if (srtFiles.Length > 0)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void InputFieldDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var srtFiles = files.Where(f => Path.GetExtension(f).ToLower() == ".srt").ToArray();
            if (srtFiles.Length > 0)
            {
                textBoxInput.Text = string.Join(";", srtFiles);
                SetDefaultOutputPath();
            }
        }

        private void SetDefaultOutputPath()
        {
            var inputPaths = textBoxInput.Text.Split(';').Where(f => !string.IsNullOrWhiteSpace(f)).ToArray();
            string suffix = textBoxSuffix.Text;
            if (inputPaths.Length == 1 && File.Exists(inputPaths[0]))
            {
                string dir = Path.GetDirectoryName(inputPaths[0]);
                string name = Path.GetFileNameWithoutExtension(inputPaths[0]);
                string ext = Path.GetExtension(inputPaths[0]);
                textBoxOutput.Text = Path.Combine(dir, name + suffix + ext);
            }
            else
            {
                textBoxOutput.Text = "(Batch mode: output files will be placed next to each input)";
            }
        }

        private int ProcessSrtFileWithEncoding(string inputPath, string outputPath)
        {
            var arabicRegex = new Regex("[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB50-\uFDFF\uFE70-\uFEFF]");
            var timecodeRegex = new Regex(@"^\d{2}:\d{2}:\d{2},\d{3} --> ");
            char rleChar = '\u202B';
            int linesWithRLE = 0;
            Encoding encoding = DetectEncoding(inputPath);
            var lines = File.ReadAllLines(inputPath, encoding);
            var outLines = new List<string>(lines.Length);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || timecodeRegex.IsMatch(line))
                {
                    outLines.Add(line);
                }
                else if (arabicRegex.IsMatch(line))
                {
                    if (!line.StartsWith(rleChar))
                    {
                        outLines.Add(rleChar + line);
                        linesWithRLE++;
                    }
                    else
                    {
                        outLines.Add(line);
                    }
                }
                else
                {
                    outLines.Add(line);
                }
            }
            // Always write as UTF-8 with BOM if input is not UTF-8 with BOM
            bool needsBom = !IsUtf8WithBom(encoding);
            var outEncoding = needsBom ? new UTF8Encoding(true) : encoding;
            File.WriteAllLines(outputPath, outLines, outEncoding);
            return linesWithRLE;
        }

        private Encoding DetectEncoding(string filePath)
        {
            using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (reader.Length >= 3)
                {
                    byte[] bom = new byte[3];
                    reader.Read(bom, 0, 3);
                    if (bom[0] == 0xEF && bom[1] == 0xBB && bom[2] == 0xBF)
                        return new UTF8Encoding(true); // UTF-8 with BOM
                }
            }
            return new UTF8Encoding(false); // Assume UTF-8 without BOM
        }

        private bool IsUtf8WithBom(Encoding encoding)
        {
            return encoding is UTF8Encoding utf8 && utf8.GetPreamble().Length > 0;
        }
    }
}
