using System;
using System.Collections.Generic;
using System.Linq;
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
            
            Label1.Text = sinus(a,b).ToString();
        }

        private double sinus(double a, double b)
        {
            int dokladnosc = 1000;
            double h = (b - a) / dokladnosc;
            double wynik = 0.0;

            for(double x=a;x<b;x+=h)
            {
                wynik += trapez(Math.Sin(x), Math.Sin(x + h), h);
            }

            return wynik;
        }

        private double trapez(double a, double b, double h)
        {
            return (a + b) * h / 2;
        }
    }
}