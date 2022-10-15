namespace ControlWork1
{
	public class Word : IPrintable
	{
		private string _textForPrint;

		public Word(string textForPrint)
		{
			_textForPrint = textForPrint;
		}

		public void Print(IPrinter printer)
		{
			printer.PrintString(_textForPrint);
		}
	}
}
