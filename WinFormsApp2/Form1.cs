using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtR.Text = Properties.Settings.Default.circleRadius.ToString();
            txtSide.Text = Properties.Settings.Default.sideOfaSquare.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int circleRadius, sideOfaSquare;
            try
            {
                circleRadius = int.Parse(this.txtR.Text);
                sideOfaSquare = int.Parse(this.txtSide.Text);
            }
            catch (FormatException)
            {
                return;
            }
            Properties.Settings.Default.circleRadius = circleRadius;
            Properties.Settings.Default.sideOfaSquare = sideOfaSquare;
            Properties.Settings.Default.Save();
            MessageBox.Show(Logic.Compare(circleRadius, sideOfaSquare));
        }
        public class Logic
        {
            public static string Compare(int circleRadius, int sideOfaSquare)
            {
                string outMessage = "";
                double circleS = Math.Pow(circleRadius, 2) * Math.PI;
                double SquareS = Math.Pow(sideOfaSquare, 2);
                if (Math.Abs(circleS - SquareS) >= 0.000000000001)
                {
                    if (circleS > SquareS)
                    {
                        outMessage = "Площадь Круга больше площади квадрата";
                    }

                    else if (circleS < SquareS)
                    {
                        outMessage = "Площадь Круга меньше площади квадрата";
                    }
                }
                else
                {
                    outMessage = "Площадь Круга и площадь квадрата равны";
                }
                return outMessage;
            }
        }


    }
}