using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_App
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            TabPage tp = new TabPage("new Document");
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;

            tp.Controls.Add(rtb);
            inputTC.TabPages.Add(tp);
        }

        private RichTextBox getRichTextBox()
        {
            RichTextBox rtp = null;
            TabPage tp = inputTC.SelectedTab;

            if (tp != null)
            {
                rtp = tp.Controls[0] as RichTextBox;
            }    
            return rtp;
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("new Document");
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;

            tp.Controls.Add(rtb);
            inputTC.TabPages.Add(tp);
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppForm form = new AppForm();
            form.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                getRichTextBox().Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Text File|*.txt|PDF file|*.pdf|Word File|*.doc";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, getRichTextBox().Text);
                inputTC.SelectedTab.Text = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().Cut();
        }

        private void selectAkkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getRichTextBox().Text = System.DateTime.Now.ToString();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                getRichTextBox().SelectionColor = colorDialog1.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                getRichTextBox().SelectionFont = fontDialog1.Font;
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = getRichTextBox().Font.Size;
            currentSize += 2.0f;
            getRichTextBox().Font = new Font(getRichTextBox().Font.Name, currentSize,
                getRichTextBox().Font.Style, getRichTextBox().Font.Unit);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = getRichTextBox().Font.Size;
            if (currentSize - 2.0f > 0)
            {
                currentSize -= 2.0f;
                getRichTextBox().Font = new Font(getRichTextBox().Font.Name, currentSize,
                getRichTextBox().Font.Style, getRichTextBox().Font.Unit);
            }
        }
    }
}
