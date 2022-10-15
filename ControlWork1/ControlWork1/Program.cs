using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var txt = new Text
			( 
				new List<IPrintable> 
				{
					new Word("Тестируем"), new Sign(' '),
					new Word("мою"), new Sign(' '),
					new Word("архитектуру"), new Sign('!')
				}
			);
			txt.Print(new PrinterDefault());
			Console.WriteLine();

			txt.Print(new PrinterSpecial());
			Console.WriteLine();

			var pd = new PrinterDefault();
			pd.Print(txt);
		}
	}
}
