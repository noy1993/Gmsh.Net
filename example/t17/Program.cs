using GmshNet;

namespace t17
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);

            Gmsh.Model.Add("t17");

            Gmsh.Model.Occ.AddRectangle(-1, -1, 0, 2, 2);
            Gmsh.Model.Occ.Synchronize();

            try
            {
                Gmsh.Merge("t17_bgmesh.pos");
            }
            catch
            {
                Gmsh.Logger.Write("Could not load background mesh: bye!");
                Gmsh.Finalize();
                return;
            }
            int bg_field = Gmsh.Model.Mesh.Field.Add("PostView");
            Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(bg_field);

            Gmsh.Option.SetNumber("Mesh.SmoothRatio", 3);
            Gmsh.Option.SetNumber("Mesh.AnisoMax", 1000);
            Gmsh.Option.SetNumber("Mesh.Algorithm", 7);

            Gmsh.Model.Mesh.Generate(2);
            Gmsh.Write("t17.msh");
            Gmsh.Finalize();
        }
    }
}