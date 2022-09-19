using Gmsh_warp;
using System.Reflection;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        public static partial class Model
        {
            public static partial class Mesh
            {
                /// <summary>
                ///  Mesh size field functions
                /// </summary>
                public static class Field
                {
                    /// <summary>
                    /// Add a new mesh size field of type `fieldType'. If `tag' is positive,
                    /// assign the tag explicitly; otherwise a new tag is assigned
                    /// automatically. Return the field tag.
                    /// </summary>
                    public static int Add(string fieldType, int tag = -1)
                    {
                        var index = Gmsh_Warp.GmshModelMeshFieldAdd(fieldType, tag, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return index;
                    }

                    /// <summary>
                    /// Remove the field with tag `tag'.
                    /// </summary>
                    public static void Remove(int tag)
                    {
                        Gmsh_Warp.GmshModelMeshFieldRemove(tag, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set the numerical option `option' to value `value' for field `tag'.
                    /// </summary>
                    public static void SetNumber(int tag, string option, double value)
                    {
                        Gmsh_Warp.GmshModelMeshFieldSetNumber(tag, option, value, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set the string option `option' to value `value' for field `tag'.
                    /// </summary>
                    public static void SetString(int tag, string option, string value)
                    {
                        Gmsh_Warp.GmshModelMeshFieldSetString(tag, option, value, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    ///  Set the numerical list option `option' to value `value' for field `tag'.
                    /// </summary>
                    public static void SetNumbers(int tag, string option, double[] value)
                    {
                        Gmsh_Warp.GmshModelMeshFieldSetNumbers(tag, option, value, value.LongLength, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    ///  Set the field `tag' as the background mesh size field.
                    /// </summary>
                    public static void SetAsBackgroundMesh(int tag)
                    {
                        Gmsh_Warp.GmshModelMeshFieldSetAsBackgroundMesh(tag, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    ///  Set the field `tag' as a boundary layer size field.
                    /// </summary>
                    public static void SetAsBoundaryLayer(int tag)
                    {
                        Gmsh_Warp.GmshModelMeshFieldSetAsBoundaryLayer(tag, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Get the list of all fields.
                    /// </summary>
                    public static int[] List()
					{
						unsafe
						{
                            int* tags_ptr;
                            int tags_n = 0;
                            Gmsh_Warp.GmshModelMeshFieldList(&tags_ptr, ref tags_n, ref Gmsh._staticreff);
                            var tags = UnsafeHelp.ToIntArray(tags_ptr, tags_n);
                            Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                            return tags;
                        }
					}

                    /// <summary>
                    /// Get the type `fieldType' of the field with tag `tag'
                    /// </summary>
                    public static string GetType(int tag)
					{
                        string fileType = string.Empty;
                        Gmsh_Warp.GmshModelMeshFieldGetType(tag, ref fileType, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return fileType;
                    }

                    /// <summary>
                    /// Get the value of the numerical option `option' for field `tag'
                    /// </summary>
                    public static double GetNumber(int tag, string option)
					{
                        double number = -1;
                        Gmsh_Warp.GmshModelMeshFieldGetNumber(tag, option, ref number, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return number;
                    }

                    /// <summary>
                    /// Get the value of the numerical list option `option' for field `tag'
                    /// </summary>
                    public static double[] GetNumbers(int tag, string option)
                    {
                        unsafe
                        {
                            double* number_ptr;
                            int number_n = 0;
                            Gmsh_Warp.GmshModelMeshFieldGetNumbers(tag, option, &number_ptr, ref number_n, ref Gmsh._staticreff);
                            Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                            var number = UnsafeHelp.ToDoubleArray(number_ptr, number_n);
                            return number;
                        }
                    }

                    public static string GetString(int tag, string option)
					{
                        string value = string.Empty;
                        Gmsh_Warp.GmshModelMeshFieldGetString(tag, option, ref value, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return value;
                    }
                }
            }
        }
    }
}