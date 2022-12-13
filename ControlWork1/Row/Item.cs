namespace Row
{
	public class Item : IIterator
	{
		private int _value;

		public Item(int value)
		{
			_value = value;
		}

		public int GetValue() => _value;

		public virtual void Iterate(Iterator i)
		{
			i(this);
		}

		public sealed override string ToString()
		{
			return _value.ToString();
		}
	}
}
