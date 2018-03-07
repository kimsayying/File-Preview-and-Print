using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //code runs to save file to hard drive
        {
            // allow us to save file,file is saved in the location selected in the file save dialog 
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               // if richTextBox.text is empty string                
                if(richTextBox1.Text == "")
                {
                    MessageBox.Show("Please type something to save!!");
                }
                else
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName); // run and save the file text to an actual file

                    MessageBox.Show("File saved!!");
                    richTextBox1.Text = "";
                }   
               
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) //code runs to open file from hard drive
        {
            openFileDialog1.FileName = ""; //Load dialog name with no file name
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName); // load file from drive to rich text box
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} Please try open another file.");//shows the message from the exception object
                }
            }                                
        }

        private void txtOld_DoubleClick(object sender, EventArgs e) //code runs to find the matched value
        {   
            if (txtOld.Text.Length > 0)
            {
                richTextBox1.Find(txtOld.Text);
                richTextBox1.SelectionBackColor = Color.DeepSkyBlue;
                MessageBox.Show($"{richTextBox1.SelectedText}");
                //richTextBox1.SelectedText = txtNew.Text;
            }
        }

        private void txtNew_DoubleClick(object sender, EventArgs e) // code runs to replace the matched value to new value 
        {
            if (txtNew.Text != "")
            {
                richTextBox1.Text = richTextBox1.Text.Replace(txtOld.Text, txtNew.Text);
            }
        }

        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e) // code runs to change to font format
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) // show a box to show font dialog
            {
                richTextBox1.Font = fontDialog1.Font;    // richtextBox font set to the font chosen
                MessageBox.Show($"{fontDialog1.Font.Name}");
            }            
        }

        private void printPreviewPrintToolStripMenuItem_Click(object sender, EventArgs e) //code runs to preview pages using the PrintPreviewDialog control
        {
            printPreviewDialog1.Document = printDocument1;//choose document to be display in the preview panel
            printPreviewDialog1.ShowDialog();//brings up a little window to show a preview
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) //code behind the scene
        {
            //code runs when a page is about to be preview or a page is about to be printed
            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(richTextBox1.Text, fontDialog1.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);
        }

        //document properties set to printDocument1
        private void printToolStripMenuItem_Click(object sender, EventArgs e) // code runs when printing
        {
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print(); // call the print method to print the document
            }
           
        }
    }
}
