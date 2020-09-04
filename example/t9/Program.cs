using GmshNet;

namespace t9
{
    using opt = Gmsh.Option;
    using p = Gmsh.Plugin;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t9");
            try
            {
                Gmsh.Merge("view3.pos");
            }
            catch
            {
                Gmsh.Logger.Write("Could not load post-processing views: bye!");
                Gmsh.Finalize();
                return;
            }

            p.SetNumber("Isosurface", "Value", 0.67);
            p.SetNumber("Isosurface", "View", 0);
            p.Run("Isosurface");

            p.SetNumber("CutPlane", "A", 0);
            p.SetNumber("CutPlane", "B", 0.2);
            p.SetNumber("CutPlane", "C", 1);
            p.SetNumber("CutPlane", "D", 0);
            p.SetNumber("CutPlane", "View", 0);
            p.Run("CutPlane");

            p.SetString("Annotate", "Text", "A nice title");
            p.SetNumber("Annotate", "X", 1.0E5);
            p.SetNumber("Annotate", "Y", 50);
            p.SetString("Annotate", "Font", "Times-BoldItalic");
            p.SetNumber("Annotate", "FontSize", 28);
            p.SetString("Annotate", "Align", "Center");
            p.SetNumber("Annotate", "View", 0);
            p.Run("Annotate");

            p.SetString("Annotate", "Text", "(and a small subtitle)");
            p.SetNumber("Annotate", "Y", 70);
            p.SetString("Annotate", "Font", "Times-Roman");
            p.SetNumber("Annotate", "FontSize", 12);
            p.Run("Annotate");

            opt.SetNumber("View[0].Light", 1);
            opt.SetNumber("View[0].IntervalsType", 1);
            opt.SetNumber("View[0].NbIso", 6);
            opt.SetNumber("View[0].SmoothNormals", 1);
            opt.SetNumber("View[1].IntervalsType", 2);
            opt.SetNumber("View[2].IntervalsType", 2);

            Gmsh.Fltk.Run();
            Gmsh.Finalize();
        }
    }
}