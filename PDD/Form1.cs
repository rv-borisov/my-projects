using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;


namespace PDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                if (ctrl.GetType().Name == "LinkLabel")
                {
                    ctrl.Visible = true;
                }
            }
            label1.Text = "Правила дорожного движения";
            richTextBox1.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                if (ctrl.GetType().Name == "LinkLabel")
                {
                    ctrl.Visible = false;
                }
                if (ctrl.GetType().Name == "RichTextBox")
                {
                    ctrl.Visible = false;
                }
            }
            label1.Text = "Тест";
        }
        private  void click_buttonPDD(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.BringToFront();
            richTextBox1.Visible = true;  
            label1.Text = (sender as LinkLabel).Text;

            Word.Application wordObject = new Word.Application();
            object File = Environment.CurrentDirectory + "\\" + (sender as LinkLabel).Text + ".docx";
            object nullobject = System.Reflection.Missing.Value;
            wordObject.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            Word._Document docs = wordObject.Documents.Open(ref File, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject);
            docs.ActiveWindow.Selection.WholeStory();
            docs.ActiveWindow.Selection.Copy();
            docs.Close(ref nullobject, ref nullobject, ref nullobject);
            richTextBox1.Paste();
            wordObject.Quit();
        }
    }
}
