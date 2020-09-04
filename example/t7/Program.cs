using GmshNet;

namespace t7
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            try
            {
                Gmsh.Merge("t7_bgmesh.pos");
            }
            catch
            {
                Gmsh.Logger.Write("Could not load background mesh: bye!");
                Gmsh.Finalize();
                return;
            }

            Gmsh.Model.Add("t7");

            double lc = 1e-2;
            geo.AddPoint(0, 0, 0, lc, 1);
            geo.AddPoint(.1, 0, 0, lc, 2);
            geo.AddPoint(.1, .3, 0, lc, 3);
            geo.AddPoint(0, .3, 0, lc, 4);
            geo.AddLine(1, 2, 1);
            geo.AddLine(3, 2, 2);
            geo.AddLine(3, 4, 3);
            geo.AddLine(4, 1, 4);
            geo.AddCurveLoop(new[] { 4, 1, -2, 3 }, 1);
            geo.AddPlaneSurface(new[] { 1 }, 1);
            geo.Synchronize();

            int bg_field = Gmsh.Model.Mesh.Field.Add("PostView");
            Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(bg_field);

            Gmsh.Option.SetNumber("Mesh.CharacteristicLengthExtendFromBoundary", 0);
            Gmsh.Option.SetNumber("Mesh.CharacteristicLengthFromPoints", 0);
            Gmsh.Option.SetNumber("Mesh.CharacteristicLengthFromCurvature", 0);

            Gmsh.Model.Mesh.Generate(2);
            Gmsh.Write("t7.msh");
            Gmsh.Finalize();
        }
    }
}