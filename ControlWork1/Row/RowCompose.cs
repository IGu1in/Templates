using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Row
{
	public class RowCompose : DigitRow
	{
		private List<DigitRow> _digitRows = new List<DigitRow>();
		private List<Item> _items = new List<Item>();

		public RowCompose() : base(0, 0, new ConcreteStrategy())
		{
		}

		public override void Add(DigitRow row)
		{
			_digitRows.Add(row);
		}

		public override void Remove(DigitRow row)
		{
			_digitRows.Remove(row);
		}

		public override void Build(int N)
		{
			_items.Clear();

			foreach (DigitRow row in _digitRows)
			{
				row.Build(N);
			}

			var listDigits = new List<List<int>>();

			foreach (var row in _digitRows)
			{
				var list = new List<int>();

				row.Iterate(r =>
				{
					list.Add(int.Parse(r.ToString()));
				});

				listDigits.Add(list);
			}

			for (int i = 0; i < N; i++)
			{
				var value = 0;

				foreach (var digitRow in listDigits)
				{
					value += digitRow[i];
				}

				_items.Add(new Item(value));
			}
		}

		public override void Iterate(Iterator i)
		{
			foreach (var item in _items)
			{
				item.Iterate(i);
			}
		}
	}
}
