using GmshNet;
using System;

namespace t4
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t4");
            double cm = 1E-2;
            double e1 = 4.5 * cm, e2 = 6 * cm / 2, e3 = 5 * cm / 2;
            double h1 = 5 * cm, h2 = 10 * cm, h3 = 5 * cm, h4 = 2 * cm, h5 = 4.5 * cm;
            double R1 = 1 * cm, R2 = 1.5 * cm, r = 1 * cm;
            double Lc1 = 0.01;
            double Lc2 = 0.003;
            double ccos = (-h5 * R1 + e2 * hypot(h5, hypot(e2, R1))) / (h5 * h5 + e2 * e2);
            double ssin = Math.Sqrt(1 - ccos * ccos);

            geo.AddPoint(-e1 - e2, 0, 0, Lc1, 1);
            geo.AddPoint(-e1 - e2, h1, 0, Lc1, 2);
            geo.AddPoint(-e3 - r, h1, 0, Lc2, 3);
            geo.AddPoint(-e3 - r, h1 + r, 0, Lc2, 4);
            geo.AddPoint(-e3, h1 + r, 0, Lc2, 5);
            geo.AddPoint(-e3, h1 + h2, 0, Lc1, 6);
            geo.AddPoint(e3, h1 + h2, 0, Lc1, 7);
            geo.AddPoint(e3, h1 + r, 0, Lc2, 8);
            geo.AddPoint(e3 + r, h1 + r, 0, Lc2, 9);
            geo.AddPoint(e3 + r, h1, 0, Lc2, 10);
            geo.AddPoint(e1 + e2, h1, 0, Lc1, 11);
            geo.AddPoint(e1 + e2, 0, 0, Lc1, 12);
            geo.AddPoint(e2, 0, 0, Lc1, 13);

            geo.AddPoint(R1 / ssin, h5 + R1 * ccos, 0, Lc2, 14);
            geo.AddPoint(0, h5, 0, Lc2, 15);
            geo.AddPoint(-R1 / ssin, h5 + R1 * ccos, 0, Lc2, 16);
            geo.AddPoint(-e2, 0.0, 0, Lc1, 17);

            geo.AddPoint(-R2, h1 + h3, 0, Lc2, 18);
            geo.AddPoint(-R2, h1 + h3 + h4, 0, Lc2, 19);
            geo.AddPoint(0, h1 + h3 + h4, 0, Lc2, 20);
            geo.AddPoint(R2, h1 + h3 + h4, 0, Lc2, 21);
            geo.AddPoint(R2, h1 + h3, 0, Lc2, 22);
            geo.AddPoint(0, h1 + h3, 0, Lc2, 23);

            geo.AddPoint(0, h1 + h3 + h4 + R2, 0, Lc2, 24);
            geo.AddPoint(0, h1 + h3 - R2, 0, Lc2, 25);

            geo.AddLine(1, 17, 1);
            geo.AddLine(17, 16, 2);

            geo.AddCircleArc(14, 15, 16, 3);

            geo.AddLine(14, 13, 4);
            geo.AddLine(13, 12, 5);
            geo.AddLine(12, 11, 6);
            geo.AddLine(11, 10, 7);
            geo.AddCircleArc(8, 9, 10, 8);
            geo.AddLine(8, 7, 9);
            geo.AddLine(7, 6, 10);
            geo.AddLine(6, 5, 11);
            geo.AddCircleArc(3, 4, 5, 12);
            geo.AddLine(3, 2, 13);
            geo.AddLine(2, 1, 14);
            geo.AddLine(18, 19, 15);
            geo.AddCircleArc(21, 20, 24, 16);
            geo.AddCircleArc(24, 20, 19, 17);
            geo.AddCircleArc(18, 23, 25, 18);
            geo.AddCircleArc(25, 23, 22, 19);
            geo.AddLine(21, 22, 20);

            geo.AddCurveLoop(new[] { 17, -15, 18, 19, -20, 16 }, 21);
            geo.AddPlaneSurface(new[] { 21 }, 22);

            // But we still need to define the exterior surface. Since this surface has a
            // hole, its definition now requires two curves loops:
            geo.AddCurveLoop(new[] { 11, -12, 13, 14, 1, 2, -3, 4, 5, 6, 7, -8, 9, 10 }, 23);
            geo.AddPlaneSurface(new[] { 23, 21 }, 24);

            geo.Synchronize();

            //int v = Gmsh.View.Add("comments");
            //Gmsh.View.AddListDataString(v, new[] { 10, -10.0 }, new[] { "Created with Gmsh" });
            //Gmsh.View.AddListDataString(v, new[] { 0, 0.09, 0 }, new[] { "file://../t4_image.png@0.01x0" }, new[] { "Align", "Center" });
            //Gmsh.View.AddListDataString(v, new[] { -0.01, 0.09,0 }, new[] { "file://../t4_image.png@0.01x0,0,0,1,0,1,0" });
            //Gmsh.View.AddListDataString(v, new[] { 0, 0.12, 0 }, new[] { "file://../t4_image.png@0.01x0#" }, new[] { "Align", "Center" });
            //Gmsh.View.AddListDataString(v, new[] { 150, -7.0 }, new[] { "file://../t4_image.png@20x0" });

            //Gmsh.Option.SetString("View[0].DoubleClickedCommand","Printf('View[0] has been double-clicked!');");
            //Gmsh.Option.SetString("Geometry.DoubleClickedLineCommand", @"Printf('Curve %g has been double-clicked!', "+
            //                        "Geometry.DoubleClickedEntityTag);");

            Gmsh.Model.SetColor(new[] { (2, 22) }, 127, 127, 127); // Gray50
            Gmsh.Model.SetColor(new[] { (2, 24) }, 160, 32, 240); // Purple
            for (int i = 1; i <= 14; i++)
                Gmsh.Model.SetColor(new[] { (1, i) }, 255, 0, 0); // Red
            for (int i = 15; i <= 20; i++)
                Gmsh.Model.SetColor(new[] { (1, i) }, 255, 255, 0); // Yellow

            Gmsh.Model.Mesh.Generate(2);
            Gmsh.Write("t4.msh");
            Gmsh.Finalize();
        }

        public static double hypot(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}