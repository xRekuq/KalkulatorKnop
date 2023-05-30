using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        double equal = .0;
        double pi = Math.PI;
        double e_ = Math.E;
        bool operandPressed = false;
        string action = "";
        List<string> operands = new List<string>();
        string[] tmp = { "+", "-", "*", "/", "=" , "%", "pi",",", "mod", "back", "e", "exp", "|x|", "2nd", "x2", "In", "+/-", "log", "10x", "²√x" };
        public MainWindow()
        {
            InitializeComponent();
            operands.AddRange(tmp.ToList());

        }
        private bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            string allowedCharacters = "0123456789+-*/.%";

            foreach (char c in input)
            {
                if (!allowedCharacters.Contains(c))
                {
                    return false;
                }
            }
            if (input.Contains("/0") || input.Contains("%0")) return false;

            return true;
        }

        private void btnnumber_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).Content.ToString();

            if (data == "=")
            {
                string x = ekran1.Text.Replace(',', '.');
                if (IsValidInput(x))
                {
                    DataTable dt = new DataTable();
                    var v = dt.Compute(x, "");
                    ekran1.Text = v.ToString();
                }
                else
                {
                    ekran1.Text = "Error: Invalid input";
                }
            }
            else
            {
                if (ekran1.Text == "Error: Invalid input")
                {
                    ekran1.Text = "";
                }
                ekran1.Text += data.ToString();
            }
        }


        private void OK_Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C)
            {
                ((Button)sender).Content = "WITAJ";
            }
            if (e.Key == Key.D)
            {
                ((Button)sender).Content = "ŻEGNAJ";
            }
        }

        private void ce(object sender, RoutedEventArgs e)
        {
           equal = .0;
           operandPressed = false;
           action = "";
           ekran1.Text = "";
        }

        private void etykieta1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (ekran.Text)
        }

        private void ekran1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comma_click(object sender, RoutedEventArgs e)
        {
            ekran1.Text += ".";
        }

        private void plusminus_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            if (math[0] == '-')
            {
                math = math.Substring(1);
            }
            else
            {
                math = "-" + math;
            }
            ekran1.Text = math;
        }

        private void pi_click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            char last = math[math.Length - 1];
            if (last == '+' || last == '-' || last == '/' || last == '*')
            {
                math += pi.ToString();
                ekran1.Text = math;
            }
            else
            {
                ekran1.Text = pi.ToString();
            }
        }

        private void pierw_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            
            double sqrt = Math.Sqrt(Convert.ToInt32(math));
            ekran1.Text = sqrt.ToString();
        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            char last = math[math.Length - 1];
            if (last == '+' || last == '-' || last == '/' || last == '*')
            {
                math += e_.ToString();
                ekran1.Text = math;
            }
            else
            {
                ekran1.Text = e_.ToString();
            }
        }

        private void log_click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            double log = 0;
            if (((Button)sender).Content.ToString() == "log")
            {
            log = Math.Log(Convert.ToDouble(math),10);
                
            }
            else
            {
                log = Math.Log(Convert.ToDouble(math));
            }
            ekran1.Text = log.ToString();
        }

        private void Pow_click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            int y = Convert.ToInt32(math);
            double x = 0;
            if (((Button)sender).Content.ToString() == "10x")
            {
            x = Math.Pow(10,y);
            }
            else
            {
                x = Math.Pow(y, 2);
            }
            ekran1.Text = x.ToString();
        }

        private void Mianownik_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            if (IsValidInput(math))
            {
                double x = Convert.ToDouble(math);
                if (x != 0)
                {
                    double y = 1 / x;
                    ekran1.Text = y.ToString();
                }
                else
                {
                    ekran1.Text = "Error: Division by zero";
                }
            }
            else
            {
                ekran1.Text = "Error: Invalid input";
            }
        }

        private void Nawias_Click(object sender, RoutedEventArgs e)
        {
            ekran1.Text += ((Button)sender).Content;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            if (ekran1.Text != "")
            {
               string back = math.Substring(0, math.Length - 1);
               ekran1.Text = back;
            }
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            double rad = Convert.ToDouble(math) * (pi / 180);
            double wynik = Math.Tan(rad);
            ekran1.Text = wynik.ToString();

        }

        private void SinCos_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            double kat = pi * Convert.ToDouble(math) / 180;
            double x = 0;
            if (((Button)sender).Content.ToString() == "sin")
            {
                x = Math.Sin(kat);
            }
            else
            {
                x = Math.Cos(kat);
            }
            ekran1.Text = x.ToString();
        }

        private void rand_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            double x = rand.NextDouble();
            ekran1.Text = x.ToString();
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            ekran1.Text += "%";
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Fact_Click(object sender, RoutedEventArgs e)
        {
            string math = ekran1.Text.ToString();
            int x = Convert.ToInt32(math);
            for (int i = x- 1; i > 0; i--)
            {
                x = x * i;
            }
            ekran1.Text = x.ToString();
        }
    }
}
