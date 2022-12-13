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
			row.Iterate(r => Console.WriteLine(r));
			Console.ReadLine();
		}
	}
}
