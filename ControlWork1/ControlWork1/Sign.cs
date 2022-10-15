namespace ControlWork1
{
	public class Sign : IPrintable
	{
		private char _textForPrint;

		public Sign(char textForPrint)
		{
			_textForPrint = textForPrint;
		}

		public void Print(IPrinter printer)
		{
			printer.PrintChar(_textForPrint);
		}
	}
}
