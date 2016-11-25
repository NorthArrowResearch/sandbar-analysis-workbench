using System;
using System.Drawing;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars.Analysis
{

    public partial class frmRunOutput : Form
    {
        delegate void SetTextCallback(string text, Color color);

        private void SetText(string text, Color color)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtOutput.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, color });
            }
            else
            {
                if (!String.IsNullOrEmpty(text))
                {
                    this.txtOutput.SelectionStart = this.txtOutput.TextLength;
                    this.txtOutput.SelectionLength = 0;

                    this.txtOutput.SelectionColor = color;
                    this.txtOutput.AppendText(text + '\n');
                    this.txtOutput.SelectionColor = this.txtOutput.ForeColor;
                }

            }
        }

        public void AppendOutput(string text, Color color)
        {
            SetText(text, color);
        }

        public void CloseWithOk(string txt)
        {
            MessageBox.Show(txt);
            this.Close();
        }

        public frmRunOutput()
        {
            InitializeComponent();
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            if (box.InvokeRequired)
                box.Invoke((Action)(() => AppendText(box, text, color)));
            else
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
            }

        }
    }

}
