using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;

[assembly: CommandClass(typeof(GrzZone3DSource.Commands))]

namespace GrzZone3DSource
{
    public class Commands
    {
        [CommandMethod("GRZZONE3D")]
        public void CreateGrzZone()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var ed = doc.Editor;

            var rods = new List<LightningRod>();
            PromptDoubleOptions prRad = new PromptDoubleOptions("\nEnter rolling sphere radius (m):");
            prRad.AllowNegative = false;
            var radRes = ed.GetDouble(prRad);
            if (radRes.Status != PromptStatus.OK) return;
            double sphereRadius = radRes.Value;

            while (true)
            {
                var ptRes = ed.GetPoint("\nSelect lightning rod base point (ENTER to finish):");
                if (ptRes.Status != PromptStatus.OK) break;

                var hRes = ed.GetDouble("\nEnter lightning rod height:");
                if (hRes.Status != PromptStatus.OK) continue;

                rods.Add(new LightningRod(ptRes.Value, hRes.Value));
            }

            var db = doc.Database;
            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                var zones = RollingSphereZoneBuilder.BuildZones(rods, sphereRadius);
                foreach (var ent in zones)
                {
                    btr.AppendEntity(ent);
                    tr.AddNewlyCreatedDBObject(ent, true);
                }

                tr.Commit();
            }

            ed.WriteMessage("\nProtection zones created.");
        }
    }
}