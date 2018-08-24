using System.Windows.Media;

namespace AwesomeShape
{
    public class Rectangle : Shape
    {
        protected override Geometry GetGeomtry()
        {
            return new RectangleGeometry(new System.Windows.Rect(0, 0, Width, Height));
        }
    }
}
