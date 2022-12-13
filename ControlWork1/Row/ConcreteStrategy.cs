using System;

namespace Row
{
	public class ConcreteStrategy : IStrategy
	{
		public int GetNext(int firstItem, int secondItem, int i)
		{
			return (int)Math.Pow(-1,i)*(firstItem-secondItem);
		}
	}
}
