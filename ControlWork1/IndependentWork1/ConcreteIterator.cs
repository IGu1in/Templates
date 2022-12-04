namespace IndependentWork1
{
	public class ConcreteIterator : IIterator
	{
		private Composite collection;
		private int current = 0;
		private int step = 1;

		public ConcreteIterator(Composite collection)
		{
			this.collection = collection;
		}

		public bool IsCompleted
		{
			get { return current >= collection.Count; }
		}

		public ICurve First()
		{
			current = 0;

			return collection[current];
		}

		public ICurve Next()
		{
			current += step;

			if (!IsCompleted)
			{
				return collection[current];
			}
			else
			{
				return null;
			}
		}
	}
}
