using GmshNet;

namespace t15
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t15");

            double lc = 1E-2;
            geo.AddPoint(0, 0, 0, lc, 1);
            geo.AddPoint(0.1, 0, 0, lc, 2);
            geo.AddPoint(0.1, 0.3, 0, lc, 3);
            var p4 = geo.AddPoint(0, 0.3, 0, lc);

            geo.AddLine(1, 2, 1);
            geo.AddLine(3, 2, 2);
            geo.AddLine(3, p4, 3);
            geo.AddLine(4, 1, p4);

            geo.AddCurveLoop(new int[] { 4, 1, -2, 3 }, 1);
            geo.AddPlaneSurface(new int[] { 1 }, 1);

            lc *= 4;
            geo.Mesh.SetSize(new[] { (0, 1), (0, 2), (0, 3), (0, 4) }, lc);
            geo.AddPoint(0.02, 0.02, 0, lc, 5);
            geo.Synchronize();

            Gmsh.Model.Mesh.Embed(0, new[] { 5 }, 2, 1);

            geo.AddPoint(0.02, 0.12, 0, lc, 6);
            geo.AddPoint(0.04, 0.18, 0, lc, 7);
            geo.AddLine(6, 7, 5);
            geo.Synchronize();
            Gmsh.Model.Mesh.Embed(1, new[] { 5 }, 2, 1);

            geo.Extrude(new[] { (2, 1) }, 0, 0, 0.1, out (int, int)[] ext);

            int p = geo.AddPoint(0.07, 0.15, 0.025, lc);

            geo.Synchronize();
            Gmsh.Model.Mesh.Embed(0, new[] { p }, 3, 1);

            geo.AddPoint(0.025, 0.15, 0.025, lc, p + 1);
            int l = geo.AddLine(7, p + 1);

            geo.Synchronize();
            Gmsh.Model.Mesh.Embed(1, new[] { l }, 3, 1);

            // Finally, we can also embed a surface in a volume:
            geo.AddPoint(0.02, 0.12, 0.05, lc, p + 2);
            geo.AddPoint(0.04, 0.12, 0.05, lc, p + 3);
            geo.AddPoint(0.04, 0.18, 0.05, lc, p + 4);
            geo.AddPoint(0.02, 0.18, 0.05, lc, p + 5);

            geo.AddLine(p + 2, p + 3, l + 1);
            geo.AddLine(p + 3, p + 4, l + 2);
            geo.AddLine(p + 4, p + 5, l + 3);
            geo.AddLine(p + 5, p + 2, l + 4);

            int ll = geo.AddCurveLoop(new[] { l + 1, l + 2, l + 3, l + 4 });
            int s = geo.AddPlaneSurface(new[] { ll });

            geo.Synchronize();
            Gmsh.Model.Mesh.Embed(2, new[] { s }, 3, 1);

            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("t15.msh");
            Gmsh.Finalize();
        }
    }
}