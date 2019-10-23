using System;
using System.Runtime.InteropServices;

namespace GMshNet
{
    internal class GMshNativeMethods
    {
        internal const string gmshdllname = "gmsh-4.4.dll";
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]

        public static extern void gmshFree(IntPtr p);
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gmshMalloc(ulong n);

        /// lesssummary>
        /// Initialize Gmsh. This must be called before any call to the other functions
        /// in the API. If `argc' and `argv' (or just `argv' in Python or Julia) are
        /// provided, they will be handled in the same way as the command line
        /// arguments in the Gmsh app. If `readConfigFiles' is set, read system Gmsh
        /// configuration files (gmshrc and gmsh-options). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshInitialize(int argc, string[] argv, int readConfigFiles, ref int ierr);

        /// lesssummary>
        /// Finalize Gmsh. This must be called when you are done using the Gmsh API. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFinalize(ref int ierr);

        /// lesssummary>
        /// Open a file. Equivalent to the `File->Open' menu in the Gmsh app. Handling
        /// of the file depends on its extension and/or its contents: opening a file
        /// with model data will create a new model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOpen(string fileName, ref int ierr);

        /// lesssummary>
        /// Merge a file. Equivalent to the `File->Merge' menu in the Gmsh app.
        /// Handling of the file depends on its extension and/or its contents. Merging
        /// a file with model data will add the data to the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshMerge(string fileName, ref int ierr);

        /// lesssummary>
        /// Write a file. The export format is determined by the file extension. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshWrite(string fileName, ref int ierr);

        /// lesssummary>
        /// Clear all loaded models and post-processing data, and add a new empty
        /// model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshClear(ref int ierr);

        /// lesssummary>
        /// Set a numerical option to `value'. `name' is of the form "category.option"
        /// or "category[num].option". Available categories and options are listed in
        /// the Gmsh reference manual. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOptionSetNumber(string name, double value, ref int ierr);

        /// lesssummary>
        /// Get the `value' of a numerical option. `name' is of the form
        /// "category.option" or "category[num].option". Available categories and
        /// options are listed in the Gmsh reference manual. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOptionGetNumber(string name, out double value, ref int ierr);

        /// lesssummary>
        /// Set a string option to `value'. `name' is of the form "category.option" or
        /// "category[num].option". Available categories and options are listed in the
        /// Gmsh reference manual. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOptionSetString(string name, string value, ref int ierr);

        /// lesssummary>
        /// Get the `value' of a string option. `name' is of the form "category.option"
        /// or "category[num].option". Available categories and options are listed in
        /// the Gmsh reference manual. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOptionGetString(string name, string value, ref int ierr);

        /// lesssummary>
        /// Set a color option to the RGBA value (`r', `g', `b', `a'), where where `r',
        /// `g', `b' and `a' should be integers between 0 and 255. `name' is of the
        /// form "category.option" or "category[num].option". Available categories and
        /// options are listed in the Gmsh reference manual, with the "Color." middle
        /// string removed. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOptionSetColor(string name, int r, int g, int b, int a, ref int ierr);

        /// lesssummary>
        /// Get the `r', `g', `b', `a' value of a color option. `name' is of the form
        /// "category.option" or "category[num].option". Available categories and
        /// options are listed in the Gmsh reference manual, with the "Color." middle
        /// string removed. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOptionGetColor(string name, out int r, out int g, out int b, out int a, ref int ierr);

        /// lesssummary>
        /// Add a new model, with name `name', and set it as the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelAdd(string name, ref int ierr);

        /// lesssummary>
        /// Remove the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelRemove(ref int ierr);

        /// lesssummary>
        /// List the names of all models. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelList(string[] names, ulong names_n, ref int ierr);

        /// lesssummary>
        /// Set the current model to the model with name `name'. If several models have
        /// the same name, select the one that was added first. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelSetCurrent(string name, ref int ierr);

        /// lesssummary>
        /// Get all the entities in the current model. If `dim' is >= 0, return only
        /// the entities of the specified dimension (e.g. points if `dim' == 0). The
        /// entities are returned as a vector of (dim, tag) integer pairs. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetEntities(ref IntPtr dimTags, ref uint dimTags_n, int dim, ref int ierr);

        /// lesssummary>
        /// Set the name of the entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelSetEntityName(int dim, int tag, string name, ref int ierr);

        /// lesssummary>
        /// Get the name of the entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetEntityName(int dim, int tag, string[] name, ref int ierr);

        /// lesssummary>
        /// Get all the physical groups in the current model. If `dim' is >= 0, return
        /// only the entities of the specified dimension (e.g. physical points if `dim'
        /// == 0). The entities are returned as a vector of (dim, tag) integer pairs. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetPhysicalGroups(int[] dimTags, ulong dimTags_n, int dim, ref int ierr);

        /// lesssummary>
        /// Get the tags of the model entities making up the physical group of
        /// dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetEntitiesForPhysicalGroup(int dim, int tag, int[] tags, ulong tags_n, ref int ierr);

        /// lesssummary>
        /// Get the tags of the physical groups (if any) to which the model entity of
        /// dimension `dim' and tag `tag' belongs. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetPhysicalGroupsForEntity(int dim, int tag, int[] physicalTags, ulong physicalTags_n, ref int ierr);

        /// lesssummary>
        /// Add a physical group of dimension `dim', grouping the model entities with
        /// tags `tags'. Return the tag of the physical group, equal to `tag' if `tag'
        /// is positive, or a new tag if `tag' less 0. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelAddPhysicalGroup(int dim, ref int tags, ulong tags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Set the name of the physical group of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelSetPhysicalName(int dim, int tag, string name, ref int ierr);

        /// lesssummary>
        /// Get the name of the physical group of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetPhysicalName(int dim, int tag, string[] name, ref int ierr);

        /// lesssummary>
        /// Get the boundary of the model entities `dimTags'. Return in `outDimTags'
        /// the boundary of the individual entities (if `combined' is false) or the
        /// boundary of the combined geometrical shape formed by all input entities (if
        /// `combined' is true). Return tags multiplied by the sign of the boundary
        /// entity if `oriented' is true. Apply the boundary operator recursively down
        /// to dimension 0 (i.e. to points) if `recursive' is true. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetBoundary(ref int dimTags, ulong dimTags_n, int[] outDimTags, ulong outDimTags_n, int combined, int oriented, int recursive, ref int ierr);

        /// lesssummary>
        /// Get the model entities in the bounding box defined by the two points
        /// (`xmin', `ymin', `zmin') and (`xmax', `ymax', `zmax'). If `dim' is >= 0,
        /// return only the entities of the specified dimension (e.g. points if `dim'
        /// == 0). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int[] tags, ulong tags_n, int dim, ref int ierr);

        /// lesssummary>
        /// Get the bounding box (`xmin', `ymin', `zmin'), (`xmax', `ymax', `zmax') of
        /// the model entity of dimension `dim' and tag `tag'. If `dim' and `tag' are
        /// negative, get the bounding box of the whole model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetBoundingBox(int dim, int tag, ref double xmin, ref double ymin, ref double zmin, ref double xmax, ref double ymax, ref double zmax, ref int ierr);

        /// lesssummary>
        /// Get the geometrical dimension of the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGetDimension(ref int ierr);

        /// lesssummary>
        /// Add a discrete model entity (defined by a mesh) of dimension `dim' in the
        /// current model. Return the tag of the new discrete entity, equal to `tag' if
        /// `tag' is positive, or a new tag if `tag' less 0. `boundary' specifies the tags
        /// of the entities on the boundary of the discrete entity, if any. Specifying
        /// `boundary' allows Gmsh to construct the topology of the overall model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelAddDiscreteEntity(int dim, int tag, ref int boundary, ulong boundary_n, ref int ierr);

        /// lesssummary>
        /// Remove the entities `dimTags' of the current model. If `recursive' is true,
        /// remove all the entities on their boundaries, down to dimension 0. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelRemoveEntities(ref int dimTags, ulong dimTags_n, int recursive, ref int ierr);

        /// lesssummary>
        /// Remove the entity name `name' from the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelRemoveEntityName(string name, ref int ierr);

        /// lesssummary>
        /// Remove the physical groups `dimTags' of the current model. If `dimTags' is
        /// empty, remove all groups. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelRemovePhysicalGroups(ref int dimTags, ulong dimTags_n, ref int ierr);

        /// lesssummary>
        /// Remove the physical name `name' from the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelRemovePhysicalName(string name, ref int ierr);

        /// lesssummary>
        /// Get the type of the entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetType(int dim, int tag, string[] entityType, ref int ierr);

        /// lesssummary>
        /// In a partitioned model, get the parent of the entity of dimension `dim' and
        /// tag `tag', i.e. from which the entity is a part of, if any. `parentDim' and
        /// `parentTag' are set to -1 if the entity has no parent. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetParent(int dim, int tag, ref int parentDim, ref int parentTag, ref int ierr);

        /// lesssummary>
        /// In a partitioned model, return the tags of the partition(s) to which the
        /// entity belongs. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetPartitions(int dim, int tag, int[] partitions, ulong partitions_n, ref int ierr);

        /// lesssummary>
        /// Evaluate the parametrization of the entity of dimension `dim' and tag `tag'
        /// at the parametric coordinates `parametricCoord'. Only valid for `dim' equal
        /// to 0 (with empty `parametricCoord'), 1 (with `parametricCoord' containing
        /// parametric coordinates on the curve) or 2 (with `parametricCoord'
        /// containing pairs of u, v parametric coordinates on the surface,
        /// concatenated: [p1u, p1v, p2u, ...]). Return triplets of x, y, z coordinates
        /// in `points', concatenated: [p1x, p1y, p1z, p2x, ...]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetValue(int dim, int tag, ref double parametricCoord, ulong parametricCoord_n, double[] points, ulong points_n, ref int ierr);

        /// lesssummary>
        /// Evaluate the derivative of the parametrization of the entity of dimension
        /// `dim' and tag `tag' at the parametric coordinates `parametricCoord'. Only
        /// valid for `dim' equal to 1 (with `parametricCoord' containing parametric
        /// coordinates on the curve) or 2 (with `parametricCoord' containing pairs of
        /// u, v parametric coordinates on the surface, concatenated: [p1u, p1v, p2u,
        /// ...]). For `dim' equal to 1 return the x, y, z components of the derivative
        /// with respect to u [d1ux, d1uy, d1uz, d2ux, ...]; for `dim' equal to 2
        /// return the x, y, z components of the derivate with respect to u and v:
        /// [d1ux, d1uy, d1uz, d1vx, d1vy, d1vz, d2ux, ...]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetDerivative(int dim, int tag, ref double parametricCoord, ulong parametricCoord_n, double[] derivatives, ulong derivatives_n, ref int ierr);

