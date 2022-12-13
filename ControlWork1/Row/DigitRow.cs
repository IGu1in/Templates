using System.Collections.Generic;

namespace Row
{
	public class DigitRow : Item
	{
		private readonly Item _firstItem;
		private readonly Item _secondItem;
		private readonly IStrategy _strategy;
		private List<Item> _digits;

		public DigitRow(int firstItem, int secondItem, IStrategy strategy) : base(0)
		{
			_firstItem =new Item(firstItem);
			_secondItem = new Item(secondItem);
			_strategy = strategy;
			_digits = new List<Item>();
		}

		public void Build(int N)
		{
			_digits.Clear();
			_digits.Add(_firstItem);
			_digits.Add(_secondItem);

			for (int i = 2; i < N; i++)
			{
				_digits.Add(new Item(_strategy.GetNext(_digits[i - 1].GetValue(), _digits[i - 2].GetValue(), i)));
			}
		}

		public override void Iterate(Iterator i)
		{
			foreach(var item in _digits)
			{
				item.Iterate(i);
			}
		}
	}
}
