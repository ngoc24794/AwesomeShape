using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using AwesomeShape;

namespace AwesomeShapeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Container _container;
        public MainWindow()
        {
            InitializeComponent();

            WrapPanel panel = new WrapPanel();

            for (int i = 0; i < 100; i++)
            {
                Container container = new Container()
                {
                    Width = 200,
                    Height = 120
                };
                Shape shape = CreateShape(container);
                container.Add(shape);
                panel.Children.Add(container);
            }

            Content = panel;
        }

        private Shape CreateShape(Container container)
        {
            Shape shape = new Rectangle()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Red,
                StrokeThickness = 5
            };

            _container = new Container()
            {
                Width = 200,
                Height = 120
            };

            BindingOperations.SetBinding(shape, Shape.WidthProperty, new Binding("Width")
            {
                Source = _container,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            BindingOperations.SetBinding(shape, Shape.HeightProperty, new Binding("Height")
            {
                Source = _container,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            return shape;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            _container.Width = Math.Max(0, Math.Min(500, _container.Width + e.Delta / 10));
            _container.Height = Math.Max(0, Math.Min(500, _container.Height + e.Delta / 10));
        }

        public class Container : FrameworkElement
        {
            private VisualCollection _visuals;

            public Container()
            {
                _visuals = new VisualCollection(this);
            }

            public void Add(Visual visual)
            {
                _visuals.Add(visual);
            }

            protected override Visual GetVisualChild(int index)
            {
                return _visuals[index];
            }

            protected override int VisualChildrenCount => _visuals.Count;
        }
    }
}