        /// lesssummary>
        /// Evaluate the (maximum) curvature of the entity of dimension `dim' and tag
        /// `tag' at the parametric coordinates `parametricCoord'. Only valid for `dim'
        /// equal to 1 (with `parametricCoord' containing parametric coordinates on the
        /// curve) or 2 (with `parametricCoord' containing pairs of u, v parametric
        /// coordinates on the surface, concatenated: [p1u, p1v, p2u, ...]). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetCurvature(int dim, int tag, ref double parametricCoord, ulong parametricCoord_n, double[] curvatures, ulong curvatures_n, ref int ierr);

        /// lesssummary>
        /// Evaluate the principal curvatures of the surface with tag `tag' at the
        /// parametric coordinates `parametricCoord', as well as their respective
        /// directions. `parametricCoord' are given by pair of u and v coordinates,
        /// concatenated: [p1u, p1v, p2u, ...]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetPrincipalCurvatures(int tag, ref double parametricCoord, ulong parametricCoord_n, double[] curvatureMax, ulong curvatureMax_n, double[] curvatureMin, ulong curvatureMin_n, double[] directionMax, ulong directionMax_n, double[] directionMin, ulong directionMin_n, ref int ierr);

        /// lesssummary>
        /// Get the normal to the surface with tag `tag' at the parametric coordinates
        /// `parametricCoord'. `parametricCoord' are given by pairs of u and v
        /// coordinates, concatenated: [p1u, p1v, p2u, ...]. `normals' are returned as
        /// triplets of x, y, z components, concatenated: [n1x, n1y, n1z, n2x, ...]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetNormal(int tag, ref double parametricCoord, ulong parametricCoord_n, double[] normals, ulong normals_n, ref int ierr);

        /// lesssummary>
        /// Set the visibility of the model entities `dimTags' to `value'. Apply the
        /// visibility setting recursively if `recursive' is true. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelSetVisibility(ref int dimTags, ulong dimTags_n, int value, int recursive, ref int ierr);

        /// lesssummary>
        /// Get the visibility of the model entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetVisibility(int dim, int tag, ref int value, ref int ierr);

        /// lesssummary>
        /// Set the color of the model entities `dimTags' to the RGBA value (`r', `g',
        /// `b', `a'), where `r', `g', `b' and `a' should be integers between 0 and
        /// 255. Apply the color setting recursively if `recursive' is true. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelSetColor(ref int dimTags, ulong dimTags_n, int r, int g, int b, int a, int recursive, ref int ierr);

        /// lesssummary>
        /// Get the color of the model entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGetColor(int dim, int tag, ref int r, ref int g, ref int b, ref int a, ref int ierr);

        /// lesssummary>
        /// Set the `x', `y', `z' coordinates of a geometrical point. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelSetCoordinates(int tag, double x, double y, double z, ref int ierr);

        /// lesssummary>
        /// Generate a mesh of the current model, up to dimension `dim' (0, 1, 2 or 3). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGenerate(int dim, ref int ierr);

        /// lesssummary>
        /// Partition the mesh of the current model into `numPart' partitions. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshPartition(int numPart, ref int ierr);

        /// lesssummary>
        /// Unpartition the mesh of the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshUnpartition(ref int ierr);

        /// lesssummary>
        /// Optimize the mesh of the current model using `method' (empty for default
        /// tetrahedral mesh optimizer, "Netgen" for Netgen optimizer, "HighOrder" for
        /// direct high-order mesh optimizer, "HighOrderElastic" for high-order elastic
        /// smoother). If `force' is set apply the optimization also to discrete
        /// entities. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshOptimize(string method, int force, ref int ierr);

        /// lesssummary>
        /// Recombine the mesh of the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRecombine(ref int ierr);

        /// lesssummary>
        /// Refine the mesh of the current model by uniformly splitting the elements. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRefine(ref int ierr);

        /// lesssummary>
        /// Smooth the mesh of the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSmooth(ref int ierr);

        /// lesssummary>
        /// Set the order of the elements in the mesh of the current model to `order'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetOrder(int order, ref int ierr);

        /// lesssummary>
        /// Get the last entities (if any) where a meshing error occurred. Currently
        /// only populated by the new 3D meshing algorithms. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetLastEntityError(int[] dimTags, ulong dimTags_n, ref int ierr);

        /// lesssummary>
        /// Get the last nodes (if any) where a meshing error occurred. Currently only
        /// populated by the new 3D meshing algorithms. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetLastNodeError(ulong[] nodeTags, ulong nodeTags_n, ref int ierr);

        /// lesssummary>
        /// Clear the mesh, i.e. delete all the nodes and elements. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshClear(ref int ierr);

        /// lesssummary>
        /// Get the nodes classified on the entity of dimension `dim' and tag `tag'. If
        /// `tag' less 0, get the nodes for all entities of dimension `dim'. If `dim' and
        /// `tag' are negative, get all the nodes in the mesh. `nodeTags' contains the
        /// node tags (their unique, strictly positive identification numbers). `coord'
        /// is a vector of length 3 times the length of `nodeTags' that contains the x,
        /// y, z coordinates of the nodes, concatenated: [n1x, n1y, n1z, n2x, ...]. If
        /// `dim' >= 0 and `returnParamtricCoord' is set, `parametricCoord' contains
        /// the parametric coordinates ([u1, u2, ...] or [u1, v1, u2, ...]) of the
        /// nodes, if available. The length of `parametricCoord' can be 0 or `dim'
        /// times the length of `nodeTags'. If `includeBoundary' is set, also return
        /// the nodes classified on the boundary of the entity (which will be
        /// reparametrized on the entity if `dim' >= 0 in order to compute their
        /// parametric coordinates). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetNodes(ref IntPtr nodeTags, ref ulong nodeTags_n, ref IntPtr coord, ref ulong coord_n, ref IntPtr parametricCoord, ref ulong parametricCoord_n, int dim, int tag, int includeBoundary, int returnParametricCoord, ref int ierr);

        /// lesssummary>
        /// Get the nodes classified on the entity of tag `tag', for all the elements
        /// of type `elementType'. The other arguments are treated as in `getNodes'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetNodesByElementType(int elementType, ulong[] nodeTags, ulong nodeTags_n, double[] coord, ulong coord_n, double[] parametricCoord, ulong parametricCoord_n, int tag, int returnParametricCoord, ref int ierr);

        /// lesssummary>
        /// Get the coordinates and the parametric coordinates (if any) of the node
        /// with tag `tag'. This is a sometimes useful but inefficient way of accessing
        /// nodes, as it relies on a cache stored in the model. For large meshes all
        /// the nodes in the model should be numbered in a continuous sequence of tags
        /// from 1 to N to maintain reasonable performance (in this case the internal
        /// cache is based on a vector; otherwise it uses a map). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetNode(ulong nodeTag, ref IntPtr coord, ref ulong coord_n, ref IntPtr parametricCoord, ref ulong parametricCoord_n, ref int ierr);

        /// lesssummary>
        /// Rebuild the node cache. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRebuildNodeCache(int onlyIfNecessary, ref int ierr);

        /// lesssummary>
        /// Get the nodes from all the elements belonging to the physical group of
        /// dimension `dim' and tag `tag'. `nodeTags' contains the node tags; `coord'
        /// is a vector of length 3 times the length of `nodeTags' that contains the x,
        /// y, z coordinates of the nodes, concatenated: [n1x, n1y, n1z, n2x, ...]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetNodesForPhysicalGroup(int dim, int tag, ulong[] nodeTags, ulong nodeTags_n, double[] coord, ulong coord_n, ref int ierr);

        /// lesssummary>
        /// Add nodes classified on the model entity of dimension `dim' and tag `tag'.
        /// `nodeTags' contains the node tags (their unique, strictly positive
        /// identification numbers). `coord' is a vector of length 3 times the length
        /// of `nodeTags' that contains the x, y, z coordinates of the nodes,
        /// concatenated: [n1x, n1y, n1z, n2x, ...]. The optional `parametricCoord'
        /// vector contains the parametric coordinates of the nodes, if any. The length
        /// of `parametricCoord' can be 0 or `dim' times the length of `nodeTags'. If
        /// the `nodeTags' vector is empty, new tags are automatically assigned to the
        /// nodes. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshAddNodes(int dim, int tag, uint[] nodeTags, ulong nodeTags_n, double[] coord, ulong coord_n, double[] parametricCoord, ulong parametricCoord_n, ref int ierr);

        /// lesssummary>
        /// Reclassify all nodes on their associated model entity, based on the
        /// elements. Can be used when importing nodes in bulk (e.g. by associating
        /// them all to a single volume), to reclassify them correctly on model
        /// surfaces, curves, etc. after the elements have been set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshReclassifyNodes(ref int ierr);

        /// lesssummary>
        /// Relocate the nodes classified on the entity of dimension `dim' and tag
        /// `tag' using their parametric coordinates. If `tag' less 0, relocate the nodes
        /// for all entities of dimension `dim'. If `dim' and `tag' are negative,
        /// relocate all the nodes in the mesh. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRelocateNodes(int dim, int tag, ref int ierr);

        /// lesssummary>
        /// Get the elements classified on the entity of dimension `dim' and tag `tag'.
        /// If `tag' less 0, get the elements for all entities of dimension `dim'. If
        /// `dim' and `tag' are negative, get all the elements in the mesh.
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
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElements(ref IntPtr elementTypes, ref ulong elementTypes_n, ref IntPtr elementTags, ref IntPtr elementTags_n, ref ulong elementTags_nn, ref IntPtr nodeTags, ref IntPtr nodeTags_n, ref ulong nodeTags_nn, int dim, int tag, ref int ierr);

        /// lesssummary>
        /// Get the type and node tags of the element with tag `tag'. This is a
        /// sometimes useful but inefficient way of accessing elements, as it relies on
        /// a cache stored in the model. For large meshes all the elements in the model
        /// should be numbered in a continuous sequence of tags from 1 to N to maintain
        /// reasonable performance (in this case the internal cache is based on a
        /// vector; otherwise it uses a map). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElement(ulong elementTag, ref int elementType, ulong[] nodeTags, ulong nodeTags_n, ref int ierr);

