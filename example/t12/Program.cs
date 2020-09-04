using GmshNet;

namespace t12
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t12");

            double lc = 0.1;
            geo.AddPoint(0, 0, 0, lc, 1);
            geo.AddPoint(1, 0, 0, lc, 2);
            geo.AddPoint(1, 1, 0.5, lc, 3);
            geo.AddPoint(0, 1, 0.4, lc, 4);
            geo.AddPoint(0.3, 0.2, 0, lc, 5);
            geo.AddPoint(0, 0.01, 0.01, lc, 6);
            geo.AddPoint(0, 0.02, 0.02, lc, 7);
            geo.AddPoint(1, 0.05, 0.02, lc, 8);
            geo.AddPoint(1, 0.32, 0.02, lc, 9);

            geo.AddLine(1, 2, 1);
            geo.AddLine(2, 8, 2);
            geo.AddLine(8, 9, 3);
            geo.AddLine(9, 3, 4);
            geo.AddLine(3, 4, 5);
            geo.AddLine(4, 7, 6);
            geo.AddLine(7, 6, 7);
            geo.AddLine(6, 1, 8);
            geo.AddSpline(new[] { 7, 5, 9 }, 9);
            geo.AddLine(6, 8, 10);

            geo.AddCurveLoop(new[] { 5, 6, 9, 4 }, 11);
            geo.AddSurfaceFilling(new[] { 11 }, 1);

            geo.AddCurveLoop(new[] { -9, 3, 10, 7 }, 13);
            geo.AddSurfaceFilling(new[] { 13 }, 5);

            geo.AddCurveLoop(new[] { -10, 2, 1, 8 }, 15);
            geo.AddSurfaceFilling(new[] { 15 }, 10);

            geo.Synchronize();

            Gmsh.Model.Mesh.SetCompound(1, new[] { 2, 3, 4 });
            Gmsh.Model.Mesh.SetCompound(1, new[] { 6, 7, 8 });
            Gmsh.Model.Mesh.SetCompound(2, new[] { 1, 5, 10 });
            Gmsh.Model.Mesh.Generate(2);
            Gmsh.Write("t12.msh");
            Gmsh.Finalize();
        }
    }
}