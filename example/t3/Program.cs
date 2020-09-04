using GmshNet;
using System;

namespace t3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t3");
            // Copied from t1...
            double lc = 1E-2;
            Gmsh.Model.Geo.AddPoint(0, 0, 0, lc, 1);
            Gmsh.Model.Geo.AddPoint(0.1, 0, 0, lc, 2);
            Gmsh.Model.Geo.AddPoint(0.1, 0.3, 0, lc, 3);
            var p4 = Gmsh.Model.Geo.AddPoint(0, 0.3, 0, lc);

            Gmsh.Model.Geo.AddLine(1, 2, 1);
            Gmsh.Model.Geo.AddLine(3, 2, 2);
            Gmsh.Model.Geo.AddLine(3, p4, 3);
            Gmsh.Model.Geo.AddLine(4, 1, p4);

            Gmsh.Model.Geo.AddCurveLoop(new int[] { 4, 1, -2, 3 }, 1);
            Gmsh.Model.Geo.AddPlaneSurface(new int[] { 1 }, 1);
            Gmsh.Model.AddPhysicalGroup(1, new int[] { 1, 2, 4 }, 5);
            var ps = Gmsh.Model.AddPhysicalGroup(2, new int[] { 1 });
            Gmsh.Model.SetPhysicalName(2, ps, "My surface");
            // As in `t2', we plan to perform an extrusion along the z axis.  But
            // here, instead of only extruding the geometry, we also want to extrude the
            // 2D mesh. This is done with the same `extrude()' function, but by specifying
            // element 'Layers' (2 layers in this case, the first one with 8 subdivisions
            // and the second one with 2 subdivisions, both with a height of h/2). The
            // number of elements for each layer and the (end) height of each layer are
            // specified in two vectors:
            double h = 0.1, angle = 90;
            Gmsh.Model.Geo.Extrude(new[] { (2, 1) }, 0, 0, h, out (int, int)[] ov, new[] { 8, 2 }, new[] { 0.5, 1 });
            Gmsh.Model.Geo.Revolve(new[] { (2, 28) }, -0.1, 0, 0.1, 0, 1, 0, -Math.PI / 2, out (int, int)[] ov2, new[] { 7 });
            Gmsh.Model.Geo.Twist(new[] { (2, 50) }, 0, 0.15, 0.25, -2 * h, 0, 0, 1, 0, 0, angle * Math.PI / 180, out (int, int)[] ov3, recombine: true);
            Gmsh.Model.Geo.Synchronize();

            Gmsh.Model.AddPhysicalGroup(3, new[] { 1, 2, ov3[1].Item2 }, 101);
            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("t3.msh");

            Gmsh.Option.SetNumber("Geometry.PointNumbers", 1);
            Gmsh.Option.SetColor("Geometry.Points", 255, 165, 0);
            Gmsh.Option.SetColor("General.Text", 255, 255, 255);
            Gmsh.Option.SetColor("Mesh.Points", 255, 0, 0);

            Gmsh.Option.GetColor("Geometry.Points", out int r, out int g, out int b, out int a);
            Gmsh.Option.SetColor("Geometry.Surfaces", r, g, b, a);

            Gmsh.Finalize();
        }
    }
}