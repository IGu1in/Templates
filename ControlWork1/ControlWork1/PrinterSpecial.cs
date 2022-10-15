namespace ControlWork1
{
	public class PrinterSpecial : PrinterDefault
	{
		public override void PrintString(string message)
		{
			base.PrintString($"({message})");
		}
	}
}
