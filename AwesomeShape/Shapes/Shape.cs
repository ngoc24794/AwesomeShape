using System.Windows;
using System.Windows.Media;

namespace AwesomeShape.Shapes
{
    public abstract class Shape : DrawingVisual
    {
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(Shape), new PropertyMetadata(0.0, OnPropertyChangedCallback));


        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(Shape), new FrameworkPropertyMetadata(0.0, OnPropertyChangedCallback));
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(Shape), new PropertyMetadata(null, AffectsRender));

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(Shape), new PropertyMetadata(null, AffectsRender));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(Shape), new PropertyMetadata(0.0, AffectsRender));

        protected static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Shape shape = d as Shape;
            shape.BeforeDefiningGeometry();
            shape.DefiningGeometry();
            shape.InvalidateVisual();
        }

        protected static void AffectsRender(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Shape shape = d as Shape;
            shape.InvalidateVisual();
        }

        protected virtual void BeforeDefiningGeometry()
        {
        }

        private void InvalidateVisual()
        {
            DrawShape();
        }

        public Geometry Geometry { get; set; }
        public Shape()
        {
            DrawShape();
        }

        private void DrawShape()
        {
            using (DrawingContext c = RenderOpen())
            {
                c.DrawGeometry(Fill, GetPen(), Geometry);
            }
        }

        protected virtual void DefiningGeometry()
        {
            Geometry = GetGeomtry();
        }

        protected virtual Geometry GetGeomtry()
        {
            return Geometry.Empty;
        }

        protected virtual Pen GetPen()
        {
            return new Pen(Stroke, StrokeThickness);
        }
    }
}
