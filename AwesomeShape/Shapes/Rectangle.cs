
namespace AwesomeShape.Shapes
{
    using System.Windows.Media;
    using geometry = Geometries;
    public class Rectangle : Shape
    {
        protected override Geometry GetGeomtry()
        {
            return new geometry.RectangleGeometry(Width, Height);
        }
    }
}
