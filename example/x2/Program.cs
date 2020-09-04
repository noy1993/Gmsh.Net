using GmshNet;
using System;
using System.Collections.Generic;

namespace x2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("x2");

            long N = 100;
            var tag = new Func<long, long, long>((i, j) => (N + 1) * i + j + 1);

            var nodes = new List<long>();
            var tris = new List<long>();
            var lin = new List<long>[4];
            var coords = new List<double>();
            var pnt = new[] { tag(0, 0), tag(N, 0), tag(N, N), tag(0, N) };
            for (int i = 0; i < N + 1; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    nodes.Add(tag(i, j));
                    coords.AddRange(new[]{(double)i / N, (double)j / N,
                                   0.05 * Math.Sin(10 * (double)(i + j) / N)});
                    if (i > 0 && j > 0)
                    {
                        tris.AddRange(new[] { tag(i - 1, j - 1), tag(i, j - 1), tag(i - 1, j) });
                        tris.AddRange(new[] { tag(i, j - 1), tag(i, j), tag(i - 1, j) });
                    }
                    if ((i == 0 || i == N) && j > 0)
                    {
                        var s = i == 0 ? 3 : 1;
                        lin[s] = new List<long>(new[] { tag(i, j - 1), tag(i, j) });
                    }
                    if ((j == 0 || j == N) && i > 0)
                    {
                        var s = (j == 0) ? 0 : 2;
                        lin[s] = new List<long>(new[] { tag(i - 1, j), tag(i, j) });
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Gmsh.Model.AddDiscreteEntity(0, i + 1);
            }
            Gmsh.Model.SetCoordinates(1, 0, 0, coords[Convert.ToInt32(3 * tag(0, 0) - 1)]);
            Gmsh.Model.SetCoordinates(2, 1, 0, coords[Convert.ToInt32(3 * tag(N, 0) - 1)]);
            Gmsh.Model.SetCoordinates(3, 1, 1, coords[Convert.ToInt32(3 * tag(N, N) - 1)]);
            Gmsh.Model.SetCoordinates(4, 0, 1, coords[Convert.ToInt32(3 * tag(0, N) - 1)]);

            for (int i = 0; i < 4; i++)
            {
                Gmsh.Model.AddDiscreteEntity(1, i + 1, new[] { i + 1, (i < 3) ? (i + 2) : 1 });
            }
            Gmsh.Model.AddDiscreteEntity(2, 1, new[] { 1, 2, -3, -4 });

            Gmsh.Model.Mesh.AddNodes(2, 1, nodes.ToArray(), coords.ToArray());

            for (int i = 0; i < 4; i++)
            {
                Gmsh.Model.Mesh.AddElementsByType(i + 1, 15, new long[] { }, new long[] { pnt[i] });
                Gmsh.Model.Mesh.AddElementsByType(i + 1, 1, new long[] { }, lin[i].ToArray());
            }
            Gmsh.Model.Mesh.AddElementsByType(1, 2, new long[] { }, tris.ToArray());
            Gmsh.Model.Mesh.ReclassifyNodes();
            Gmsh.Model.Mesh.CreateGeometry();

            int p1 = Gmsh.Model.Geo.AddPoint(0, 0, -0.5);
            int p2 = Gmsh.Model.Geo.AddPoint(1, 0, -0.5);
            int p3 = Gmsh.Model.Geo.AddPoint(1, 1, -0.5);
            int p4 = Gmsh.Model.Geo.AddPoint(0, 1, -0.5);
            int c1 = Gmsh.Model.Geo.AddLine(p1, p2);
            int c2 = Gmsh.Model.Geo.AddLine(p2, p3);
            int c3 = Gmsh.Model.Geo.AddLine(p3, p4);
            int c4 = Gmsh.Model.Geo.AddLine(p4, p1);
            int c10 = Gmsh.Model.Geo.AddLine(p1, 1);
            int c11 = Gmsh.Model.Geo.AddLine(p2, 2);
            int c12 = Gmsh.Model.Geo.AddLine(p3, 3);
            int c13 = Gmsh.Model.Geo.AddLine(p4, 4);
            int ll1 = Gmsh.Model.Geo.AddCurveLoop(new[] { c1, c2, c3, c4 });
            int s1 = Gmsh.Model.Geo.AddPlaneSurface(new[] { ll1 });
            int ll3 = Gmsh.Model.Geo.AddCurveLoop(new[] { c1, c11, -1, -c10 });
            int s3 = Gmsh.Model.Geo.AddPlaneSurface(new[] { ll3 });
            int ll4 = Gmsh.Model.Geo.AddCurveLoop(new[] { c2, c12, -2, -c11 });
            int s4 = Gmsh.Model.Geo.AddPlaneSurface(new[] { ll4 });
            int ll5 = Gmsh.Model.Geo.AddCurveLoop(new[] { c3, c13, 3, -c12 });
            int s5 = Gmsh.Model.Geo.AddPlaneSurface(new[] { ll5 });
            int ll6 = Gmsh.Model.Geo.AddCurveLoop(new[] { c4, c10, 4, -c13 });
            int s6 = Gmsh.Model.Geo.AddPlaneSurface(new[] { ll6 });
            int sl1 = Gmsh.Model.Geo.AddSurfaceLoop(new[] { s1, s3, s4, s5, s6, 1 });
            int v1 = Gmsh.Model.Geo.AddVolume(new[] { sl1 });

            Gmsh.Model.Geo.Synchronize();
            bool transfinite = true;

            if (transfinite)
            {
                int NN = 30;
                var tmp = Gmsh.Model.GetEntities(1);
                for (int i = 0; i < tmp.Length; i++)
                {
                    Gmsh.Model.Mesh.SetTransfiniteCurve(tmp[i].Item2, NN);
                }
                tmp = Gmsh.Model.GetEntities(2);
                for (int i = 0; i < tmp.Length; i++)
                {
                    Gmsh.Model.Mesh.SetTransfiniteSurface(tmp[i].Item2);
                    Gmsh.Model.Mesh.SetRecombine(tmp[i].Item1, tmp[i].Item2);
                    Gmsh.Model.Mesh.SetSmoothing(tmp[i].Item1, tmp[i].Item2, 100);
                }
                Gmsh.Model.Mesh.SetTransfiniteVolume(v1);
            }
            else
            {
                Gmsh.Option.SetNumber("Mesh.CharacteristicLengthMin", 0.05);
                Gmsh.Option.SetNumber("Mesh.CharacteristicLengthMax", 0.05);
            }
            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("x2.msh");
            Gmsh.Finalize();
        }
    }
}