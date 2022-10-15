using System.Collections.Generic;

namespace ControlWork1
{
	public class Text : IPrintable
	{
		private List<IPrintable> _list;

		public Text(List<IPrintable> printList)
		{
			_list = new List<IPrintable>();
			_list.AddRange(printList);
		}

		public void Print(IPrinter printer)
		{
			foreach(var print in _list)
			{
				print.Print(printer);
			}
		}
	}
}