        /// lesssummary>
        /// Search the mesh for an element located at coordinates (`x', `y', `z'). This
        /// is a sometimes useful but inefficient way of accessing elements, as it
        /// relies on a search in a spatial octree. If an element is found, return its
        /// tag, type and node tags, as well as the local coordinates (`u', `v', `w')
        /// within the element corresponding to search location. If `dim' is >= 0, only
        /// search for elements of the given dimension. If `strict' is not set, use a
        /// tolerance to find elements near the search location. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElementByCoordinates(double x, double y, double z, ulong elementTag, ref int elementType, ulong[] nodeTags, ulong nodeTags_n, ref double u, ref double v, ref double w, int dim, int strict, ref int ierr);

        /// lesssummary>
        /// Get the types of elements in the entity of dimension `dim' and tag `tag'.
        /// If `tag' less 0, get the types for all entities of dimension `dim'. If `dim'
        /// and `tag' are negative, get all the types in the mesh. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElementTypes(int[] elementTypes, ulong elementTypes_n, int dim, int tag, ref int ierr);

        /// lesssummary>
        /// Return an element type given its family name `familyName' ("point", "line",
        /// "triangle", "quadrangle", "tetrahedron", "pyramid", "prism", "hexahedron")
        /// and polynomial order `order'. If `serendip' is true, return the
        /// corresponding serendip element type (element without interior nodes). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelMeshGetElementType(string familyName, int order, int serendip, ref int ierr);

        /// lesssummary>
        /// Get the properties of an element of type `elementType': its name
        /// (`elementName'), dimension (`dim'), order (`order'), number of nodes
        /// (`numNodes') and coordinates of the nodes in the reference element
        /// (`nodeCoord' vector, of length `dim' times `numNodes'). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElementProperties(int elementType, string[] elementName, ref int dim, ref int order, ref int numNodes, double[] nodeCoord, ulong nodeCoord_n, ref int ierr);

        /// lesssummary>
        /// Get the elements of type `elementType' classified on the entity of tag
        /// `tag'. If `tag' less 0, get the elements for all entities. `elementTags' is a
        /// vector containing the tags (unique, strictly positive identifiers) of the
        /// elements of the corresponding type. `nodeTags' is a vector of length equal
        /// to the number of elements of the given type times the number N of nodes for
        /// this type of element, that contains the node tags of all the elements of
        /// the given type, concatenated: [e1n1, e1n2, ..., e1nN, e2n1, ...]. If
        /// `numTasks' > 1, only compute and return the part of the data indexed by
        /// `task'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElementsByType(int elementType, ref IntPtr elementTags,ref ulong elementTags_n, ref IntPtr nodeTags,ref ulong nodeTags_n, int tag, ulong task, ulong numTasks, ref int ierr);

        /// lesssummary>
        /// Preallocate data before calling `getElementsByType' with `numTasks' > 1.
        /// For C and C++ only. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshPreallocateElementsByType(int elementType, int elementTag, int nodeTag, ulong[] elementTags, ulong elementTags_n, ulong[] nodeTags, ulong nodeTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add elements classified on the entity of dimension `dim' and tag `tag'.
        /// `types' contains the MSH types of the elements (e.g. `2' for 3-node
        /// triangles: see the Gmsh reference manual). `elementTags' is a vector of the
        /// same length as `types'; each entry is a vector containing the tags (unique,
        /// strictly positive identifiers) of the elements of the corresponding type.
        /// `nodeTags' is also a vector of the same length as `types'; each entry is a
        /// vector of length equal to the number of elements of the given type times
        /// the number N of nodes per element, that contains the node tags of all the
        /// elements of the given type, concatenated: [e1n1, e1n2, ..., e1nN, e2n1,
        /// ...]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshAddElements(int dim, int tag, ref int elementTypes, ulong elementTypes_n, ulong[] elementTags, ulong elementTags_n, ulong elementTags_nn, ulong[] nodeTags, ulong nodeTags_n, ulong nodeTags_nn, ref int ierr);

        /// lesssummary>
        /// Add elements of type `elementType' classified on the entity of tag `tag'.
        /// `elementTags' contains the tags (unique, strictly positive identifiers) of
        /// the elements of the corresponding type. `nodeTags' is a vector of length
        /// equal to the number of elements times the number N of nodes per element,
        /// that contains the node tags of all the elements, concatenated: [e1n1, e1n2,
        /// ..., e1nN, e2n1, ...]. If the `elementTag' vector is empty, new tags are
        /// automatically assigned to the elements. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshAddElementsByType(int tag, int elementType, long[] elementTags, ulong elementTags_n, long[] nodeTags, ulong nodeTags_n, ref int ierr);

        /// lesssummary>
        /// Get the numerical quadrature information for the given element type
        /// `elementType' and integration rule `integrationType' (e.g. "Gauss4" for a
        /// Gauss quadrature suited for integrating 4th order polynomials).
        /// `integrationPoints' contains the u, v, w coordinates of the G integration
        /// points in the reference element: [g1u, g1v, g1w, ..., gGu, gGv, gGw].
        /// `integrationWeigths' contains the associated weights: [g1q, ..., gGq]. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetIntegrationPoints(int elementType, string integrationType, double[] integrationPoints, ulong integrationPoints_n, double[] integrationWeights, ulong integrationWeights_n, ref int ierr);

        /// lesssummary>
        /// Get the Jacobians of all the elements of type `elementType' classified on
        /// the entity of tag `tag', at the G integration points `integrationPoints'
        /// given as concatenated triplets of coordinates in the reference element
        /// [g1u, g1v, g1w, ..., gGu, gGv, gGw]. Data is returned by element, with
        /// elements in the same order as in `getElements' and `getElementsByType'.
        /// `jacobians' contains for each element the 9 entries of the 3x3 Jacobian
        /// matrix at each integration point. The matrix is returned by column:
        /// [e1g1Jxu, e1g1Jyu, e1g1Jzu, e1g1Jxv, ..., e1g1Jzw, e1g2Jxu, ..., e1gGJzw,
        /// e2g1Jxu, ...], with Jxu=dx/du, Jyu=dy/du, etc. `determinants' contains for
        /// each element the determinant of the Jacobian matrix at each integration
        /// point: [e1g1, e1g2, ... e1gG, e2g1, ...]. `points' contains for each
        /// element the x, y, z coordinates of the integration points. If `tag' less 0,
        /// get the Jacobian data for all entities. If `numTasks' > 1, only compute and
        /// return the part of the data indexed by `task'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetJacobians(int elementType, ref double integrationPoints, ulong integrationPoints_n, double[] jacobians, ulong jacobians_n, double[] determinants, ulong determinants_n, double[] points, ulong points_n, int tag, ulong task, ulong numTasks, ref int ierr);

        /// lesssummary>
        /// Preallocate data before calling `getJacobians' with `numTasks' > 1. For C
        /// and C++ only. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshPreallocateJacobians(int elementType, int numIntegrationPoints, int jacobian, int determinant, int point, double[] jacobians, ulong jacobians_n, double[] determinants, ulong determinants_n, double[] points, ulong points_n, int tag, ref int ierr);

        /// lesssummary>
        /// Get the basis functions of the element of type `elementType' at the
        /// integration points `integrationPoints' (given as concatenated triplets of
        /// coordinates in the reference element [g1u, g1v, g1w, ..., gGu, gGv, gGw]),
        /// for the function space `functionSpaceType' (e.g. "Lagrange" or
        /// "GradLagrange" for Lagrange basis functions or their gradient, in the u, v,
        /// w coordinates of the reference element). `numComponents' returns the number
        /// C of components of a basis function. `basisFunctions' returns the value of
        /// the N basis functions at the integration points, i.e. [g1f1, g1f2, ...,
        /// g1fN, g2f1, ...] when C == 1 or [g1f1u, g1f1v, g1f1w, g1f2u, ..., g1fNw,
        /// g2f1u, ...] when C == 3. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetBasisFunctions(int elementType, ref double integrationPoints, ulong integrationPoints_n, string functionSpaceType, ref int numComponents, double[] basisFunctions, ulong basisFunctions_n, ref int ierr);

        /// lesssummary>
        /// Get the element-dependent basis functions of the elements of type
        /// `elementType' in the entity of tag `tag'at the integration points
        /// `integrationPoints' (given as concatenated triplets of coordinates in the
        /// reference element [g1u, g1v, g1w, ..., gGu, gGv, gGw]), for the function
        /// space `functionSpaceType' (e.g. "H1Legendre3" or "GradH1Legendre3" for 3rd
        /// order hierarchical H1 Legendre functions or their gradient, in the u, v, w
        /// coordinates of the reference elements). `numComponents' returns the number
        /// C of components of a basis function. `numBasisFunctions' returns the number
        /// N of basis functions per element. `basisFunctions' returns the value of the
        /// basis functions at the integration points for each element: [e1g1f1,...,
        /// e1g1fN, e1g2f1,..., e2g1f1, ...] when C == 1 or [e1g1f1u, e1g1f1v,...,
        /// e1g1fNw, e1g2f1u,..., e2g1f1u, ...]. Warning: this is an experimental
        /// feature and will probably change in a future release. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetBasisFunctionsForElements(int elementType, ref double integrationPoints, ulong integrationPoints_n, string functionSpaceType, ref int numComponents, ref int numFunctionsPerElements, double[] basisFunctions, ulong basisFunctions_n, int tag, ref int ierr);

        /// lesssummary>
        /// Generate the `keys' for the elements of type `elementType' in the entity of
        /// tag `tag', for the `functionSpaceType' function space. Each key uniquely
        /// identifies a basis function in the function space. If `returnCoord' is set,
        /// the `coord' vector contains the x, y, z coordinates locating basis
        /// functions for sorting purposes. Warning: this is an experimental feature
        /// and will probably change in a future release. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetKeysForElements(int elementType, string functionSpaceType, int[] keys, ulong keys_n, double[] coord, ulong coord_n, int tag, int returnCoord, ref int ierr);

        /// lesssummary>
        /// Get information about the `keys'. `infoKeys' returns information about the
        /// functions associated with the `keys'. `infoKeys[0].first' describes the
        /// type of function (0 for  vertex function, 1 for edge function, 2 for face
        /// function and 3 for bubble function). `infoKeys[0].second' gives the order
        /// of the function associated with the key. Warning: this is an experimental
        /// feature and will probably change in a future release. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetInformationForElements(ref int keys, ulong keys_n, int elementType, string functionSpaceType, int[] infoKeys, ulong infoKeys_n, ref int ierr);

        /// lesssummary>
        /// Precomputes the basis functions corresponding to `elementType'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshPrecomputeBasisFunctions(int elementType, ref int ierr);

