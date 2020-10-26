using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
	class Model
	{
		public double result { get; set; }

		public void Add(double num1, double num2)
		{
			result = num1 + num2;
		}

		public void Subtraction(double num1, double num2)
		{
			result = num1 - num2;
		}

		public void Multiplication(double num1, double num2)
		{
			result = num1 * num2;
		}

		public void Division(double num1, double num2)
		{
			result = num1 / num2;
		}

		public void Percent(double num1, double num2)
		{
			result = num1 / 100 * num2;
		}

		public void Pow(double num1, double num2)
		{
			result = Math.Pow(num1, num2);
		}

		public void Sqrt(double num1)
		{
			result = Math.Sqrt(num1);
		}

		public void Abs(double num1)
		{
			result = Math.Abs(num1);
		}

		public void Log10(double num1)
		{
			result = Math.Log10(num1);
		}

		public void Log(double num1)
		{
			result = Math.Log(num1);
		}

		public void Sin(double num1)
		{
			result = Math.Sin(num1);
		}
		public void Cos(double num1)
		{
			result = Math.Cos(num1);
		}

		public void Tan(double num1)
		{
			result = Math.Tan(num1);
		}

		public void Sec(double num1)
		{
			result = 1 / Math.Cos(num1);
		}
		public void Csc(double num1)
		{
			result = 1 / Math.Sin(num1);
		}
	}
}
