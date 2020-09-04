using GmshNet;

namespace t6
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t6");

            double lc = 1E-2;

            geo.AddPoint(0, 0, 0, lc, 1);
            geo.AddPoint(0.1, 0, 0, lc, 2);
            geo.AddPoint(0.1, 0.3, 0, lc, 3);
            var p4 = Gmsh.Model.Geo.AddPoint(0, 0.3, 0, lc);

            geo.AddLine(1, 2, 1);
            geo.AddLine(3, 2, 2);
            geo.AddLine(3, p4, 3);
            geo.AddLine(4, 1, p4);
            geo.AddCurveLoop(new[] { 4, 1, -2, 3 }, 1);
            geo.AddPlaneSurface(new[] { 1 }, 1);

            geo.Remove(new[] { (2, 1), (1, 4) });

            int p1 = geo.AddPoint(-0.05, 0.05, 0, lc);
            int p2 = geo.AddPoint(-0.05, 0.1, 0, lc);
            int l1 = geo.AddLine(1, p1);
            int l2 = geo.AddLine(p1, p2);
            int l3 = geo.AddLine(p2, 4);

            geo.AddCurveLoop(new[] { 2, -1, l1, l2, l3, -3 }, 2);
            geo.AddPlaneSurface(new[] { -2 }, 1);

            geo.Mesh.SetTransfiniteCurve(2, 20);

            geo.Mesh.SetTransfiniteCurve(l1, 6);
            geo.Mesh.SetTransfiniteCurve(l2, 6);
            geo.Mesh.SetTransfiniteCurve(l3, 10);

            geo.Mesh.SetTransfiniteCurve(1, 30, coef: -1.2);
            geo.Mesh.SetTransfiniteCurve(3, 30, coef: 1.2);

            geo.Mesh.SetTransfiniteSurface(1, cornerTags: new[] { 1, 2, 3, 4 });
            geo.Mesh.SetRecombine(2, 1);

            geo.AddPoint(0.2, 0.2, 0, 1.0, 7);
            geo.AddPoint(0.2, 0.1, 0, 1.0, 8);
            geo.AddPoint(0, 0.3, 0, 1.0, 9);
            geo.AddPoint(0.25, 0.2, 0, 1.0, 10);
            geo.AddPoint(0.3, 0.1, 0, 1.0, 11);
            geo.AddLine(8, 11, 10);
            geo.AddLine(11, 10, 11);
            geo.AddLine(10, 7, 12);
            geo.AddLine(7, 8, 13);
            geo.AddCurveLoop(new[] { 13, 10, 11, 12 }, 14);
            geo.AddPlaneSurface(new[] { 14 }, 15);

            for (int i = 10; i <= 13; i++)
                geo.Mesh.SetTransfiniteCurve(i, 10);

            geo.Mesh.SetTransfiniteSurface(15);

            Gmsh.Option.SetNumber("Mesh.Smoothing", 100);
            geo.Synchronize();
            Gmsh.Model.Mesh.Generate(2);
            Gmsh.Write("t6.msh");
            Gmsh.Finalize();
        }
    }
}