        /// lesssummary>
        /// Get the barycenters of all elements of type `elementType' classified on the
        /// entity of tag `tag'. If `primary' is set, only the primary nodes of the
        /// elements are taken into account for the barycenter calculation. If `fast'
        /// is set, the function returns the sum of the primary node coordinates
        /// (without normalizing by the number of nodes). If `tag' less 0, get the
        /// barycenters for all entities. If `numTasks' > 1, only compute and return
        /// the part of the data indexed by `task'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetBarycenters(int elementType, int tag, int fast, int primary, double[] barycenters, ulong barycenters_n, ulong task, ulong numTasks, ref int ierr);

        /// lesssummary>
        /// Preallocate data before calling `getBarycenters' with `numTasks' > 1. For C
        /// and C++ only. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshPreallocateBarycenters(int elementType, double[] barycenters, ulong barycenters_n, int tag, ref int ierr);

        /// lesssummary>
        /// Get the nodes on the edges of all elements of type `elementType' classified
        /// on the entity of tag `tag'. `nodeTags' contains the node tags of the edges
        /// for all the elements: [e1a1n1, e1a1n2, e1a2n1, ...]. Data is returned by
        /// element, with elements in the same order as in `getElements' and
        /// `getElementsByType'. If `primary' is set, only the primary (begin/end)
        /// nodes of the edges are returned. If `tag' less 0, get the edge nodes for all
        /// entities. If `numTasks' > 1, only compute and return the part of the data
        /// indexed by `task'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElementEdgeNodes(int elementType, ulong[] nodeTags, ulong nodeTags_n, int tag, int primary, ulong task, ulong numTasks, ref int ierr);

        /// lesssummary>
        /// Get the nodes on the faces of type `faceType' (3 for triangular faces, 4
        /// for quadrangular faces) of all elements of type `elementType' classified on
        /// the entity of tag `tag'. `nodeTags' contains the node tags of the faces for
        /// all elements: [e1f1n1, ..., e1f1nFaceType, e1f2n1, ...]. Data is returned
        /// by element, with elements in the same order as in `getElements' and
        /// `getElementsByType'. If `primary' is set, only the primary (corner) nodes
        /// of the faces are returned. If `tag' less 0, get the face nodes for all
        /// entities. If `numTasks' > 1, only compute and return the part of the data
        /// indexed by `task'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetElementFaceNodes(int elementType, int faceType, ulong[] nodeTags, ulong nodeTags_n, int tag, int primary, ulong task, ulong numTasks, ref int ierr);

        /// lesssummary>
        /// Get the ghost elements `elementTags' and their associated `partitions'
        /// stored in the ghost entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetGhostElements(int dim, int tag, ulong[] elementTags, ulong elementTags_n, int[] partitions, ulong partitions_n, ref int ierr);

        /// lesssummary>
        /// Set a mesh size constraint on the model entities `dimTags'. Currently only
        /// entities of dimension 0 (points) are handled. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetSize(ref int dimTags, ulong dimTags_n, double size, ref int ierr);

        /// lesssummary>
        /// Set a transfinite meshing constraint on the curve `tag', with `numNodes'
        /// nodes distributed according to `meshType' and `coef'. Currently supported
        /// types are "Progression" (geometrical progression with power `coef') and
        /// "Bump" (refinement toward both extremities of the curve). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetTransfiniteCurve(int tag, int numNodes, string meshType, double coef, ref int ierr);

        /// lesssummary>
        /// Set a transfinite meshing constraint on the surface `tag'. `arrangement'
        /// describes the arrangement of the triangles when the surface is not flagged
        /// as recombined: currently supported values are "Left", "Right",
        /// "AlternateLeft" and "AlternateRight". `cornerTags' can be used to specify
        /// the (3 or 4) corners of the transfinite interpolation explicitly;
        /// specifying the corners explicitly is mandatory if the surface has more that
        /// 3 or 4 points on its boundary. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetTransfiniteSurface(int tag, string arrangement, ref int cornerTags, ulong cornerTags_n, ref int ierr);

        /// lesssummary>
        /// Set a transfinite meshing constraint on the surface `tag'. `cornerTags' can
        /// be used to specify the (6 or 8) corners of the transfinite interpolation
        /// explicitly. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetTransfiniteVolume(int tag, ref int cornerTags, ulong cornerTags_n, ref int ierr);

        /// lesssummary>
        /// Set a recombination meshing constraint on the model entity of dimension
        /// `dim' and tag `tag'. Currently only entities of dimension 2 (to recombine
        /// triangles into quadrangles) are supported. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetRecombine(int dim, int tag, ref int ierr);

        /// lesssummary>
        /// Set a smoothing meshing constraint on the model entity of dimension `dim'
        /// and tag `tag'. `val' iterations of a Laplace smoother are applied. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetSmoothing(int dim, int tag, int val, ref int ierr);

        /// lesssummary>
        /// Set a reverse meshing constraint on the model entity of dimension `dim' and
        /// tag `tag'. If `val' is true, the mesh orientation will be reversed with
        /// respect to the natural mesh orientation (i.e. the orientation consistent
        /// with the orientation of the geometry). If `val' is false, the mesh is left
        /// as-is. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetReverse(int dim, int tag, int val, ref int ierr);

        /// lesssummary>
        /// Set meshing constraints on the bounding surfaces of the volume of tag `tag'
        /// so that all surfaces are oriented with outward pointing normals. Currently
        /// only available with the OpenCASCADE kernel, as it relies on the STL
        /// triangulation. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetOutwardOrientation(int tag, ref int ierr);

        /// lesssummary>
        /// Embed the model entities of dimension `dim' and tags `tags' in the
        /// (`inDim', `inTag') model entity. The dimension `dim' can 0, 1 or 2 and must
        /// be strictly smaller than `inDim', which must be either 2 or 3. The embedded
        /// entities should not be part of the boundary of the entity `inTag', whose
        /// mesh will conform to the mesh of the embedded entities. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshEmbed(int dim, ref int tags, ulong tags_n, int inDim, int inTag, ref int ierr);

        /// lesssummary>
        /// Remove embedded entities from the model entities `dimTags'. if `dim' is >=
        /// 0, only remove embedded entities of the given dimension (e.g. embedded
        /// points if `dim' == 0). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRemoveEmbedded(ref int dimTags, ulong dimTags_n, int dim, ref int ierr);

        /// lesssummary>
        /// Reorder the elements of type `elementType' classified on the entity of tag
        /// `tag' according to `ordering'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshReorderElements(int elementType, int tag, ulong ordering, ulong ordering_n, ref int ierr);

        /// lesssummary>
        /// Renumber the node tags in a continuous sequence. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRenumberNodes(ref int ierr);

        /// lesssummary>
        /// Renumber the element tags in a continuous sequence. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRenumberElements(ref int ierr);

        /// lesssummary>
        /// Set the meshes of the entities of dimension `dim' and tag `tags' as
        /// periodic copies of the meshes of entities `tagsMaster', using the affine
        /// transformation specified in `affineTransformation' (16 entries of a 4x4
        /// matrix, by row). Currently only available for `dim' == 1 and `dim' == 2. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSetPeriodic(int dim, ref int tags, ulong tags_n, ref int tagsMaster, ulong tagsMaster_n, ref double affineTransform, ulong affineTransform_n, ref int ierr);

        /// lesssummary>
        /// Get the master entity `tagMaster', the node tags `nodeTags' and their
        /// corresponding master node tags `nodeTagsMaster', and the affine transform
        /// `affineTransform' for the entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshGetPeriodicNodes(int dim, int tag, ref int tagMaster, ulong[] nodeTags, ulong nodeTags_n, ulong[] nodeTagsMaster, ulong nodeTagsMaster_n, double[] affineTransform, ulong affineTransform_n, ref int ierr);

        /// lesssummary>
        /// Remove duplicate nodes in the mesh of the current model. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshRemoveDuplicateNodes(ref int ierr);

        /// lesssummary>
        /// Split (into two triangles) all quadrangles in surface `tag' whose quality
        /// is lower than `quality'. If `tag' less 0, split quadrangles in all surfaces. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshSplitQuadrangles(double quality, int tag, ref int ierr);

        /// lesssummary>
        /// Classify ("color") the surface mesh based on the angle threshold `angle'
        /// (in radians), and create new discrete surfaces, curves and points
        /// accordingly. If `boundary' is set, also create discrete curves on the
        /// boundary if the surface is open. If `forReparametrization' is set, create
        /// edges and surfaces that can be reparametrized using a single map. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshClassifySurfaces(double angle, int boundary, int forReparametrization, ref int ierr);

        /// lesssummary>
        /// Create a parametrization for discrete curves and surfaces (i.e. curves and
        /// surfaces represented solely by a mesh, without an underlying CAD
        /// description), assuming that each can be parametrized with a single map. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshCreateGeometry(ref int ierr);

        /// lesssummary>
        /// Create a boundary representation from the mesh if the model does not have
        /// one (e.g. when imported from mesh file formats with no BRep representation
        /// of the underlying model). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshCreateTopology(ref int ierr);

        /// lesssummary>
        /// Compute a basis representation for homology spaces after a mesh has been
        /// generated. The computation domain is given in a list of physical group tags
        /// `domainTags'; if empty, the whole mesh is the domain. The computation
        /// subdomain for relative homology computation is given in a list of physical
        /// group tags `subdomainTags'; if empty, absolute homology is computed. The
        /// dimensions homology bases to be computed are given in the list `dim'; if
        /// empty, all bases are computed. Resulting basis representation chains are
        /// stored as physical groups in the mesh. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshComputeHomology(ref int domainTags, ulong domainTags_n, ref int subdomainTags, ulong subdomainTags_n, ref int dims, ulong dims_n, ref int ierr);

        /// lesssummary>
        /// Compute a basis representation for cohomology spaces after a mesh has been
        /// generated. The computation domain is given in a list of physical group tags
        /// `domainTags'; if empty, the whole mesh is the domain. The computation
        /// subdomain for relative cohomology computation is given in a list of
        /// physical group tags `subdomainTags'; if empty, absolute cohomology is
        /// computed. The dimensions homology bases to be computed are given in the
        /// list `dim'; if empty, all bases are computed. Resulting basis
        /// representation cochains are stored as physical groups in the mesh. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshComputeCohomology(ref int domainTags, ulong domainTags_n, ref int subdomainTags, ulong subdomainTags_n, ref int dims, ulong dims_n, ref int ierr);

