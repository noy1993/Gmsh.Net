using GmshNet;

namespace t11
{
    using f = Gmsh.Model.Mesh.Field;
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t11");

            int p1 = geo.AddPoint(-1.25, -.5, 0);
            int p2 = geo.AddPoint(1.25, -.5, 0);
            int p3 = geo.AddPoint(1.25, 1.25, 0);
            int p4 = geo.AddPoint(-1.25, 1.25, 0);

            int l1 = geo.AddLine(p1, p2);
            int l2 = geo.AddLine(p2, p3);
            int l3 = geo.AddLine(p3, p4);
            int l4 = geo.AddLine(p4, p1);

            int cl = geo.AddCurveLoop(new[] { l1, l2, l3, l4 });
            int pl = geo.AddPlaneSurface(new[] { cl });

            geo.Synchronize();

            f.Add("MathEval", 1);
            f.SetString(1, "F", "0.01*(1.0+30.*(y-x*x)*(y-x*x) + (1-x)*(1-x))");
            f.SetAsBackgroundMesh(1);

            Gmsh.Model.Mesh.SetRecombine(2, pl);

            Gmsh.Model.Mesh.Generate(2);

            Gmsh.Fltk.Run();
            Gmsh.Finalize();
        }
    }
}