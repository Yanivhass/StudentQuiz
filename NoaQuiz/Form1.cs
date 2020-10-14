using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentQuiz
{
    public partial class Form1 : Form
    {
        string[] lines;
        int currLine = 0;
        
        public Form1()
        {
            InitializeComponent();
             lines = System.IO.File.ReadAllLines(@"C:\QuizData.csv");
            //should be formatted as question,answer
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
           
            string[] line = lines[currLine].Split(',');

            bool done = true;
            foreach (string lineA in lines)
            {
                if (!lineA.Contains("DONE"))
                {
                    done = false;
                    break;
                }
            }
            if (done)
            {
                richTextBox1.Text = "DONE";
                richTextBox2.Text = "DONE";
                return;

            }
            if (richTextBox1.Text == "")
            {
                currLine = r.Next(0, lines.Length);
                line = lines[currLine].Split(',');
                richTextBox1.Text = line[0];
                line[0] = "DONE";
                return;
            }
            if (richTextBox2.Text != "")
            {
                do
                {
                    currLine = r.Next(0, lines.Length);
                    line = lines[currLine].Split(',');
                }
                while (line[0] == "DONE");
                richTextBox1.Text = line[0];
                richTextBox2.Text = "";
                
            }
            else
            {
                string s = "";
                for (int i = 1; i < line.Length; i++)
                {
                    s += line[i] + " ";
                }

                richTextBox2.Text = s;
            }

            
        }
    }
}