        /// lesssummary>
        /// Add a new mesh size field of type `fieldType'. If `tag' is positive, assign
        /// the tag explicitly; otherwise a new tag is assigned automatically. Return
        /// the field tag. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelMeshFieldAdd(string fieldType, int tag, ref int ierr);

        /// lesssummary>
        /// Remove the field with tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshFieldRemove(int tag, ref int ierr);

        /// lesssummary>
        /// Set the numerical option `option' to value `value' for field `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshFieldSetNumber(int tag, string option, double value, ref int ierr);

        /// lesssummary>
        /// Set the string option `option' to value `value' for field `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshFieldSetString(int tag, string option, string value, ref int ierr);

        /// lesssummary>
        /// Set the numerical list option `option' to value `value' for field `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshFieldSetNumbers(int tag, string option, double[] value, ulong value_n, ref int ierr);

        /// lesssummary>
        /// Set the field `tag' as the background mesh size field. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshFieldSetAsBackgroundMesh(int tag, ref int ierr);

        /// lesssummary>
        /// Set the field `tag' as a boundary layer size field. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelMeshFieldSetAsBoundaryLayer(int tag, ref int ierr);

        /// lesssummary>
        /// Add a geometrical point in the built-in CAD representation, at coordinates
        /// (`x', `y', `z'). If `meshSize' is > 0, add a meshing constraint at that
        /// point. If `tag' is positive, set the tag explicitly; otherwise a new tag is
        /// selected automatically. Return the tag of the point. (Note that the point
        /// will be added in the current model only after `synchronize' is called. This
        /// behavior holds for all the entities added in the geo module.) 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddPoint(double x, double y, double z, double meshSize, int tag, ref int ierr);

        /// lesssummary>
        /// Add a straight line segment between the two points with tags `startTag' and
        /// `endTag'. If `tag' is positive, set the tag explicitly; otherwise a new tag
        /// is selected automatically. Return the tag of the line. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddLine(int startTag, int endTag, int tag, ref int ierr);

        /// lesssummary>
        /// Add a circle arc (strictly smaller than Pi) between the two points with
        /// tags `startTag' and `endTag', with center `centertag'. If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. If (`nx', `ny', `nz') != (0,0,0), explicitly set the plane
        /// of the circle arc. Return the tag of the circle arc. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddCircleArc(int startTag, int centerTag, int endTag, int tag, double nx, double ny, double nz, ref int ierr);

        /// lesssummary>
        /// Add an ellipse arc (strictly smaller than Pi) between the two points
        /// `startTag' and `endTag', with center `centerTag' and major axis point
        /// `majorTag'. If `tag' is positive, set the tag explicitly; otherwise a new
        /// tag is selected automatically. If (`nx', `ny', `nz') != (0,0,0), explicitly
        /// set the plane of the circle arc. Return the tag of the ellipse arc. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag, double nx, double ny, double nz, ref int ierr);

        /// lesssummary>
        /// Add a spline (Catmull-Rom) curve going through the points `pointTags'. If
        /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. Create a periodic curve if the first and last points are the
        /// same. Return the tag of the spline curve. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddSpline(ref int pointTags, ulong pointTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a cubic b-spline curve with `pointTags' control points. If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. Creates a periodic curve if the first and last points are
        /// the same. Return the tag of the b-spline curve. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddBSpline(ref int pointTags, ulong pointTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a Bezier curve with `pointTags' control points. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the Bezier curve. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddBezier(ref int pointTags, ulong pointTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a curve loop (a closed wire) formed by the curves `curveTags'.
        /// `curveTags' should contain (signed) tags of model enties of dimension 1
        /// forming a closed loop: a negative tag signifies that the underlying curve
        /// is considered with reversed orientation. If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Return the tag
        /// of the curve loop. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddCurveLoop(ref int curveTags, ulong curveTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a plane surface defined by one or more curve loops `wireTags'. The
        /// first curve loop defines the exterior contour; additional curve loop define
        /// holes. If `tag' is positive, set the tag explicitly; otherwise a new tag is
        /// selected automatically. Return the tag of the surface. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddPlaneSurface(ref int wireTags, ulong wireTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a surface filling the curve loops in `wireTags'. Currently only a
        /// single curve loop is supported; this curve loop should be composed by 3 or
        /// 4 curves only. If `tag' is positive, set the tag explicitly; otherwise a
        /// new tag is selected automatically. Return the tag of the surface. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddSurfaceFilling(ref int wireTags, ulong wireTags_n, int tag, int sphereCenterTag, ref int ierr);

        /// lesssummary>
        /// Add a surface loop (a closed shell) formed by `surfaceTags'.  If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. Return the tag of the shell. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddSurfaceLoop(int[] surfaceTags, ulong surfaceTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a volume (a region) defined by one or more shells `shellTags'. The
        /// first surface loop defines the exterior boundary; additional surface loop
        /// define holes. If `tag' is positive, set the tag explicitly; otherwise a new
        /// tag is selected automatically. Return the tag of the volume. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelGeoAddVolume(int[] shellTags, ulong shellTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Extrude the model entities `dimTags' by translation along (`dx', `dy',
        /// `dz'). Return extruded entities in `outDimTags'. If `numElements' is not
        /// empty, also extrude the mesh: the entries in `numElements' give the number
        /// of elements in each layer. If `height' is not empty, it provides the
        /// (cumulative) height of the different layers, normalized to 1. If `dx' ==
        /// `dy' == `dz' == 0, the entities are extruded along their normal. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoExtrude(ref int dimTags, ulong dimTags_n, double dx, double dy, double dz, int[] outDimTags, ulong outDimTags_n, ref int numElements, ulong numElements_n, ref double heights, ulong heights_n, int recombine, ref int ierr);

        /// lesssummary>
        /// Extrude the model entities `dimTags' by rotation of `angle' radians around
        /// the axis of revolution defined by the point (`x', `y', `z') and the
        /// direction (`ax', `ay', `az'). The angle should be strictly smaller than Pi.
        /// Return extruded entities in `outDimTags'. If `numElements' is not empty,
        /// also extrude the mesh: the entries in `numElements' give the number of
        /// elements in each layer. If `height' is not empty, it provides the
        /// (cumulative) height of the different layers, normalized to 1. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoRevolve(ref int dimTags, ulong dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int[] outDimTags, ulong outDimTags_n, ref int numElements, ulong numElements_n, ref double heights, ulong heights_n, int recombine, ref int ierr);

        /// lesssummary>
        /// Extrude the model entities `dimTags' by a combined translation and rotation
        /// of `angle' radians, along (`dx', `dy', `dz') and around the axis of
        /// revolution defined by the point (`x', `y', `z') and the direction (`ax',
        /// `ay', `az'). The angle should be strictly smaller than Pi. Return extruded
        /// entities in `outDimTags'. If `numElements' is not empty, also extrude the
        /// mesh: the entries in `numElements' give the number of elements in each
        /// layer. If `height' is not empty, it provides the (cumulative) height of the
        /// different layers, normalized to 1. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoTwist(ref int dimTags, ulong dimTags_n, double x, double y, double z, double dx, double dy, double dz, double ax, double ay, double az, double angle, int[] outDimTags, ulong outDimTags_n, ref int numElements, ulong numElements_n, ref double heights, ulong heights_n, int recombine, ref int ierr);

        /// lesssummary>
        /// Translate the model entities `dimTags' along (`dx', `dy', `dz'). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoTranslate(ref int dimTags, ulong dimTags_n, double dx, double dy, double dz, ref int ierr);

        /// lesssummary>
        /// Rotate the model entities `dimTags' of `angle' radians around the axis of
        /// revolution defined by the point (`x', `y', `z') and the direction (`ax',
        /// `ay', `az'). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoRotate(ref int dimTags, ulong dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, ref int ierr);

        /// lesssummary>
        /// Scale the model entities `dimTag' by factors `a', `b' and `c' along the
        /// three coordinate axes; use (`x', `y', `z') as the center of the homothetic
        /// transformation. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoDilate(ref int dimTags, ulong dimTags_n, double x, double y, double z, double a, double b, double c, ref int ierr);

        /// lesssummary>
        /// Apply a symmetry transformation to the model entities `dimTag', with
        /// respect to the plane of equation `a' /// x + `b' /// y + `c' /// z + `d' = 0. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoSymmetrize(ref int dimTags, ulong dimTags_n, double a, double b, double c, double d, ref int ierr);

        /// lesssummary>
        /// Copy the entities `dimTags'; the new entities are returned in `outDimTags'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoCopy(ref int dimTags, ulong dimTags_n, int[] outDimTags, ulong outDimTags_n, ref int ierr);

        /// lesssummary>
        /// Remove the entities `dimTags'. If `recursive' is true, remove all the
        /// entities on their boundaries, down to dimension 0. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoRemove(ref int dimTags, ulong dimTags_n, int recursive, ref int ierr);

        /// lesssummary>
        /// Remove all duplicate entities (different entities at the same geometrical
        /// location). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoRemoveAllDuplicates(ref int ierr);

        /// lesssummary>
        /// Synchronize the built-in CAD representation with the current Gmsh model.
        /// This can be called at any time, but since it involves a non trivial amount
        /// of processing, the number of synchronization points should normally be
        /// minimized. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoSynchronize(ref int ierr);

        /// lesssummary>
        /// Set a mesh size constraint on the model entities `dimTags'. Currently only
        /// entities of dimension 0 (points) are handled. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetSize(ref int dimTags, ulong dimTags_n, double size, ref int ierr);

        /// lesssummary>
        /// Set a transfinite meshing constraint on the curve `tag', with `numNodes'
        /// nodes distributed according to `meshType' and `coef'. Currently supported
        /// types are "Progression" (geometrical progression with power `coef') and
        /// "Bump" (refinement toward both extremities of the curve). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetTransfiniteCurve(int tag, int nPoints, string meshType, double coef, ref int ierr);

        /// lesssummary>
        /// Set a transfinite meshing constraint on the surface `tag'. `arrangement'
        /// describes the arrangement of the triangles when the surface is not flagged
        /// as recombined: currently supported values are "Left", "Right",
        /// "AlternateLeft" and "AlternateRight". `cornerTags' can be used to specify
        /// the (3 or 4) corners of the transfinite interpolation explicitly;
        /// specifying the corners explicitly is mandatory if the surface has more that
        /// 3 or 4 points on its boundary. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetTransfiniteSurface(int tag, string arrangement, ref int cornerTags, ulong cornerTags_n, ref int ierr);

