using GmshNet;
using System;
using System.Collections.Generic;

namespace t16
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);

            Gmsh.Model.Add("t16");
            Gmsh.Logger.Start();

            try
            {
                Gmsh.Model.Occ.AddBox(0, 0, 0, 1, 1, 1, 1);
                Gmsh.Model.Occ.AddBox(0, 0, 0, 0.5, 0.5, 0.5, 2);
            }
            catch
            {
                Gmsh.Logger.Write("Could not create OpenCASCADE shapes: bye!");
                return;
            }

            Gmsh.Model.Occ.Cut(new[] { (3, 1) }, new[] { (3, 2) }, out var ov, out var ovv, 3);

            double x = 0, y = 0.75, z = 0, r = 0.09;
            List<(int, int)> holes = new List<(int, int)>();
            for (int i = 1; i <= 5; i++)
            {
                x += 0.166;
                z += 0.166;
                Gmsh.Model.Occ.AddSphere(x, y, z, r, 3 + i);
                holes.Add((3, 3 + i));
            }
            Gmsh.Model.Occ.Fragment(new[] { (3, 3) }, holes.ToArray(), out ov, out ovv);
            Gmsh.Logger.Write("fragment produced volumes:");

            List<(int, int)> @in = new List<(int, int)>() { (3, 3) };
            @in.AddRange(holes);

            for (int i = 0; i < @in.Count; i++)
            {
                var s = $"parent ({@in[i].Item1},{@in[i].Item2}) -> child";
                for (int j = 0; j < ovv[i].Length; j++)
                {
                    s += $" ({ovv[i][j].Item1},{ovv[i][j].Item2})";
                }
                Gmsh.Logger.Write(s);
            }
            Gmsh.Model.Occ.Synchronize();

            for (int i = 1; i <= 5; i++)
            {
                Gmsh.Model.AddPhysicalGroup(3, new[] { 3 + i }, i);
            }

            Gmsh.Model.AddPhysicalGroup(3, new[] { ov[ov.Length - 1].Item2 }, 10);

            double lcar1 = .1;
            double lcar2 = .0005;
            double lcar3 = .055;
            ov = Gmsh.Model.GetEntities(0);
            Gmsh.Model.Mesh.SetSize(ov, lcar1);

            ov = Gmsh.Model.GetBoundary(holes.ToArray(), false, false, true);
            Gmsh.Model.Mesh.SetSize(ov, lcar3);

            double eps = 1e-3;
            ov = Gmsh.Model.GetEntitiesInBoundingBox(0.5 - eps, 0.5 - eps, 0.5 - eps,
                                        0.5 + eps, 0.5 + eps, 0.5 + eps, 0);
            Gmsh.Model.Mesh.SetSize(ov, lcar2);

            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("t16.msh");

            var log = Gmsh.Logger.Get();
            Console.WriteLine($"Logger has recorded {log.Length} lines");
            Gmsh.Logger.Stop();

            Gmsh.Finalize();
        }
    }
}