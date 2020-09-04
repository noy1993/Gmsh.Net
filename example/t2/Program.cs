using GmshNet;
using System;

namespace t2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t2");
            double lc = 1E-2;
            Gmsh.Model.Geo.AddPoint(0, 0, 0, lc, 1);
            Gmsh.Model.Geo.AddPoint(0.1, 0, 0, lc, 2);
            Gmsh.Model.Geo.AddPoint(0.1, 0.3, 0, lc, 3);
            Gmsh.Model.Geo.AddPoint(0, 0.3, 0, lc, 4);

            Gmsh.Model.Geo.AddLine(1, 2, 1);
            Gmsh.Model.Geo.AddLine(3, 2, 2);
            Gmsh.Model.Geo.AddLine(3, 4, 3);
            Gmsh.Model.Geo.AddLine(4, 1, 4);

            Gmsh.Model.Geo.AddCurveLoop(new[] { 4, 1, -2, 3 }, 1);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 1 }, 1);
            Gmsh.Model.AddPhysicalGroup(1, new[] { 1, 2, 4 }, 5);

            int ps = Gmsh.Model.AddPhysicalGroup(2, new[] { 1 });
            Gmsh.Model.SetPhysicalName(2, ps, "My surface");

            // We can then add new points and curves in the same way as we did in "t1"
            Gmsh.Model.Geo.AddPoint(0, 0.4, 0, lc, 5);
            Gmsh.Model.Geo.AddLine(4, 5, 5);
            Gmsh.Model.Geo.Translate(new[] { (0, 5) }, -0.02, 0, 0);
            Gmsh.Model.Geo.Rotate(new[] { (0, 5) }, 0, 0.3, 0, 0, 0, 1, -Math.PI / 4);
            // Note that there are no units in Gmsh: coordinates are just numbers - it's
            // up to the user to associate a meaning to them.

            // Point 3 can be duplicated and translated by 0.05 along the y axis by using
            // the `copy()' function, which takes a vector of (dim, tag) pairs as input,
            // and returns another vector of (dim, tag) pairs:
            Gmsh.Model.Geo.Copy(new[] { (0, 3) }, out ValueTuple<int, int>[] ov);
            Gmsh.Model.Geo.Translate(ov, 0, 0.05, 0);
            // The new point tag is available in ov[0].Item2, and can be used to create
            // new lines:
            Gmsh.Model.Geo.AddLine(3, ov[0].Item2, 7);
            Gmsh.Model.Geo.AddLine(ov[0].Item2, 5, 8);
            Gmsh.Model.Geo.AddCurveLoop(new[] { 5, -8, -7, 3 }, 10);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 10 }, 11);

            // In the same way, we can translate copies of the two surfaces 1 and 11 to
            // the right with the following command:
            Gmsh.Model.Geo.Copy(new[] { (2, 1), (2, 11) }, out ov);
            Gmsh.Model.Geo.Translate(ov, 0.12, 0, 0);

            Console.WriteLine($"New surfaces '{ov[0].Item2}' and '{ov[1].Item2}'");
            Gmsh.Model.Geo.AddPoint(0, 0.3, 0.12, lc, 100);
            Gmsh.Model.Geo.AddPoint(0.1, 0.3, 0.12, lc, 101);
            Gmsh.Model.Geo.AddPoint(0.1, 0.35, 0.12, lc, 102);

            Gmsh.Model.Geo.Synchronize();
            var xyz = Gmsh.Model.GetValue(0, 5, new double[0]);
            Gmsh.Model.Geo.AddPoint(xyz[0], xyz[1], 0.12, lc, 103);

            Gmsh.Model.Geo.AddLine(4, 100, 110);
            Gmsh.Model.Geo.AddLine(3, 101, 111);
            Gmsh.Model.Geo.AddLine(6, 102, 112);
            Gmsh.Model.Geo.AddLine(5, 103, 113);
            Gmsh.Model.Geo.AddLine(103, 100, 114);
            Gmsh.Model.Geo.AddLine(100, 101, 115);
            Gmsh.Model.Geo.AddLine(101, 102, 116);
            Gmsh.Model.Geo.AddLine(102, 103, 117);

            Gmsh.Model.Geo.AddCurveLoop(new[] { 115, -111, 3, 110 }, 118);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 118 }, 119);
            Gmsh.Model.Geo.AddCurveLoop(new[] { 111, 116, -112, -7 }, 120);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 120 }, 121);
            Gmsh.Model.Geo.AddCurveLoop(new[] { 112, 117, -113, -8 }, 122);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 122 }, 123);
            Gmsh.Model.Geo.AddCurveLoop(new[] { 114, -110, 5, 113 }, 124);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 124 }, 125);
            Gmsh.Model.Geo.AddCurveLoop(new[] { 115, 116, 117, 114 }, 126);
            Gmsh.Model.Geo.AddPlaneSurface(new[] { 126 }, 127);

            Gmsh.Model.Geo.AddSurfaceLoop(new[] { 127, 119, 121, 123, 125, 11 }, 128);
            Gmsh.Model.Geo.AddVolume(new[] { 128 }, 129);

            Gmsh.Model.Geo.Extrude(new[] { ov[1] }, 0, 0, 0.12, out ValueTuple<int, int>[] ov2);

            Gmsh.Model.Geo.Mesh.SetSize(new[] { (0, 103), (0, 105), (0, 109), (0, 102), (0, 28), (0, 24), (0, 6), (0, 5) }, lc * 3);

            Gmsh.Model.AddPhysicalGroup(3, new[] { 129, 130 }, 1);
            Gmsh.Model.SetPhysicalName(3, 1, "The volume");
            Gmsh.Model.Geo.Synchronize();
            Gmsh.Model.Mesh.Generate(3);

            Gmsh.Write("t2.msh");
            Gmsh.Finalize();
        }
    }
}