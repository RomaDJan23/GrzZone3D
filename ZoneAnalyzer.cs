using Autodesk.AutoCAD.Geometry;
using System.Collections.Generic;

namespace GrzZone3DSource
{
    public static class ZoneAnalyzer
    {
        public static bool IsPointProtected(Point3d point, List<LightningRod> rods, double sphereRadius)
        {
            foreach (var rod in rods)
            {
                double dz = sphereRadius - rod.Height;
                if (dz <= 0) continue;

                double r = System.Math.Sqrt(sphereRadius * sphereRadius - dz * dz);
                double dist = point.DistanceTo(rod.BasePoint);

                if (dist <= r) return true;
            }
            return false;
        }
    }
}