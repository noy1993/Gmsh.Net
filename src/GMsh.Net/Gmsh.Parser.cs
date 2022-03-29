using Gmsh_warp;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// Parser functions
        /// </summary>
        public static class Parser
        {
            /// <summary>
            /// Get the names of the variables in the Gmsh parser matching the `search'
            /// regular expression. If `search' is empty, return all the names.
            /// </summary>
            public static string[] GetNames(string name = "")
            {
                unsafe
                {
                    byte** names_ptr;
                    int names_n = 0;
                    Gmsh_Warp.GmshParserGetNames(name, &names_ptr, ref names_n, ref Gmsh._staticreff);                    
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return UnsafeHelp.ToString(names_ptr, names_n); 
                }
            }

            /// <summary>
            /// Set the value of the number variable `name' in the Gmsh parser. Create the
            /// variable if it does not exist; update the value if the variable exists.
            /// </summary>
            public static void SetNumber(string name, double[] value)
            {
                Gmsh_Warp.GmshParserSetNumber(name, value, value.LongLength, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Set the value of the string variable name in the Gmsh parser. Create the variable 
            /// if it does not exist; update the value if the variable exists
            /// </summary>
            public static void SetString(string name, string[] value)
            {
                unsafe
                {
                    byte* dataptr = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(value, 0);
                    Gmsh_Warp.GmshParserSetString(name, &dataptr, value.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Get the `value' of a numerical option. `name' is of the form
            /// "category.option" or "category[num].option". Available categories and
            /// options are listed in the Gmsh reference manual.
            /// </summary>
            public static double[] GetNumber(string name)
            {
                unsafe
                {
                    double* tags_ptr;
                    long tags_n = 0;
                    Gmsh_Warp.GmshParserGetNumber(name, &tags_ptr, ref tags_n, ref Gmsh._staticreff);
                    var value = UnsafeHelp.ToDoubleArray(tags_ptr, tags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }
            }

            ///// <summary>
            ///// Set the value of the string variable `name' in the Gmsh parser. Create the
            ///// variable if it does not exist; update the value if the variable exists.
            ///// </summary>
            //public static void SetString(string name, string value)
            //{
            //    Gmsh_Warp.GmshParserSetString(name, value, ref Gmsh._staticreff);
            //    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            //}

            /// <summary>
            /// Get the value of the string variable `name' from the Gmsh parser. Return an
            /// empty vector if the variable does not exist.
            /// </summary>
            public static string[] GetString(string name)
            {
                unsafe
                {
                    byte** value_ptr;
                    long value_n = 0;
                    Gmsh_Warp.GmshParserGetString(name, &value_ptr, ref value_n, ref Gmsh._staticreff);
                    var value = UnsafeHelp.ToString(value_ptr, value_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }
            }

            /// <summary>
            /// Clear all the Gmsh parser variables, or remove a single variable if name is given.
            /// </summary>
            public static void Clear(string name = "")
			{
                Gmsh_Warp.GmshParserClear(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Parse the file fileName with the Gmsh parser.
            /// </summary>
            public static void Parse(string name)
            {
                Gmsh_Warp.GmshParserParse(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

        }
    }
}