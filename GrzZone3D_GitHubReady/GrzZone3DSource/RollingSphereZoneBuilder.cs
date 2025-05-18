using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;

namespace GrzZone3DSource
{
    public static class RollingSphereZoneBuilder
    {
        public static List<Entity> BuildZones(List<LightningRod> rods, double sphereRadius)
        {
            var zones = new List<Entity>();

            foreach (var rod in rods)
            {
                double dz = sphereRadius - rod.Height;
                if (dz <= 0) continue;

                double r = System.Math.Sqrt(sphereRadius * sphereRadius - dz * dz);

                // Create a circle in XY plane at base point
                var circ = new Circle(rod.BasePoint, Vector3d.ZAxis, r);
                circ.Color = Color.FromRgb(0, 150, 255);
                zones.Add(circ);
            }

            return zones;
        }
    }
}