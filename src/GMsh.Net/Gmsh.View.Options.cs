using Gmsh_warp;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {        
        public static partial class View
        {
            /// <summary>
            /// View option handling functions
            /// </summary>
            public static class Options
			{
                /// <summary>
                /// Copy the options from the view with tag `refTag' to the view with tag `tag'.
                /// </summary>
                public static void Copy(int refTag, int tag)
                {
                    Gmsh_Warp.GmshViewOptionsCopy(refTag, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set the numerical option `name' to value `value' for the view with tag
                /// </summary>
                public static void SetNumber(int tag, string name, double value)
				{
                    Gmsh_Warp.GmshViewOptionsSetNumber(tag, name, value, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the `value' of the numerical option `name' for the view with tag
                /// </summary>
                public static double GetNumber(int tag, string name)
                {
                    double value = -1;
                    Gmsh_Warp.GmshViewOptionsGetNumber(tag, name, ref value, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }

                /// <summary>
                /// Set the string option `name' to value `value' for the view with tag `tag'.
                /// </summary>
                public static void SetString(int tag, string name, double value)
                {
                    Gmsh_Warp.GmshViewOptionsSetString(tag, name, value, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                public static string GetString(int tag, string name)
                {
                    string value = string.Empty;
                    Gmsh_Warp.GmshViewOptionsGetString(tag, name, ref value, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }

                /// <summary>
                /// Set the color option `name' to the RGBA value (`r', `g', `b', `a') for the
                /// view with tag `tag', where where `r', `g', `b' and `a' should be integers
                /// between 0 and 255.
                /// </summary>
                public static void SetColor(string name, int r, int g, int b, int a = 255)
                {
                    Gmsh_Warp.GmshOptionSetColor(name, r, g, b, a, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                ///Get the `r', `g', `b', `a' value of the color option `name' for the view
                /// with tag `tag'.
                /// </summary>
                public static void GetColor(string name, out int r, out int g, out int b, out int a)
                {
                    r = 0; g = 0; b = 0; a = 0;
                    Gmsh_Warp.GmshOptionGetColor(name, ref r, ref g, ref b, ref a, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }            
        }
    }
}