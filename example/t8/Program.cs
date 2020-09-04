using GmshNet;
using System.Drawing;

namespace t8
{
    using geo = Gmsh.Model.Geo;
    using opt = Gmsh.Option;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t6");

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

            try
            {
                Gmsh.Merge("view1.pos");
                Gmsh.Merge("view1.pos");
                Gmsh.Merge("view4.pos"); // contains 2 views inside
            }
            catch
            {
                Gmsh.Logger.Write("Could not load post-processing views: bye!");
                Gmsh.Finalize();
                return;
            }

            opt.SetNumber("General.Trackball", 0);
            opt.SetNumber("General.RotationX", 0);
            opt.SetNumber("General.RotationY", 0);
            opt.SetNumber("General.RotationZ", 0);

            opt.SetColor("General.Background", Color.White);

            opt.SetColor("General.Foreground", Color.Black);
            opt.SetColor("General.Text", Color.Black);

            opt.SetNumber("General.Orthographic", 0);
            opt.SetNumber("General.Axes", 0);
            opt.SetNumber("General.SmallAxes", 0);

            Gmsh.Fltk.Initialize();

            opt.SetNumber("View[0].IntervalsType", 2);
            opt.SetNumber("View[0].OffsetZ", 0.05);
            opt.SetNumber("View[0].RaiseZ", 0);
            opt.SetNumber("View[0].Light", 1);
            opt.SetNumber("View[0].ShowScale", 0);
            opt.SetNumber("View[0].SmoothNormals", 1);

            opt.SetNumber("View[1].IntervalsType", 1);
            opt.SetNumber("View[1].NbIso", 10);
            opt.SetNumber("View[1].ShowScale", 0);

            opt.SetString("View[2].Name", "Test...");
            opt.SetNumber("View[2].Axes", 1);
            opt.SetNumber("View[2].IntervalsType", 2);
            opt.SetNumber("View[2].Type", 2);
            opt.SetNumber("View[2].IntervalsType", 2);
            opt.SetNumber("View[2].AutoPosition", 0);
            opt.SetNumber("View[2].PositionX", 85);
            opt.SetNumber("View[2].PositionY", 50);
            opt.SetNumber("View[2].Width", 200);
            opt.SetNumber("View[2].Height", 130);

            opt.SetNumber("View[3].Visible", 0);

            int t = 0; // Initial step

            for (int num = 1; num <= 3; num++)
            {
                var nbt = opt.GetNumber("View[0].NbTimeStep");
                t = (t < nbt - 1) ? t + 1 : 0;

                // Set time step
                opt.SetNumber("View[0].TimeStep", t);
                opt.SetNumber("View[1].TimeStep", t);
                opt.SetNumber("View[2].TimeStep", t);
                opt.SetNumber("View[3].TimeStep", t);

                var max = opt.GetNumber("View[0].Max");
                opt.SetNumber("View[0].RaiseZ", 0.01 / max * t);

                if (num == 3)
                {
                    var mw = opt.GetNumber("General.MenuWidth");
                    opt.SetNumber("General.GraphicsWidth", mw + 640);
                    opt.SetNumber("General.GraphicsHeight", 480);
                }

                int frames = 50;
                for (int num2 = 1; num2 <= frames; num2++)
                {
                    var rotx = opt.GetNumber("General.RotationX");
                    opt.SetNumber("General.RotationX", rotx + 10);
                    opt.SetNumber("General.RotationY", (rotx + 10) / 3.0);

                    var rotz = opt.GetNumber("General.RotationZ");
                    opt.SetNumber("General.RotationZ", rotz + 0.1);

                    Gmsh.Graphics.Draw();

                    if (num == 3)
                    {
                        // Uncomment the following lines to save each frame to an image file
                        // gmsh::write("t2-" + std::to_string(num2) + ".gif");
                        // gmsh::write("t2-" + std::to_string(num2) + ".ppm");
                        // gmsh::write("t2-" + std::to_string(num2) + ".jpg");
                    }
                }

                if (num == 3)
                {
                    // Here we could make a system call to generate a movie...
                }
            }
            Gmsh.Fltk.Run();
            Gmsh.Finalize();
        }
    }
}