        /// lesssummary>
        /// Set a transfinite meshing constraint on the surface `tag'. `cornerTags' can
        /// be used to specify the (6 or 8) corners of the transfinite interpolation
        /// explicitly. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetTransfiniteVolume(int tag, ref int cornerTags, ulong cornerTags_n, ref int ierr);

        /// lesssummary>
        /// Set a recombination meshing constraint on the model entity of dimension
        /// `dim' and tag `tag'. Currently only entities of dimension 2 (to recombine
        /// triangles into quadrangles) are supported. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetRecombine(int dim, int tag, double angle, ref int ierr);

        /// lesssummary>
        /// Set a smoothing meshing constraint on the model entity of dimension `dim'
        /// and tag `tag'. `val' iterations of a Laplace smoother are applied. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetSmoothing(int dim, int tag, int val, ref int ierr);

        /// lesssummary>
        /// Set a reverse meshing constraint on the model entity of dimension `dim' and
        /// tag `tag'. If `val' is true, the mesh orientation will be reversed with
        /// respect to the natural mesh orientation (i.e. the orientation consistent
        /// with the orientation of the geometry). If `val' is false, the mesh is left
        /// as-is. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelGeoMeshSetReverse(int dim, int tag, int val, ref int ierr);

        /// lesssummary>
        /// Add a geometrical point in the OpenCASCADE CAD representation, at
        /// coordinates (`x', `y', `z'). If `meshSize' is > 0, add a meshing constraint
        /// at that point. If `tag' is positive, set the tag explicitly; otherwise a
        /// new tag is selected automatically. Return the tag of the point. (Note that
        /// the point will be added in the current model only after `synchronize' is
        /// called. This behavior holds for all the entities added in the occ module.) 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddPoint(double x, double y, double z, double meshSize, int tag, ref int ierr);

        /// lesssummary>
        /// Add a straight line segment between the two points with tags `startTag' and
        /// `endTag'. If `tag' is positive, set the tag explicitly; otherwise a new tag
        /// is selected automatically. Return the tag of the line. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddLine(int startTag, int endTag, int tag, ref int ierr);

        /// lesssummary>
        /// Add a circle arc between the two points with tags `startTag' and `endTag',
        /// with center `centerTag'. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the circle
        /// arc. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddCircleArc(int startTag, int centerTag, int endTag, int tag, ref int ierr);

        /// lesssummary>
        /// Add a circle of center (`x', `y', `z') and radius `r'. If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. If `angle1' and `angle2' are specified, create a circle arc
        /// between the two angles. Return the tag of the circle. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddCircle(double x, double y, double z, double r, int tag, double angle1, double angle2, ref int ierr);

        /// lesssummary>
        /// Add an ellipse arc between the two points `startTag' and `endTag', with
        /// center `centerTag' and major axis point `majorTag'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the ellipse arc. Note that OpenCASCADE does not allow
        /// creating ellipse arcs with the major radius smaller than the minor radius. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag, ref int ierr);

        /// lesssummary>
        /// Add an ellipse of center (`x', `y', `z') and radii `r1' and `r2' along the
        /// x- and y-axes respectively. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. If `angle1' and `angle2' are
        /// specified, create an ellipse arc between the two angles. Return the tag of
        /// the ellipse. Note that OpenCASCADE does not allow creating ellipses with
        /// the major radius (along the x-axis) smaller than or equal to the minor
        /// radius (along the y-axis): rotate the shape or use `addCircle' in such
        /// cases. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddEllipse(double x, double y, double z, double r1, double r2, int tag, double angle1, double angle2, ref int ierr);

        /// lesssummary>
        /// Add a spline (C2 b-spline) curve going through the points `pointTags'. If
        /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. Create a periodic curve if the first and last points are the
        /// same. Return the tag of the spline curve. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddSpline(int[] pointTags, ulong pointTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a b-spline curve of degree `degree' with `pointTags' control points. If
        /// `weights', `knots' or `multiplicities' are not provided, default parameters
        /// are computed automatically. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Create a periodic curve if
        /// the first and last points are the same. Return the tag of the b-spline
        /// curve. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddBSpline(int[] pointTags, ulong pointTags_n, int tag, int degree, double[] weights, ulong weights_n, double[] knots, ulong knots_n, int[] multiplicities, ulong multiplicities_n, ref int ierr);

        /// lesssummary>
        /// Add a Bezier curve with `pointTags' control points. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the Bezier curve. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddBezier(int[] pointTags, ulong pointTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a wire (open or closed) formed by the curves `curveTags'. Note that an
        /// OpenCASCADE wire can be made of curves that share geometrically identical
        /// (but topologically different) points. If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Return the tag
        /// of the wire. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddWire(int[] curveTags, ulong curveTags_n, int tag, int checkClosed, ref int ierr);

        /// lesssummary>
        /// Add a curve loop (a closed wire) formed by the curves `curveTags'.
        /// `curveTags' should contain tags of curves forming a closed loop. Note that
        /// an OpenCASCADE curve loop can be made of curves that share geometrically
        /// identical (but topologically different) points. If `tag' is positive, set
        /// the tag explicitly; otherwise a new tag is selected automatically. Return
        /// the tag of the curve loop. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddCurveLoop(int[] curveTags, ulong curveTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a rectangle with lower left corner at (`x', `y', `z') and upper right
        /// corner at (`x' + `dx', `y' + `dy', `z'). If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Round the
        /// corners if `roundedRadius' is nonzero. Return the tag of the rectangle. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddRectangle(double x, double y, double z, double dx, double dy, int tag, double roundedRadius, ref int ierr);

        /// lesssummary>
        /// Add a disk with center (`xc', `yc', `zc') and radius `rx' along the x-axis
        /// and `ry' along the y-axis. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the disk. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddDisk(double xc, double yc, double zc, double rx, double ry, int tag, ref int ierr);

        /// lesssummary>
        /// Add a plane surface defined by one or more curve loops (or closed wires)
        /// `wireTags'. The first curve loop defines the exterior contour; additional
        /// curve loop define holes. If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the
        /// surface. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddPlaneSurface(int[] wireTags, ulong wireTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a surface filling the curve loops in `wireTags'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically.
        /// Return the tag of the surface. If `pointTags' are provided, force the
        /// surface to pass through the given points. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddSurfaceFilling(int wireTag, int tag, int[] pointTags, ulong pointTags_n, ref int ierr);

        /// lesssummary>
        /// Add a surface loop (a closed shell) formed by `surfaceTags'.  If `tag' is
        /// positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. Return the tag of the surface loop. Setting `sewing' allows
        /// to build a shell made of surfaces that share geometrically identical (but
        /// topologically different) curves. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddSurfaceLoop(int[] surfaceTags, ulong surfaceTags_n, int tag, int sewing, ref int ierr);

        /// lesssummary>
        /// Add a volume (a region) defined by one or more surface loops `shellTags'.
        /// The first surface loop defines the exterior boundary; additional surface
        /// loop define holes. If `tag' is positive, set the tag explicitly; otherwise
        /// a new tag is selected automatically. Return the tag of the volume. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddVolume(int[] shellTags, ulong shellTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Add a sphere of center (`xc', `yc', `zc') and radius `r'. The optional
        /// `angle1' and `angle2' arguments define the polar angle opening (from -Pi/2
        /// to Pi/2). The optional `angle3' argument defines the azimuthal opening
        /// (from 0 to 2///Pi). If `tag' is positive, set the tag explicitly; otherwise a
        /// new tag is selected automatically. Return the tag of the sphere. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddSphere(double xc, double yc, double zc, double radius, int tag, double angle1, double angle2, double angle3, ref int ierr);

        /// lesssummary>
        /// Add a parallelepipedic box defined by a point (`x', `y', `z') and the
        /// extents along the x-, y- and z-axes. If `tag' is positive, set the tag
        /// explicitly; otherwise a new tag is selected automatically. Return the tag
        /// of the box. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddBox(double x, double y, double z, double dx, double dy, double dz, int tag, ref int ierr);

        /// lesssummary>
        /// Add a cylinder, defined by the center (`x', `y', `z') of its first circular
        /// face, the 3 components (`dx', `dy', `dz') of the vector defining its axis
        /// and its radius `r'. The optional `angle' argument defines the angular
        /// opening (from 0 to 2///Pi). If `tag' is positive, set the tag explicitly;
        /// otherwise a new tag is selected automatically. Return the tag of the
        /// cylinder. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddCylinder(double x, double y, double z, double dx, double dy, double dz, double r, int tag, double angle, ref int ierr);

        /// lesssummary>
        /// Add a cone, defined by the center (`x', `y', `z') of its first circular
        /// face, the 3 components of the vector (`dx', `dy', `dz') defining its axis
        /// and the two radii `r1' and `r2' of the faces (these radii can be zero). If
        /// `tag' is positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. `angle' defines the optional angular opening (from 0 to
        /// 2///Pi). Return the tag of the cone. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddCone(double x, double y, double z, double dx, double dy, double dz, double r1, double r2, int tag, double angle, ref int ierr);

        /// lesssummary>
        /// Add a right angular wedge, defined by the right-angle point (`x', `y', `z')
        /// and the 3 extends along the x-, y- and z-axes (`dx', `dy', `dz'). If `tag'
        /// is positive, set the tag explicitly; otherwise a new tag is selected
        /// automatically. The optional argument `ltx' defines the top extent along the
        /// x-axis. Return the tag of the wedge. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddWedge(double x, double y, double z, double dx, double dy, double dz, int tag, double ltx, ref int ierr);

        /// lesssummary>
        /// Add a torus, defined by its center (`x', `y', `z') and its 2 radii `r' and
        /// `r2'. If `tag' is positive, set the tag explicitly; otherwise a new tag is
        /// selected automatically. The optional argument `angle' defines the angular
        /// opening (from 0 to 2///Pi). Return the tag of the wedge. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshModelOccAddTorus(double x, double y, double z, double r1, double r2, int tag, double angle, ref int ierr);

        /// lesssummary>
        /// Add a volume (if the optional argument `makeSolid' is set) or surfaces
        /// defined through the open or closed wires `wireTags'. If `tag' is positive,
        /// set the tag explicitly; otherwise a new tag is selected automatically. The
        /// new entities are returned in `outDimTags'. If the optional argument
        /// `makeRuled' is set, the surfaces created on the boundary are forced to be
        /// ruled surfaces. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccAddThruSections(int[] wireTags, ulong wireTags_n, out int[] outDimTags, out ulong outDimTags_n, int tag, int makeSolid, int makeRuled, ref int ierr);

