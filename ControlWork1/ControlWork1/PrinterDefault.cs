using System;

namespace ControlWork1
{
	public class PrinterDefault : IPrinter
	{
		public void PrintChar(char message)
		{
			Console.Write(message);
		}

		public virtual void PrintString(string message)
		{
			Console.Write(message);
		}
	}
}
