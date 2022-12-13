using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Row
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var strat = new ConcreteStrategy();
			var row = new DigitRow(2, 5, strat);
			row.Build(10);
			//row.Iterate(r => Console.WriteLine(r));

			var row2 = new DigitRow(2,15, strat);
			row2.Build(5);

			var row4 = new DigitRow(7, 2, strat);
			row4.Build(3);

			var row3 = new RowCompose();
			row3.Add(row);
			row3.Add(row2);
			row3.Add(row4);
			row3.Build(7);
			row3.Iterate(r => Console.WriteLine(r));

			Console.ReadLine();
		}
	}
}
