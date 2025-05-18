using Autodesk.AutoCAD.Geometry;

namespace GrzZone3DSource
{
    public class LightningRod
    {
        public Point3d BasePoint { get; set; }
        public double Height { get; set; }

        public Point3d TopPoint => new Point3d(BasePoint.X, BasePoint.Y, BasePoint.Z + Height);

        public LightningRod(Point3d basePoint, double height)
        {
            BasePoint = basePoint;
            Height = height;
        }
    }
}