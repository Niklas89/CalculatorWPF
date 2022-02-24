using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculate cal = new Calculate();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            // cast sender to button
            Button button = (Button)sender;
            displayResult.Text += button.Content.ToString();

        }

        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == resetButton)
            {
                displayResult.Text = "";
            }
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception ex)
            {
                displayResult.Text = "Error!";
            }
        }

        private void Calculate()
        {
            // méthode plus rapide :
            // string result = new DataTable().Compute(displayResult.Text, null).ToString();
            // displayResult.Text = result;


            int opPos = 0;
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            string op = "";

            if (displayResult.Text.Contains("*"))
            {
                opPos = displayResult.Text.IndexOf("*");
            }
            else if (displayResult.Text.Contains("/"))
            {
                opPos = displayResult.Text.IndexOf("/");
            }
            else if (displayResult.Text.Contains("+"))
            {
                opPos = displayResult.Text.IndexOf("+");
            }
            else if (displayResult.Text.Contains("-"))
            {
                opPos = displayResult.Text.IndexOf("-");
            }

            value1 = Double.Parse(displayResult.Text.Substring(0, opPos));
            op = displayResult.Text.Substring(opPos, 1);
            value2 = Double.Parse(displayResult.Text.Substring(opPos + 1, displayResult.Text.Length - opPos - 1));

            if (op == "*")
            {
                result = cal.multiply(value1, value2);
                displayResult.Text = result.ToString();
            }
            else if (op == "/")
            {
                if (value2 == 0)
                {
                    displayResult.Text = "Don't / 0";
                }
                else
                {
                    result = cal.divide(value1, value2);
                    displayResult.Text = result.ToString();
                }
            }
            else if (op == "+")
            {
                result = cal.add(value1, value2);
                displayResult.Text = result.ToString();
            }
            else if (op == "-")
            {
                result = cal.subtract(value1, value2);
                displayResult.Text = result.ToString();
            }

            
        
    }
    }
}
