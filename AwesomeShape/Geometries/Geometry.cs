namespace AwesomeShape.Geometries
{
    using media = System.Windows.Media;
    public abstract class Geometry
    {
        protected Geometry(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }        
        protected virtual media.Geometry ToGeometry()
        {
            return media.Geometry.Empty;
        }
        public static implicit operator media.Geometry(Geometry geometry)
        {
            return geometry.ToGeometry();
        }
    }
}
