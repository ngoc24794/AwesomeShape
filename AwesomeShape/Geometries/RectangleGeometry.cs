using media = System.Windows.Media;

namespace AwesomeShape.Geometries
{
    public class RectangleGeometry : Geometry
    {
        public RectangleGeometryKind Kind { get; set; }
        public RectangleGeometry(double width, double height) : base(width, height)
        {
        }

        protected override media.Geometry ToGeometry()
        {
            return new media.RectangleGeometry(new System.Windows.Rect(0, 0, Width, Height));
        }
    }

    public enum RectangleGeometryKind
    {

    }
}
