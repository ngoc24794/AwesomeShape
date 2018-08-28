using System;
using System.Windows;
using System.Windows.Media;

namespace AwesomeShape
{
    public static class Helpers
    {
        public static PathGeometry FitBoundGeometry(PathGeometry pathGeometry, double width, double height)
        {
            PathGeometry result = pathGeometry;
            Rect rect = pathGeometry.GetRenderBounds(null);
            if (rect != null && rect.Width > 0 && rect.Height > 0)
            {
                double
                    scaleX = width / rect.Width,
                    scaleY = height / rect.Height;
                Point origin = rect.TopLeft;
                result = FitBound(pathGeometry.Figures, origin, scaleX, scaleY);
            }
            return result;
        }

        private static PathGeometry FitBound(PathFigureCollection pathFigures, Point origin, double scaleX = 1, double scaleY = 1, int decimals = 2)
        {
            Point vector = new Point(-origin.X, -origin.Y);
            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            PathGeometry pathGeometry = new PathGeometry()
            {
                Figures = pathFigureCollection
            };

            foreach (PathFigure figure in pathFigures)
            {
                Point startPoint = FitBound(figure.StartPoint, vector, scaleX, scaleY, decimals);
                PathFigure newPathFigure = new PathFigure()
                {
                    StartPoint = startPoint,
                    IsClosed = figure.IsClosed,
                    IsFilled = figure.IsFilled
                };
                foreach (PathSegment segment in figure.Segments)
                {
                    if (segment is LineSegment lineSegment)
                    {
                        LineSegment newLineSegment = new LineSegment()
                        {
                            Point = FitBound(lineSegment.Point, vector, scaleX, scaleY, decimals)
                        };
                        newPathFigure.Segments.Add(newLineSegment);
                    }
                    else if (segment is PolyLineSegment polyLineSegment)
                    {
                        PolyLineSegment newPolyLineSegment = new PolyLineSegment();
                        foreach (Point p in polyLineSegment.Points)
                        {
                            newPolyLineSegment.Points.Add(FitBound(p, vector, scaleX, scaleY, decimals));
                        }
                        newPathFigure.Segments.Add(newPolyLineSegment);
                    }
                    else if (segment is PolyBezierSegment polyBezierSegment)
                    {
                        PolyBezierSegment newPolyBezierSegment = new PolyBezierSegment();
                        foreach (Point p in polyBezierSegment.Points)
                        {
                            newPolyBezierSegment.Points.Add(FitBound(p, vector, scaleX, scaleY, decimals));
                        }
                        newPathFigure.Segments.Add(newPolyBezierSegment);
                    }
                    else if (segment is PolyQuadraticBezierSegment polyQuadraticBezierSegment)
                    {
                        PolyQuadraticBezierSegment newPolyQuadraticBezierSegment = new PolyQuadraticBezierSegment();
                        foreach (Point p in polyQuadraticBezierSegment.Points)
                        {
                            newPolyQuadraticBezierSegment.Points.Add(FitBound(p, vector, scaleX, scaleY, decimals));
                        }
                        newPathFigure.Segments.Add(newPolyQuadraticBezierSegment);
                    }
                    else if (segment is QuadraticBezierSegment quadraticBezierSegment)
                    {
                        QuadraticBezierSegment newQuadraticBezierSegment = new QuadraticBezierSegment()
                        {
                            Point1 = FitBound(quadraticBezierSegment.Point1, vector, scaleX, scaleY, decimals),
                            Point2 = FitBound(quadraticBezierSegment.Point2, vector, scaleX, scaleY, decimals)
                        };
                        newPathFigure.Segments.Add(newQuadraticBezierSegment);
                    }
                    else if (segment is ArcSegment arcSegment)
                    {
                        ArcSegment newArcSegment = new ArcSegment()
                        {
                            Point = FitBound(arcSegment.Point, vector, scaleX, scaleY, decimals),
                            Size = arcSegment.Size,
                            IsLargeArc = arcSegment.IsLargeArc,
                            SweepDirection = arcSegment.SweepDirection,
                            RotationAngle = arcSegment.RotationAngle
                        };
                        newPathFigure.Segments.Add(newArcSegment);
                    }
                    else if (segment is BezierSegment bezierSegment)
                    {
                        BezierSegment newBezierSegment = new BezierSegment()
                        {
                            Point1 = FitBound(bezierSegment.Point1, vector, scaleX, scaleY, decimals),
                            Point2 = FitBound(bezierSegment.Point2, vector, scaleX, scaleY, decimals),
                            Point3 = FitBound(bezierSegment.Point3, vector, scaleX, scaleY, decimals),
                        };
                        newPathFigure.Segments.Add(newBezierSegment);
                    }
                }
                pathFigureCollection.Add(newPathFigure);
            }

            return pathGeometry;
        }

        private static Point FitBound(Point point, Point vector, double scaleX = 1, double scaleY = 1, int decimals = 2)
        {
            return new Point()
            {
                X = Math.Round((point.X + vector.X) * scaleX, decimals),
                Y = Math.Round((point.Y + vector.Y) * scaleY, decimals)
            };
        }
    }
}
