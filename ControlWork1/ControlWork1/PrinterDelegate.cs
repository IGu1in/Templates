using System;

namespace ControlWork1
{
	public class PrinterDelegate : IPrinterDelegate
	{
		public void Print(IPrintable print)
		{
			print.Print(this);
		}

		public void PrintChar(char message)
		{
			Console.Write(message);
		}

		public void PrintString(string message)
		{
			Console.Write(message);
		}
	}
}
