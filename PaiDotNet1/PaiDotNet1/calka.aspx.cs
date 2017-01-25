using System;
using System.Collections.Generic;
using System.Drawing;
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
            Chart1.Visible = true;
            Chart1.Series.Clear();
            Chart1.Titles.Clear();
            
            Chart1.Titles.Add("Całka sinx");
            Chart1.ChartAreas[0].AxisX.Title = "Oś wartości X";
            Chart1.ChartAreas[0].AxisY.Title = "Oś wartości Y";
            Chart1.ChartAreas[0].AxisY.LineWidth = 5;
            
            Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
            Chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            Chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = System.Web.UI.DataVisualization.Charting.ChartDashStyle.Dot;
            
            Chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            Chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Silver;
            Chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = System.Web.UI.DataVisualization.Charting.ChartDashStyle.Dot;
            
            Chart1.Series.Add("Wykres sinx");

            Chart1.Series["Wykres sinx"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series["Wykres sinx"].Color = Color.DarkBlue;
            Chart1.Series["Wykres sinx"].BorderWidth = 2;

            Chart1.Series.Add("Wykres cosx");

            Chart1.Series["Wykres cosx"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series["Wykres cosx"].Color = Color.DarkOrange;
            Chart1.Series["Wykres cosx"].BorderWidth = 2;


            double a = double.Parse(TextBox1.Text);
            double b = double.Parse(TextBox2.Text);
            int liczbaWatkow = 8;
            
            Label1.Text = sinus2(a,b,liczbaWatkow).ToString();


            for (double x = a; x <= b; x += 0.001)
            {
                Chart1.Series["Wykres sinx"].Points.AddXY(x, Math.Sin(x));
                Chart1.Series["Wykres cosx"].Points.AddXY(x, Math.Cos(x));
            }
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