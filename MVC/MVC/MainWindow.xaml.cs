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

namespace MVC
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Calculate calc;
		string sign;

		public MainWindow()
		{
			InitializeComponent();
			calc = new Calculate();
		}

		private void Calculate_Click(object sender, RoutedEventArgs e) // Получение значений
		{
			string text1 = Num1Box.Text.Trim();
			string text2 = Num2Box.Text.Trim();
			double num1 = 0;
			double num2 = 0;
			if (string.IsNullOrEmpty(text2)) text2 = "0";
			if (!string.IsNullOrEmpty(text1) && !string.IsNullOrEmpty(text2))
			{
				try
				{
					num1 = Convert.ToInt32(text1);
					num2 = Convert.ToInt32(text2);
				}
				catch (Exception exc) { }
				Calculate(num1, num2);

				Result.Text = calc.result.ToString();
			}
		}

		public void ButonClick(object sender, RoutedEventArgs e)
		{
			sign = ((Button)sender).Content.ToString();
			SignBox.Text = sign;
		}

		public void Calculate(double num1, double num2)
		{
			switch (sign)
			{
				case "+":
					calc.Add(num1, num2);
					break;
				case "-":
					calc.Subtraction(num1, num2);
					break;
				case "*":
					calc.Multiplication(num1, num2);
					break;
				case "/":
					calc.Division(num1, num2);
					break;
				case "%":
					calc.Percent(num1, num2);
					break;
				case "^":
					calc.Pow(num1, num2);
					break;
				case "√":
					calc.Sqrt(num1);
					break;
				case "|x|":
					calc.Abs(num1);
					break;
				case "log":
					calc.Log10(num1);
					break;
				case "ln":
					calc.Log(num1);
					break;
				case "sin":
					calc.Sin(num1);
					break;
				case "cos":
					calc.Cos(num1);
					break;
				case "tan":
					calc.Tan(num1);
					break;
				case "sec":
					calc.Sec(num1);
					break;
				case "csc":
					calc.Csc(num1);
					break;
			}
		}
	}
}

