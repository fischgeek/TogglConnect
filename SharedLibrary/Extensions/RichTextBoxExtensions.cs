using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharedLibrary
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color? color)
        {
            if (color == null) {
                color = Color.White;
            }
            box.SuspendLayout();
            //box.SelectionStart = box.TextLength;
            //box.SelectionLength = 0;
            
            box.SelectionColor = color.Value;
            box.AppendText(text);
            //box.SelectionColor = box.ForeColor;
            
            box.ScrollToCaret();
            box.ResumeLayout();
        }

        public static void AppendLine(this RichTextBox box, string text, Color? color = null) => box.AppendText($"\n{text}", color);

        public static void AppendStampedLine(this RichTextBox box, string text, Color? color = null)
        {
            var stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            box.AppendLine($"[{stamp}] {text}", color);
        }

        public static void AppendDateStampedLine(this RichTextBox box, string text, Color? color = null)
        {
            var stamp = DateTime.Now.ToString("yyyy-MM-dd");
            box.AppendLine($"[{stamp}] {text}", color);
        }

        public static void AppendTimeStampedLine(this RichTextBox box, string text, Color? color = null)
        {
            var stamp = DateTime.Now.ToString("HH:mm:ss");
            box.AppendLine($"[{stamp}] {text}", color);
        }
    }
}
