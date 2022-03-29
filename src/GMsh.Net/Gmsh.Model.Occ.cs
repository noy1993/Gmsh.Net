using Gmsh_warp;
using System;
using System.Linq;
using System.Reflection;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        public static partial class Model
        {
            public static class Occ
            {
                /// <summary>
                /// Add a geometrical point in the OpenCASCADE CAD representation, at
                /// coordinates (`x', `y', `z'). If `meshSize' is > 0, add a meshing
                /// constraint at that point. If `tag' is positive, set the tag explicitly;
                /// otherwise a new tag is selected automatically. Return the tag of the
                /// point. (Note that the point will be added in the current model only after
                /// `synchronize' is called. This behavior holds for all the entities added in
                /// the occ module.)
                /// </summary>
                public static int AddPoint(double x, double y, double z, double meshSize = 0, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddPoint(x, y, z, meshSize, tag, ref Gmsh._staticreff);
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
                    var index = Gmsh_Warp.GmshModelOccAddLine(startTag, endTag, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a circle arc between the two points with tags `startTag' and `endTag',
                /// with center `centerTag'. If `tag' is positive, set the tag explicitly;
                /// otherwise a new tag is selected automatically. Return the tag of the
                /// circle arc.
                /// </summary>
                public static int AddCircleArc(int startTag, int centerTag, int endTag, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddCircleArc(startTag, centerTag, endTag, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a circle of center (`x', `y', `z') and radius `r'. If `tag' is
                /// positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. If `angle1' and `angle2' are specified, create a circle arc
                /// between the two angles. Return the tag of the circle.
                /// </summary>
                public static int AddCircle(int x, int y, int z, int r, int tag = -1, double angle1 = 0, double angle2 = 2 * Math.PI)
                {
                    var index = Gmsh_Warp.GmshModelOccAddCircle(x, y, z, r, tag, angle1, angle2, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add an ellipse arc between the two points `startTag' and `endTag', with
                /// center `centerTag' and major axis point `majorTag'. If `tag' is positive,
                /// set the tag explicitly; otherwise a new tag is selected automatically.
                /// Return the tag of the ellipse arc. Note that OpenCASCADE does not allow
                /// creating ellipse arcs with the major radius smaller than the minor radius.
                /// </summary>
                public static int AddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddEllipseArc(startTag, centerTag, majorTag, endTag, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add an ellipse of center (`x', `y', `z') and radii `r1' and `r2' along the
                /// x- and y-axes respectively. If `tag' is positive, set the tag explicitly;
                /// otherwise a new tag is selected automatically. If `angle1' and `angle2'
                /// are specified, create an ellipse arc between the two angles. Return the
                /// tag of the ellipse. Note that OpenCASCADE does not allow creating ellipses
                /// with the major radius (along the x-axis) smaller than or equal to the
                /// minor radius (along the y-axis): rotate the shape or use `addCircle' in
                /// such cases.
                /// </summary>
                public static int AddEllipse(int x, int y, int z, int r1, int r2, int tag = -1, double angle1 = 0, double angle2 = 2 * Math.PI)
                {
                    var index = Gmsh_Warp.GmshModelOccAddEllipse(x, y, z, r1, r2, tag, angle1, angle2, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a spline (C2 b-spline) curve going through the points `pointTags'. If
                /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Create a periodic curve if the first and last points are
                /// the same. Return the tag of the spline curve.
                /// </summary>
                public static int AddSpline(int[] pointTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddSpline(pointTags, pointTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a b-spline curve of degree `degree' with `pointTags' control points.
                /// If `weights', `knots' or `multiplicities' are not provided, default
                /// parameters are computed automatically. If `tag' is positive, set the tag
                /// explicitly; otherwise a new tag is selected automatically. Create a
                /// periodic curve if the first and last points are the same. Return the tag
                /// of the b-spline curve.
                /// </summary>
                public static int AddBSpline(int[] pointTags, int tag = -1, int degree = 3, double[] weights = default, double[] knots = default, int[] multiplicities = default)
                {
                    if (weights == default) weights = new double[0];
                    if (knots == default) knots = new double[0];
                    if (multiplicities == default) multiplicities = new int[0];
                    var index = Gmsh_Warp.GmshModelOccAddBSpline(pointTags, pointTags.LongLength, tag, degree,
                        weights, weights.LongLength,
                        knots, knots.LongLength,
                        multiplicities, multiplicities.LongLength,
                        ref Gmsh._staticreff);
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
                    var index = Gmsh_Warp.GmshModelOccAddBezier(pointTags, pointTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a wire (open or closed) formed by the curves `curveTags'. Note that an
                /// OpenCASCADE wire can be made of curves that share geometrically identical
                /// (but topologically different) points. If `tag' is positive, set the tag
                /// explicitly; otherwise a new tag is selected automatically. Return the tag
                /// of the wire.
                /// </summary>
                public static int AddWire(int[] curveTags, int tag = -1, bool checkClosed = false)
                {
                    var index = Gmsh_Warp.GmshModelOccAddWire(curveTags, curveTags.LongLength, tag, Convert.ToInt32(checkClosed), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a curve loop (a closed wire) formed by the curves `curveTags'.
                /// `curveTags' should contain tags of curves forming a closed loop. Note that
                /// an OpenCASCADE curve loop can be made of curves that share geometrically
                /// identical (but topologically different) points. If `tag' is positive, set
                /// the tag explicitly; otherwise a new tag is selected automatically. Return
                /// the tag of the curve loop.
                /// </summary>
                public static int AddCurveLoop(int[] curveTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddCurveLoop(curveTags, curveTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a rectangle with lower left corner at (`x', `y', `z') and upper right
                /// corner at (`x' + `dx', `y' + `dy', `z'). If `tag' is positive, set the tag
                /// explicitly; otherwise a new tag is selected automatically. Round the
                /// corners if `roundedRadius' is nonzero. Return the tag of the rectangle.
                /// </summary>
                public static int AddRectangle(double x, double y, double z, double dx, double dy, int tag = -1, double roundedRadius = 0)
                {
                    var index = Gmsh_Warp.GmshModelOccAddRectangle(x, y, z, dx, dy, tag, roundedRadius, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a disk with center (`xc', `yc', `zc') and radius `rx' along the x-axis
                /// and `ry' along the y-axis. If `tag' is positive, set the tag explicitly;
                /// otherwise a new tag is selected automatically. Return the tag of the disk.
                /// </summary>
                public static int AddDisk(double xc, double yc, double zc, double rx, double ry, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddDisk(xc, yc, zc, rx, ry, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a plane surface defined by one or more curve loops (or closed wires)
                /// `wireTags'. The first curve loop defines the exterior contour; additional
                /// curve loop define holes. If `tag' is positive, set the tag explicitly;
                /// otherwise a new tag is selected automatically. Return the tag of the
                /// surface.
                /// </summary>
                public static int AddPlaneSurface(int[] wireTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddPlaneSurface(wireTags, wireTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a surface filling the curve loop `wireTag'. If `tag' is positive, set
                /// the tag explicitly; otherwise a new tag is selected automatically. Return
                /// the tag of the surface. If `pointTags' are provided, force the surface to
                /// pass through the given points.
                /// </summary>
                public static int AddSurfaceFilling(int wireTag, int tag = -1, int[] pointTags = default, int degree = 3, int numPointsOnCurves = 15, int numIter = 2,
                    bool anisotropic = false, double tol2d = 0.00001, double tol3d = 0.0001, double tolAng = 0.01, double tolCurv = 0.1, int maxDegree = 8, int maxSegments = 9)
                {
                    if (pointTags == default) pointTags = new int[0];
                    var index = Gmsh_Warp.GmshModelOccAddSurfaceFilling(wireTag, tag, pointTags, pointTags.LongLength, degree, numPointsOnCurves, numIter,
                        Convert.ToInt16(anisotropic), tol2d, tol3d, tolAng, tolCurv, maxDegree, maxSegments, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a BSpline surface filling the curve loop `wireTag'. The curve loop
                /// should be made of 2, 3 or 4 BSpline curves. The optional `type' argument
                /// specifies the type of filling: "Stretch" creates the flattest patch,
                /// "Curved" (the default) creates the most rounded patch, and "Coons" creates
                /// a rounded patch with less depth than "Curved". If `tag' is positive, set
                /// the tag explicitly; otherwise a new tag is selected automatically. Return
                /// the tag of the surface.
                /// </summary>
                public static int AddBSplineFilling(int wireTag, int tag = -1, string type = "")
                {
                    var index = Gmsh_Warp.GmshModelOccAddBSplineFilling(wireTag, tag, type, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a Bezier surface filling the curve loop `wireTag'. The curve loop
                /// should be made of 2, 3 or 4 Bezier curves. The optional `type' argument
                /// specifies the type of filling: "Stretch" creates the flattest patch,
                /// "Curved" (the default) creates the most rounded patch, and "Coons" creates
                /// a rounded patch with less depth than "Curved". If `tag' is positive, set
                /// the tag explicitly; otherwise a new tag is selected automatically. Return
                /// the tag of the surface.
                /// </summary>
                public static int AddBezierFilling(int wireTag, int tag = -1, string type = "")
                {
                    var index = Gmsh_Warp.GmshModelOccAddBezierFilling(wireTag, tag, type, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a b-spline surface of degree `degreeU' x `degreeV' with `pointTags'
                /// control points given as a single vector [Pu1v1, ... Pu`numPointsU'v1,
                /// Pu1v2, ...]. If `weights', `knotsU', `knotsV', `multiplicitiesU' or
                /// `multiplicitiesV' are not provided, default parameters are computed
                /// automatically. If `tag' is positive, set the tag explicitly; otherwise a
                /// new tag is selected automatically. 
                /// If wireTags is provided, trim the b-spline patch using the provided wires: the first wire defines the external contour, the others define holes.
                /// If wire3D is set, consider wire curves as 3D curves and project them on the b-spline surface;
                /// otherwise consider the wire curves as defined in the parametric space of the surface. 
                /// Return the tag of the b-spline surface..
                /// </summary>
                public static int AddBSplineSurface(int[] pointTags, int numPointsU, int tag = -1, int degreeU = 3, int degreeV = 3,
                    double[] weights = default, double[] knotsU = default, double[] knotsV = default, int[] multiplicitiesU = default, int[] multiplicitiesV = default, 
                    int[] wireTags = default, bool wire3D = false)
                {
                    if (weights == default) weights = new double[0];
                    if (knotsU == default) knotsU = new double[0];
                    if (knotsV == default) knotsV = new double[0];
                    if (multiplicitiesU == default) multiplicitiesU = new int[0];
                    if (multiplicitiesV == default) multiplicitiesV = new int[0];
                    if (wireTags == default) wireTags = new int[0];
                    var index = Gmsh_Warp.GmshModelOccAddBSplineSurface(
                        pointTags, pointTags.LongLength,
                        numPointsU, tag, degreeU, degreeV,
                        weights, weights.LongLength,
                        knotsU, knotsU.LongLength,
                        knotsV, knotsV.LongLength,
                        multiplicitiesU, multiplicitiesU.LongLength,
                        multiplicitiesV, multiplicitiesV.LongLength,
                        wireTags, wireTags.LongLength,
                        Convert.ToInt32(wire3D),
                        ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a Bezier surface with `pointTags' control points given as a single
                /// vector [Pu1v1, ... Pu`numPointsU'v1, Pu1v2, ...]. If `tag' is positive,
                /// set the tag explicitly; otherwise a new tag is selected automatically.
                /// Return the tag of the b-spline surface.
                /// </summary>
                public static int AddBezierSurface(int[] pointTags, int numPointsU, int tag = -1, int[] wireTags = default, bool wire3D = false)
                {
                    if (wireTags == default) wireTags = new int[0];

                    var index = Gmsh_Warp.GmshModelOccAddBezierSurface(pointTags, pointTags.LongLength, numPointsU, tag, wireTags, 
                                                                      wireTags.LongLength, Convert.ToInt32(wire3D), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>                
                /// Trim the surface surfaceTag with the wires wireTags, replacing any existing trimming curves. 
                /// The first wire defines the external contour, the others define holes. 
                /// If wire3D is set, consider wire curves as 3D curves and project them on the surface; 
                /// otherwise consider the wire curves as defined in the parametric space of the surface.
                /// If tag is positive, set the tag explicitly; otherwise a new tag is selected automatically.
                /// Return the tag of the trimmed surface.
                /// </summary>
                public static int AddTrimmedSurface(int surfacetag, int[] wireTags, bool wire3D = false, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddTrimmedSurface(surfacetag, wireTags, wireTags.LongLength, Convert.ToInt32(wire3D), tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a surface loop (a closed shell) formed by `surfaceTags'.  If `tag' is
                /// positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. Return the tag of the surface loop. Setting `sewing' allows
                /// to build a shell made of surfaces that share geometrically identical (but
                /// topologically different) curves.
                /// </summary>
                public static int AddSurfaceLoop(int[] surfaceTags, int tag = -1, bool sewing = false)
                {
                    var index = Gmsh_Warp.GmshModelOccAddSurfaceLoop(surfaceTags, surfaceTags.LongLength, tag, Convert.ToInt32(sewing), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a volume (a region) defined by one or more surface loops `shellTags'.
                /// The first surface loop defines the exterior boundary; additional surface
                /// loop define holes. If `tag' is positive, set the tag explicitly; otherwise
                /// a new tag is selected automatically. Return the tag of the volume.
                /// </summary>
                public static int AddVolume(int[] shellTags, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddVolume(shellTags, shellTags.LongLength, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a sphere of center (`xc', `yc', `zc') and radius `r'. The optional
                /// `angle1' and `angle2' arguments define the polar angle opening (from -Pi/2
                /// to Pi/2). The optional `angle3' argument defines the azimuthal opening
                /// (from 0 to 2*Pi). If `tag' is positive, set the tag explicitly; otherwise
                /// a new tag is selected automatically. Return the tag of the sphere.
                /// </summary>
                public static int AddSphere(double xc, double yc, double zc, double radius, int tag, double angle1 = -Math.PI / 2, double angle2 = Math.PI / 2, double angle3 = Math.PI * 2)
                {
                    var index = Gmsh_Warp.GmshModelOccAddSphere(xc, yc, zc, radius, tag, angle1, angle2, angle3, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a parallelepipedic box defined by a point (`x', `y', `z') and the
                /// extents along the x-, y- and z-axes. If `tag' is positive, set the tag
                /// explicitly; otherwise a new tag is selected automatically. Return the tag
                /// of the box.
                /// </summary>
                public static int AddBox(double x, double y, double z, double dx, double dy, double dz, int tag = -1)
                {
                    var index = Gmsh_Warp.GmshModelOccAddBox(x, y, z, dx, dy, dz, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a parallelepipedic box defined by a point (`x', `y', `z') and the
                /// extents along the x-, y- and z-axes. If `tag' is positive, set the tag
                /// explicitly; otherwise a new tag is selected automatically. Return the tag
                /// of the box.
                /// </summary>
                public static int AddCylinder(double x, double y, double z, double dx, double dy, double dz, double r, int tag = -1, double angle = 2 * Math.PI)
                {
                    var index = Gmsh_Warp.GmshModelOccAddCylinder(x, y, z, dx, dy, dz, r, tag, angle, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a cone, defined by the center (`x', `y', `z') of its first circular
                /// face, the 3 components of the vector (`dx', `dy', `dz') defining its axis
                /// and the two radii `r1' and `r2' of the faces (these radii can be zero). If
                /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. `angle' defines the optional angular opening (from 0 to
                /// 2*Pi). Return the tag of the cone.
                /// </summary>
                public static int AddCone(double x, double y, double z, double dx, double dy, double dz, double r1, double r2, int tag = -1, double angle = 2 * Math.PI)
                {
                    var index = Gmsh_Warp.GmshModelOccAddCone(x, y, z, dx, dy, dz, r1, r2, tag, angle, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a right angular wedge, defined by the right-angle point (`x', `y',
                /// `z') and the 3 extends along the x-, y- and z-axes (`dx', `dy', `dz'). If
                /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
                /// automatically. The optional argument `ltx' defines the top extent along
                /// the x-axis. Return the tag of the wedge.
                /// </summary>
                public static int AddWedge(double x, double y, double z, double dx, double dy, double dz, int tag = -1, double ltx = 0)
                {
                    var index = Gmsh_Warp.GmshModelOccAddWedge(x, y, z, dx, dy, dz, tag, ltx, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a torus, defined by its center (`x', `y', `z') and its 2 radii `r' and
                /// `r2'. If `tag' is positive, set the tag explicitly; otherwise a new tag is
                /// selected automatically. The optional argument `angle' defines the angular
                /// opening (from 0 to 2*Pi). Return the tag of the wedge.
                /// </summary>
                public static int AddTorus(double x, double y, double z, double r1, double r2, int tag = -1, double angle = 2 * Math.PI)
                {
                    var index = Gmsh_Warp.GmshModelOccAddTorus(x, y, z, r1, r2, tag, angle, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Add a volume (if the optional argument `makeSolid' is set) or surfaces
                /// defined through the open or closed wires `wireTags'. If `tag' is positive,
                /// set the tag explicitly; otherwise a new tag is selected automatically. The
                /// new entities are returned in `outDimTags'. If the optional argument
                /// `makeRuled' is set, the surfaces created on the boundary are forced to be
                /// ruled surfaces. If `maxDegree' is positive, set the maximal degree of
                /// resulting surface.
                /// </summary>
                public static ValueTuple<int, int>[] AddThruSections(int[] wireTags, int tag = -1, bool makeSolid = true, bool makeRuled = false, int maxDegree = -1)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccAddThruSections(wireTags, wireTags.LongLength, &outDimTags_ptr, ref outDimTags_n, tag,
                           Convert.ToInt32(makeSolid), Convert.ToInt32(makeRuled), maxDegree, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n).ToIntPair().ToArray();
                    }
                }

                /// <summary>
                /// Add a hollowed volume built from an initial volume `volumeTag' and a set
                /// of faces from this volume `excludeSurfaceTags', which are to be removed.
                /// The remaining faces of the volume become the walls of the hollowed solid,
                /// with thickness `offset'. If `tag' is positive, set the tag explicitly;
                /// otherwise a new tag is selected automatically.
                /// </summary>
                public static ValueTuple<int, int>[] AddThickSolid(int volumeTag, int[] excludeSurfaceTags, double offset, int tag = -1)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccAddThickSolid(volumeTag, excludeSurfaceTags, excludeSurfaceTags.LongLength, offset, &outDimTags_ptr, ref outDimTags_n, tag, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n).ToIntPair();
                    }
                }

                /// <summary>
                /// Extrude the model entities `dimTags' by translation along (`dx', `dy',
                /// `dz'). Return extruded entities in `outDimTags'. If `numElements' is not
                /// empty, also extrude the mesh: the entries in `numElements' give the number
                /// of elements in each layer. If `height' is not empty, it provides the
                /// (cumulative) height of the different layers, normalized to 1.
                /// </summary>
                public static ValueTuple<int, int>[] Extrude(ValueTuple<int, int>[] dimTags, double dx, double dy, double dz, int[] numElements = default, double[] heights = default, bool recombine = false)
                {
                    unsafe
                    {
                        if (numElements == default) numElements = new int[0];
                        if (heights == default) heights = new double[0];
                        var dimTags_array = dimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccExtrude(dimTags_array, dimTags_array.LongLength, dx, dy, dz,
                            &outDimTags_ptr, ref outDimTags_n, numElements, numElements.LongLength, heights, heights.LongLength,
                            Convert.ToInt32(recombine), ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Extrude the model entities `dimTags' by rotation of `angle' radians around
                /// the axis of revolution defined by the point (`x', `y', `z') and the
                /// direction (`ax', `ay', `az'). Return extruded entities in `outDimTags'. If
                /// `numElements' is not empty, also extrude the mesh: the entries in
                /// `numElements' give the number of elements in each layer. If `height' is
                /// not empty, it provides the (cumulative) height of the different layers,
                /// normalized to 1. When the mesh is extruded the angle should be strictly
                /// smaller than 2*Pi.
                /// </summary>
                public static ValueTuple<int, int>[] Revolve(ValueTuple<int, int>[] dimTags, double x, double y, double z, double ax, double ay, double az, double angle, int[] numElements = default, double[] heights = default, bool recombine = false)
                {
                    unsafe
                    {
                        if (numElements == default) numElements = new int[0];
                        if (heights == default) heights = new double[0];
                        var dimTags_array = dimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccRevolve(dimTags_array, dimTags_array.LongLength, x, y, z, ax, ay, az, angle,
                            &outDimTags_ptr, ref outDimTags_n, numElements, numElements.LongLength, heights, heights.LongLength,
                            Convert.ToInt32(recombine), ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Add a pipe in the OpenCASCADE CAD representation, by extruding the entities dimTags along the wire wireTag. 
                /// The type of sweep can be specified with trihedron (possible values: "DiscreteTrihedron", "CorrectedFrenet", 
                /// "Fixed", "Frenet", "ConstantNormal", "Darboux", "GuideAC", "GuidePlan", "GuideACWithContact", "GuidePlanWithContact").
                /// If trihedron is not provided, "DiscreteTrihedron" is assumed.
                /// Return the pipe in `outDimTags'.
                /// </summary>
                public static ValueTuple<int, int>[] AddPipe(ValueTuple<int, int>[] dimTags, int wireTag, string trihedron = "")
                {
                    unsafe
                    {
                        var dimTags_array = dimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccAddPipe(dimTags_array, dimTags_array.LongLength, wireTag,
                            &outDimTags_ptr, ref outDimTags_n, trihedron, ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Fillet the volumes `volumeTags' on the curves `curveTags' with radii
                /// `radii'. The `radii' vector can either contain a single radius, as many
                /// radii as `curveTags', or twice as many as `curveTags' (in which case
                /// different radii are provided for the begin and end points of the curves).
                /// Return the filleted entities in `outDimTags'. Remove the original volume
                /// if `removeVolume' is set.
                /// </summary>
                public static ValueTuple<int, int>[] Fillet(int[] volumeTags, int[] curveTags, double[] radii, bool removeVolume = true)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccFillet(volumeTags, volumeTags.LongLength, curveTags, curveTags.LongLength, radii, radii.LongLength,
                            &outDimTags_ptr, ref outDimTags_n, Convert.ToInt32(removeVolume), ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Chamfer the volumes `volumeTags' on the curves `curveTags' with distances
                /// `distances' measured on surfaces `surfaceTags'. The `distances' vector can
                /// either contain a single distance, as many distances as `curveTags' and
                /// `surfaceTags', or twice as many as `curveTags' and `surfaceTags' (in which
                /// case the first in each pair is measured on the corresponding surface in
                /// `surfaceTags', the other on the other adjacent surface). Return the
                /// chamfered entities in `outDimTags'. Remove the original volume if
                /// `removeVolume' is set.
                /// </summary>
                public static ValueTuple<int, int>[] Chamfer(int[] volumeTags, int[] curveTags, int[] surfaceTags, double[] distances, bool removeVolume = true)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccChamfer(volumeTags, volumeTags.LongLength, curveTags, curveTags.LongLength,
                            surfaceTags, surfaceTags.LongLength, distances, distances.LongLength,
                            &outDimTags_ptr, ref outDimTags_n, Convert.ToInt32(removeVolume), ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Convert the entities dimTags to NURBS.
                /// </summary>
                public static void ConvertToNURBS(ValueTuple<int, int>[] dimTags)
				{
					unsafe
					{
                        var dimTags_array = dimTags.ToIntArray();
                        Gmsh_Warp.GmshModelOccConvertToNURBS(dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
				}

                /// <summary>
                /// Compute the boolean union (the fusion) of the entities `objectDimTags' and
                /// `toolDimTags'. Return the resulting entities in `outDimTags'. If `tag' is
                /// positive, try to set the tag explicitly (only valid if the boolean
                /// operation results in a single entity). Remove the object if `removeObject'
                /// is set. Remove the tool if `removeTool' is set.
                /// </summary>
                public static void Fuse(ValueTuple<int, int>[] objectDimTags, ValueTuple<int, int>[] toolDimTags, out ValueTuple<int, int>[] outDimTags, out ValueTuple<int, int>[][] outDimTagsMap, int tag = -1, bool removeObject = true, bool removeTool = true)
                {
                    unsafe
                    {
                        var objectDimTags_array = objectDimTags.ToIntArray();
                        var toolDimTags_array = toolDimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        int** outDimTagsMap_ptr;
                        long* outDimTagsMap_n_ptr;
                        long outDimTagsMap_nn = 0;
                        Gmsh_Warp.GmshModelOccFuse(objectDimTags_array, objectDimTags_array.LongLength,
                            toolDimTags_array, toolDimTags_array.LongLength,
                            &outDimTags_ptr, ref outDimTags_n,
                            &outDimTagsMap_ptr, &outDimTagsMap_n_ptr, ref outDimTagsMap_nn,
                            tag, Convert.ToInt32(removeObject), Convert.ToInt32(removeTool),
                            ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        outDimTags = outDimTags_array.ToIntPair();

                        var outDimTagsMap_array = UnsafeHelp.ToIntArray(outDimTagsMap_ptr, outDimTagsMap_n_ptr, outDimTagsMap_nn);
                        outDimTagsMap = outDimTagsMap_array.ToIntPair();
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Compute the boolean intersection (the common parts) of the entities
                /// `objectDimTags' and `toolDimTags'. Return the resulting entities in
                /// `outDimTags'. If `tag' is positive, try to set the tag explicitly (only
                /// valid if the boolean operation results in a single entity). Remove the
                /// object if `removeObject' is set. Remove the tool if `removeTool' is set.
                /// </summary>
                public static void Intersect(ValueTuple<int, int>[] objectDimTags, ValueTuple<int, int>[] toolDimTags, out ValueTuple<int, int>[] outDimTags, out ValueTuple<int, int>[][] outDimTagsMap, int tag = -1, bool removeObject = true, bool removeTool = true)
                {
                    unsafe
                    {
                        var objectDimTags_array = objectDimTags.ToIntArray();
                        var toolDimTags_array = toolDimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        int** outDimTagsMap_ptr;
                        long* outDimTagsMap_n_ptr;
                        long outDimTagsMap_nn = 0;
                        Gmsh_Warp.GmshModelOccIntersect(objectDimTags_array, objectDimTags_array.LongLength,
                            toolDimTags_array, toolDimTags_array.LongLength,
                            &outDimTags_ptr, ref outDimTags_n,
                            &outDimTagsMap_ptr, &outDimTagsMap_n_ptr, ref outDimTagsMap_nn,
                            tag, Convert.ToInt32(removeObject), Convert.ToInt32(removeTool),
                            ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        outDimTags = outDimTags_array.ToIntPair();

                        var outDimTagsMap_array = UnsafeHelp.ToIntArray(outDimTagsMap_ptr, outDimTagsMap_n_ptr, outDimTagsMap_nn);
                        outDimTagsMap = outDimTagsMap_array.ToIntPair();
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Compute the boolean difference between the entities `objectDimTags' and
                /// `toolDimTags'. Return the resulting entities in `outDimTags'. If `tag' is
                /// positive, try to set the tag explicitly (only valid if the boolean
                /// operation results in a single entity). Remove the object if `removeObject'
                /// is set. Remove the tool if `removeTool' is set.
                /// </summary>
                public static void Cut(ValueTuple<int, int>[] objectDimTags, ValueTuple<int, int>[] toolDimTags, out ValueTuple<int, int>[] outDimTags, out ValueTuple<int, int>[][] outDimTagsMap, int tag = -1, bool removeObject = true, bool removeTool = true)
                {
                    unsafe
                    {
                        var objectDimTags_array = objectDimTags.ToIntArray();
                        var toolDimTags_array = toolDimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        int** outDimTagsMap_ptr;
                        long* outDimTagsMap_n_ptr;
                        long outDimTagsMap_nn = 0;
                        Gmsh_Warp.GmshModelOccCut(objectDimTags_array, objectDimTags_array.LongLength, toolDimTags_array, toolDimTags_array.LongLength,
                            &outDimTags_ptr, ref outDimTags_n, &outDimTagsMap_ptr, &outDimTagsMap_n_ptr, ref outDimTagsMap_nn, tag,
                            Convert.ToInt32(removeObject), Convert.ToInt32(removeTool),
                            ref Gmsh._staticreff);

                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        outDimTags = outDimTags_array.ToIntPair();
                        var outDimTagsMap_array = UnsafeHelp.ToIntArray(outDimTagsMap_ptr, outDimTagsMap_n_ptr, outDimTagsMap_nn);
                        outDimTagsMap = new (int, int)[outDimTagsMap_array.Length][];
                        for (int i = 0; i < outDimTagsMap_array.Length; i++)
                        {
                            outDimTagsMap[i] = outDimTagsMap_array[i].ToIntPair();
                        }
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Compute the boolean fragments (general fuse) of the entities
                /// `objectDimTags' and `toolDimTags'. Return the resulting entities in
                /// `outDimTags'. If `tag' is positive, try to set the tag explicitly (only
                /// valid if the boolean operation results in a single entity). Remove the
                /// object if `removeObject' is set. Remove the tool if `removeTool' is set.
                /// </summary>
                public static void Fragment(ValueTuple<int, int>[] objectDimTags, ValueTuple<int, int>[] toolDimTags, out ValueTuple<int, int>[] outDimTags, out ValueTuple<int, int>[][] outDimTagsMap, int tag = -1, bool removeObject = true, bool removeTool = true)
                {
                    unsafe
                    {
                        var objectDimTags_array = objectDimTags.ToIntArray();
                        var toolDimTags_array = toolDimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        int** outDimTagsMap_ptr;
                        long* outDimTagsMap_n_ptr;
                        long outDimTagsMap_nn = 0;
                        Gmsh_Warp.GmshModelOccFragment(objectDimTags_array, objectDimTags_array.LongLength,
                            toolDimTags_array, toolDimTags_array.LongLength,
                            &outDimTags_ptr, ref outDimTags_n,
                            &outDimTagsMap_ptr, &outDimTagsMap_n_ptr, ref outDimTagsMap_nn,
                            tag, Convert.ToInt32(removeObject), Convert.ToInt32(removeTool),
                            ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        outDimTags = outDimTags_array.ToIntPair();

                        var outDimTagsMap_array = UnsafeHelp.ToIntArray(outDimTagsMap_ptr, outDimTagsMap_n_ptr, outDimTagsMap_nn);
                        outDimTagsMap = outDimTagsMap_array.ToIntPair();
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Translate the model entities `dimTags' along (`dx', `dy', `dz').
                /// </summary>
                public static void Translate(ValueTuple<int, int>[] dimTags, double dx, double dy, double dz)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccTranslate(dimTags_array, dimTags_array.LongLength,
                        dx, dy, dz, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Rotate the model entities `dimTags' of `angle' radians around the axis of
                /// revolution defined by the point (`x', `y', `z') and the direction (`ax',
                /// `ay', `az').
                /// </summary>
                public static void Rotate(ValueTuple<int, int>[] dimTags, double x, double y, double z, double ax, double ay, double az, double angle)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccRotate(dimTags_array, dimTags_array.LongLength,
                        x, y, z, ax, ay, az, angle, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Scale the model entities `dimTag' by factors `a', `b' and `c' along the
                /// three coordinate axes; use (`x', `y', `z') as the center of the homothetic
                /// transformation.
                /// </summary>
                public static void Dilate(ValueTuple<int, int>[] dimTags, double x, double y, double z, double a, double b, double c)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccDilate(dimTags_array, dimTags_array.LongLength,
                        x, y, z, a, b, c, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Apply a symmetry transformation to the model entities `dimTag', with
                /// respect to the plane of equation `a' * x + `b' * y + `c' * z + `d' = 0.
                /// </summary>
                public static void Mirror(ValueTuple<int, int>[] dimTags, double a, double b, double c, double d)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccMirror(dimTags_array, dimTags_array.LongLength,
                         a, b, c, d, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Apply a symmetry transformation to the model entities `dimTag', with
                /// respect to the plane of equation `a' * x + `b' * y + `c' * z + `d' = 0.
                /// (This is a synonym for `mirror', which will be deprecated in a future
                /// release.)
                /// </summary>
                public static void Symmetrize(ValueTuple<int, int>[] dimTags, double a, double b, double c, double d)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccSymmetrize(dimTags_array, dimTags_array.LongLength,
                         a, b, c, d, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Apply a general affine transformation matrix `a' (16 entries of a 4x4
                /// matrix, by row; only the 12 first can be provided for convenience) to the
                /// model entities `dimTag'.
                /// </summary>
                public static void AffineTransform(ValueTuple<int, int>[] dimTags, double[] a)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccAffineTransform(dimTags_array, dimTags_array.LongLength,
                         a, a.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Copy the entities `dimTags'; the new entities are returned in
                /// `outDimTags'.
                /// </summary>
                public static ValueTuple<int, int>[] Copy(ValueTuple<int, int>[] dimTags)
                {
                    unsafe
                    {
                        var dimTags_array = dimTags.ToIntArray();

                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccCopy(dimTags_array, dimTags_array.LongLength,
                            &outDimTags_ptr, ref outDimTags_n, ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Remove the entities `dimTags'. If `recursive' is true, remove all the
                /// entities on their boundaries, down to dimension 0.
                /// </summary>
                public static void Remove(ValueTuple<int, int>[] dimTags, bool recursive = false)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelOccRemove(dimTags_array, dimTags_array.LongLength,
                         Convert.ToInt32(recursive), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Remove all duplicate entities (different entities at the same geometrical
                /// location) after intersecting (using boolean fragments) all highest
                /// dimensional entities.
                /// </summary>
                public static void RemoveAllDuplicates()
                {
                    Gmsh_Warp.GmshModelOccRemoveAllDuplicates(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Apply various healing procedures to the entities `dimTags' (or to all the
                /// entities in the model if `dimTags' is empty). Return the healed entities
                /// in `outDimTags'. Available healing options are listed in the Gmsh
                /// reference manual.
                /// </summary>
                public static ValueTuple<int, int>[] HealShapes(ValueTuple<int, int>[] dimTags = default, double tolerance = 1e-8, bool fixDegenerated = true, bool fixSmallEdges = true, bool fixSmallFaces = true, bool sewFaces = true, bool makeSolids = true)
                {
                    unsafe
                    {
                        if (dimTags == default) dimTags = new (int, int)[0];

                        var dimTags_array = dimTags.ToIntArray();
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccHealShapes(
                            &outDimTags_ptr, ref outDimTags_n,
                            dimTags_array, dimTags_array.LongLength,
                            tolerance, Convert.ToInt32(fixDegenerated), Convert.ToInt32(fixSmallEdges), Convert.ToInt32(fixSmallFaces), Convert.ToInt32(sewFaces),
                            Convert.ToInt32(makeSolids),
                            ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Import BREP, STEP or IGES shapes from the file `fileName'. The imported
                /// entities are returned in `outDimTags'. If the optional argument
                /// `highestDimOnly' is set, only import the highest dimensional entities in
                /// the file. The optional argument `format' can be used to force the format
                /// of the file (currently "brep", "step" or "iges").
                /// </summary>
                public static ValueTuple<int, int>[] ImportShapes(string filename, bool highestDimOnly = true, string format = "")
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccImportShapes(filename,
                            &outDimTags_ptr, ref outDimTags_n, Convert.ToInt32(highestDimOnly), format, ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Imports an OpenCASCADE `shape' by providing a pointer to a native
                /// OpenCASCADE `TopoDS_Shape' object (passed as a pointer to void). The
                /// imported entities are returned in `outDimTags'. If the optional argument
                /// `highestDimOnly' is set, only import the highest dimensional entities in
                /// `shape'. For C and C++ only. Warning: this function is unsafe, as
                /// providing an invalid pointer will lead to undefined behavior.
                /// </summary>
                public static ValueTuple<int, int>[] ImportShapesNativePointer(IntPtr shape, bool highestDimOnly = true)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccImportShapesNativePointer(shape,
                            &outDimTags_ptr, ref outDimTags_n, Convert.ToInt32(highestDimOnly), ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Get all the OpenCASCADE entities. If `dim' is >= 0, return only the
                /// entities of the specified dimension (e.g. points if `dim' == 0). The
                /// entities are returned as a vector of (dim, tag) integer pairs.
                /// </summary>
                public static ValueTuple<int, int>[] GetEntities(int dim = -1)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccGetEntities(&outDimTags_ptr, ref outDimTags_n, dim, ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Get the OpenCASCADE entities in the bounding box defined by the two points
                /// (`xmin', `ymin', `zmin') and (`xmax', `ymax', `zmax'). If `dim' is >= 0,
                /// return only the entities of the specified dimension (e.g. points if `dim'
                /// == 0).
                /// </summary>
                public static ValueTuple<int, int>[] GetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int dim = -1)
                {
                    unsafe
                    {
                        int* outDimTags_ptr;
                        long outDimTags_n = 0;
                        Gmsh_Warp.GmshModelOccGetEntitiesInBoundingBox(xmin, ymin, zmin, xmax, ymax, zmax, &outDimTags_ptr, ref outDimTags_n, dim, ref Gmsh._staticreff);
                        var outDimTags_array = UnsafeHelp.ToIntArray(outDimTags_ptr, outDimTags_n);
                        var outDimTags = outDimTags_array.ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return outDimTags;
                    }
                }

                /// <summary>
                /// Get the bounding box (`xmin', `ymin', `zmin'), (`xmax', `ymax', `zmax') of
                /// the OpenCASCADE entity of dimension `dim' and tag `tag'.
                /// </summary>
                public static void GetBoundingBox(int dim, int tag, out double xmin, out double ymin, out double zmin, out double xmax, out double ymax, out double zmax)
                {
                    xmin = 0; ymin = 0; zmin = 0; xmax = 0; ymax = 0; zmax = 0;
                    Gmsh_Warp.GmshModelOccGetBoundingBox(dim, tag, ref xmin, ref ymin, ref zmin, ref xmax, ref ymax, ref zmax, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the mass of the OpenCASCADE entity of dimension `dim' and tag `tag'.
                /// </summary>
                public static double GetMass(int dim, int tag)
                {
                    double mass = 0;
                    Gmsh_Warp.GmshModelOccGetMass(dim, tag, ref mass, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return mass;
                }

                /// <summary>
                /// Get the center of mass of the OpenCASCADE entity of dimension `dim' and
                /// tag `tag'.
                /// </summary>
                public static void GetCenterOfMass(int dim, int tag, out double x, out double y, out double z)
                {
                    x = 0; y = 0; z = 0;
                    Gmsh_Warp.GmshModelOccGetCenterOfMass(dim, tag, ref x, ref y, ref z, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the matrix of inertia (by row) of the OpenCASCADE entity of dimension
                /// `dim' and tag `tag'.
                /// </summary>
                public static double[] GetMatrixOfInertia(int dim, int tag)
                {
                    unsafe
                    {
                        double* mat_ptr;
                        long mat_n = 0;
                        Gmsh_Warp.GmshModelOccGetMatrixOfInertia(dim, tag, &mat_ptr, ref mat_n, ref Gmsh._staticreff);
                        var mat = UnsafeHelp.ToDoubleArray(mat_ptr, mat_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return mat;
                    }
                }

                /// <summary>
                /// Get the maximum tag of entities of dimension `dim' in the OpenCASCADE CAD
                /// representation.
                /// </summary>
                public static int GetMaxTag(int dim)
                {
                    var maxTag = Gmsh_Warp.GmshModelOccGetMaxTag(dim, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return maxTag;
                }

                /// <summary>
                /// Set the maximum tag `maxTag' for entities of dimension `dim' in the
                /// OpenCASCADE CAD representation.
                /// </summary>
                public static void SetMaxTag(int dim, int maxTag)
                {
                    Gmsh_Warp.GmshModelOccSetMaxTag(dim, maxTag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the tags of the curve loops making up the surface of tag surfaceTag.
                /// </summary>
                public static int[] GetCurveLoops(int surfaceTag)
                {
                    unsafe
                    {
                        int* tags_ptr;
                        long tags_n = 0;
                        Gmsh_Warp.GmshModelOccGetCurveLoops(surfaceTag, &tags_ptr, ref tags_n, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        var outDimTags_array = UnsafeHelp.ToIntArray(tags_ptr, tags_n);
                        return outDimTags_array;
                    }
                }

                /// <summary>
                /// Synchronize the OpenCASCADE CAD representation with the current Gmsh
                /// model. This can be called at any time, but since it involves a non trivial
                /// amount of processing, the number of synchronization points should normally
                /// be minimized.
                /// </summary>
                public static void Synchronize()
                {
                    Gmsh_Warp.GmshModelOccSynchronize(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                public static int[] GetSurfaceLoops(int volumeTag)
				{
                    unsafe
                    {
                        int* tags_ptr;
                        long tags_n = 0;
                        Gmsh_Warp.GmshModelOccGetSurfaceLoops(volumeTag, &tags_ptr, ref tags_n, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        var outDimTags_array = UnsafeHelp.ToIntArray(tags_ptr, tags_n);
                        return outDimTags_array;
                    }
                }
            }
        }
    }
}