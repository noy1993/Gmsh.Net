using GmshNet;

namespace t1
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t1");
            var lc = 1E-2;
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
            Gmsh.Model.AddPhysicalGroup(1, new int[] { 1, 2, 4 }, 5);
            var ps = Gmsh.Model.AddPhysicalGroup(2, new int[] { 1 });
            Gmsh.Model.SetPhysicalName(2, ps, "My surface");
            geo.Synchronize();
            Gmsh.Model.Mesh.Generate(2);

            Gmsh.Write("t1.msh");
            Gmsh.Finalize();
        }
    }
}