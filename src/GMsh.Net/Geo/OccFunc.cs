using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GMshNet
{
    /// <summary>
    /// OpenCASCADE CAD kernel functions
    /// </summary>
    public sealed class OccFunc
    {
        private int ierr = 0;
        /// <summary>
        /// Add a geometrical point in the OpenCASCADE CAD representation, at
        /// coordinates (`x', `y', `z'). If `meshSize' is > 0, add a meshing
        /// constraint at that point. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the
        /// point. (Note that the point will be added in the current model only after
        /// `synchronize' is called. This behavior holds for all the entities added in
        /// the occ module.) 
        /// </summary>
        public int AddPoint(double x, double y, double z, int tag = -1, double meshSize = 0)
        {
            var api = GMshNativeMethods.gmshModelOccAddPoint(x, y, z, meshSize, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a straight line segment between the two points with tags `startTag'
        /// and `endTag'. If `tag' is positive, set the tag explicitly; otherwise a
        /// new tag is selected automatically. Return the tag of the line.
        /// </summary>
        public int AddLine(int startTag, int endTag, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddLine(startTag, endTag, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a circle arc between the two points with tags `startTag' and `endTag',
        /// with center `centerTag'. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the
        /// circle arc.
        /// </summary>
        public int AddCircleArc(int startTag, int centerTag, int endTag, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddCircleArc(startTag, centerTag, endTag, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }

        /// <summary>
        /// Add a circle of center (`x', `y', `z') and radius `r'. If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. If `angle1' and `angle2' are specified, create a circle arc
        /// between the two angles. Return the tag of the circle.
        /// </summary>
        public int AddCircle(int startTag, int centerTag, int endTag, double angle1 = 0, double angle2 = 2 * Math.PI, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddCircleArc(startTag, centerTag, endTag, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add an ellipse arc between the two points `startTag' and `endTag', with
        /// center `centerTag' and major axis point `majorTag'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the ellipse arc. Note that OpenCASCADE does not allow
        /// creating ellipse arcs with the major radius smaller than the minor radius.
        /// </summary>
        public int AddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddEllipseArc(startTag, centerTag, majorTag, endTag, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
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
        public int AddEllipse(double x, double y, double z, double r1, double r2, double angle1 = 0, double angle2 = 2 * Math.PI, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddEllipse(x, y, z, r1, r2, tag, angle1, angle2, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        public int AddSpline(List<int> pointTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddSpline(pointTags.ToArray(), pointTags.Count.ToUint(), tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a b-spline curve of degree `degree' with `pointTags' control points.
        /// If `weights', `knots' or `multiplicities' are not provided, default
        /// parameters are computed automatically. If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Create a
        /// periodic curve if the first and last points are the same. Return the tag
        /// of the b-spline curve.
        /// </summary>
        public int AddBSpline(IEnumerable<int> pointTags, IEnumerable<double> weights, IEnumerable<double> knots, IEnumerable<int> multiplicities, int tag = -1, int degree = 3)
        {
            var api = GMshNativeMethods.gmshModelOccAddBSpline(pointTags.ToArray(), pointTags.Count().ToUint(), tag, degree, weights.ToArray(), weights.Count().ToUint(),
                knots.ToArray(), knots.Count().ToUint(), multiplicities.ToArray(), multiplicities.Count().ToUint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        public int AddBSpline(IEnumerable<int> pointTags, IEnumerable<double> weights, int tag = -1, int degree = 3)
        {
            List<double> knots = new List<double>();
            List<int> multiplicities = new List<int>();
            return AddBSpline(pointTags, weights, knots, multiplicities, tag, degree);
        }
        /// <summary>
        /// Add a b-spline curve of degree `degree' with `pointTags' control points.
        /// </summary>
        public int AddBSpline(IEnumerable<int> pointTags, int tag = -1, int degree = 3)
        {
            List<double> weights = new List<double>();
            List<double> knots = new List<double>();
            List<int> multiplicities = new List<int>();
            return AddBSpline(pointTags, weights, knots, multiplicities, tag, degree);
        }
        /// <summary>
        /// Add a Bezier curve with `pointTags' control points. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the Bezier curve.
        /// </summary>
        public int AddBezier(IEnumerable<int> pointTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddBezier(pointTags.ToArray(), pointTags.Count().ToUint(), tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a wire (open or closed) formed by the curves `curveTags'. Note that an
        /// OpenCASCADE wire can be made of curves that share geometrically identical
        /// (but topologically different) points. If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Return the tag
        /// of the wire.
        /// </summary>
        public int AddWire(IEnumerable<int> curveTags, int tag = -1, bool checkClosed = false)
        {
            var api = GMshNativeMethods.gmshModelOccAddWire(curveTags.ToArray(), curveTags.Count().ToUint(), tag, checkClosed.Toint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a curve loop (a closed wire) formed by the curves `curveTags'.
        /// `curveTags' should contain tags of curves forming a closed loop. Note that
        /// an OpenCASCADE curve loop can be made of curves that share geometrically
        /// identical (but topologically different) points. If `tag' is positive, set
        /// the tag explicitly; otherwise a new tag is selected automatically. Return
        /// the tag of the curve loop.
        /// </summary>
        public int AddCurveLoop(IEnumerable<int> curveTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddCurveLoop(curveTags.ToArray(), curveTags.Count().ToUint(), tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a rectangle with lower left corner at (`x', `y', `z') and upper right
        /// corner at (`x' + `dx', `y' + `dy', `z'). If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Round the
        /// corners if `roundedRadius' is nonzero. Return the tag of the rectangle.
        /// </summary>
        public int AddRectangle(double x, double y, double z, double dx, double dy, int tag = -1, double roundedRadius = 0)
        {
            var api = GMshNativeMethods.gmshModelOccAddRectangle(x, y, z, dx, dy, tag, roundedRadius, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a disk with center (`xc', `yc', `zc') and radius `rx' along the x-axis
        /// and `ry' along the y-axis. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the disk.
        /// </summary>
        public int AddDisk(double xc, double yc, double zc, double rx, double ry, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddDisk(xc, yc, zc, rx, ry, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a plane surface defined by one or more curve loops (or closed wires)
        /// `wireTags'. The first curve loop defines the exterior contour; additional
        /// curve loop define holes. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the
        /// surface.
        /// </summary>
        public int AddPlaneSurface(IEnumerable<int> wireTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddPlaneSurface(wireTags.ToArray(), wireTags.Count().ToUint(), tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a surface filling the curve loops in `wireTags'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the surface. If `pointTags' are provided, force the
        /// surface to pass through the given points.
        /// </summary>
        public int AddSurfaceFilling(int wireTag, IEnumerable<int> pointTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddSurfaceFilling(wireTag, tag, pointTags.ToArray(), pointTags.Count().ToUint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a surface filling the curve loops in `wireTags'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the surface.
        /// </summary>
        public int AddSurfaceFilling(int wireTag, int tag = -1)
        {
            List<int> pointTags = new List<int>();
            return AddSurfaceFilling(wireTag, pointTags, tag);
        }

        /// <summary>
        /// Add a surface loop (a closed shell) formed by `surfaceTags'.  If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. Return the tag of the surface loop. Setting `sewing' allows
        /// to build a shell made of surfaces that share geometrically identical (but
        /// topologically different) curves.
        /// </summary>
        public int AddSurfaceLoop(IEnumerable<int> surfaceTags, int tag = -1, bool sewing = false)
        {
            var api = GMshNativeMethods.gmshModelOccAddSurfaceLoop(surfaceTags.ToArray(), surfaceTags.Count().ToUint(), tag, sewing.Toint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }

        /// <summary>
        /// Add a volume (a region) defined by one or more surface loops `shellTags'.
        /// The first surface loop defines the exterior boundary; additional surface
        /// loop define holes. If `tag' is positive, set the tag explicitly; otherwise
        /// a new tag is selected automatically. Return the tag of the volume.
        /// </summary>
        public int AddVolume(IEnumerable<int> shellTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddVolume(shellTags.ToArray(), shellTags.Count().ToUint(), tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }

        /// <summary>
        /// Add a sphere of center (`xc', `yc', `zc') and radius `r'. The optional
        /// `angle1' and `angle2' arguments define the polar angle opening (from -Pi/2
        /// to Pi/2). The optional `angle3' argument defines the azimuthal opening
        /// (from 0 to 2*Pi). If `tag' is positive, set the tag explicitly; otherwise
        /// a new tag is selected automatically. Return the tag of the sphere.
        /// </summary>
        public int AddSphere(double xc, double yc, double zc, double radius, int tag = -1, double angle1 = -Math.PI / 2, double angle2 = Math.PI / 2, double angle3 = 2 * Math.PI / 2)
        {
            var api = GMshNativeMethods.gmshModelOccAddSphere(xc, yc, zc, radius, tag, angle1, angle2, angle3, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a parallelepipedic box defined by a point (`x', `y', `z') and the
        /// extents along the x-, y- and z-axes. If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Return the tag
        /// of the box.
        /// </summary>
        public int AddBox(double x, double y, double z, double dx, double dy, double dz, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelOccAddBox(x, y, z, dx, dy, dz, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }

        /// <summary>
        /// Add a cylinder, defined by the center (`x', `y', `z') of its first
        /// circular face, the 3 components (`dx', `dy', `dz') of the vector defining
        /// its axis and its radius `r'. The optional `angle' argument defines the
        /// angular opening (from 0 to 2*Pi). If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Return the tag
        /// of the cylinder.
        /// </summary>
        public int AddCylinder(double x, double y, double z, double dx, double dy, double dz, double r, int tag = -1, double angle = 2 * Math.PI)
        {
            var api = GMshNativeMethods.gmshModelOccAddCylinder(x, y, z, dx, dy, dz, r, tag, angle, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a cone, defined by the center (`x', `y', `z') of its first circular
        /// face, the 3 components of the vector (`dx', `dy', `dz') defining its axis
        /// and the two radii `r1' and `r2' of the faces (these radii can be zero). If
        /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. `angle' defines the optional angular opening (from 0 to
        /// 2*Pi). Return the tag of the cone.
        /// </summary>
        public int AddCone(double x, double y, double z, double dx, double dy, double dz, double r1, double r2, int tag = -1, double angle = 2 * Math.PI)
        {
            var api = GMshNativeMethods.gmshModelOccAddCone(x, y, z, dx, dy, dz, r1, r2, tag, angle, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a right angular wedge, defined by the right-angle point (`x', `y',
        /// `z') and the 3 extends along the x-, y- and z-axes (`dx', `dy', `dz'). If
        /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. The optional argument `ltx' defines the top extent along
        /// the x-axis. Return the tag of the wedge.
        /// </summary>
        public int AddWedge(double x, double y, double z, double dx, double dy, double dz, int tag = -1, double ltx = 0)
        {
            var api = GMshNativeMethods.gmshModelOccAddWedge(x, y, z, dx, dy, dz, tag, ltx, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a torus, defined by its center (`x', `y', `z') and its 2 radii `r' and
        /// `r2'. If `tag' is positive, set the tag explicitly; otherwise a new tag is
        /// selected automatically. The optional argument `angle' defines the angular
        /// opening (from 0 to 2*Pi). Return the tag of the wedge.
        /// </summary>
        public int AddTorus(double x, double y, double z, double r1, double r2, int tag = -1, double angle = 2 * Math.PI)
        {
            var api = GMshNativeMethods.gmshModelOccAddTorus(x, y, z, r1, r2, tag, angle, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        /// <summary>
        /// Add a volume (if the optional argument `makeSolid' is set) or surfaces
        /// defined through the open or closed wires `wireTags'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically. The
        /// new entities are returned in `outDimTags'. If the optional argument
        /// `makeRuled' is set, the surfaces created on the boundary are forced to be
        /// ruled surfaces.
        /// </summary>
        //public Dictionary<int, int> AddThruSections(IEnumerable<int> wireTags, int tag = -1, bool makeSolid = true, bool makeRuled = false)
        //{
        //    GMshNativeMethods.gmshModelOccAddThruSections(wireTags.ToArray(), wireTags.Count().ToUint(), out int[] api_outDimTags_, out uint api_outDimTags_n_, tag, makeSolid.Toint(), makeRuled.Toint(), ref ierr);
        //    if (ierr != 0) throw new GMshException(ierr);
        //    return ArrayToPairs(api_outDimTags_, api_outDimTags_n_);
        //}
        /// <summary>
        /// Add a hollowed volume built from an initial volume `volumeTag' and a set
        /// of faces from this volume `excludeSurfaceTags', which are to be removed.
        /// The remaining faces of the volume become the walls of the hollowed solid,
        /// with thickness `offset'. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically.
        /// </summary>
        //public Dictionary<int, int> AddThickSolid(int volumeTag, IEnumerable<int> excludeSurfaceTags, double offset, int tag = -1)
        //{
        //    GMshNativeMethods.gmshModelOccAddThickSolid(volumeTag, excludeSurfaceTags.ToArray(), excludeSurfaceTags.Count().ToUint(), offset, out int[] api_outDimTags_, out uint api_outDimTags_n_, tag, ref ierr);
        //    if (ierr != 0) throw new GMshException(ierr);
        //    return ArrayToPairs(api_outDimTags_, api_outDimTags_n_);
        //}
        internal Dictionary<int, int> ArrayToPairs(int[] tags,uint tags_n)
        {
            Dictionary<int, int> outDimTags = new Dictionary<int, int>(Convert.ToInt32(tags_n) / 2);
            for (int i = 0; i < tags_n; i++)
            {
                var index = i * 2;
                outDimTags.Add(tags[index], tags[index + 1]);
            }
            return outDimTags;
        }
        internal void PairsToArray(Dictionary<int, int> pairs, out int[] tags, out uint tags_n)
        {
            tags_n = Convert.ToUInt32(pairs.Count * 2);
            tags = new int[tags_n];

            for (int i = 0; i < pairs.Count; i++)
            {
                var index = i * 2;
                var element = pairs.ElementAt(i);
                tags[index] = element.Key;
                tags[index + 1] = element.Value;
            }
        }
        public void Synchronize()
        {
            GMshNativeMethods.gmshModelOccSynchronize(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        //public Dictionary<int, int> Extrude(Dictionary<int, int> dimTags, double dx, double dy, double dz, IEnumerable<int> numElements, IEnumerable<double> heights, bool recombine = false)
        //{
        //    PairsToArray(dimTags, out int[] api_dimTags, out uint api_dimTags_n);
        //    GMshNativeMethods.gmshModelOccExtrude(api_dimTags, api_dimTags_n, dx, dy, dz, out int[] outDimTags, out uint outDimTags_n, numElements.ToArray(), numElements.Count().ToUint(), heights.ToArray(), heights.Count().ToUint(), recombine.Toint(), ref ierr);
        //    if (ierr != 0) throw new GMshException(ierr);
        //    return ArrayToPairs(outDimTags, outDimTags_n);
        //}

        //public Dictionary<int, int> Revolve(Dictionary<int, int> dimTags, double x, double y, double z, double ax, double ay, double az, double angle, IEnumerable<int> numElements, IEnumerable<double> heights, bool recombine = false)
        //{
        //    PairsToArray(dimTags, out int[] api_dimTags, out uint api_dimTags_n);
        //    GMshNativeMethods.gmshModelOccRevolve(api_dimTags, api_dimTags_n, x, y, z, ax, ay, az, angle, out int[] outDimTags, out uint outDimTags_n, numElements.ToArray(), numElements.Count().ToUint(), heights.ToArray(), heights.Count().ToUint(), recombine.Toint(), ref ierr);
        //    if (ierr != 0) throw new GMshException(ierr);
        //    return ArrayToPairs(outDimTags, outDimTags_n);
        //}


        //public Dictionary<int, int> AddPipe(Dictionary<int, int> dimTags, int wireTag)
        //{
        //    PairsToArray(dimTags, out int[] api_dimTags, out uint api_dimTags_n);
        //    GMshNativeMethods.gmshModelOccAddPipe(api_dimTags, api_dimTags_n, wireTag, out int[] outDimTags, out uint outDimTags_n, ref ierr);
        //    if (ierr != 0) throw new GMshException(ierr);
        //    return ArrayToPairs(outDimTags, outDimTags_n);
        //}

 
        //public void Cut(Dictionary<int, int> objectDimTags, Dictionary<int, int> toolDimTags, out Dictionary<int, int> outDimTags, out IList<Dictionary<int, int>> outDimTagsMap, int tag = -1, bool removeObject = true, bool removeTool = true)
        //{
        //    PairsToArray(objectDimTags, out int[] api_objectDimTags, out uint api_objectDimTags_n);
        //    PairsToArray(toolDimTags, out int[] api_toolDimTags, out uint api_toolDimTags_n);

        //    unsafe
        //    {


        //        GMshNativeMethods.gmshModelOccCut(api_objectDimTags, api_objectDimTags_n, api_toolDimTags, api_toolDimTags_n, out int[] api_outDimTags, out uint api_outDimTags_n, out int*[] api_outDimTagsMap, out uint[] api_outDimTagsMap_n, out uint api_outDimTagsMap_nn, tag, removeObject.Toint(), removeTool.Toint(), ref ierr);

        //    }//if (ierr != 0) throw new GMshException(ierr);

        //    //outDimTags = ArrayToPairs(api_outDimTags, api_outDimTags_n);

        //    //outDimTagsMap = new List<Dictionary<int, int>>(api_outDimTagsMap_nn.Toint());
        //    //for (int i = 0; i < api_outDimTagsMap_nn; i++)
        //    //{
        //    //    outDimTagsMap[i] = new Dictionary<int, int>(api_outDimTagsMap_n[i].Toint() / 2);
        //    //    var count = api_outDimTagsMap_n[i];
        //    //    int[] apt = new int[count];

        //    //    var ptr = api_outDimTagsMap[i];
        //    //    Marshal.Copy(ptr, apt, 0, Convert.ToInt32(count));

        //    //    for (int j = 0; j < count; j++)
        //    //    {
        //    //        var cen = j * 2;
        //    //        outDimTagsMap[i].Add(apt[cen], apt[cen + 1]);
        //    //    }
        //    //}
        //    outDimTagsMap = new List<Dictionary<int, int>>();
        //    outDimTags = new Dictionary<int, int>();
        //}
    }
}
