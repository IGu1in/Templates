using System.Collections.Generic;
using System.Windows.Controls;

namespace IndependentWork1
{
	public interface IDrawable
	{
		void Draw(Canvas canvas, IEnumerable<IPoint> points);
	}
}