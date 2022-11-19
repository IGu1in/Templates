using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public interface IDrawable
	{
		public IEnumerable<Shape> CustomShapes { get; }
		void Draw(IEnumerable<System.Windows.Shapes.Line> lines);
	}
}