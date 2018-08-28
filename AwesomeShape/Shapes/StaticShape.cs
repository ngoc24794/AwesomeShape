using AwesomeShape.Geometries;
using System.Windows;
using media = System.Windows.Media;

namespace AwesomeShape.Shapes
{
    public class StaticShape : Shape
    {
        public StaticShapeKind Kind
        {
            get { return (StaticShapeKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public static readonly DependencyProperty KindProperty =
            DependencyProperty.Register("Kind", typeof(StaticShapeKind), typeof(StaticShape), new PropertyMetadata(default(StaticShapeKind), OnPropertyChangedCallback));

        protected override media.Geometry GetGeomtry()
        {
            return new StaticGeometry(Width, Height, Kind);
        }
    }    
}
