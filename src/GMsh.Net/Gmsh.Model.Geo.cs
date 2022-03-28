using Gmsh_warp;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        public static partial class Model
        {
            public static partial class Geo
            {
                /// <summary>
                /// Add a geometrical point in the built-in CAD representation, at coordinates
                /// (`x', `y', `z'). If `meshSize' is > 0, add a meshing constraint at that
                /// point. If `tag' is positive, set the tag explicitly; otherwise a new tag
                /// is selected automatically. Return the tag of the point. (Note that the
                /// point will be added in the current model only after `synchronize' is
                /// called. This behavior holds for all the entities added in the geo module.)
                /// </summary>
                public static int AddPoint(double x, double y, double z, double meshsize = 0, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddPoint(x, y, z, meshsize, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a straight line segment between the two points with tags `startTag'
                /// and `endTag'. If `tag' is positive, set the tag explicitly; otherwise a
                /// new tag is selected automatically. Return the tag of the line.
                /// </summary>
                public static int AddLine(int startTag, int endTag, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddLine(startTag, endTag, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a circle arc (strictly smaller than Pi) between the two points with
                /// tags `startTag' and `endTag', with center `centertag'. If `tag' is
                /// positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. If (`nx', `ny', `nz') != (0, 0, 0), explicitly set the
                /// plane of the circle arc. Return the tag of the circle arc.
                /// </summary>
                public static int AddCircleArc(int startTag, int centerTag, int endTag, int tag = -1, double nx = 0, double ny = 0, double nz = 0)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddCircleArc(startTag, centerTag, endTag, tag, nx, ny, nz, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add an ellipse arc (strictly smaller than Pi) between the two points
                /// `startTag' and `endTag', with center `centerTag' and major axis point
                /// `majorTag'. If `tag' is positive, set the tag explicitly; otherwise a new
                /// tag is selected automatically. If (`nx', `ny', `nz') != (0, 0, 0),
                /// explicitly set the plane of the circle arc. Return the tag of the ellipse
                /// arc.
                /// </summary>
                public static int AddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag = -1, double nx = 0, double ny = 0, double nz = 0)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddEllipseArc(startTag, centerTag, majorTag, endTag, tag, nx, ny, nz, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a spline (Catmull-Rom) curve going through the points `pointTags'. If
                /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Create a periodic curve if the first and last points are
                /// the same. Return the tag of the spline curve.
                /// </summary>
                public static int AddSpline(int[] pointTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddSpline(pointTags, pointTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a cubic b-spline curve with `pointTags' control points. If `tag' is
                /// positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Creates a periodic curve if the first and last points are
                /// the same. Return the tag of the b-spline curve.
                /// </summary>
                public static int AddBSpline(int[] pointTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddBSpline(pointTags, pointTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a Bezier curve with `pointTags' control points. If `tag' is positive,
                /// set the tag explicitly; otherwise a new tag is selected automatically.
                /// Return the tag of the Bezier curve.
                /// </summary>
                public static int AddBezier(int[] pointTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddBezier(pointTags, pointTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a polyline curve going through the points `pointTags'. If `tag' is
                /// positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Create a periodic curve if the first and last points are
                /// the same. Return the tag of the polyline curve.
                /// </summary>
                public static int AddPolyline(int[] pointTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddPolyline(pointTags, pointTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a spline (Catmull-Rom) going through points sampling the curves in
                /// `curveTags'. The density of sampling points on each curve is governed by
                /// `numIntervals'. If `tag' is positive, set the tag explicitly; otherwise a
                /// new tag is selected automatically. Return the tag of the spline.
                /// </summary>
                public static int AddCompoundSpline(int[] curveTags, int numIntervals = 5, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddCompoundSpline(curveTags, curveTags.LongLength, numIntervals, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a b-spline with control points sampling the curves in `curveTags'. The
                /// density of sampling points on each curve is governed by `numIntervals'. If
                /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Return the tag of the b-spline.
                /// </summary>
                public static int AddCompoundBSpline(int[] curveTags, int numIntervals = 20, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddCompoundBSpline(curveTags, curveTags.LongLength, numIntervals, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a curve loop (a closed wire) formed by the curves `curveTags'.
                /// `curveTags' should contain (signed) tags of model enties of dimension 1
                /// forming a closed loop: a negative tag signifies that the underlying curve
                /// is considered with reversed orientation. If `tag' is positive, set the tag
                /// explicitly; otherwise a new tag is selected automatically. Return the tag
                /// of the curve loop.
                /// </summary>
                public static int AddCurveLoop(int[] curveTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddCurveLoop(curveTags, curveTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add curve loops in the built-in CAD representation based on the curves curveTags. Return the tags of found curve loops, if any.
                /// </summary>
                /// <returns></returns>
                public static int[] AddCurveLoops(int[] curveTags)
                {
					unsafe
                    {
                        int* pointTags_ptr;
                        long pointTags_n = 0;
                        Gmsh_Warp.GmshModelGeoAddCurveLoops(curveTags, curveTags.LongLength, &pointTags_ptr, ref pointTags_n, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        var tags = UnsafeHelp.ToIntArray(pointTags_ptr, pointTags_n);
                        return tags;
                    }
                }

                /// <summary>
                /// Add a plane surface defined by one or more curve loops `wireTags'. The
                /// first curve loop defines the exterior contour; additional curve loop
                /// define holes. If `tag' is positive, set the tag explicitly; otherwise a
                /// new tag is selected automatically. Return the tag of the surface.
                /// </summary>
                public static int AddPlaneSurface(int[] wireTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddPlaneSurface(wireTags, wireTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a surface filling the curve loops in `wireTags'. Currently only a
                /// single curve loop is supported; this curve loop should be composed by 3 or
                /// 4 curves only. If `tag' is positive, set the tag explicitly; otherwise a
                /// new tag is selected automatically. Return the tag of the surface.
                /// </summary>
                public static int AddSurfaceFilling(int[] wireTags, int tag = -1, int sphereCenterTag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddSurfaceFilling(wireTags, wireTags.LongLength, tag, sphereCenterTag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a surface loop (a closed shell) formed by `surfaceTags'.  If `tag' is
                /// positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Return the tag of the shell.
                /// </summary>
                public static int AddSurfaceLoop(int[] surfaceTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddSurfaceLoop(surfaceTags, surfaceTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a volume (a region) defined by one or more shells `shellTags'. The
                /// first surface loop defines the exterior boundary; additional surface loop
                /// define holes. If `tag' is positive, set the tag explicitly; otherwise a
                /// new tag is selected automatically. Return the tag of the volume.
                /// </summary>
                public static int AddVolume(int[] shellTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelGeoAddVolume(shellTags, shellTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Extrude the model entities `dimTags' by translation along (`dx', `dy',
                /// `dz'). Return extruded entities in `outDimTags'. If `numElements' is not
                /// empty, also extrude the mesh: the entries in `numElements' give the number
                /// of elements in each layer. If `height' is not empty, it provides the
                /// (cumulative) height of the different layers, normalized to 1. If `dx' ==
                /// `dy' == `dz' == 0, the entities are extruded along their normal.
                /// </summary>
                public static void Extrude(ValueTuple<int, int>[] dimTags, double dx, double dy, double dz, out ValueTuple<int, int>[] outDimTags, 
                    int[] numElements = default, double[] heights = default, bool recombine = false)
                {
                    var dimarray = dimTags.ToIntArray();
                    unsafe
                    {
                        int* ptrss;
                        long outcount = 0;
                        if (numElements == default) numElements = new int[0];
                        if (heights == default) heights = new double[0];
                        Gmsh_Warp.GmshModelGeoExtrude(dimarray, dimarray.LongLength, dx, dy, dz, &ptrss, ref outcount, numElements, numElements.LongLength, heights, heights.LongLength, Convert.ToInt32(recombine), ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);

                        var outDimTagsint = UnsafeHelp.ToIntArray(ptrss, outcount);
                        outDimTags = outDimTagsint.ToIntPair();
                    }
                }

                /// <summary>
                /// Extrude the model entities `dimTags' by rotation of `angle' radians around
                /// the axis of revolution defined by the point (`x', `y', `z') and the
                /// direction (`ax', `ay', `az'). The angle should be strictly smaller than
                /// Pi. Return extruded entities in `outDimTags'. If `numElements' is not
                /// empty, also extrude the mesh: the entries in `numElements' give the number
                /// of elements in each layer. If `height' is not empty, it provides the
                /// (cumulative) height of the different layers, normalized to 1.
                /// </summary>
                public static void Revolve(ValueTuple<int, int>[] dimTags, double x, double y, double z, double ax, double ay, double az, double angle, 
                    out ValueTuple<int, int>[] outDimTags, int[] numElements = default, double[] heights = default, bool recombine = false)
                {
                    var dimarray = dimTags.ToIntArray();
                    unsafe
                    {
                        int* ptrss;
                        long outcount = 0;
                        if (numElements == default) numElements = new int[0];
                        if (heights == default) heights = new double[0];
                        Gmsh_Warp.GmshModelGeoRevolve(dimarray, dimarray.LongLength, x, y, z, ax, ay, az, angle, &ptrss, ref outcount, numElements, numElements.LongLength, heights, heights.LongLength, Convert.ToInt32(recombine), ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        var outDimTagsint = new int[outcount];
                        Marshal.Copy(new IntPtr(ptrss), outDimTagsint, 0, outDimTagsint.Length);
                        outDimTags = outDimTagsint.ToIntPair();
                    }
                }

                /// <summary>
                /// Extrude the model entities `dimTags' by a combined translation and
                /// rotation of `angle' radians, along (`dx', `dy', `dz') and around the axis
                /// of revolution defined by the point (`x', `y', `z') and the direction
                /// (`ax', `ay', `az'). The angle should be strictly smaller than Pi. Return
                /// extruded entities in `outDimTags'. If `numElements' is not empty, also
                /// extrude the mesh: the entries in `numElements' give the number of elements
                /// in each layer. If `height' is not empty, it provides the (cumulative)
                /// height of the different layers, normalized to 1.
                /// </summary>
                public static void Twist(ValueTuple<int, int>[] dimTags, double x, double y, double z, double dx, double dy, double dz, double ax, double ay, double az, double angle, 
                    out ValueTuple<int, int>[] outDimTags, int[] numElements = default, double[] heights = default, bool recombine = false)
                {
                    var dimarray = dimTags.ToIntArray();
                    unsafe
                    {
                        int* ptrss;
                        long outcount = 0;
                        if (numElements == default) numElements = new int[0];
                        if (heights == default) heights = new double[0];
                        Gmsh_Warp.GmshModelGeoTwist(dimarray, dimarray.LongLength, x, y, z, dx, dy, dz, ax, ay, az, angle, &ptrss, ref outcount, numElements, numElements.LongLength, heights, heights.LongLength, Convert.ToInt32(recombine), ref Gmsh._staticreff);

                        var array = UnsafeHelp.ToIntArray(ptrss, outcount);
                        outDimTags = array.ToIntPair();
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Translate the model entities `dimTags' along (`dx', `dy', `dz').
                /// </summary>
                public static void Translate(ValueTuple<int, int>[] dimTags, double dx, double dy, double dz)
                {
                    var list = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGeoTranslate(list, list.LongLength, dx, dy, dz, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Rotate the model entities `dimTags' of `angle' radians around the axis of
                /// revolution defined by the point (`x', `y', `z') and the direction (`ax',
                /// `ay', `az').
                /// </summary>
                public static void Rotate(ValueTuple<int, int>[] dimTags, double x, double y, double z, double ax, double ay, double az, double angle)
                {
                    var list = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGeoRotate(list, list.LongLength, x, y, z, ax, ay, az, angle, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                public static void Dilate(ValueTuple<int, int>[] dimTags, double x, double y, double z, double a, double b, double c)
                {
                    var list = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGeoDilate(list, list.LongLength, x, y, z, a, b, c, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Mirror the model entities `dimTag', with respect to the plane of equation
                /// `a' * x + `b' * y + `c' * z + `d' = 0.
                /// </summary>
                public static void Mirror(ValueTuple<int, int>[] dimTags, double a, double b, double c, double d)
                {
                    var list = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGeoMirror(list, list.LongLength, a, b, c, d, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Mirror the model entities `dimTag', with respect to the plane of equation
                /// `a' * x + `b' * y + `c' * z + `d' = 0. (This is a synonym for `mirror',
                /// which will be deprecated in a future release.)
                /// </summary>
                public static void Symmetrize(ValueTuple<int, int>[] dimTags, double a, double b, double c, double d)
                {
                    var list = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGeoSymmetrize(list, list.LongLength, a, b, c, d, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Copy the entities `dimTags'; the new entities are returned in
                /// `outDimTags'.
                /// </summary>
                public static void Copy(ValueTuple<int, int>[] dimTags, out ValueTuple<int, int>[] outDimTags)
                {
                    long outcount = 0;
                    var list = dimTags.ToIntArray();
                    unsafe
                    {
                        int* ptrss;
                        Gmsh_Warp.GmshModelGeoCopy(list, list.LongLength, &ptrss, ref outcount, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);

                        var outDimTagsint = UnsafeHelp.ToIntArray(ptrss, outcount);
                        outDimTags = outDimTagsint.ToIntPair();
                    }
                }

                /// <summary>
                /// Remove the entities `dimTags'. If `recursive' is true, remove all the
                /// entities on their boundaries, down to dimension 0.
                /// </summary>
                public static void Remove(ValueTuple<int, int>[] dimTags, bool recursive = false)
                {
                    var dimarray = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGeoRemove(dimarray, dimarray.LongLength, Convert.ToInt32(recursive), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Remove all duplicate entities (different entities at the same geometrical
                /// location).
                /// </summary>
                public static void RemoveAllDuplicates()
                {
                    Gmsh_Warp.GmshModelGeoRemoveAllDuplicates(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Split the model curve of tag `tag' on the control points `pointTags'.
                /// Return the tags `curveTags' of the newly created curves.
                /// </summary>
                public static int[] SplitCurve(int tag, int[] pointTags)
                {
                    unsafe
                    {
                        int* pointTags_ptr;
                        long pointTags_n = 0;
                        Gmsh_Warp.GmshModelGeoSplitCurve(tag, pointTags, pointTags.LongLength, &pointTags_ptr, ref pointTags_n, ref Gmsh._staticreff);
                        var curveTags = UnsafeHelp.ToIntArray(pointTags_ptr, pointTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return curveTags;
                    }
                }

                /// <summary>
                /// Get the maximum tag of entities of dimension `dim' in the built-in CAD
                /// representation.
                /// </summary>
                public static int GetMaxTag(int dim)
                {
                    var index = Gmsh_Warp.GmshModelGeoGetMaxTag(dim, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Set the maximum tag `maxTag' for entities of dimension `dim' in the built-
                /// in CAD representation.
                /// </summary>
                public static void SetMaxTag(int dim, int maxTag)
                {
                    Gmsh_Warp.GmshModelGeoSetMaxTag(dim, maxTag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Synchronize the built-in CAD representation with the current Gmsh model.
                /// This can be called at any time, but since it involves a non trivial amount
                /// of processing, the number of synchronization points should normally be
                /// minimized.
                /// </summary>
                public static void Synchronize()
                {
                    Gmsh_Warp.GmshModelGeoSynchronize(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }
        }
    }
}