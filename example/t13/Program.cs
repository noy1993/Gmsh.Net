using GmshNet;
using System;
using System.Linq;

namespace t13
{
    using f = Gmsh.Model.Mesh.Field;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t13");

            try
            {
                Gmsh.Merge("t13_data.stl");
            }
            catch
            {
                Gmsh.Logger.Write("Could not load STL mesh: bye!");
                Gmsh.Finalize();
                return;
            }

            double angle = 40;

            // For complex geometries, patches can be too complex, too elongated or too
            // large to be parametrized; setting the following option will force the
            // creation of patches that are amenable to reparametrization:
            bool forceParametrizablePatches = false;

            // For open surfaces include the boundary edges in the classification process:
            bool includeBoundary = true;

            // Force curves to be split on given angle:
            double curveAngle = 180;

            Gmsh.Model.Mesh.ClassifySurfaces(angle * Math.PI / 180, includeBoundary, forceParametrizablePatches, curveAngle * Math.PI / 180);
            Gmsh.Model.Mesh.CreateGeometry();

            var s = Gmsh.Model.GetEntities(2);
            var sl = s.Select(ss => ss.Item2).ToArray();
            var l = Gmsh.Model.Geo.AddSurfaceLoop(sl);

            Gmsh.Model.Geo.AddVolume(new[] { l });
            Gmsh.Model.Geo.Synchronize();

            bool funny = true; // false;
            int ff = f.Add("MathEval");
            if (funny)
                f.SetString(ff, "F", "2*Sin((x+y)/5) + 3");
            else
                f.SetString(ff, "F", "4");
            f.SetAsBackgroundMesh(ff);

            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Fltk.Run();
            Gmsh.Finalize();
        }
    }
}