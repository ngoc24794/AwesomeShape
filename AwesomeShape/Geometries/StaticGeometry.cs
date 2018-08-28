using AwesomeShape.Resource;
using media = System.Windows.Media;

namespace AwesomeShape.Geometries
{
    public class StaticGeometry : Geometry
    {
        private StaticShapeKind _kind;
        private string _pathData;
        public StaticGeometry(double width, double height, StaticShapeKind kind) : base(width, height)
        {
            _kind = kind;
        }

        protected override media.Geometry ToGeometry()
        {
            switch (_kind)
            {
                case StaticShapeKind.Rectangle:
                    _pathData = PathDataResources.Rectangle;
                    break;
                case StaticShapeKind.Ellipse:
                    _pathData = PathDataResources.Ellipse;
                    break;
                case StaticShapeKind.RightTriangle:
                    _pathData = PathDataResources.RightTriangle;
                    break;
                case StaticShapeKind.Diamond:
                    _pathData = PathDataResources.Diamond;
                    break;
                case StaticShapeKind.RegularPentagon:
                    _pathData = PathDataResources.RegularPentagon;
                    break;
                case StaticShapeKind.Heptagon:
                    _pathData = PathDataResources.Heptagon;
                    break;
                case StaticShapeKind.Decagon:
                    _pathData = PathDataResources.Decagon;
                    break;
                case StaticShapeKind.Process:
                    _pathData = PathDataResources.Process;
                    break;
                case StaticShapeKind.AlternateProcess:
                    _pathData = PathDataResources.AlternateProcess;
                    break;
                case StaticShapeKind.Decision:
                    _pathData = PathDataResources.Decision;
                    break;
                case StaticShapeKind.Data:
                    _pathData = PathDataResources.Data;
                    break;
                case StaticShapeKind.PredefinedProcess:
                    _pathData = PathDataResources.PredefinedProcess;
                    break;
                case StaticShapeKind.InternalStorage:
                    _pathData = PathDataResources.InternalStorage;
                    break;
                case StaticShapeKind.Document:
                    _pathData = PathDataResources.Document;
                    break;
                case StaticShapeKind.Multidocument:
                    _pathData = PathDataResources.Multidocument;
                    break;
                case StaticShapeKind.Terminator:
                    _pathData = PathDataResources.Terminator;
                    break;
                case StaticShapeKind.Preparation:
                    _pathData = PathDataResources.Preparation;
                    break;
                case StaticShapeKind.ManualInput:
                    _pathData = PathDataResources.ManualInput;
                    break;
                case StaticShapeKind.ManualOperation:
                    _pathData = PathDataResources.ManualOperation;
                    break;
                case StaticShapeKind.Connector:
                    _pathData = PathDataResources.Connector;
                    break;
                case StaticShapeKind.OffpageConnector:
                    _pathData = PathDataResources.OffpageConnector;
                    break;
                case StaticShapeKind.Card:
                    _pathData = PathDataResources.Card;
                    break;
                case StaticShapeKind.PunchedTape:
                    _pathData = PathDataResources.PunchedTape;
                    break;
                case StaticShapeKind.SummingJunction:
                    _pathData = PathDataResources.SummingJunction;
                    break;
                case StaticShapeKind.Or:
                    _pathData = PathDataResources.Or;
                    break;
                case StaticShapeKind.Collate:
                    _pathData = PathDataResources.Collate;
                    break;
                case StaticShapeKind.Sort:
                    _pathData = PathDataResources.Sort;
                    break;
                case StaticShapeKind.Extract:
                    _pathData = PathDataResources.Extract;
                    break;
                case StaticShapeKind.Merge:
                    _pathData = PathDataResources.Merge;
                    break;
                case StaticShapeKind.StoredData:
                    _pathData = PathDataResources.StoredData;
                    break;
                case StaticShapeKind.Delay:
                    _pathData = PathDataResources.Delay;
                    break;
                case StaticShapeKind.SequentialAccessStorage:
                    _pathData = PathDataResources.SequentialAccessStorage;
                    break;
                case StaticShapeKind.MagneticDisk:
                    _pathData = PathDataResources.MagneticDisk;
                    break;
                case StaticShapeKind.DirectAccessStorage:
                    _pathData = PathDataResources.DirectAccessStorage;
                    break;
                case StaticShapeKind.Display:
                    _pathData = PathDataResources.Display;
                    break;
                case StaticShapeKind.Explosion1:
                    _pathData = PathDataResources.Explosion1;
                    break;
                case StaticShapeKind.Explosion2:
                    _pathData = PathDataResources.Explosion2;
                    break;
            }
            media.PathGeometry pathGeometry = media.PathGeometry.CreateFromGeometry(media.Geometry.Parse(_pathData));
            pathGeometry = Helpers.FitBoundGeometry(pathGeometry, Width, Height);
            return pathGeometry;
        }
    }

    public enum StaticShapeKind
    {
        Rectangle,
        Ellipse,
        RightTriangle, Diamond, RegularPentagon, Heptagon, Decagon,
        Process, AlternateProcess, Decision, Data, PredefinedProcess,
        InternalStorage, Document, Multidocument, Terminator, Preparation,
        ManualInput, ManualOperation, Connector, OffpageConnector,
        Card, PunchedTape, SummingJunction, Or, Collate, Sort,
        Extract, Merge, StoredData, Delay, SequentialAccessStorage,
        MagneticDisk, DirectAccessStorage, Display, Explosion1, Explosion2
    }
}
