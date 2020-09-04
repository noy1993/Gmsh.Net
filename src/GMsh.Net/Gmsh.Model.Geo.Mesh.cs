using Gmsh_warp;
using System;
using System.Reflection;

namespace GmshNet
{
    public static partial class Gmsh
    {
        public static partial class Model
        {
            public static partial class Geo
            {
                /// <summary>
                /// Built-in CAD kernel meshing constraints
                /// </summary>
                public static class Mesh
                {
                    /// <summary>
                    /// Set a mesh size constraint on the model entities `dimTags'. Currently
                    /// only entities of dimension 0 (points) are handled.
                    /// </summary>
                    public static void SetSize(ValueTuple<int, int>[] dimTags, double size)
                    {
                        var list = dimTags.ToIntArray();
                        Gmsh_Warp.GmshModelGeoMeshSetSize(list, list.LongLength, size, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set a transfinite meshing constraint on the curve `tag', with `numNodes'
                    /// nodes distributed according to `meshType' and `coef'. Currently
                    /// supported types are "Progression" (geometrical progression with power
                    /// `coef') and "Bump" (refinement toward both extremities of the curve).
                    /// </summary>
                    public static void SetTransfiniteCurve(int tag, int nPoints, string meshType = "Progression", double coef = 1)
                    {
                        Gmsh_Warp.GmshModelGeoMeshSetTransfiniteCurve(tag, nPoints, meshType, coef, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set a transfinite meshing constraint on the surface `tag'. `arrangement'
                    /// describes the arrangement of the triangles when the surface is not
                    /// flagged as recombined: currently supported values are "Left", "Right",
                    /// "AlternateLeft" and "AlternateRight". `cornerTags' can be used to
                    /// specify the (3 or 4) corners of the transfinite interpolation
                    /// explicitly; specifying the corners explicitly is mandatory if the
                    /// surface has more that 3 or 4 points on its boundary.
                    /// </summary>
                    public static void SetTransfiniteSurface(int tag, string arrangement = "Left", int[] cornerTags = default)
                    {
                        if (cornerTags == default) cornerTags = new int[0];
                        Gmsh_Warp.GmshModelGeoMeshSetTransfiniteSurface(tag, arrangement, cornerTags, cornerTags.LongLength, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set a transfinite meshing constraint on the surface `tag'. `cornerTags'
                    /// can be used to specify the (6 or 8) corners of the transfinite
                    /// interpolation explicitly.
                    /// </summary>
                    public static void SetTransfiniteVolume(int tag, int[] cornerTags = default)
                    {
                        if (cornerTags == default) cornerTags = new int[0];
                        Gmsh_Warp.GmshModelGeoMeshSetTransfiniteVolume(tag, cornerTags, cornerTags.LongLength, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set a recombination meshing constraint on the model entity of dimension
                    /// `dim' and tag `tag'. Currently only entities of dimension 2 (to
                    /// recombine triangles into quadrangles) are supported.
                    /// </summary>
                    public static void SetRecombine(int dim, int tag, double angle = 45)
                    {
                        Gmsh_Warp.GmshModelGeoMeshSetRecombine(dim, tag, angle, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set a smoothing meshing constraint on the model entity of dimension
                    /// `dim' and tag `tag'. `val' iterations of a Laplace smoother are applied.
                    /// </summary>
                    public static void SetSmoothing(int dim, int tag, int val)
                    {
                        Gmsh_Warp.GmshModelGeoMeshSetSmoothing(dim, tag, val, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set a reverse meshing constraint on the model entity of dimension `dim'
                    /// and tag `tag'. If `val' is true, the mesh orientation will be reversed
                    /// with respect to the natural mesh orientation (i.e. the orientation
                    /// consistent with the orientation of the geometry). If `val' is false, the
                    /// mesh is left as-is.
                    /// </summary>
                    public static void SetReverse(int dim, int tag, bool val = true)
                    {
                        Gmsh_Warp.GmshModelGeoMeshSetReverse(dim, tag, Convert.ToInt32(val), ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Set the meshing algorithm on the model entity of dimension `dim' and tag
                    /// `tag'. Currently only supported for `dim' == 2.
                    /// </summary>
                    public static void SetAlgorithm(int dim, int tag, int val)
                    {
                        Gmsh_Warp.GmshModelGeoMeshSetAlgorithm(dim, tag, val, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }

                    /// <summary>
                    /// Force the mesh size to be extended from the boundary, or not, for the
                    /// model entity of dimension `dim' and tag `tag'. Currently only supported
                    /// for `dim' == 2.
                    /// </summary>
                    public static void SetSizeFromBoundary(int dim, int tag, int val)
                    {
                        Gmsh_Warp.GmshModelGeoMeshSetSizeFromBoundary(dim, tag, val, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }
            }
        }
    }
}