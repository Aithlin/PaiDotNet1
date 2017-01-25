using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaiDotNet1
{
    public partial class calka : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(TextBox1.Text);
            double b = double.Parse(TextBox2.Text);
            int liczbaWatkow = 8;
            
            Label1.Text = sinus2(a,b,liczbaWatkow).ToString();
        }

        private double sinus2(double a, double b, int liczbaWatkow)
        {
            int dokladnosc = 1000;
            double przedzial = (b - a) / liczbaWatkow;
            double[] wynik = new double[liczbaWatkow];

            Parallel.For(0, liczbaWatkow, (int x) =>
             {
                 double start = a + x * przedzial;
                 double koniec = start + przedzial;

                 wynik[x] = sinus(start, koniec, dokladnosc);
             });

            return wynik.Sum();
        }

        private double sinus(double a, double b, double dokladnosc = 1000)
        {
            double h = (b - a) / dokladnosc;
            double wynik = 0.0;

            for(double x=a;x<b;x+=h)
            {
                wynik += trapez(Math.Sin(x)-Math.Cos(x), Math.Sin(x + h)- Math.Cos(x + h), h);
            }

            return wynik;
        }

        private double trapez(double a, double b, double h)
        {
            return (a + b) * h / 2;
        }
    }
}