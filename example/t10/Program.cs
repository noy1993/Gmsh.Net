using GmshNet;

namespace t10
{
    using f = Gmsh.Model.Mesh.Field;
    using geo = Gmsh.Model.Geo;
    using opt = Gmsh.Option;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t10");

            double lc = .15;
            geo.AddPoint(0.0, 0.0, 0, lc, 1);
            geo.AddPoint(1, 0.0, 0, lc, 2);
            geo.AddPoint(1, 1, 0, lc, 3);
            geo.AddPoint(0, 1, 0, lc, 4);
            geo.AddPoint(0.2, .5, 0, lc, 5);

            geo.AddLine(1, 2, 1);
            geo.AddLine(2, 3, 2);
            geo.AddLine(3, 4, 3);
            geo.AddLine(4, 1, 4);

            geo.AddCurveLoop(new[] { 1, 2, 3, 4 }, 5);
            geo.AddPlaneSurface(new[] { 5 }, 6);

            geo.Synchronize();

            f.Add("Distance", 1);
            f.SetNumbers(1, "NodesList", new[] { 5.0 });
            f.SetNumber(1, "NNodesByEdge", 100);
            f.SetNumbers(1, "EdgesList", new[] { 2.0 });

            f.Add("Threshold", 2);
            f.SetNumber(2, "IField", 1);
            f.SetNumber(2, "LcMin", lc / 30);
            f.SetNumber(2, "LcMax", lc);
            f.SetNumber(2, "DistMin", 0.15);
            f.SetNumber(2, "DistMax", 0.5);

            f.Add("Min", 7);
            f.SetNumbers(7, "FieldsList", new[] { 2.0, 3, 5, 6 });

            f.SetAsBackgroundMesh(7);

            opt.SetNumber("Mesh.CharacteristicLengthExtendFromBoundary", 0);
            opt.SetNumber("Mesh.CharacteristicLengthFromPoints", 0);
            opt.SetNumber("Mesh.CharacteristicLengthFromCurvature", 0);

            Gmsh.Model.Mesh.Generate(2);
            Gmsh.Write("t10.msh");
            Gmsh.Finalize();
        }
    }
}