        /// lesssummary>
        /// Add a hollowed volume built from an initial volume `volumeTag' and a set of
        /// faces from this volume `excludeSurfaceTags', which are to be removed. The
        /// remaining faces of the volume become the walls of the hollowed solid, with
        /// thickness `offset'. If `tag' is positive, set the tag explicitly; otherwise
        /// a new tag is selected automatically. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccAddThickSolid(int volumeTag, int[] excludeSurfaceTags, ulong excludeSurfaceTags_n, double offset, out int[] outDimTags, out ulong outDimTags_n, int tag, ref int ierr);

        /// lesssummary>
        /// Extrude the model entities `dimTags' by translation along (`dx', `dy',
        /// `dz'). Return extruded entities in `outDimTags'. If `numElements' is not
        /// empty, also extrude the mesh: the entries in `numElements' give the number
        /// of elements in each layer. If `height' is not empty, it provides the
        /// (cumulative) height of the different layers, normalized to 1. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccExtrude(int[] dimTags, ulong dimTags_n, double dx, double dy, double dz, out int[] outDimTags, out ulong outDimTags_n, int[] numElements, ulong numElements_n, double[] heights, ulong heights_n, int recombine, ref int ierr);

        /// lesssummary>
        /// Extrude the model entities `dimTags' by rotation of `angle' radians around
        /// the axis of revolution defined by the point (`x', `y', `z') and the
        /// direction (`ax', `ay', `az'). Return extruded entities in `outDimTags'. If
        /// `numElements' is not empty, also extrude the mesh: the entries in
        /// `numElements' give the number of elements in each layer. If `height' is not
        /// empty, it provides the (cumulative) height of the different layers,
        /// normalized to 1. When the mesh is extruded the angle should be strictly
        /// smaller than 2///Pi. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccRevolve(int[] dimTags, ulong dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, out int[] outDimTags, out ulong outDimTags_n, int[] numElements, ulong numElements_n, double[] heights, ulong heights_n, int recombine, ref int ierr);

        /// lesssummary>
        /// Add a pipe by extruding the entities `dimTags' along the wire `wireTag'.
        /// Return the pipe in `outDimTags'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccAddPipe(int[] dimTags, ulong dimTags_n, int wireTag, out int[] outDimTags, out ulong outDimTags_n, ref int ierr);

        /// lesssummary>
        /// Fillet the volumes `volumeTags' on the curves `curveTags' with radii
        /// `radii'. The `radii' vector can either contain a single radius, as many
        /// radii as `curveTags', or twice as many as `curveTags' (in which case
        /// different radii are provided for the begin and end points of the curves).
        /// Return the filleted entities in `outDimTags'. Remove the original volume if
        /// `removeVolume' is set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccFillet(ref int volumeTags, ulong volumeTags_n, ref int curveTags, ulong curveTags_n, ref double radii, ulong radii_n, int[] outDimTags, ulong outDimTags_n, int removeVolume, ref int ierr);

        /// lesssummary>
        /// Chamfer the volumes `volumeTags' on the curves `curveTags' with distances
        /// `distances' measured on surfaces `surfaceTags'. The `distances' vector can
        /// either contain a single distance, as many distances as `curveTags' and
        /// `surfaceTags', or twice as many as `curveTags' and `surfaceTags' (in which
        /// case the first in each pair is measured on the corresponding surface in
        /// `surfaceTags', the other on the other adjacent surface). Return the
        /// chamfered entities in `outDimTags'. Remove the original volume if
        /// `removeVolume' is set. 
        /// less/summary>

        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccChamfer(ref int volumeTags, ulong volumeTags_n, ref int curveTags, ulong curveTags_n, ref int surfaceTags, ulong surfaceTags_n, ref double distances, ulong distances_n, int[] outDimTags, ulong outDimTags_n, int removeVolume, ref int ierr);

        /// lesssummary>
        /// Compute the boolean union (the fusion) of the entities `objectDimTags' and
        /// `toolDimTags'. Return the resulting entities in `outDimTags'. If `tag' is
        /// positive, try to set the tag explicitly (only valid if the boolean
        /// operation results in a single entity). Remove the object if `removeObject'
        /// is set. Remove the tool if `removeTool' is set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccFuse(ref int objectDimTags, ulong objectDimTags_n, ref int toolDimTags, ulong toolDimTags_n, int[] outDimTags, ulong outDimTags_n, int[][] outDimTagsMap, ulong[] outDimTagsMap_n, ulong outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr);

        /// lesssummary>
        /// Compute the boolean intersection (the common parts) of the entities
        /// `objectDimTags' and `toolDimTags'. Return the resulting entities in
        /// `outDimTags'. If `tag' is positive, try to set the tag explicitly (only
        /// valid if the boolean operation results in a single entity). Remove the
        /// object if `removeObject' is set. Remove the tool if `removeTool' is set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccIntersect(ref int objectDimTags, ulong objectDimTags_n, ref int toolDimTags, ulong toolDimTags_n, int[] outDimTags, ulong outDimTags_n, int[][] outDimTagsMap, ulong[] outDimTagsMap_n, ulong outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr);

        /// lesssummary>
        /// Compute the boolean difference between the entities `objectDimTags' and
        /// `toolDimTags'. Return the resulting entities in `outDimTags'. If `tag' is
        /// positive, try to set the tag explicitly (only valid if the boolean
        /// operation results in a single entity). Remove the object if `removeObject'
        /// is set. Remove the tool if `removeTool' is set. 
        /// less/summary>
        //[DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        //public static extern void gmshModelOccCut(int[] objectDimTags, ulong objectDimTags_n, int[] toolDimTags, ulong toolDimTags_n, out int[] outDimTags, out ulong outDimTags_n, out int*[] outDimTagsMap, out ulong[] outDimTagsMap_n, out ulong outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr);

        /// lesssummary>
        /// Compute the boolean fragments (general fuse) of the entities
        /// `objectDimTags' and `toolDimTags'. Return the resulting entities in
        /// `outDimTags'. If `tag' is positive, try to set the tag explicitly (only
        /// valid if the boolean operation results in a single entity). Remove the
        /// object if `removeObject' is set. Remove the tool if `removeTool' is set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccFragment(ref int objectDimTags, ulong objectDimTags_n, ref int toolDimTags, ulong toolDimTags_n, int[] outDimTags, ulong outDimTags_n, int[][] outDimTagsMap, ulong[] outDimTagsMap_n, ulong outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr);

        /// lesssummary>
        /// Translate the model entities `dimTags' along (`dx', `dy', `dz'). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccTranslate(ref int dimTags, ulong dimTags_n, double dx, double dy, double dz, ref int ierr);

        /// lesssummary>
        /// Rotate the model entities `dimTags' of `angle' radians around the axis of
        /// revolution defined by the point (`x', `y', `z') and the direction (`ax',
        /// `ay', `az'). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccRotate(ref int dimTags, ulong dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, ref int ierr);

        /// lesssummary>
        /// Scale the model entities `dimTag' by factors `a', `b' and `c' along the
        /// three coordinate axes; use (`x', `y', `z') as the center of the homothetic
        /// transformation. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccDilate(ref int dimTags, ulong dimTags_n, double x, double y, double z, double a, double b, double c, ref int ierr);

        /// lesssummary>
        /// Apply a symmetry transformation to the model entities `dimTag', with
        /// respect to the plane of equation `a' /// x + `b' /// y + `c' /// z + `d' = 0. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccSymmetrize(ref int dimTags, ulong dimTags_n, double a, double b, double c, double d, ref int ierr);

        /// lesssummary>
        /// Apply a general affine transformation matrix `a' (16 entries of a 4x4
        /// matrix, by row; only the 12 first can be provided for convenience) to the
        /// model entities `dimTag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccAffineTransform(ref int dimTags, ulong dimTags_n, ref double a, ulong a_n, ref int ierr);

        /// lesssummary>
        /// Copy the entities `dimTags'; the new entities are returned in `outDimTags'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccCopy(ref int dimTags, ulong dimTags_n, int[] outDimTags, ulong outDimTags_n, ref int ierr);

        /// lesssummary>
        /// Remove the entities `dimTags'. If `recursive' is true, remove all the
        /// entities on their boundaries, down to dimension 0. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccRemove(ref int dimTags, ulong dimTags_n, int recursive, ref int ierr);

        /// lesssummary>
        /// Remove all duplicate entities (different entities at the same geometrical
        /// location) after intersecting (using boolean fragments) all highest
        /// dimensional entities. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccRemoveAllDuplicates(ref int ierr);

        /// lesssummary>
        /// Apply various healing procedures to the entities `dimTags' (or to all the
        /// entities in the model if `dimTags' is empty). Return the healed entities in
        /// `outDimTags'. Available healing options are listed in the Gmsh reference
        /// manual. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccHealShapes(int[] outDimTags, ulong outDimTags_n, ref int dimTags, ulong dimTags_n, double tolerance, int fixDegenerated, int fixSmallEdges, int fixSmallFaces, int sewFaces, ref int ierr);

        /// lesssummary>
        /// Import BREP, STEP or IGES shapes from the file `fileName'. The imported
        /// entities are returned in `outDimTags'. If the optional argument
        /// `highestDimOnly' is set, only import the highest dimensional entities in
        /// the file. The optional argument `format' can be used to force the format of
        /// the file (currently "brep", "step" or "iges"). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccImportShapes(string fileName, int[] outDimTags, ulong outDimTags_n, int highestDimOnly, string format, ref int ierr);

        /// lesssummary>
        /// Imports an OpenCASCADE `shape' by providing a pointer to a native
        /// OpenCASCADE `TopoDS_Shape' object (passed as a pointer to public static extern void). The
        /// imported entities are returned in `outDimTags'. If the optional argument
        /// `highestDimOnly' is set, only import the highest dimensional entities in
        /// `shape'. For C and C++ only. Warning: this function is unsafe, as providing
        /// an invalid pointer will lead to undefined behavior. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccImportShapesNativePointer(object shape, int[] outDimTags, ulong outDimTags_n, int highestDimOnly, ref int ierr);

        /// lesssummary>
        /// Set a mesh size constraint on the model entities `dimTags'. Currently only
        /// entities of dimension 0 (points) are handled. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccSetMeshSize(ref int dimTags, ulong dimTags_n, double size, ref int ierr);

        /// lesssummary>
        /// Get the mass of the model entity of dimension `dim' and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccGetMass(int dim, int tag, ref double mass, ref int ierr);

