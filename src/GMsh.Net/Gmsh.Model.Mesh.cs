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
        public static partial class Model
        {
            /// <summary>
            /// Mesh functions
            /// </summary>
            public static partial class Mesh
            {
                /// <summary>
                /// Generate a mesh of the current model, up to dimension `dim' (0, 1, 2 or 3).
                /// </summary>
                public static void Generate(int dim)
                {
                    Gmsh_Warp.GmshModelMeshGenerate(dim, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Partition the mesh of the current model into numPart partitions. Optionally, elementTags and
                /// partitions can be provided to specify the partition of each element explicitly.
                /// </summary>
                public static void Partition(int numPart, long[] elementTags = default, int[] partitions = default)
                {
                    if (elementTags == default) elementTags = new long[0];
                    if (partitions == default) partitions = new int[0];
                    Gmsh_Warp.GmshModelMeshPartition(numPart, elementTags, elementTags.Length, partitions, partitions.Length, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                ///  Unpartition the mesh of the current model.
                /// </summary>
                public static void Unpartition()
                {
                    Gmsh_Warp.GmshModelMeshUnpartition(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Optimize the mesh of the current model using `method' (empty for default
                /// tetrahedral mesh optimizer, "Netgen" for Netgen optimizer, "HighOrder" for
                /// direct high-order mesh optimizer, "HighOrderElastic" for high-order
                /// elastic smoother, "HighOrderFastCurving" for fast curving algorithm,
                /// "Laplace2D" for Laplace smoothing, "Relocate2D" and "Relocate3D" for node
                /// relocation). If `force' is set apply the optimization also to discrete
                /// entities. If `dimTags' is given, only apply the optimizer to the given
                /// entities.
                /// </summary>
                public static void Optimize(string method, bool force = false, int niter = 1, ValueTuple<int, int>[] dimTags = default)
                {
                    if (dimTags == default) dimTags = new (int, int)[0];
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshOptimize(method, Convert.ToInt32(force), niter, dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Recombine the mesh of the current model.
                /// </summary>
                public static void Recombine()
                {
                    Gmsh_Warp.GmshModelMeshRecombine(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Refine the mesh of the current model by uniformly splitting the elements.
                /// </summary>
                public static void Refine()
                {
                    Gmsh_Warp.GmshModelMeshRecombine(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set the order of the elements in the mesh of the current model to `order'.
                /// </summary>
                public static void SetOrder(int order)
                {
                    Gmsh_Warp.GmshModelMeshSetOrder(order, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the last entities (if any) where a meshing error occurred. Currently
                /// only populated by the new 3D meshing algorithms.
                /// </summary>
                public static ValueTuple<int, int>[] GetLastEntityError()
                {
                    unsafe
                    {
                        int* dimTag_ptr;
                        long dimTag_n = 0;
                        Gmsh_Warp.GmshModelMeshGetLastEntityError(&dimTag_ptr, ref dimTag_n, ref Gmsh._staticreff);
                        var dimTag = UnsafeHelp.ToIntArray(dimTag_ptr, dimTag_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return dimTag.ToIntPair();
                    }
                }

                /// <summary>
                /// Get the last nodes (if any) where a meshing error occurred. Currently only
                /// populated by the new 3D meshing algorithms.
                /// </summary>
                public static long[] GetLastNodeError()
                {
                    unsafe
                    {
                        long* nodeTag_ptr;
                        long nodeTag_n = 0;
                        Gmsh_Warp.GmshModelMeshGetLastNodeError(&nodeTag_ptr, ref nodeTag_n, ref Gmsh._staticreff);
                        var nodeTag = UnsafeHelp.ToLongArray(nodeTag_ptr, nodeTag_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return nodeTag;
                    }
                }

                /// <summary>
                /// Clear the mesh, i.e. delete all the nodes and elements, for the entities
                /// `dimTags'. if `dimTags' is empty, clear the whole mesh. Note that the mesh
                /// of an entity can only be cleared if this entity is not on the boundary of
                /// another entity with a non-empty mesh.
                /// </summary>
                public static void Clear(ValueTuple<int, int>[] dimTags)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshClear(dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the nodes classified on the entity of dimension `dim' and tag `tag'.
                /// If `tag' &lt; 0, get the nodes for all entities of dimension `dim'. If `dim'
                /// and `tag' are negative, get all the nodes in the mesh. `nodeTags' contains
                /// the node tags (their unique, strictly positive identification numbers).
                /// `coord' is a vector of length 3 times the length of `nodeTags' that
                /// contains the x, y, z coordinates of the nodes, concatenated: [n1x, n1y,
                /// n1z, n2x, ...]. If `dim' >= 0 and `returnParamtricCoord' is set,
                /// `parametricCoord' contains the parametric coordinates ([u1, u2, ...] or
                /// [u1, v1, u2, ...]) of the nodes, if available. The length of
                /// `parametricCoord' can be 0 or `dim' times the length of `nodeTags'. If
                /// `includeBoundary' is set, also return the nodes classified on the boundary
                /// of the entity (which will be reparametrized on the entity if `dim' >= 0 in
                /// order to compute their parametric coordinates).
                /// </summary>
                public static void GetNodes(out long[] nodeTags, out double[] coord, out double[] parametricCoord, int dim = -1, int tag = -1, bool includeBoundary = false, bool returnParametricCoord = true)
                {
                    unsafe
                    {
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;
                        double* parametricCoord_ptr;
                        long parametricCoord_n = 0;
                        Gmsh_Warp.GmshModelMeshGetNodes(&nodeTags_ptr, ref nodeTags_n, &coord_ptr, ref coord_n, &parametricCoord_ptr, ref parametricCoord_n, dim, tag, Convert.ToInt32(includeBoundary), Convert.ToInt32(returnParametricCoord), ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        parametricCoord = UnsafeHelp.ToDoubleArray(parametricCoord_ptr, parametricCoord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the nodes classified on the entity of tag `tag', for all the elements
                /// of type `elementType'. The other arguments are treated as in `getNodes'.
                /// </summary>
                public static void GetNodesByElementType(int elementType, out long[] nodeTags, out double[] coord, out double[] parametricCoord, int tag = -1, bool returnParametricCoord = true)
                {
                    unsafe
                    {
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;
                        double* parametricCoord_ptr;
                        long parametricCoord_n = 0;
                        Gmsh_Warp.GmshModelMeshGetNodesByElementType(elementType, &nodeTags_ptr, ref nodeTags_n, &coord_ptr, ref coord_n, &parametricCoord_ptr, ref parametricCoord_n, tag, Convert.ToInt32(returnParametricCoord), ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        parametricCoord = UnsafeHelp.ToDoubleArray(parametricCoord_ptr, parametricCoord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the coordinates and the parametric coordinates (if any) of the node
                /// with tag `tag', as well as the dimension `dim' and tag `tag' of the entity
                /// on which the node is classified. This function relies on an internal cache
                /// (a vector in case of dense node numbering, a map otherwise); for large
                /// meshes accessing nodes in bulk is often preferable.
                /// </summary>
                public static void GetNode(long nodeTag, out double[] coord, out double[] parametricCoord, out int dim, out int tag)
                {
                    unsafe
                    {
                        double* coord_ptr;
                        long coord_n = 0;
                        double* parametricCoord_ptr;
                        long parametricCoord_n = 0;
                        dim = -1;
                        tag = -1;
                        Gmsh_Warp.GmshModelMeshGetNode(nodeTag, &coord_ptr, ref coord_n, &parametricCoord_ptr, ref parametricCoord_n, ref dim, ref tag, ref Gmsh._staticreff);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        parametricCoord = UnsafeHelp.ToDoubleArray(parametricCoord_ptr, parametricCoord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Set the coordinates and the parametric coordinates (if any) of the node
                /// with tag `tag'. This function relies on an internal cache (a vector in
                /// case of dense node numbering, a map otherwise); for large meshes accessing
                /// nodes in bulk is often preferable.
                /// </summary>
                public static void SetNode(long nodeTag, double[] coord, double[] parametricCoord)
                {
                    Gmsh_Warp.GmshModelMeshSetNode(nodeTag, coord, coord.LongLength, parametricCoord, parametricCoord.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Rebuild the node cache.
                /// </summary>
                public static void RebuildNodeCache(bool onlyIfNecessary = true)
                {
                    Gmsh_Warp.GmshModelMeshRebuildNodeCache(Convert.ToInt32(onlyIfNecessary), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Rebuild the element cache.
                /// </summary>
                public static void RebuildElementCache(bool onlyIfNecessary = true)
                {
                    Gmsh_Warp.GmshModelMeshRebuildElementCache(Convert.ToInt32(onlyIfNecessary), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the nodes from all the elements belonging to the physical group of
                /// dimension `dim' and tag `tag'. `nodeTags' contains the node tags; `coord'
                /// is a vector of length 3 times the length of `nodeTags' that contains the
                /// x, y, z coordinates of the nodes, concatenated: [n1x, n1y, n1z, n2x, ...].
                /// </summary>
                public static void GetNodesForPhysicalGroup(int dim, int tag, out long[] nodeTags, out double[] coord)
                {
                    unsafe
                    {
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;
                        Gmsh_Warp.GmshModelMeshGetNodesForPhysicalGroup(dim, tag, &nodeTags_ptr, ref nodeTags_n, &coord_ptr, ref coord_n, ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Add nodes classified on the model entity of dimension `dim' and tag `tag'.
                /// `nodeTags' contains the node tags (their unique, strictly positive
                /// identification numbers). `coord' is a vector of length 3 times the length
                /// of `nodeTags' that contains the x, y, z coordinates of the nodes,
                /// concatenated: [n1x, n1y, n1z, n2x, ...]. The optional `parametricCoord'
                /// vector contains the parametric coordinates of the nodes, if any. The
                /// length of `parametricCoord' can be 0 or `dim' times the length of
                /// `nodeTags'. If the `nodeTags' vector is empty, new tags are automatically
                /// assigned to the nodes.
                /// </summary>
                public static void AddNodes(int dim, int tag, long[] nodeTags, double[] coord, double[] parametricCoord = default)
                {
                    if (parametricCoord == default) parametricCoord = new double[0];
                    Gmsh_Warp.GmshModelMeshAddNodes(dim, tag, nodeTags, nodeTags.LongLength, coord, coord.LongLength, parametricCoord, parametricCoord.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Reclassify all nodes on their associated model entity, based on the
                /// elements. Can be used when importing nodes in bulk (e.g. by associating
                /// them all to a single volume), to reclassify them correctly on model
                /// surfaces, curves, etc. after the elements have been set.
                /// </summary>
                public static void ReclassifyNodes()
                {
                    Gmsh_Warp.GmshModelMeshReclassifyNodes(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Relocate the nodes classified on the entity of dimension `dim' and tag
                /// `tag' using their parametric coordinates. If `tag' &lt; 0, relocate the nodes
                /// for all entities of dimension `dim'. If `dim' and `tag' are negative,
                /// relocate all the nodes in the mesh.
                /// </summary>
                public static void RelocateNodes(int dim = -1, int tag = -1)
                {
                    Gmsh_Warp.GmshModelMeshRelocateNodes(dim, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the elements classified on the entity of dimension `dim' and tag
                /// `tag'. If `tag' &lt; 0, get the elements for all entities of dimension `dim'.
                /// If `dim' and `tag' are negative, get all the elements in the mesh.
                /// `elementTypes' contains the MSH types of the elements (e.g. `2' for 3-node
                /// triangles: see `getElementProperties' to obtain the properties for a given
                /// element type). `elementTags' is a vector of the same length as
                /// `elementTypes'; each entry is a vector containing the tags (unique,
                /// strictly positive identifiers) of the elements of the corresponding type.
                /// `nodeTags' is also a vector of the same length as `elementTypes'; each
                /// entry is a vector of length equal to the number of elements of the given
                /// type times the number N of nodes for this type of element, that contains
                /// the node tags of all the elements of the given type, concatenated: [e1n1,
                /// e1n2, ..., e1nN, e2n1, ...].
                /// </summary>
                public static void GetElements(out int[] elementTypes, out long[][] elementTags, out long[][] nodeTags, int dim = -1, int tag = -1)
                {
                    unsafe
                    {
                        int* elementTypesptr;
                        long elementTypes_n = 0;

                        long** elementTags_ptr;
                        long* elementTags_nptr;
                        long elementTags_nn = 0;

                        long** nodeTags_ptr;
                        long* nodeTags_nptr;
                        long nodeTags_nn = 0;

                        Gmsh_Warp.GmshModelMeshGetElements(&elementTypesptr, ref elementTypes_n, &elementTags_ptr, &elementTags_nptr, ref elementTags_nn, &nodeTags_ptr, &nodeTags_nptr, ref nodeTags_nn, dim, tag, ref Gmsh._staticreff);

                        elementTypes = UnsafeHelp.ToIntArray(elementTypesptr, elementTypes_n);
                        elementTags = UnsafeHelp.ToLongArray(elementTags_ptr, elementTags_nptr, elementTags_nn);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_nptr, nodeTags_nn);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the type and node tags of the element with tag `tag'. This function
                /// relies on an internal cache (a vector in case of dense element numbering,
                /// a map otherwise); for large meshes accessing elements in bulk is often
                /// preferable.
                /// </summary>
                public static void GetElement(long elementTag, out int elementType, out long[] nodeTags, out int dim, out int tag)
                {
                    unsafe
                    {
                        elementType = 0;
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        dim = -1;
                        tag = -1;
                        Gmsh_Warp.GmshModelMeshGetElement(elementTag, ref elementType, &nodeTags_ptr, ref nodeTags_n, ref dim, ref tag, ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Search the mesh for an element located at coordinates (`x', `y', `z').
                /// This function performs a search in a spatial octree. If an element is
                /// found, return its tag, type and node tags, as well as the local
                /// coordinates (`u', `v', `w') within the reference element corresponding to
                /// search location. If `dim' is >= 0, only search for elements of the given
                /// dimension. If `strict' is not set, use a tolerance to find elements near
                /// the search location.
                /// </summary>
                public static void GetElementByCoordinates(double x, double y, double z, out long elementTag, out int elementType, out long[] nodeTags, out double u, out double v, out double w, int dim = -1, bool strict = false)
                {
                    unsafe
                    {
                        elementTag = 0;
                        elementType = 0;
                        u = 0; v = 0; w = 0;
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        Gmsh_Warp.GmshModelMeshGetElementByCoordinates(x, y, z, ref elementTag, ref elementType, &nodeTags_ptr, ref nodeTags_n, ref u, ref v, ref w, dim, Convert.ToInt32(strict), ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Search the mesh for element(s) located at coordinates (`x', `y', `z').
                /// This function performs a search in a spatial octree. Return the tags of
                /// all found elements in `elementTags'. Additional information about the
                /// elements can be accessed through `getElement' and
                /// `getLocalCoordinatesInElement'. If `dim' is >= 0, only search for elements
                /// of the given dimension. If `strict' is not set, use a tolerance to find
                /// elements near the search location.
                /// </summary>
                public static void GetElementsByCoordinates(double x, double y, double z, out long[] elementTags, int dim = -1, bool strict = false)
                {
                    unsafe
                    {
                        long* elementTags_ptr;
                        long elementTags_n = 0;
                        Gmsh_Warp.GmshModelMeshGetElementsByCoordinates(x, y, z, &elementTags_ptr, ref elementTags_n, dim, Convert.ToInt32(strict), ref Gmsh._staticreff);
                        elementTags = UnsafeHelp.ToLongArray(elementTags_ptr, elementTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Return the local coordinates (`u', `v', `w') within the element
                /// `elementTag' corresponding to the model coordinates (`x', `y', `z'). This
                /// function relies on an internal cache (a vector in case of dense element
                /// numbering, a map otherwise); for large meshes accessing elements in bulk
                /// is often preferable.
                /// </summary>
                public static void GetLocalCoordinatesInElement(long elementTag, double x, double y, double z, out double u, out double v, out double w)
                {
                    u = 0; v = 0; w = 0;
                    Gmsh_Warp.GmshModelMeshGetLocalCoordinatesInElement(elementTag, x, y, z, ref u, ref v, ref w, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the types of elements in the entity of dimension `dim' and tag `tag'.
                /// If `tag' &lt; 0, get the types for all entities of dimension `dim'. If `dim'
                /// and `tag' are negative, get all the types in the mesh.
                /// </summary>
                public static int[] GetElementTypes(int dim = -1, int tag = -1)
                {
                    unsafe
                    {
                        int* elementTypes_ptr;
                        long elementTypes_n = 0;
                        Gmsh_Warp.GmshModelMeshGetElementTypes(&elementTypes_ptr, ref elementTypes_n, dim, tag, ref Gmsh._staticreff);
                        var elementTypes = UnsafeHelp.ToIntArray(elementTypes_ptr, elementTypes_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return elementTypes;
                    }
                }

                /// <summary>
                /// Return an element type given its family name `familyName' ("Point",
                /// "Line", "Triangle", "Quadrangle", "Tetrahedron", "Pyramid", "Prism",
                /// "Hexahedron") and polynomial order `order'. If `serendip' is true, return
                /// the corresponding serendip element type (element without interior nodes).
                /// </summary>
                public static int GetElementType(string familyname, int order = -1, bool serendip = false)
                {
                    var index = Gmsh_Warp.GmshModelMeshGetElementType(familyname, order, Convert.ToInt32(serendip), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Get the properties of an element of type `elementType': its name
                /// (`elementName'), dimension (`dim'), order (`order'), number of nodes
                /// (`numNodes'), local coordinates of the nodes in the reference element
                /// (`localNodeCoord' vector, of length `dim' times `numNodes') and number of
                /// primary (first order) nodes (`numPrimaryNodes').
                /// </summary>
                public static void GetElementProperties(int elementType, out string elementName, out int dim, out int order, out int numNodes, out double[] localNodeCoord, out int numPrimaryNodes)
                {
                    unsafe
                    {
                        byte* elementNameptr;
                        double* localNodeCoordptr;
                        long localNodeCoord_n = 0;
                        dim = 0; order = 0; numNodes = 0; numPrimaryNodes = 0;
                        Gmsh_Warp.GmshModelMeshGetElementProperties(elementType, &elementNameptr, ref dim, ref order, ref numNodes, &localNodeCoordptr, ref localNodeCoord_n, ref numPrimaryNodes, ref Gmsh._staticreff);
                        elementName = UnsafeHelp.ToString(elementNameptr);
                        localNodeCoord = UnsafeHelp.ToDoubleArray(localNodeCoordptr, localNodeCoord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the elements of type `elementType' classified on the entity of tag
                /// `tag'. If `tag' &lt; 0, get the elements for all entities. `elementTags' is a
                /// vector containing the tags (unique, strictly positive identifiers) of the
                /// elements of the corresponding type. `nodeTags' is a vector of length equal
                /// to the number of elements of the given type times the number N of nodes
                /// for this type of element, that contains the node tags of all the elements
                /// of the given type, concatenated: [e1n1, e1n2, ..., e1nN, e2n1, ...]. If
                /// `numTasks' > 1, only compute and return the part of the data indexed by
                /// `task'.
                /// </summary>
                public static void GetElementsByType(int elementType, out long[] elementTags, out long[] nodeTags, int tag = -1, long task = 0, long numTasks = 1)
                {
                    unsafe
                    {
                        long* elementTags_ptr;
                        long elementTags_n = 0;
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;

                        Gmsh_Warp.GmshModelMeshGetElementsByType(elementType, &elementTags_ptr, ref elementTags_n, &nodeTags_ptr, ref nodeTags_n, tag, task, numTasks, ref Gmsh._staticreff);
                        elementTags = UnsafeHelp.ToLongArray(elementTags_ptr, elementTags_n);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Preallocate data before calling `getElementsByType' with `numTasks' > 1.
                /// For C and C++ only.
                /// </summary>
                public static void PreallocateElementsByType(int elementType, bool elementTag, bool nodeTag, out long[] elementTags, out long[] nodeTags, int tag = -1)
                {
                    unsafe
                    {
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        long* elementTags_ptr;
                        long elementTags_n = 0;
                        Gmsh_Warp.GmshModelMeshPreallocateElementsByType(elementType, Convert.ToInt32(elementTag), Convert.ToInt32(nodeTag),
                            &elementTags_ptr, ref elementTags_n, &nodeTags_ptr, ref nodeTags_n, tag, ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        elementTags = UnsafeHelp.ToLongArray(elementTags_ptr, elementTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Add elements classified on the entity of dimension `dim' and tag `tag'.
                /// `types' contains the MSH types of the elements (e.g. `2' for 3-node
                /// triangles: see the Gmsh reference manual). `elementTags' is a vector of
                /// the same length as `types'; each entry is a vector containing the tags
                /// (unique, strictly positive identifiers) of the elements of the
                /// corresponding type. `nodeTags' is also a vector of the same length as
                /// `types'; each entry is a vector of length equal to the number of elements
                /// of the given type times the number N of nodes per element, that contains
                /// the node tags of all the elements of the given type, concatenated: [e1n1,
                /// e1n2, ..., e1nN, e2n1, ...].
                /// </summary>
                public static void AddElements(int dim, int tag, int[] elementTypes, long[][] elementTags, long[][] nodeTags)
                {
                    unsafe
                    {
                        var eptr = (long*)Marshal.UnsafeAddrOfPinnedArrayElement(elementTags, 0).ToPointer();
                        var nptr = (long*)Marshal.UnsafeAddrOfPinnedArrayElement(nodeTags, 0).ToPointer();
                        Gmsh_Warp.GmshModelMeshAddElements(dim, tag, elementTypes, elementTypes.LongLength,
                            &eptr, elementTags.Select(e => e.LongLength).ToArray(), elementTags.LongLength,
                            &nptr, nodeTags.Select(e => e.LongLength).ToArray(), nodeTags.LongLength,
                            ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Add elements of type `elementType' classified on the entity of tag `tag'.
                /// `elementTags' contains the tags (unique, strictly positive identifiers) of
                /// the elements of the corresponding type. `nodeTags' is a vector of length
                /// equal to the number of elements times the number N of nodes per element,
                /// that contains the node tags of all the elements, concatenated: [e1n1,
                /// e1n2, ..., e1nN, e2n1, ...]. If the `elementTag' vector is empty, new tags
                /// are automatically assigned to the elements.
                /// </summary>
                public static void AddElementsByType(int tag, int elementType, long[] elementTags, long[] nodeTags)
                {
                    Gmsh_Warp.GmshModelMeshAddElementsByType(tag, elementType, elementTags, elementTags.LongLength, nodeTags, nodeTags.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the numerical quadrature information for the given element type
                /// `elementType' and integration rule `integrationType' (e.g. "Gauss4" for a
                /// Gauss quadrature suited for integrating 4th order polynomials).
                /// `localCoord' contains the u, v, w coordinates of the G integration points
                /// in the reference element: [g1u, g1v, g1w, ..., gGu, gGv, gGw]. `weights'
                /// contains the associated weights: [g1q, ..., gGq].
                /// </summary>
                public static void GetIntegrationPoints(int elementType, string integrationType, out double[] localCoord, out double[] weights)
                {
                    unsafe
                    {
                        double* localCoord_ptr;
                        long localCoord_n = 0;
                        double* weights_ptr;
                        long weights_n = 0;

                        Gmsh_Warp.GmshModelMeshGetIntegrationPoints(elementType, integrationType, &localCoord_ptr, ref localCoord_n, &weights_ptr, ref weights_n, ref Gmsh._staticreff);

                        localCoord = UnsafeHelp.ToDoubleArray(localCoord_ptr, localCoord_n);
                        weights = UnsafeHelp.ToDoubleArray(weights_ptr, weights_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the Jacobians of all the elements of type `elementType' classified on
                /// the entity of tag `tag', at the G evaluation points `localCoord' given as
                /// concatenated triplets of coordinates in the reference element [g1u, g1v,
                /// g1w, ..., gGu, gGv, gGw]. Data is returned by element, with elements in
                /// the same order as in `getElements' and `getElementsByType'. `jacobians'
                /// contains for each element the 9 entries of the 3x3 Jacobian matrix at each
                /// evaluation point. The matrix is returned by column: [e1g1Jxu, e1g1Jyu,
                /// e1g1Jzu, e1g1Jxv, ..., e1g1Jzw, e1g2Jxu, ..., e1gGJzw, e2g1Jxu, ...], with
                /// Jxu=dx/du, Jyu=dy/du, etc. `determinants' contains for each element the
                /// determinant of the Jacobian matrix at each evaluation point: [e1g1, e1g2,
                /// ... e1gG, e2g1, ...]. `coord' contains for each element the x, y, z
                /// coordinates of the evaluation points. If `tag' &lt; 0, get the Jacobian data
                /// for all entities. If `numTasks' > 1, only compute and return the part of
                /// the data indexed by `task'.
                /// </summary>
                public static void GetJacobians(int elementType, double[] localCoord, out double[] jacobians, out double[] determinants, out double[] coord, int tag = -1, long task = 0, long numTasks = 1)
                {
                    unsafe
                    {
                        double* jacobians_ptr;
                        long jacobians_n = 0;
                        double* determinants_ptr;
                        long determinants_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;

                        Gmsh_Warp.GmshModelMeshGetJacobians(elementType, localCoord, localCoord.LongLength,
                            &jacobians_ptr, ref jacobians_n, &determinants_ptr, ref determinants_n, &coord_ptr, ref coord_n,
                            tag, task, numTasks,
                            ref Gmsh._staticreff);

                        jacobians = UnsafeHelp.ToDoubleArray(jacobians_ptr, jacobians_n);
                        determinants = UnsafeHelp.ToDoubleArray(determinants_ptr, determinants_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Preallocate data before calling `getJacobians' with `numTasks' > 1. For C and C++ only.
                /// </summary>
                public static void PreallocateJacobians(int elementType, int numEvaluationPoints, bool allocateJacobians, bool allocateDeterminants, bool allocateCoord, out double[] jacobians, out double[] determinants, out double[] coord, int tag = -1)
                {
                    unsafe
                    {
                        double* jacobians_ptr;
                        long jacobians_n = 0;
                        double* determinants_ptr;
                        long determinants_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;

                        Gmsh_Warp.GmshModelMeshPreallocateJacobians(elementType, numEvaluationPoints, Convert.ToInt32(allocateJacobians), Convert.ToInt32(allocateDeterminants), Convert.ToInt32(allocateCoord),
                            &jacobians_ptr, ref jacobians_n, &determinants_ptr, ref determinants_n, &coord_ptr, ref coord_n,
                            tag, ref Gmsh._staticreff);

                        jacobians = UnsafeHelp.ToDoubleArray(jacobians_ptr, jacobians_n);
                        determinants = UnsafeHelp.ToDoubleArray(determinants_ptr, determinants_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the Jacobian for a single element `elementTag', at the G evaluation
                /// points `localCoord' given as concatenated triplets of coordinates in the
                /// reference element [g1u, g1v, g1w, ..., gGu, gGv, gGw]. `jacobians'
                /// contains the 9 entries of the 3x3 Jacobian matrix at each evaluation
                /// point. The matrix is returned by column: [e1g1Jxu, e1g1Jyu, e1g1Jzu,
                /// e1g1Jxv, ..., e1g1Jzw, e1g2Jxu, ..., e1gGJzw, e2g1Jxu, ...], with
                /// Jxu=dx/du, Jyu=dy/du, etc. `determinants' contains the determinant of the
                /// Jacobian matrix at each evaluation point. `coord' contains the x, y, z
                /// coordinates of the evaluation points. This function relies on an internal
                /// cache (a vector in case of dense element numbering, a map otherwise); for
                /// large meshes accessing Jacobians in bulk is often preferable.
                /// </summary>
                public static void GetJacobian(long elementTag, double[] localCoord, out double[] jacobians, out double[] determinants, out double[] coord)
                {
                    unsafe
                    {
                        double* jacobians_ptr;
                        long jacobians_n = 0;
                        double* determinants_ptr;
                        long determinants_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;

                        Gmsh_Warp.GmshModelMeshGetJacobian(elementTag, localCoord, localCoord.LongLength,
                            &jacobians_ptr, ref jacobians_n, &determinants_ptr, ref determinants_n, &coord_ptr, ref coord_n,
                            ref Gmsh._staticreff);

                        jacobians = UnsafeHelp.ToDoubleArray(jacobians_ptr, jacobians_n);
                        determinants = UnsafeHelp.ToDoubleArray(determinants_ptr, determinants_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the basis functions of the element of type `elementType' at the
                /// evaluation points `localCoord' (given as concatenated triplets of
                /// coordinates in the reference element [g1u, g1v, g1w, ..., gGu, gGv, gGw]),
                /// for the function space `functionSpaceType' (e.g. "Lagrange" or
                /// "GradLagrange" for Lagrange basis functions or their gradient, in the u,
                /// v, w coordinates of the reference element; or "H1Legendre3" or
                /// "GradH1Legendre3" for 3rd order hierarchical H1 Legendre functions).
                /// `numComponents' returns the number C of components of a basis function.
                /// `basisFunctions' returns the value of the N basis functions at the
                /// evaluation points, i.e. [g1f1, g1f2, ..., g1fN, g2f1, ...] when C == 1 or
                /// [g1f1u, g1f1v, g1f1w, g1f2u, ..., g1fNw, g2f1u, ...] when C == 3. For
                /// basis functions that depend on the orientation of the elements, all values
                /// for the first orientation are returned first, followed by values for the
                /// second, etc. `numOrientations' returns the overall number of orientations.
                /// If `wantedOrientations' is not empty, only return the values for the
                /// desired orientation indices.
                /// </summary>
                public static void GetBasisFunctions(int elementType, double[] localCoord, string functionSpaceType, out int numComponents, out double[] basisFunctions, out int numOrientations, int[] wantedOrientations = default)
                {
                    unsafe
                    {
                        double* basisFunctions_ptr;
                        long basisFunctions_n = 0;
                        numComponents = 0;
                        numOrientations = 0;
                        if (wantedOrientations == default) wantedOrientations = new int[0];
                        Gmsh_Warp.GmshModelMeshGetBasisFunctions(elementType, localCoord, localCoord.LongLength,
                            functionSpaceType, ref numComponents, &basisFunctions_ptr, ref basisFunctions_n, ref numOrientations,
                            wantedOrientations, wantedOrientations.LongLength,
                            ref Gmsh._staticreff);

                        basisFunctions = UnsafeHelp.ToDoubleArray(basisFunctions_ptr, basisFunctions_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the orientation index of the elements of type `elementType' in the
                /// entity of tag `tag'. The arguments have the same meaning as in
                /// `getBasisFunctions'. `basisFunctionsOrientation' is a vector giving for
                /// each element the orientation index in the values returned by
                /// `getBasisFunctions'. For Lagrange basis functions the call is superfluous
                /// as it will return a vector of zeros.
                /// </summary>
                public static void GetBasisFunctionsOrientation(int elementType, string functionSpaceType, out int[] basisFunctionsOrientation, int tag = -1, long task = 0, long numTasks = 1)
                {
                    unsafe
                    {
                        int* basisFunctionsOrientation_ptr;
                        long basisFunctionsOrientation_n = 0;

                        Gmsh_Warp.GmshModelMeshGetBasisFunctionsOrientation(elementType, functionSpaceType, &basisFunctionsOrientation_ptr, ref basisFunctionsOrientation_n,
                            tag, task, numTasks,
                            ref Gmsh._staticreff);

                        basisFunctionsOrientation = UnsafeHelp.ToIntArray(basisFunctionsOrientation_ptr, basisFunctionsOrientation_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the orientation of a single element `elementTag'.
                /// </summary>
                public static int GetBasisFunctionsOrientationForElement(long elementTag, string functionSpaceType)
                {
                    int basisFunctionsOrientation = 0;
                    Gmsh_Warp.GmshModelMeshGetBasisFunctionsOrientationForElement(elementTag, functionSpaceType, ref basisFunctionsOrientation,
                        ref Gmsh._staticreff);

                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return basisFunctionsOrientation;
                }

                /// <summary>
                /// Get the number of possible orientations for elements of type `elementType'
                /// and function space named `functionSpaceType'.
                /// </summary>
                public static int GetNumberOfOrientations(int elementType, string functionSpaceType)
                {
                    var index = Gmsh_Warp.GmshModelMeshGetNumberOfOrientations(elementType, functionSpaceType, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Preallocate data before calling `getBasisFunctionsOrientation' with `numTasks' > 1. For C and C++ only.
                /// </summary>
                public static int[] PreallocateBasisFunctionsOrientationForElements(int elementType, int tag = -1)
                {
                    unsafe
                    {
                        int* basisFunctionsOrientation_ptr;
                        long basisFunctionsOrientation_n = 0;
                        Gmsh_Warp.GmshModelMeshPreallocateBasisFunctionsOrientation(elementType,
                             &basisFunctionsOrientation_ptr, ref basisFunctionsOrientation_n, tag, ref Gmsh._staticreff);
                        var basisFunctionsOrientation = UnsafeHelp.ToIntArray(basisFunctionsOrientation_ptr, basisFunctionsOrientation_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return basisFunctionsOrientation;
                    }
                }

                /// <summary>
                /// Get the global unique mesh edge identifiers edgeTags and orientations edgeOrientation 
                /// for an input list of node tag pairs defining these edges, concatenated in the vector nodeTags.
                /// </summary>
                public static int[] GetEdges(int[] edgeNodes)
                {
                    unsafe
                    {
                        int* edgeNum_ptr;
                        long edgeNum_n = 0;

                        Gmsh_Warp.GmshModelMeshGetEdges(edgeNodes, edgeNodes.LongLength, &edgeNum_ptr, ref edgeNum_n, ref Gmsh._staticreff);

                        var edgeNum = UnsafeHelp.ToIntArray(edgeNum_ptr, edgeNum_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return edgeNum;
                    }
                }

                /// <summary>
                /// Get the global unique mesh face identifiers `faceTags' and orientations
                /// `faceOrientations' for an input list of node tag triplets (if `faceType'
                /// == 3) or quadruplets (if `faceType' == 4) defining these faces,
                /// concatenated in the vector `nodeTags'. Mesh faces are created e.g. by
                /// `createFaces()', `getKeys()' or `addFaces()'.
                /// </summary>
                public static void GetFaces(int faceType, int[] nodeTags, out int[] faceTags, out int[] faceOrientations)
                {
                    unsafe
                    {
                        int* faceTags_ptr;
                        long faceTags_n = 0;
                        int* faceOrientations_ptr;
                        long faceOrientations_n = 0;

                        Gmsh_Warp.GmshModelMeshGetGetFaces(faceType, nodeTags, nodeTags.LongLength, &faceTags_ptr, ref faceTags_n, &faceOrientations_ptr, ref faceOrientations_n, ref Gmsh._staticreff);

                        faceTags = UnsafeHelp.ToIntArray(faceTags_ptr, faceTags_n);
                        faceOrientations = UnsafeHelp.ToIntArray(faceOrientations_ptr, faceOrientations_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the global unique mesh edge identifiers `edgeTags' and orientations
                /// `edgeOrientation' for an input list of node tag pairs defining these
                /// edges, concatenated in the vector `nodeTags'. Mesh edges are created e.g.
                /// by `createEdges()', `getKeys()' or `addEdges()'. The reference positive
                /// orientation is n1 < n2, where n1 and n2 are the tags of the two edge
                /// nodes, which corresponds to the local orientation of edge-based basis
                /// functions as well.
                /// </summary>
                public static void CreateEdges(ValueTuple<int, int>[] dimTags = default)
				{
                    if (dimTags == default) dimTags = new (int, int)[0];
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshCreateEdges(dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the global unique mesh face identifiers `faceTags' and orientations
                /// `faceOrientations' for an input list of node tag triplets (if `faceType'
                /// == 3) or quadruplets (if `faceType' == 4) defining these faces,
                /// concatenated in the vector `nodeTags'. Mesh faces are created e.g. by
                /// `createFaces()', `getKeys()' or `addFaces()'.
                /// </summary>
                public static void CreateFaces(ValueTuple<int, int>[] dimTags = default)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshCreateFaces(dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// // Remove all meshing constraints from the model entities `dimTags'. If
                /// `dimTags' is empty, remove all constraings.
                /// </summary>
                public static void RemoveConstraints(ValueTuple<int, int>[] dimTags = default)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshRemoveConstraints(dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                ///  Get the entities (if any) embedded in the model entity of dimension `dim'
                /// and tag `tag'.
                /// </summary>
                public static ValueTuple<int, int>[] GetEmbedded(int dim, int tag)
                {
                    unsafe
                    {
                        int* ptrss;
                        long outcount = 0;
                        Gmsh_Warp.GmshModelMeshGetEmbedded(dim, tag, &ptrss, ref outcount, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return UnsafeHelp.ToIntArray(ptrss, outcount).ToIntPair();
                    }
                }

                /// <summary>
                /// Generate the `keys' for the elements of type `elementType' in the entity
                /// of tag `tag', for the `functionSpaceType' function space. Each key
                /// uniquely identifies a basis function in the function space. If
                /// `returnCoord' is set, the `coord' vector contains the x, y, z coordinates
                /// locating basis functions for sorting purposes. Warning: this is an
                /// experimental feature and will probably change in a future release.
                /// </summary>
                public static void GetKeys(int elementType, string functionSpaceType, out ValueTuple<int, int>[] keys, out double[] coord, int tag = -1, bool returnCoord = true)
                {
                    unsafe
                    {
                        int* keys_ptr;
                        long keys_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;
                        Gmsh_Warp.GmshModelMeshGetKeys(elementType, functionSpaceType,
                             &keys_ptr, ref keys_n, &coord_ptr, ref coord_n, tag, Convert.ToInt32(returnCoord), ref Gmsh._staticreff);
                        keys = UnsafeHelp.ToIntArray(keys_ptr, keys_n).ToIntPair();
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the keys for a single element `elementTag'.
                /// </summary>
                public static void GetKeysForElement(long elementTag, string functionSpaceType, out int[] typeKeys, out long[] entityKeys, out double[] coord, bool returnCoord = true)
                {
                    unsafe
                    {
                        int* typeKeys_ptr;
                        long typeKeys_n = 0;
                        long* entityKeys_ptr;
                        long entityKeys_n = 0;
                        double* coord_ptr;
                        long coord_n = 0;
                        Gmsh_Warp.GmshModelMeshGetKeysForElement(elementTag, functionSpaceType,
                             &typeKeys_ptr, ref typeKeys_n, &entityKeys_ptr, ref entityKeys_n, &coord_ptr, ref coord_n, Convert.ToInt32(returnCoord), ref Gmsh._staticreff);
                        typeKeys = UnsafeHelp.ToIntArray(typeKeys_ptr, typeKeys_n);
                        entityKeys = UnsafeHelp.ToLongArray(entityKeys_ptr, entityKeys_n);
                        coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Get the number of keys by elements of type `elementType' for function
                /// space named `functionSpaceType'.
                /// </summary>
                public static int GetNumberOfKeys(int elementType, string functionSpaceType)
                {
                    var index = Gmsh_Warp.GmshModelMeshGetNumberOfKeys(elementType, functionSpaceType, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }

                /// <summary>
                /// Get information about the `keys'. `infoKeys' returns information about the
                /// functions associated with the `keys'. `infoKeys[0].first' describes the
                /// type of function (0 for  vertex function, 1 for edge function, 2 for face
                /// function and 3 for bubble function). `infoKeys[0].second' gives the order
                /// of the function associated with the key. Warning: this is an experimental
                /// feature and will probably change in a future release.
                /// </summary>
                public static ValueTuple<int, int>[] GetKeysInformation(ValueTuple<int, int>[] keys, int elementType, string functionSpaceType)
                {
                    unsafe
                    {
                        int* infokeys_ptr;
                        long infokeys_n = 0;
                        var key_array = keys.ToIntArray();
                        Gmsh_Warp.GmshModelMeshGetKeysInformation(key_array, key_array.LongLength, elementType, functionSpaceType,
                             &infokeys_ptr, ref infokeys_n, ref Gmsh._staticreff);
                        var infoKeys = UnsafeHelp.ToIntArray(infokeys_ptr, infokeys_n).ToIntPair();

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return infoKeys;
                    }
                }

                /// <summary>
                /// Get the barycenters of all elements of type `elementType' classified on
                /// the entity of tag `tag'. If `primary' is set, only the primary nodes of
                /// the elements are taken into account for the barycenter calculation. If
                /// `fast' is set, the function returns the sum of the primary node
                /// coordinates (without normalizing by the number of nodes). If `tag' &lt; 0,
                /// get the barycenters for all entities. If `numTasks' > 1, only compute and
                /// return the part of the data indexed by `task'.
                /// </summary>
                public static double[] GetBarycenters(int elementType, int tag, bool fast, bool primary, long task = 0, long numTasks = 1)
                {
                    unsafe
                    {
                        double* barycenters_ptr;
                        long barycenters_n = 0;

                        Gmsh_Warp.GmshModelMeshGetBarycenters(elementType, tag, Convert.ToInt32(fast), Convert.ToInt32(primary),
                            &barycenters_ptr, ref barycenters_n, task, numTasks, ref Gmsh._staticreff);

                        var barycenters = UnsafeHelp.ToDoubleArray(barycenters_ptr, barycenters_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return barycenters;
                    }
                }

                /// <summary>
                /// Preallocate data before calling `getBarycenters' with `numTasks' > 1. For C and C++ only.
                /// </summary>
                public static double[] PreallocateBarycenters(int elementType, int tag = -1)
                {
                    unsafe
                    {
                        double* barycenters_ptr;
                        long barycenters_n = 0;

                        Gmsh_Warp.GmshModelMeshPreallocateBarycenters(elementType,
                            &barycenters_ptr, ref barycenters_n, tag, ref Gmsh._staticreff);

                        var barycenters = UnsafeHelp.ToDoubleArray(barycenters_ptr, barycenters_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return barycenters;
                    }
                }

                /// <summary>
                /// Get the nodes on the edges of all elements of type `elementType'
                /// classified on the entity of tag `tag'. `nodeTags' contains the node tags
                /// of the edges for all the elements: [e1a1n1, e1a1n2, e1a2n1, ...]. Data is
                /// returned by element, with elements in the same order as in `getElements'
                /// and `getElementsByType'. If `primary' is set, only the primary (begin/end)
                /// nodes of the edges are returned. If `tag' &lt; 0, get the edge nodes for all
                /// entities. If `numTasks' > 1, only compute and return the part of the data
                /// indexed by `task'
                /// </summary>

                public static long[] GetElementEdgeNodes(int elementType, int tag = -1, bool primary = false, long task = 0, long numTasks = 1)
                {
                    unsafe
                    {
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;

                        Gmsh_Warp.GmshModelMeshGetElementEdgeNodes(elementType,
                            &nodeTags_ptr, ref nodeTags_n, tag, Convert.ToInt32(primary), task, numTasks, ref Gmsh._staticreff);

                        var nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return nodeTags;
                    }
                }

                /// <summary>
                /// Get the nodes on the faces of type `faceType' (3 for triangular faces, 4
                /// for quadrangular faces) of all elements of type `elementType' classified
                /// on the entity of tag `tag'. `nodeTags' contains the node tags of the faces
                /// for all elements: [e1f1n1, ..., e1f1nFaceType, e1f2n1, ...]. Data is
                /// returned by element, with elements in the same order as in `getElements'
                /// and `getElementsByType'. If `primary' is set, only the primary (corner)
                /// nodes of the faces are returned. If `tag' &lt; 0, get the face nodes for all
                /// entities. If `numTasks' > 1, only compute and return the part of the data
                /// indexed by `task'.
                /// </summary>
                public static long[] GetElementFaceNodes(int elementType, int faceType, int tag = -1, bool primary = false, long task = 0, long numTasks = 1)
                {
                    unsafe
                    {
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;

                        Gmsh_Warp.GmshModelMeshGetElementFaceNodes(elementType, faceType,
                            &nodeTags_ptr, ref nodeTags_n, tag, Convert.ToInt32(primary), task, numTasks, ref Gmsh._staticreff);

                        var nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return nodeTags;
                    }
                }

                /// <summary>
                /// Get the ghost elements `elementTags' and their associated `partitions'
                /// stored in the ghost entity of dimension `dim' and tag `tag'.
                /// </summary>
                public static void GetGhostElements(int dim, int tag, out long[] elementTags, out int[] partitions)
                {
                    unsafe
                    {
                        long* elementTags_ptr;
                        long elementTags_n = 0;
                        int* partitions_ptr;
                        long partitions_n = 0;

                        Gmsh_Warp.GmshModelMeshGetGhostElements(dim, tag,
                            &elementTags_ptr, ref elementTags_n, &partitions_ptr, ref partitions_n, ref Gmsh._staticreff);

                        elementTags = UnsafeHelp.ToLongArray(elementTags_ptr, elementTags_n);
                        partitions = UnsafeHelp.ToIntArray(partitions_ptr, partitions_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Set a mesh size constraint on the model entities `dimTags'. Currently only
                /// entities of dimension 0 (points) are handled.
                /// </summary>
                public static void SetSize(ValueTuple<int, int>[] dimTags, double size)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshSetSize(dimTags_array, dimTags_array.LongLength, size, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set mesh size constraints at the given parametric points `parametricCoord'
                /// on the model entity of dimension `dim' and tag `tag'. Currently only
                /// entities of dimension 1 (lines) are handled.
                /// </summary>
                public static void SetSizeAtParametricPoints(int dim, int tag, double[] parametricCoord, double[] sizes)
                {
                    Gmsh_Warp.GmshModelMeshSetSizeAtParametricPoints(dim, tag, parametricCoord, parametricCoord.LongLength, sizes, sizes.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set a transfinite meshing constraint on the curve `tag', with `numNodes'
                /// nodes distributed according to `meshType' and `coef'. Currently supported
                /// types are "Progression" (geometrical progression with power `coef') and
                /// "Bump" (refinement toward both extremities of the curve).
                /// </summary>
                public static void SetTransfiniteCurve(int tag, int numNodes, string meshType = "Progression", double coef = 1)
                {
                    Gmsh_Warp.GmshModelMeshSetTransfiniteCurve(tag, numNodes, meshType, coef, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set a transfinite meshing constraint on the surface `tag'. `arrangement'
                /// describes the arrangement of the triangles when the surface is not flagged
                /// as recombined: currently supported values are "Left", "Right",
                /// "AlternateLeft" and "AlternateRight". `cornerTags' can be used to specify
                /// the (3 or 4) corners of the transfinite interpolation explicitly;
                /// specifying the corners explicitly is mandatory if the surface has more
                /// that 3 or 4 points on its boundary.
                /// </summary>
                public static void SetTransfiniteSurface(int tag, string arrangement = "Left", int[] cornerTags = default)
                {
                    if (cornerTags == default) cornerTags = new int[0];
                    Gmsh_Warp.GmshModelMeshSetTransfiniteSurface(tag, arrangement, cornerTags, cornerTags.LongLength, ref Gmsh._staticreff);
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
                    Gmsh_Warp.GmshModelMeshSetTransfiniteVolume(tag, cornerTags, cornerTags.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set a recombination meshing constraint on the model entity of dimension
                /// `dim' and tag `tag'. Currently only entities of dimension 2 (to recombine
                /// triangles into quadrangles) are supported.
                /// </summary>
                public static void SetRecombine(int dim, int tag)
                {
                    Gmsh_Warp.GmshModelMeshSetRecombine(dim, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set a smoothing meshing constraint on the model entity of dimension `dim'
                /// and tag `tag'. `val' iterations of a Laplace smoother are applied.
                /// </summary>
                public static void SetSmoothing(int dim, int tag, int val)
                {
                    Gmsh_Warp.GmshModelMeshSetSmoothing(dim, tag, val, ref Gmsh._staticreff);
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
                    Gmsh_Warp.GmshModelMeshSetReverse(dim, tag, Convert.ToInt32(val), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set the meshing algorithm on the model entity of dimension `dim' and tag
                /// `tag'. Currently only supported for `dim' == 2.
                /// </summary>
                public static void SetAlgorithm(int dim, int tag, int val)
                {
                    Gmsh_Warp.GmshModelMeshSetAlgorithm(dim, tag, val, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Force the mesh size to be extended from the boundary, or not, for the
                /// model entity of dimension `dim' and tag `tag'. Currently only supported
                /// for `dim' == 2.
                /// </summary>
                public static void SetSizeFromBoundary(int dim, int tag, int val)
                {
                    Gmsh_Warp.GmshModelMeshSetSizeFromBoundary(dim, tag, val, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set a compound meshing constraint on the model entities of dimension `dim'
                /// and tags `tags'. During meshing, compound entities are treated as a single
                /// discrete entity, which is automatically reparametrized.
                /// </summary>
                public static void SetCompound(int dim, int[] tags)
                {
                    Gmsh_Warp.GmshModelMeshSetCompound(dim, tags, tags.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set meshing constraints on the bounding surfaces of the volume of tag
                /// `tag' so that all surfaces are oriented with outward pointing normals.
                /// Currently only available with the OpenCASCADE kernel, as it relies on the
                /// STL triangulation.
                /// </summary>
                public static void SetOutwardOrientation(int tag)
                {
                    Gmsh_Warp.GmshModelMeshSetOutwardOrientation(tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Embed the model entities of dimension `dim' and tags `tags' in the
                /// (`inDim', `inTag') model entity. The dimension `dim' can 0, 1 or 2 and
                /// must be strictly smaller than `inDim', which must be either 2 or 3. The
                /// embedded entities should not be part of the boundary of the entity
                /// `inTag', whose mesh will conform to the mesh of the embedded entities.
                /// </summary>
                public static void Embed(int dim, int[] tags, int inDim, int inTag)
                {
                    Gmsh_Warp.GmshModelMeshEmbed(dim, tags, tags.LongLength, inDim, inTag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Remove embedded entities from the model entities `dimTags'. if `dim' is >=
                /// 0, only remove embedded entities of the given dimension (e.g. embedded
                /// points if `dim' == 0).
                /// </summary>
                public static void RemoveEmbedded(ValueTuple<int, int>[] dimTags, int dim = -1)
                {
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshRemoveEmbedded(dimTags_array, dimTags_array.LongLength, dim, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Reorder the elements of type `elementType' classified on the entity of tag
                /// `tag' according to `ordering'.
                /// </summary>
                public static void ReorderElements(int elementType, int tag, long[] ordering)
                {
                    Gmsh_Warp.GmshModelMeshReorderElements(elementType, tag, ordering, ordering.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Renumber the node tags in a continuous sequence.
                /// </summary>
                public static void RenumberNodes()
                {
                    Gmsh_Warp.GmshModelMeshRenumberNodes(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Renumber the element tags in a continuous sequence.
                /// </summary>
                public static void RenumberElements()
                {
                    Gmsh_Warp.GmshModelMeshRenumberElements(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Set the meshes of the entities of dimension `dim' and tag `tags' as
                /// periodic copies of the meshes of entities `tagsMaster', using the affine
                /// transformation specified in `affineTransformation' (16 entries of a 4x4
                /// matrix, by row). If used after meshing, generate the periodic node
                /// correspondence information assuming the meshes of entities `tags'
                /// effectively match the meshes of entities `tagsMaster' (useful for
                /// structured and extruded meshes). Currently only available for @code{dim}
                /// == 1 and @code{dim} == 2.
                /// </summary>
                public static void SetPeriodic(int dim, int[] tags, int[] tagsMaster, double[] affineTransform)
                {
                    Gmsh_Warp.GmshModelMeshSetPeriodic(dim, tags, tags.LongLength, tagsMaster, tagsMaster.LongLength, affineTransform, affineTransform.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get master entities `tagsMaster' for the entities of dimension `dim' and
                /// tags `tags'.
                /// </summary>
                public static int[] GetPeriodic(int dim, int[] tags)
				{
					unsafe
                    {
                        int* tagsMaster_ptr;
                        int tagsMaster_n = 0;
                        Gmsh_Warp.GmshModelMeshGetPeriodic(dim, tags, tags.LongLength, &tagsMaster_ptr, ref tagsMaster_n, ref Gmsh._staticreff);
                        var tagsMaster = UnsafeHelp.ToIntArray(tagsMaster_ptr, tagsMaster_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return tagsMaster;
                    }
				}

                /// <summary>
                /// Get the global unique identifiers `edgeTags' and the nodes `edgeNodes' of
                /// the edges in the mesh. Mesh edges are created e.g. by `createEdges()',
                /// `getKeys()' or addEdges().
                /// </summary>
                public static void GetAllEdges(out long[] edgeTags, out long[] edgeNodes)
				{
					unsafe
					{
                        long* edgeTags_ptr = default;
                        long edgeTags_n = 0;
                        long* edgeNodes_ptr = default;
                        long edgeNodes_n = 0;
                        Gmsh_Warp.GmshModelMeshGetAllEdges(&edgeTags_ptr, ref edgeTags_n, &edgeNodes_ptr, ref edgeNodes_n, ref Gmsh._staticreff);
                        edgeTags = UnsafeHelp.ToLongArray(edgeTags_ptr, edgeTags_n);
                        edgeNodes = UnsafeHelp.ToLongArray(edgeNodes_ptr, edgeNodes_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
				}

                /// <summary>
                /// Get the global unique identifiers `faceTags' and the nodes `faceNodes' of
                /// the faces of type `faceType' in the mesh. Mesh faces are created e.g. by
                /// `createFaces()', `getKeys()' or addFaces().
                /// </summary>
                public static void GetAllFaces(int faceType, out long[] faceTags, out long[] faceNodes)
                {
                    unsafe
                    {
                        long* edgeTags_ptr = default;
                        long edgeTags_n = 0;
                        long* edgeNodes_ptr = default;
                        long edgeNodes_n = 0;
                        Gmsh_Warp.GmshModelMeshGetAllFaces(faceType, & edgeTags_ptr, ref edgeTags_n, &edgeNodes_ptr, ref edgeNodes_n, ref Gmsh._staticreff);
                        faceTags = UnsafeHelp.ToLongArray(edgeTags_ptr, edgeTags_n);
                        faceNodes = UnsafeHelp.ToLongArray(edgeNodes_ptr, edgeNodes_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Add mesh edges defined by their global unique identifiers `edgeTags' and
                /// their nodes `edgeNodes'.
                /// </summary>
                public static void GetAddEdges(long[] edgeTags, long[] edgeNodes)
                {
                    Gmsh_Warp.GmshModelMeshAddEdges(edgeTags, edgeTags.LongLength, edgeNodes, edgeNodes.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Add mesh faces of type `faceType' defined by their global unique
                /// identifiers `faceTags' and their nodes `faceNodes'.
                /// </summary>
                public static void AddFacees(int faceType, long[] edgeTags, long[] edgeNodes)
                {
                    Gmsh_Warp.GmshModelMeshAddFaces(faceType, edgeTags, edgeTags.LongLength, edgeNodes, edgeNodes.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the master entity `tagMaster', the node tags `nodeTags' and their
                /// corresponding master node tags `nodeTagsMaster', and the affine transform
                /// `affineTransform' for the entity of dimension `dim' and tag `tag'. If
                /// `includeHighOrderNodes' is set, include high-order nodes in the returned
                /// data.
                /// </summary>
                public static void GetPeriodicNodes(int dim, int tag, out int tagsMaster, out long[] nodeTags, out long[] nodeTagsMaster, out double[] affineTransform, bool includeHighOrderNodes = false)
                {
                    unsafe
                    {
                        tagsMaster = 0;
                        long* nodeTags_ptr;
                        long nodeTags_n = 0;
                        long* nodeTagsMaster_ptr;
                        long nodeTagsMaster_n = 0;
                        double* affineTransform_ptr;
                        long affineTransform_n = 0;

                        Gmsh_Warp.GmshModelMeshGetPeriodicNodes(dim, tag, ref tagsMaster,
                            &nodeTags_ptr, ref nodeTags_n, &nodeTagsMaster_ptr, ref nodeTagsMaster_n,
                            &affineTransform_ptr, ref affineTransform_n, Convert.ToInt32(includeHighOrderNodes),
                            ref Gmsh._staticreff);
                        nodeTags = UnsafeHelp.ToLongArray(nodeTags_ptr, nodeTags_n);
                        nodeTagsMaster = UnsafeHelp.ToLongArray(nodeTagsMaster_ptr, nodeTagsMaster_n);
                        affineTransform = UnsafeHelp.ToDoubleArray(affineTransform_ptr, affineTransform_n);

                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Remove duplicate nodes in the mesh of the current model.
                /// </summary>
                public static void RemoveDuplicateNodes()
                {
                    Gmsh_Warp.GmshModelMeshRemoveDuplicateNodes(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Triangulate the points given in the `coord' vector as pairs of u, v
                /// coordinates, and return the node tags (with numbering starting at 1) of
                /// the resulting triangles in `tri'.
                /// </summary>
                public static void Triangulate(double[] coord, out long[] tri)
                {
                    unsafe
                    {
                        long* tri_ptr;
                        long tri_n = 0;
                        Gmsh_Warp.GmshModelMeshTriangulate(coord, coord.LongLength, &tri_ptr, ref tri_n, ref Gmsh._staticreff);
                        tri = UnsafeHelp.ToLongArray(tri_ptr, tri_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Tetrahedralize the points given in the coord vector as triplets of x, y, z coordinates, and return the node tags (with numbering starting at 1) of the resulting tetrahedra in tetra.
                /// </summary>
                public static void Tetrahedralize(double[] coord, out long[] tetra)
                {
                    unsafe
                    {
                        long* tri_ptr;
                        long tri_n = 0;
                        Gmsh_Warp.GmshModelMeshTetrahedralize(coord, coord.LongLength, &tri_ptr, ref tri_n, ref Gmsh._staticreff);
                        tetra = UnsafeHelp.ToLongArray(tri_ptr, tri_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    }
                }

                /// <summary>
                /// Split (into two triangles) all quadrangles in surface `tag' whose quality
                /// is lower than `quality'. If `tag' &lt; 0, split quadrangles in all surfaces.
                /// </summary>
                public static void SplitQuadrangles(double quality = 1, int tag = -1)
                {
                    Gmsh_Warp.GmshModelMeshSplitQuadrangles(quality, tag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Classify ("color") the surface mesh based on the angle threshold `angle'
                /// (in radians), and create new discrete surfaces, curves and points
                /// accordingly. If `boundary' is set, also create discrete curves on the
                /// boundary if the surface is open. If `forReparametrization' is set, create
                /// edges and surfaces that can be reparametrized using a single map. If
                /// `curveAngle' is less than Pi, also force curves to be split according to
                /// `curveAngle'. 
                /// If exportDiscrete is set, clear any built-in CAD kernel entities and export the discrete entities in the built-in CAD kernel.
                /// </summary>
                public static void ClassifySurfaces(double angle, bool boundary = true, bool forReparametrization = false, double curveAngle =Math.PI, bool exportDiscrete = true)
                {
                    Gmsh_Warp.GmshModelMeshClassifySurfaces(angle, Convert.ToInt32(boundary), Convert.ToInt32(forReparametrization), curveAngle, Convert.ToInt32(exportDiscrete), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Create a geometry for the discrete entities `dimTags' (represented solely
                /// by a mesh, without an underlying CAD description), i.e. create a
                /// parametrization for discrete curves and surfaces, assuming that each can
                /// be parametrized with a single map. If `dimTags' is empty, create a
                /// geometry for all the discrete entities.
                /// </summary>
                public static void CreateGeometry(ValueTuple<int, int>[] dimTags = default)
                {
                    if (dimTags == default) dimTags = new (int, int)[0];
                    var dimarray = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshCreateGeometry(dimarray, dimarray.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Create a boundary representation from the mesh if the model does not have
                /// one (e.g. when imported from mesh file formats with no BRep representation
                /// of the underlying model). If `makeSimplyConnected' is set, enforce simply
                /// connected discrete surfaces and volumes. If `exportDiscrete' is set, clear
                /// any built-in CAD kernel entities and export the discrete entities in the
                /// built-in CAD kernel.
                /// </summary>
                public static void CreateTopology(bool makeSimplyConnected = true, bool exportDiscrete = true)
                {
                    Gmsh_Warp.GmshModelMeshCreateTopology(Convert.ToInt32(makeSimplyConnected), Convert.ToInt32(exportDiscrete), ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Compute a basis representation for homology spaces after a mesh has been
                /// generated. The computation domain is given in a list of physical group
                /// tags `domainTags'; if empty, the whole mesh is the domain. The computation
                /// subdomain for relative homology computation is given in a list of physical
                /// group tags `subdomainTags'; if empty, absolute homology is computed. The
                /// dimensions homology bases to be computed are given in the list `dim'; if
                /// empty, all bases are computed. Resulting basis representation chains are
                /// stored as physical groups in the mesh.
                /// </summary>
                public static void ComputeHomology(int[] domainTags, int[] subdomainTags, int[] dims)
                {
                    Gmsh_Warp.GmshModelMeshComputeHomology(domainTags, domainTags.LongLength, subdomainTags, subdomainTags.LongLength, dims, dims.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Compute a basis representation for cohomology spaces after a mesh has been
                /// generated. The computation domain is given in a list of physical group
                /// tags `domainTags'; if empty, the whole mesh is the domain. The computation
                /// subdomain for relative cohomology computation is given in a list of
                /// physical group tags `subdomainTags'; if empty, absolute cohomology is
                /// computed. The dimensions homology bases to be computed are given in the
                /// list `dim'; if empty, all bases are computed. Resulting basis
                /// representation cochains are stored as physical groups in the mesh.
                /// </summary>
                public static void ComputeCohomology(int[] domainTags, int[] subdomainTags, int[] dims)
                {
                    Gmsh_Warp.GmshModelMeshComputeCohomology(domainTags, domainTags.LongLength, subdomainTags, subdomainTags.LongLength, dims, dims.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Compute a cross field for the current mesh. The function creates 3 views:
                /// the H function, the Theta function and cross directions. Return the tags
                /// of the views
                /// </summary>
                public static int[] ComputeCrossField()
                {
                    unsafe
                    {
                        int* viewTags_ptr;
                        long viewTags_n = 0;
                        Gmsh_Warp.GmshModelMeshComputeCrossField(&viewTags_ptr, ref viewTags_n, ref Gmsh._staticreff);
                        var viewTags = UnsafeHelp.ToIntArray(viewTags_ptr, viewTags_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return viewTags;
                    }
                }

                /// <summary>
                /// Reverse the orientation of the elements in the entities dimTags. If dimTags is empty, 
                /// reverse the orientation of the elements in the whole mesh.
                /// </summary>
                public static void Reverse(ValueTuple<int, int>[] dimTags = default)
                {
                    if (dimTags == default) dimTags = new (int, int)[0];
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshReverse(dimTags_array, dimTags.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Apply the affine transformation `affineTransform' (16 entries of a 4x4
                /// matrix, by row; only the 12 first can be provided for convenience) to the
                /// coordinates of the nodes classified on the entities `dimTags'. If
                /// `dimTags' is empty, transform all the nodes in the mesh.
                /// </summary>
                public static void AffineTransform(double[] affineTransform, ValueTuple<int, int>[] dimTags = default)
                {
                    if (dimTags == default) dimTags = new (int, int)[0];
                    var dimTags_array = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelMeshAffineTransform(affineTransform, affineTransform.LongLength, dimTags_array, dimTags.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the maximum tag maxTag of a node in the mesh.
                /// </summary>
                public static int GetMaxNodeTag()
				{
                    long maxTag = -1;
                    Gmsh_Warp.GmshModelMeshGetMaxNodeTag(ref maxTag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return (int)maxTag;
                }

                /// <summary>
                /// Get the maximum tag maxTag of an element in the mesh.
                /// </summary>
                public static int GetMaxElementTag()
                {
                    long maxTag = -1;
                    Gmsh_Warp.GmshModelMeshGetMaxElementTag(ref maxTag, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return (int)maxTag;
                }

                /// <summary>
                /// Get the mesh size constraints (if any) associated with the model entities
                /// `dimTags'. A zero entry in the output `sizes' vector indicates that no
                /// size constraint is specified on the corresponding entity.
                /// </summary>
                public static double[] GetSizes(ValueTuple<int, int>[] dimTags)
                {
                    unsafe
                    {
                        double* sizes_ptr;
                        long sizes_n = 0;
                        var dimTags_array = dimTags.ToIntArray();
                        Gmsh_Warp.GmshModelMeshGetSizes(dimTags_array, dimTags.LongLength, &sizes_ptr, ref sizes_n, ref Gmsh._staticreff);
                        var sizes = UnsafeHelp.ToDoubleArray(sizes_ptr, sizes_n);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return sizes;
                    }
                }

                /// <summary>
                /// Import the model STL representation (if available) as the current mesh.
                /// </summary>
                public static void ImportStl()
				{
                    Gmsh_Warp.GmshModelMeshImportStl(ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }

                /// <summary>
                /// Get the `tags' of any duplicate nodes in the mesh of the entities
                /// `dimTags'. If `dimTags' is empty, consider the whole mesh.
                /// </summary>
                public static int[] GetDuplicateNodes(ValueTuple<int, int>[] dimTags = default)
                {
                    unsafe
                    {
                        int* nodes_ptr;
                        long nodes_n = 0;
                        if (dimTags == default) dimTags = new (int, int)[0];
                        var dimTags_array = dimTags.ToIntArray();
                        Gmsh_Warp.GmshModelMeshGetDuplicateNodes(&nodes_ptr, ref nodes_n, dimTags_array, dimTags.LongLength, ref Gmsh._staticreff);
                        Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                        return UnsafeHelp.ToIntArray(nodes_ptr, nodes_n);
                    }
                }
            }
        }
    }
}