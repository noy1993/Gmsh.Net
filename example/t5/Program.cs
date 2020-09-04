using GmshNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace t5
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            double lcar1 = .1;
            double lcar2 = .0005;
            double lcar3 = .055;

            geo.AddPoint(0.5, 0.5, 0.5, lcar2, 1);
            geo.AddPoint(0.5, 0.5, 0, lcar1, 2);
            geo.AddPoint(0, 0.5, 0.5, lcar1, 3);
            geo.AddPoint(0, 0, 0.5, lcar1, 4);
            geo.AddPoint(0.5, 0, 0.5, lcar1, 5);
            geo.AddPoint(0.5, 0, 0, lcar1, 6);
            geo.AddPoint(0, 0.5, 0, lcar1, 7);
            geo.AddPoint(0, 1, 0, lcar1, 8);
            geo.AddPoint(1, 1, 0, lcar1, 9);
            geo.AddPoint(0, 0, 1, lcar1, 10);
            geo.AddPoint(0, 1, 1, lcar1, 11);
            geo.AddPoint(1, 1, 1, lcar1, 12);
            geo.AddPoint(1, 0, 1, lcar1, 13);
            geo.AddPoint(1, 0, 0, lcar1, 14);

            geo.AddLine(8, 9, 1);
            geo.AddLine(9, 12, 2);
            geo.AddLine(12, 11, 3);
            geo.AddLine(11, 8, 4);
            geo.AddLine(9, 14, 5);
            geo.AddLine(14, 13, 6);
            geo.AddLine(13, 12, 7);
            geo.AddLine(11, 10, 8);
            geo.AddLine(10, 13, 9);
            geo.AddLine(10, 4, 10);
            geo.AddLine(4, 5, 11);
            geo.AddLine(5, 6, 12);
            geo.AddLine(6, 2, 13);
            geo.AddLine(2, 1, 14);
            geo.AddLine(1, 3, 15);
            geo.AddLine(3, 7, 16);
            geo.AddLine(7, 2, 17);
            geo.AddLine(3, 4, 18);
            geo.AddLine(5, 1, 19);
            geo.AddLine(7, 8, 20);
            geo.AddLine(6, 14, 21);

            geo.AddCurveLoop(new[] { -11, -19, -15, -18 }, 22);
            geo.AddPlaneSurface(new[] { 22 }, 23);
            geo.AddCurveLoop(new[] { 16, 17, 14, 15 }, 24);
            geo.AddPlaneSurface(new[] { 24 }, 25);
            geo.AddCurveLoop(new[] { -17, 20, 1, 5, -21, 13 }, 26);
            geo.AddPlaneSurface(new[] { 26 }, 27);
            geo.AddCurveLoop(new[] { -4, -1, -2, -3 }, 28);
            geo.AddPlaneSurface(new[] { 28 }, 29);
            geo.AddCurveLoop(new[] { -7, 2, -5, -6 }, 30);
            geo.AddPlaneSurface(new[] { 30 }, 31);
            geo.AddCurveLoop(new[] { 6, -9, 10, 11, 12, 21 }, 32);
            geo.AddPlaneSurface(new[] { 32 }, 33);
            geo.AddCurveLoop(new[] { 7, 3, 8, 9 }, 34);
            geo.AddPlaneSurface(new[] { 34 }, 35);
            geo.AddCurveLoop(new[] { -10, 18, -16, -20, 4, -8 }, 36);
            geo.AddPlaneSurface(new[] { 36 }, 37);
            geo.AddCurveLoop(new[] { -14, -13, -12, 19 }, 38);
            geo.AddPlaneSurface(new[] { 38 }, 39);

            List<int> shells = new List<int>();
            List<int> volumes = new List<int>();
            int sl = geo.AddSurfaceLoop(new[] { 35, 31, 29, 37, 33, 23, 39, 25, 27 });
            shells.Add(sl);
            // We create five holes in the cube:
            double x = 0, y = 0.75, z = 0, r = 0.09;
            for (int t = 1; t <= 5; t++)
            {
                x += 0.166;
                z += 0.166;
                CheeseHole(x, y, z, r, lcar3, shells, volumes);
                Gmsh.Model.AddPhysicalGroup(3, new[] { volumes.Last() }, t);
                Console.WriteLine($"Hole {t} (center = {{{x},{y},{z}}}, radius = {r}) has number {volumes.Last()}!");
            }

            var ve = geo.AddVolume(shells.ToArray());
            Gmsh.Model.AddPhysicalGroup(3, new[] { ve }, 10);
            geo.Synchronize();
            Gmsh.Option.SetNumber("Mesh.Algorithm", 6);
            Gmsh.Model.Mesh.SetAlgorithm(2, 33, 1);
            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("t5.msh");
            Gmsh.Finalize();
        }

        private static void CheeseHole(double x, double y, double z, double r, double lc, List<int> shells, List<int> volumes)
        {
            int p1 = geo.AddPoint(x, y, z, lc);
            int p2 = geo.AddPoint(x + r, y, z, lc);
            int p3 = geo.AddPoint(x, y + r, z, lc);
            int p4 = geo.AddPoint(x, y, z + r, lc);
            int p5 = geo.AddPoint(x - r, y, z, lc);
            int p6 = geo.AddPoint(x, y - r, z, lc);
            int p7 = geo.AddPoint(x, y, z - r, lc);

            int c1 = geo.AddCircleArc(p2, p1, p7);
            int c2 = geo.AddCircleArc(p7, p1, p5);
            int c3 = geo.AddCircleArc(p5, p1, p4);
            int c4 = geo.AddCircleArc(p4, p1, p2);
            int c5 = geo.AddCircleArc(p2, p1, p3);
            int c6 = geo.AddCircleArc(p3, p1, p5);
            int c7 = geo.AddCircleArc(p5, p1, p6);
            int c8 = geo.AddCircleArc(p6, p1, p2);
            int c9 = geo.AddCircleArc(p7, p1, p3);
            int c10 = geo.AddCircleArc(p3, p1, p4);
            int c11 = geo.AddCircleArc(p4, p1, p6);
            int c12 = geo.AddCircleArc(p6, p1, p7);

            int l1 = geo.AddCurveLoop(new[] { c5, c10, c4 });
            int l2 = geo.AddCurveLoop(new[] { c9, -c5, c1 });
            int l3 = geo.AddCurveLoop(new[] { c12, -c8, -c1 });
            int l4 = geo.AddCurveLoop(new[] { c8, -c4, c11 });
            int l5 = geo.AddCurveLoop(new[] { -c10, c6, c3 });
            int l6 = geo.AddCurveLoop(new[] { -c11, -c3, c7 });
            int l7 = geo.AddCurveLoop(new[] { -c2, -c7, -c12 });
            int l8 = geo.AddCurveLoop(new[] { -c6, -c9, c2 });

            int s1 = geo.AddSurfaceFilling(new[] { l1 });
            int s2 = geo.AddSurfaceFilling(new[] { l2 });
            int s3 = geo.AddSurfaceFilling(new[] { l3 });
            int s4 = geo.AddSurfaceFilling(new[] { l4 });
            int s5 = geo.AddSurfaceFilling(new[] { l5 });
            int s6 = geo.AddSurfaceFilling(new[] { l6 });
            int s7 = geo.AddSurfaceFilling(new[] { l7 });
            int s8 = geo.AddSurfaceFilling(new[] { l8 });

            int sl = geo.AddSurfaceLoop(new[] { s1, s2, s3, s4, s5, s6, s7, s8 });
            int v = geo.AddVolume(new[] { sl });
            shells.Add(sl);
            volumes.Add(v);
        }
    }
}