        /// lesssummary>
        /// Get the center of mass of the model entity of dimension `dim' and tag
        /// `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccGetCenterOfMass(int dim, int tag, ref double x, ref double y, ref double z, ref int ierr);

        /// lesssummary>
        /// Get the matrix of inertia (by row) of the model entity of dimension `dim'
        /// and tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccGetMatrixOfInertia(int dim, int tag, double[] mat, ulong mat_n, ref int ierr);

        /// lesssummary>
        /// Synchronize the OpenCASCADE CAD representation with the current Gmsh model.
        /// This can be called at any time, but since it involves a non trivial amount
        /// of processing, the number of synchronization points should normally be
        /// minimized. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshModelOccSynchronize(ref int ierr);

        /// lesssummary>
        /// Add a new post-processing view, with name `name'. If `tag' is positive use
        /// it (and remove the view with that tag if it already exists), otherwise
        /// associate a new tag. Return the view tag. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshViewAdd(string name, int tag, ref int ierr);

        /// lesssummary>
        /// Remove the view with tag `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewRemove(int tag, ref int ierr);

        /// lesssummary>
        /// Get the index of the view with tag `tag' in the list of currently loaded
        /// views. This dynamic index (it can change when views are removed) is used to
        /// access view options. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshViewGetIndex(int tag, ref int ierr);

        /// lesssummary>
        /// Get the tags of all views. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewGetTags(int[] tags, ulong tags_n, ref int ierr);

        /// lesssummary>
        /// Add model-based post-processing data to the view with tag `tag'.
        /// `modelName' identifies the model the data is attached to. `dataType'
        /// specifies the type of data, currently either "NodeData", "ElementData" or
        /// "ElementNodeData". `step' specifies the identifier (>= 0) of the data in a
        /// sequence. `tags' gives the tags of the nodes or elements in the mesh to
        /// which the data is associated. `data' is a vector of the same length as
        /// `tags': each entry is the vector of double precision numbers representing
        /// the data associated with the corresponding tag. The optional `time'
        /// argument associate a time value with the data. `numComponents' gives the
        /// number of data components (1 for scalar data, 3 for vector data, etc.) per
        /// entity; if negative, it is automatically inferred (when possible) from the
        /// input data. `partition' allows to specify data in several sub-sets. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewAddModelData(int tag, int step, string modelName, string dataType, ulong tags, ulong tags_n, double[] data, ulong data_n, ulong data_nn, double time, int numComponents, int partition, ref int ierr);

        /// lesssummary>
        /// Get model-based post-processing data from the view with tag `tag' at step
        /// `step'. Return the `data' associated to the nodes or the elements with tags
        /// `tags', as well as the `dataType' and the number of components
        /// `numComponents'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewGetModelData(int tag, int step, string[] dataType, ulong[] tags, ulong tags_n, double[][] data, ulong[] data_n, ulong data_nn, ref double time, ref int numComponents, ref int ierr);

        /// lesssummary>
        /// Add list-based post-processing data to the view with tag `tag'. `dataType'
        /// identifies the data: "SP" for scalar points, "VP", for vector points, etc.
        /// `numEle' gives the number of elements in the data. `data' contains the data
        /// for the `numEle' elements. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewAddListData(int tag, string dataType, int numEle, ref double data, ulong data_n, ref int ierr);

        /// lesssummary>
        /// Get list-based post-processing data from the view with tag `tag'. Return
        /// the types `dataTypes', the number of elements `numElements' for each data
        /// type and the `data' for each data type. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewGetListData(int tag, string[][] dataType, ulong dataType_n, int[] numElements, ulong numElements_n, double[][] data, ulong[] data_n, ulong data_nn, ref int ierr);

        /// lesssummary>
        /// Add a post-processing view as an `alias' of the reference view with tag
        /// `refTag'. If `copyOptions' is set, copy the options of the reference view.
        /// If `tag' is positive use it (and remove the view with that tag if it
        /// already exists), otherwise associate a new tag. Return the view tag. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshViewAddAlias(int refTag, int copyOptions, int tag, ref int ierr);

        /// lesssummary>
        /// Copy the options from the view with tag `refTag' to the view with tag
        /// `tag'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewCopyOptions(int refTag, int tag, ref int ierr);

        /// lesssummary>
        /// Combine elements (if `what' == "elements") or steps (if `what' == "steps")
        /// of all views (`how' == "all"), all visible views (`how' == "visible") or
        /// all views having the same name (`how' == "name"). Remove original views if
        /// `remove' is set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewCombine(string what, string how, int remove, ref int ierr);

        /// lesssummary>
        /// Probe the view `tag' for its `value' at point (`x', `y', `z'). Return only
        /// the value at step `step' is `step' is positive. Return only values with
        /// `numComp' if `numComp' is positive. Return the gradient of the `value' if
        /// `gradient' is set. Probes with a geometrical tolerance (in the reference
        /// unit cube) of `tolerance' if `tolerance' is not zero. Return the result
        /// from the element described by its coordinates if `xElementCoord',
        /// `yElementCoord' and `zElementCoord' are provided. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewProbe(int tag, double x, double y, double z, double[] value, ulong value_n, int step, int numComp, int gradient, double tolerance, ref double xElemCoord, ulong xElemCoord_n, ref double yElemCoord, ulong yElemCoord_n, ref double zElemCoord, ulong zElemCoord_n, ref int ierr);

        /// lesssummary>
        /// Write the view to a file `fileName'. The export format is determined by the
        /// file extension. Append to the file if `append' is set. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshViewWrite(int tag, string fileName, int append, ref int ierr);

        /// lesssummary>
        /// Set the numerical option `option' to the value `value' for plugin `name'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshPluginSetNumber(string name, string option, double value, ref int ierr);

        /// lesssummary>
        /// Set the string option `option' to the value `value' for plugin `name'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshPluginSetString(string name, string option, string value, ref int ierr);

        /// lesssummary>
        /// Run the plugin `name'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshPluginRun(string name, ref int ierr);

        /// lesssummary>
        /// Draw all the OpenGL scenes. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshGraphicsDraw(ref int ierr);

        /// lesssummary>
        /// Create the FLTK graphical user interface. Can only be called in the main
        /// thread. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkInitialize(ref int ierr);

        /// lesssummary>
        /// Wait at most `time' seconds for user interface events and return. If `time'
        /// less 0, wait indefinitely. First automatically create the user interface if it
        /// has not yet been initialized. Can only be called in the main thread. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkWait(double time, ref int ierr);

        /// lesssummary>
        /// Update the user interface (potentially creating new widgets and windows).
        /// First automatically create the user interface if it has not yet been
        /// initialized. Can only be called in the main thread: use `awake("update")'
        /// to trigger an update of the user interface from another thread. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkUpdate(ref int ierr);

        /// lesssummary>
        /// Awake the main user interface thread and process pending events, and
        /// optionally perform an action (currently the only `action' allowed is
        /// "update"). 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkAwake(string action, ref int ierr);

        /// lesssummary>
        /// Block the current thread until it can safely modify the user interface. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkLock(ref int ierr);

        /// lesssummary>
        /// Release the lock that was set using lock. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkUnlock(ref int ierr);

        /// lesssummary>
        /// Run the event loop of the graphical user interface, i.e. repeatedly call
        /// `wait()'. First automatically create the user interface if it has not yet
        /// been initialized. Can only be called in the main thread. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshFltkRun(ref int ierr);

        /// lesssummary>
        /// Select entities in the user interface. If `dim' is >= 0, return only the
        /// entities of the specified dimension (e.g. points if `dim' == 0). 
        /// less/summary>

        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshFltkSelectEntities(int[] dimTags, ulong dimTags_n, int dim, ref int ierr);

        /// lesssummary>
        /// Select elements in the user interface. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshFltkSelectElements(ulong[] elementTags, ulong elementTags_n, ref int ierr);

        /// lesssummary>
        /// Select views in the user interface. 
        /// less/summary>

        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gmshFltkSelectViews(int[] viewTags, ulong viewTags_n, ref int ierr);

        /// lesssummary>
        /// Set one or more parameters in the ONELAB database, encoded in `format'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabSet(string data, string format, ref int ierr);

        /// lesssummary>
        /// Get all the parameters (or a single one if `name' is specified) from the
        /// ONELAB database, encoded in `format'. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabGet(string[] data, string name, string format, ref int ierr);

        /// lesssummary>
        /// Set the value of the number parameter `name' in the ONELAB database. Create
        /// the parameter if it does not exist; update the value if the parameter
        /// exists. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabSetNumber(string name, ref double value, ulong value_n, ref int ierr);

        /// lesssummary>
        /// Set the value of the string parameter `name' in the ONELAB database. Create
        /// the parameter if it does not exist; update the value if the parameter
        /// exists. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabSetString(string name, string[] value, ulong value_n, ref int ierr);

        /// lesssummary>
        /// Get the value of the number parameter `name' from the ONELAB database.
        /// Return an empty vector if the parameter does not exist. 
        /// less/summary>

        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabGetNumber(string name, double[] value, ulong value_n, ref int ierr);

        /// lesssummary>
        /// Get the value of the string parameter `name' from the ONELAB database.
        /// Return an empty vector if the parameter does not exist. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabGetString(string name, string[][] value, ulong value_n, ref int ierr);

        /// lesssummary>
        /// Clear the ONELAB database, or remove a single parameter if `name' is given. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabClear(string name, ref int ierr);

        /// lesssummary>
        /// Run a ONELAB client. If `name' is provided, create a new ONELAB client with
        /// name `name' and executes `command'. If not, try to run a client that might
        /// be linked to the processed input files. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshOnelabRun(string name, string command, ref int ierr);

        /// lesssummary>
        /// Write a `message'. `level' can be "info", "warning" or "error". 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshLoggerWrite(string message, string level, ref int ierr);

        /// lesssummary>
        /// Start logging messages. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshLoggerStart(ref int ierr);

        /// lesssummary>
        /// Get logged messages. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshLoggerGet(ref IntPtr log, ref uint log_n, ref int ierr);

        /// lesssummary>
        /// Stop logging messages. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gmshLoggerStop(ref int ierr);

        /// lesssummary>
        /// Return wall clock time. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern double gmshLoggerTime(ref int ierr);

        /// lesssummary>
        /// Return CPU time. 
        /// less/summary>
        [DllImport(gmshdllname, CallingConvention = CallingConvention.Cdecl)]
        public static extern double gmshLoggerCputime(ref int ierr);
    }
}