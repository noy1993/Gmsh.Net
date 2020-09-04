using Gmsh_warp;
using System.Drawing;
using System.Reflection;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// Option handling functions
        /// </summary>
        public static class Option
        {
            /// <summary>
            /// Set a numerical option to `value'. `name' is of the form "category.option"
            /// or "category[num].option". Available categories and options are listed in
            /// the Gmsh reference manual.
            /// </summary>
            public static void SetNumber(string name, double value)
            {
                Gmsh_Warp.GmshOptionSetNumber(name, value, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the `value' of a numerical option. `name' is of the form
            /// "category.option" or "category[num].option". Available categories and
            /// options are listed in the Gmsh reference manual.
            /// </summary>
            public static double GetNumber(string name)
            {
                var value = 0.0;
                Gmsh_Warp.GmshOptionGetNumber(name, ref value, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return value;
            }

            /// <summary>
            /// Set a string option to `value'. `name' is of the form "category.option" or
            /// "category[num].option". Available categories and options are listed in the
            /// Gmsh reference manual.
            /// </summary>
            public static void SetString(string name, string value)
            {
                Gmsh_Warp.GmshOptionSetString(name, value, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the `value' of a string option. `name' is of the form "category.option"
            /// or "category[num].option". Available categories and options are listed in
            /// the Gmsh reference manual.
            /// </summary>
            public static string GetString(string name)
            {
                unsafe
                {
                    byte* valueptr;
                    Gmsh_Warp.GmshOptionGetString(name, &valueptr, ref Gmsh._staticreff);
                    var value = UnsafeHelp.ToString(valueptr);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }
            }

            /// <summary>
            /// Set a color option to the RGBA value (`r', `g', `b', `a'), where where `r',
            /// `g', `b' and `a' should be integers between 0 and 255. `name' is of the form
            /// "category.option" or "category[num].option". Available categories and
            /// options are listed in the Gmsh reference manual, with the "Color." middle
            /// string removed.
            /// </summary>
            public static void SetColor(string name, int r, int g, int b, int a = 255)
            {
                Gmsh_Warp.GmshOptionSetColor(name, r, g, b, a, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            public static void SetColor(string name, Color color)
            {
                SetColor(name, color.R, color.G, color.B, color.A);
            }

            /// <summary>
            /// Get the `r', `g', `b', `a' value of a color option. `name' is of the form
            /// "category.option" or "category[num].option". Available categories and
            /// options are listed in the Gmsh reference manual, with the "Color." middle
            /// string removed.
            /// </summary>
            public static void GetColor(string name, out int r, out int g, out int b, out int a)
            {
                r = 0; g = 0; b = 0; a = 0;
                Gmsh_Warp.GmshOptionGetColor(name, ref r, ref g, ref b, ref a, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            public static void GetColor(string name, out Color color)
            {
                GetColor(name, out int r, out int g, out int b, out int a);
                color = Color.FromArgb(a, r, g, b);
            }
        }
    }
}