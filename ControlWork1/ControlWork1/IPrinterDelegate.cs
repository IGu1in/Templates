namespace ControlWork1
{
	public interface IPrinterDelegate : IPrinter
	{
		void Print(IPrintable print);
	}
}
