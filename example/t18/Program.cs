using GmshNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace t18
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);

            Gmsh.Model.Add("t18");

            Gmsh.Model.Occ.AddBox(0, 0, 0, 1, 1, 1, 1);
            Gmsh.Model.Occ.Synchronize();

            var @out = Gmsh.Model.GetEntities(0);
            Gmsh.Model.Mesh.SetSize(@out, 0.1);
            Gmsh.Model.Mesh.SetSize(new[] { (0, 1) }, 0.02);

            double[] translation = new double[] { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            Gmsh.Model.Mesh.SetPeriodic(2, new[] { 2 }, new[] { 1 }, translation);
            Gmsh.Model.Mesh.SetPeriodic(2, new[] { 6 }, new[] { 5 }, new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1 });
            Gmsh.Model.Mesh.SetPeriodic(2, new[] { 4 }, new[] { 3 }, new double[] { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1 });

            Gmsh.Model.Occ.AddBox(2, 0, 0, 1, 1, 1, 10);

            double x = 2 - 0.3, y = 0, z = 0;
            Gmsh.Model.Occ.AddSphere(x, y, z, 0.35, 11);
            Gmsh.Model.Occ.AddSphere(x + 1, y, z, 0.35, 12);
            Gmsh.Model.Occ.AddSphere(x, y + 1, z, 0.35, 13);
            Gmsh.Model.Occ.AddSphere(x, y, z + 1, 0.35, 14);
            Gmsh.Model.Occ.AddSphere(x + 1, y + 1, z, 0.35, 15);
            Gmsh.Model.Occ.AddSphere(x, y + 1, z + 1, 0.35, 16);
            Gmsh.Model.Occ.AddSphere(x + 1, y, z + 1, 0.35, 17);
            Gmsh.Model.Occ.AddSphere(x + 1, y + 1, z + 1, 0.35, 18);

            List<(int, int)> sph = new List<(int, int)>();
            for (int i = 11; i <= 18; i++)
            {
                sph.Add((3, i));
            }
            Gmsh.Model.Occ.Fragment(new[] { (3, 10) }, sph.ToArray(), out @out, out var out_map);
            Gmsh.Model.Occ.Synchronize();

            Gmsh.Option.SetNumber("Geometry.OCCBoundsUseStl", 1);

            double eps = 1e-3;
            var @in = Gmsh.Model.GetEntitiesInBoundingBox(2 - eps, -eps, -eps, 2 + 1 + eps,
                                        1 + eps, 1 + eps, 3);
            var outlist = @out.ToList();
            foreach (var item in @in)
            {
                var it = outlist.Contains(item);
                if (it)
                {
                    outlist.Remove(item);
                }
            }
            @out = outlist.ToArray();
            Gmsh.Model.RemoveEntities(@out, true);

            var p = Gmsh.Model.GetBoundary(@in, false, false, true);
            Gmsh.Model.Mesh.SetSize(p, 0.1);
            p = Gmsh.Model.GetEntitiesInBoundingBox(2 - eps, -eps, -eps, 2 + eps, eps, eps, 0);
            Gmsh.Model.Mesh.SetSize(p, 0.001);

            var sxmin = Gmsh.Model.GetEntitiesInBoundingBox(2 - eps, -eps, -eps, 2 + eps, 1 + eps,
                                        1 + eps, 2);

            for (int i = 0; i < sxmin.Length; i++)
            {
                double xmin, ymin, zmin, xmax, ymax, zmax;
                Gmsh.Model.GetBoundingBox(sxmin[i].Item1, sxmin[i].Item2, out xmin, out ymin, out zmin, out xmax, out ymax, out zmax);
                var sxmax = Gmsh.Model.GetEntitiesInBoundingBox(xmin - eps + 1, ymin - eps,
                                          zmin - eps, xmax + eps + 1,
                                          ymax + eps, zmax + eps, 2);
                for (int j = 0; j < sxmax.Length; j++)
                {
                    double xmin2, ymin2, zmin2, xmax2, ymax2, zmax2;
                    Gmsh.Model.GetBoundingBox(sxmax[j].Item1, sxmax[j].Item2, out xmin2, out ymin2, out zmin2, out xmax2, out ymax2, out zmax2);
                    xmin2 -= 1;
                    xmax2 -= 1;
                    if (Math.Abs(xmin2 - xmin) < eps && Math.Abs(xmax2 - xmax) < eps &&
                        Math.Abs(ymin2 - ymin) < eps && Math.Abs(ymax2 - ymax) < eps &&
                        Math.Abs(zmin2 - zmin) < eps && Math.Abs(zmax2 - zmax) < eps)
                    {
                        Gmsh.Model.Mesh.SetPeriodic(2, new[] { sxmax[j].Item2 }, new[] { sxmin[i].Item2 },
                                       translation);
                    }
                }
            }
            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("t18.msh");
            Gmsh.Finalize();
        }
    }
}