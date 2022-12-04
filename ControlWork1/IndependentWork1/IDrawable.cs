using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public interface IDrawable
	{
		public IEnumerable<Shape> CustomShapes { get; }
		void Clear(IEnumerable<System.Windows.Shapes.Line> lines, bool hasFirstPoint = true, bool hasLastPoint = true);
		void DrawLine(IEnumerable<System.Windows.Shapes.Line> lines);
		void DrawStartPoint(double x, double y);
		void DrawEndPoint(double x, double y);

		void DrawCentralPoint(Ellipse el);
	}
}