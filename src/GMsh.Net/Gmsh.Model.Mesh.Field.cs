using Gmsh_warp;
using System.Reflection;

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
                }
            }
        }
    }
}