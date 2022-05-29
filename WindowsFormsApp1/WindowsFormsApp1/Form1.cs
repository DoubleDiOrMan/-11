using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string result = "";
        public static bool IsCoprime(int num1, int num2)
        {
            if (num1 == num2)
            {
                return num1 == 1;
            }
            else
            {
                if (num1 > num2)
                {
                    return IsCoprime(num1 - num2, num2);
                }
                else
                {
                    return IsCoprime(num2 - num1, num1);
                }
            }
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsCoprime(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)))
            {
                textBox3.Clear();
                textBox3.Text = "Числа " + textBox1.Text + " и " + textBox2.Text + " взаимно простые";
            }
            else
            {
                textBox3.Clear();
                textBox3.Text = "Числа " + textBox1.Text + " и " + textBox2.Text + " не взаимно простые";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = textBox3.Text;
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
                MessageBox.Show("Успешно", "!");
            }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = "";
            result = textBox3.Text + "\n\n";
            System.IO.File.AppendAllText(@"C:\Users\double_di\Desktop\huita.txt", result);
            MessageBox.Show("Запись успешна", "Успех!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
