using Gmsh_warp;
using System;
using System.Drawing;
using System.Reflection;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        ///  Model functions
        /// </summary>
        public static partial class Model
        {
            /// <summary>
            /// Add a new model, with name `name', and set it as the current model.
            /// </summary>
            public static void Add(string name)
            {
                Gmsh_Warp.GmshModelAdd(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Remove the current model.
            /// </summary>
            public static void Remove()
            {
                Gmsh_Warp.GmshModelRemove(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// List the names of all models.
            /// </summary>
            public static string[] List()
            {
                unsafe
                {
                    byte** names_ptr;
                    long name_n = 0;
                    Gmsh_Warp.GmshModelList(&names_ptr, ref name_n, ref Gmsh._staticreff);
                    var names = UnsafeHelp.ToString(names_ptr, name_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return names;
                }
            }

            /// <summary>
            /// Get the name of the current model.
            /// </summary>
            public static string GetCurrent()
            {
                unsafe
                {
                    byte* nameptr;
                    Gmsh_Warp.GmshModelGetCurrent(&nameptr, ref Gmsh._staticreff);
                    var array = UnsafeHelp.ToString(nameptr);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return array;
                }
            }

            /// <summary>
            /// Set the current model to the model with name `name'. If several models have
            /// the same name, select the one that was added first.
            /// </summary>
            public static void SetCurrent(string name)
            {
                Gmsh_Warp.GmshModelSetCurrent(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get all the entities in the current model. If `dim' is >= 0, return only the
            /// entities of the specified dimension (e.g. points if `dim' == 0). The
            /// entities are returned as a vector of (dim, tag) integer pairs.
            /// </summary>
            public static ValueTuple<int, int>[] GetEntities(int dim = -1)
            {
                unsafe
                {
                    int* dimTags_ptr;
                    long dimTags_n = 0;
                    Gmsh_Warp.GmshModelGetEntities(&dimTags_ptr, ref dimTags_n, dim, ref Gmsh._staticreff);
                    var array = UnsafeHelp.ToIntArray(dimTags_ptr, dimTags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return array.ToIntPair();
                }
            }

            /// <summary>
            /// Set the name of the entity of dimension `dim' and tag `tag'.
            /// </summary>
            public static void SetEntityName(int dim, int tag, string name)
            {
                Gmsh_Warp.GmshModelSetEntityName(dim, tag, name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the name of the entity of dimension `dim' and tag `tag'.
            /// </summary>
            public static string GetEntitiesName(int dim, int tag)
            {
                unsafe
                {
                    byte* nameptr;
                    Gmsh_Warp.GmshModelGetEntityName(dim, tag, &nameptr, ref Gmsh._staticreff);
                    var name = UnsafeHelp.ToString(nameptr);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return name;
                }
            }

            /// <summary>
            /// Get all the physical groups in the current model. If `dim' is >= 0, return
            /// only the entities of the specified dimension (e.g. physical points if `dim'
            /// == 0). The entities are returned as a vector of (dim, tag) integer pairs.
            /// </summary>
            public static ValueTuple<int, int>[] GetPhysicalGroups(int dim = -1)
            {
                unsafe
                {
                    int* dimTags_ptr;
                    long dimTags_n = 0;
                    Gmsh_Warp.GmshModelGetPhysicalGroups(&dimTags_ptr, ref dimTags_n, dim, ref Gmsh._staticreff);
                    var array = UnsafeHelp.ToIntArray(dimTags_ptr, dimTags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return array.ToIntPair();
                }
            }

            /// <summary>
            /// Get the tags of the model entities making up the physical group of dimension
            /// `dim' and tag `tag'.
            /// </summary>
            public static int[] GetEntitiesForPhysicalGroup(int dim, int tag)
            {
                unsafe
                {
                    int* tags_ptr;
                    long tags_n = default;
                    Gmsh_Warp.GmshModelGetEntitiesForPhysicalGroup(dim, tag, &tags_ptr, ref tags_n, ref Gmsh._staticreff);
                    var physicalTags = UnsafeHelp.ToIntArray(tags_ptr, tags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return physicalTags;
                }
            }

            /// <summary>
            /// Get the tags of the physical groups (if any) to which the model entity of
            /// dimension `dim' and tag `tag' belongs.
            /// </summary>
            public static int[] GetPhysicalGroupsForEntity(int dim, int tag)
            {
                unsafe
                {
                    int* physicalTagsptr;
                    long physicalTags_n = default;
                    Gmsh_Warp.GmshModelGetPhysicalGroupsForEntity(dim, tag, &physicalTagsptr, ref physicalTags_n, ref Gmsh._staticreff);
                    var physicalTags = UnsafeHelp.ToIntArray(physicalTagsptr, physicalTags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return physicalTags;
                }
            }

            /// <summary>
            /// Add a physical group of dimension `dim', grouping the model entities with
            /// tags `tags'. Return the tag of the physical group, equal to `tag' if `tag'
            /// is positive, or a new tag if `tag' < 0.
            /// </summary>
            public static int AddPhysicalGroup(int dim, int[] tags, int tag = -1)
            {
                var index = Gmsh_Warp.GmshModelAddPhysicalGroup(dim, tags, tags.LongLength, tag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return index;
            }

            /// <summary>
            /// Set the name of the physical group of dimension `dim' and tag `tag'.
            /// </summary>
            public static void SetPhysicalName(int dim, int tag, string name)
            {
                Gmsh_Warp.GmshModelSetPhysicalName(dim, tag, name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the name of the physical group of dimension `dim' and tag `tag'.
            /// </summary>
            public static string GetPhysicalName(int dim, int tag)
            {
                unsafe
                {
                    byte* nameptr;
                    Gmsh_Warp.GmshModelGetPhysicalName(dim, tag, &nameptr, ref Gmsh._staticreff);
                    var name = UnsafeHelp.ToString(nameptr);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return name;
                }
            }

            /// <summary>
            /// Get the boundary of the model entities `dimTags'. Return in `outDimTags' the
            /// boundary of the individual entities (if `combined' is false) or the boundary
            /// of the combined geometrical shape formed by all input entities (if
            /// `combined' is true). Return tags multiplied by the sign of the boundary
            /// entity if `oriented' is true. Apply the boundary operator recursively down
            /// to dimension 0 (i.e. to points) if `recursive' is true.
            /// </summary>
            public static ValueTuple<int, int>[] GetBoundary(ValueTuple<int, int>[] dimTags, bool combined = true, bool oriented = true, bool recursive = false)
            {
                unsafe
                {
                    int* outDimTagsptr;
                    long outdimTags_n = 0;
                    var dimarray = dimTags.ToIntArray();
                    Gmsh_Warp.GmshModelGetBoundary(dimarray, dimarray.LongLength, &outDimTagsptr, ref outdimTags_n, Convert.ToInt32(combined), Convert.ToInt32(oriented), Convert.ToInt32(recursive), ref Gmsh._staticreff);

                    var array = UnsafeHelp.ToIntArray(outDimTagsptr, outdimTags_n);
                    var outDimTags = array.ToIntPair();

                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return outDimTags;
                }
            }

            /// <summary>
            /// Get the model entities in the bounding box defined by the two points
            /// (`xmin', `ymin', `zmin') and (`xmax', `ymax', `zmax'). If `dim' is >= 0,
            /// return only the entities of the specified dimension (e.g. points if `dim' ==
            /// 0).
            /// </summary>
            public static ValueTuple<int, int>[] GetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int dim = -1)
            {
                unsafe
                {
                    int* tags_ptr;
                    long tags_n = 0;
                    Gmsh_Warp.GmshModelGetEntitiesInBoundingBox(xmin, ymin, zmin, xmax, ymax, zmax, &tags_ptr, ref tags_n, dim, ref Gmsh._staticreff);
                    var pairs = UnsafeHelp.ToIntArray(tags_ptr, tags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return pairs.ToIntPair();
                }
            }

            /// <summary>
            /// Get the bounding box (`xmin', `ymin', `zmin'), (`xmax', `ymax', `zmax') of
            /// the model entity of dimension `dim' and tag `tag'. If `dim' and `tag' are
            /// negative, get the bounding box of the whole model.
            /// </summary>
            public static void GetBoundingBox(int dim, int tag, out double xmin, out double ymin, out double zmin, out double xmax, out double ymax, out double zmax)
            {
                xmin = 0; ymin = 0; zmin = 0; xmax = 0; ymax = 0; zmax = 0;
                Gmsh_Warp.GmshModelGetBoundingBox(dim, tag, ref xmin, ref ymin, ref zmin, ref xmax, ref ymax, ref zmax, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the geometrical dimension of the current model.
            /// </summary>
            public static int GetDimension()
            {
                var index = Gmsh_Warp.GmshModelGetDimension(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return index;
            }

            /// <summary>
            /// Add a discrete model entity (defined by a mesh) of dimension `dim' in the
            /// current model. Return the tag of the new discrete entity, equal to `tag' if
            /// `tag' is positive, or a new tag if `tag' < 0. `boundary' specifies the tags
            /// of the entities on the boundary of the discrete entity, if any. Specifying
            /// `boundary' allows Gmsh to construct the topology of the overall model.
            /// </summary>
            public static void AddDiscreteEntity(int dim, int tag, int[] boundary = default)
            {
                if (boundary == default) boundary = new int[0];
                Gmsh_Warp.GmshModelAddDiscreteEntity(dim, tag, boundary, boundary.LongLength, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Remove the entities `dimTags' of the current model. If `recursive' is true,
            /// remove all the entities on their boundaries, down to dimension 0.
            /// </summary>
            public static void RemoveEntities(ValueTuple<int, int>[] dimTags, bool recursive = false)
            {
                var dimTags_array = dimTags.ToIntArray();
                Gmsh_Warp.GmshModelRemoveEntities(dimTags_array, dimTags_array.LongLength, Convert.ToInt32(recursive), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Remove the entity name `name' from the current model.
            /// </summary>
            public static void RemoveEntityName(string name)
            {
                Gmsh_Warp.GmshModelRemoveEntityName(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Remove the physical groups `dimTags' of the current model. If `dimTags' is
            /// empty, remove all groups.
            /// </summary>
            public static void RemovePhysicalGroups(ValueTuple<int, int>[] dimTags)
            {
                var dimTags_array = dimTags.ToIntArray();
                Gmsh_Warp.GmshModelRemovePhysicalGroups(dimTags_array, dimTags_array.LongLength, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Remove the entity name `name' from the current model.
            /// </summary>
            public static void RemovePhysicalName(string name)
            {
                Gmsh_Warp.GmshModelRemovePhysicalName(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the type of the entity of dimension `dim' and tag `tag'.
            /// </summary>
            public static string GetType(int dim, int tag)
            {
                unsafe
                {
                    byte* entityTypeptr;
                    Gmsh_Warp.GmshModelGetType(dim, tag, &entityTypeptr, ref Gmsh._staticreff);
                    var typename = UnsafeHelp.ToString(entityTypeptr);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return typename;
                }
            }

            /// <summary>
            /// In a partitioned model, get the parent of the entity of dimension `dim' and
            /// tag `tag', i.e. from which the entity is a part of, if any. `parentDim' and
            /// `parentTag' are set to -1 if the entity has no parent.
            /// </summary>
            public static void GetParent(int dim, int tag, out int parentDim, out int parentTag)
            {
                parentDim = default;
                parentTag = default;
                Gmsh_Warp.GmshModelGetParent(dim, tag, ref parentDim, ref parentTag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// In a partitioned model, return the tags of the partition(s) to which the
            /// entity belongs.
            /// </summary>
            public static int[] GetPartitions(int dim, int tag)
            {
                unsafe
                {
                    int* partitions_ptr;
                    long partitions_n = default;
                    Gmsh_Warp.GmshModelGetPartitions(dim, tag, &partitions_ptr, ref partitions_n, ref Gmsh._staticreff);
                    var partitions = UnsafeHelp.ToIntArray(partitions_ptr, partitions_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return partitions;
                }
            }

            /// <summary>
            /// Evaluate the parametrization of the entity of dimension `dim' and tag `tag'
            /// at the parametric coordinates `parametricCoord'. Only valid for `dim' equal
            /// to 0 (with empty `parametricCoord'), 1 (with `parametricCoord' containing
            /// parametric coordinates on the curve) or 2 (with `parametricCoord' containing
            /// pairs of u, v parametric coordinates on the surface, concatenated: [p1u,
            /// p1v, p2u, ...]). Return triplets of x, y, z coordinates in `coord',
            /// concatenated: [p1x, p1y, p1z, p2x, ...].
            /// </summary>
            public static double[] GetValue(int dim, int tag, double[] parametricCoord)
            {
                unsafe
                {
                    double* ptr;
                    long outcount = 0;
                    Gmsh_Warp.GmshModelGetValue(dim, tag, parametricCoord, parametricCoord.LongLength, &ptr, ref outcount, ref Gmsh._staticreff);
                    var coord = UnsafeHelp.ToDoubleArray(ptr, outcount);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return coord;
                }
            }

            /// <summary>
            /// Evaluate the derivative of the parametrization of the entity of dimension
            /// `dim' and tag `tag' at the parametric coordinates `parametricCoord'. Only
            /// valid for `dim' equal to 1 (with `parametricCoord' containing parametric
            /// coordinates on the curve) or 2 (with `parametricCoord' containing pairs of
            /// u, v parametric coordinates on the surface, concatenated: [p1u, p1v, p2u,
            /// ...]). For `dim' equal to 1 return the x, y, z components of the derivative
            /// with respect to u [d1ux, d1uy, d1uz, d2ux, ...]; for `dim' equal to 2 return
            /// the x, y, z components of the derivate with respect to u and v: [d1ux, d1uy,
            /// d1uz, d1vx, d1vy, d1vz, d2ux, ...].
            /// </summary>
            public static double[] GetDerivative(int dim, int tag, double[] parametricCoord)
            {
                unsafe
                {
                    double* ptr;
                    long outcount = 0;
                    Gmsh_Warp.GmshModelGetDerivative(dim, tag, parametricCoord, parametricCoord.LongLength, &ptr, ref outcount, ref Gmsh._staticreff);
                    var derivatives = UnsafeHelp.ToDoubleArray(ptr, outcount);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return derivatives;
                }
            }

            /// <summary>
            /// Evaluate the (maximum) curvature of the entity of dimension `dim' and tag
            /// `tag' at the parametric coordinates `parametricCoord'. Only valid for `dim'
            /// equal to 1 (with `parametricCoord' containing parametric coordinates on the
            /// curve) or 2 (with `parametricCoord' containing pairs of u, v parametric
            /// coordinates on the surface, concatenated: [p1u, p1v, p2u, ...]).
            /// </summary>
            public static double[] GetCurvature(int dim, int tag, double[] parametricCoord)
            {
                unsafe
                {
                    double* ptr;
                    long outcount = 0;
                    Gmsh_Warp.GmshModelGetCurvature(dim, tag, parametricCoord, parametricCoord.LongLength, &ptr, ref outcount, ref Gmsh._staticreff);
                    var curvatures = UnsafeHelp.ToDoubleArray(ptr, outcount);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return curvatures;
                }
            }

            /// <summary>
            /// Evaluate the principal curvatures of the surface with tag `tag' at the
            /// parametric coordinates `parametricCoord', as well as their respective
            /// directions. `parametricCoord' are given by pair of u and v coordinates,
            /// concatenated: [p1u, p1v, p2u, ...].
            /// </summary>
            public static void GetPrincipalCurvatures(int dim, double[] parametricCoord, out double[] curvatureMax, out double[] curvatureMin, out double[] directionMax, out double[] directionMin)
            {
                unsafe
                {
                    double* curvatureMax_ptr;
                    long curvatureMax_n = 0;
                    double* curvatureMin_ptr;
                    long curvatureMin_n = 0;
                    double* directionMax_ptr;
                    long directionMax_n = 0;
                    double* directionMin_ptr;
                    long directionMin_n = 0;
                    Gmsh_Warp.GmshModelGetPrincipalCurvatures(dim, parametricCoord, parametricCoord.LongLength,
                        &curvatureMax_ptr, ref curvatureMax_n,
                        &curvatureMin_ptr, ref curvatureMin_n,
                        &directionMax_ptr, ref directionMax_n,
                        &directionMin_ptr, ref directionMin_n,
                        ref Gmsh._staticreff);
                    curvatureMax = UnsafeHelp.ToDoubleArray(curvatureMax_ptr, curvatureMax_n);
                    curvatureMin = UnsafeHelp.ToDoubleArray(curvatureMin_ptr, curvatureMin_n);
                    directionMax = UnsafeHelp.ToDoubleArray(directionMax_ptr, directionMax_n);
                    directionMin = UnsafeHelp.ToDoubleArray(directionMin_ptr, directionMin_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Get the normal to the surface with tag `tag' at the parametric coordinates
            /// `parametricCoord'. `parametricCoord' are given by pairs of u and v
            /// coordinates, concatenated: [p1u, p1v, p2u, ...]. `normals' are returned as
            /// triplets of x, y, z components, concatenated: [n1x, n1y, n1z, n2x, ...].
            /// </summary>
            public static double[] GetNormal(int tag, double[] parametricCoord)
            {
                unsafe
                {
                    double* ptr;
                    long outcount = 0;
                    Gmsh_Warp.GmshModelGetNormal(tag, parametricCoord, parametricCoord.LongLength, &ptr, ref outcount, ref Gmsh._staticreff);
                    var normals = UnsafeHelp.ToDoubleArray(ptr, outcount);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return normals;
                }
            }

            /// <summary>
            /// Get the parametric coordinates `parametricCoord' for the points `coord' on
            /// the entity of dimension `dim' and tag `tag'. `coord' are given as triplets
            /// of x, y, z coordinates, concatenated: [p1x, p1y, p1z, p2x, ...].
            /// `parametricCoord' returns the parametric coordinates t on the curve (if
            /// `dim' = 1) or pairs of u and v coordinates concatenated on the surface (if
            /// `dim' = 2), i.e. [p1t, p2t, ...] or [p1u, p1v, p2u, ...].
            /// </summary>
            public static double[] GetParametrization(int dim, int tag, double[] coord)
            {
                unsafe
                {
                    double* ptr;
                    long outcount = 0;
                    Gmsh_Warp.GmshModelGetParametrization(dim, tag, coord, coord.LongLength, &ptr, ref outcount, ref Gmsh._staticreff);
                    var parametricCoord = UnsafeHelp.ToDoubleArray(ptr, outcount);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return parametricCoord;
                }
            }

            /// <summary>
            /// Get the `min' and `max' bounds of the parametric coordinates for the entity
            /// of dimension `dim' and tag `tag'.
            /// </summary>
            public static void GetParametrizationBounds(int dim, int tag, out double[] min, out double[] max)
            {
                unsafe
                {
                    double* min_ptr;
                    long min_n = 0;
                    double* max_ptr;
                    long max_n = 0;

                    Gmsh_Warp.GmshModelGetParametrizationBounds(dim, tag, &min_ptr, ref min_n, &max_ptr, ref max_n, ref Gmsh._staticreff);
                    min = UnsafeHelp.ToDoubleArray(min_ptr, min_n);
                    max = UnsafeHelp.ToDoubleArray(max_ptr, max_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Check if the parametric coordinates provided in `parametricCoord' correspond
            /// to points inside the entitiy of dimension `dim' and tag `tag', and return
            /// the number of points inside. This feature is only available for a subset of
            /// curves and surfaces, depending on the underyling geometrical representation.
            /// </summary>
            public static int IsInside(int dim, int tag, double[] parametricCoord)
            {
                var index = Gmsh_Warp.GmshModelIsInside(dim, tag, parametricCoord, parametricCoord.LongLength, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return index;
            }

            /// <summary>
            /// Get the points `closestCoord' on the entity of dimension `dim' and tag `tag'
            /// to the points `coord', by orthogonal projection. `coord' and `closestCoord'
            /// are given as triplets of x, y, z coordinates, concatenated: [p1x, p1y, p1z,
            /// p2x, ...]. `parametricCoord' returns the parametric coordinates t on the
            /// curve (if `dim' = 1) or pairs of u and v coordinates concatenated on the
            /// surface (if `dim' = 2), i.e. [p1t, p2t, ...] or [p1u, p1v, p2u, ...].
            /// </summary>
            public static void GetClosestPoint(int dim, int tag, double[] coord, out double[] closestCoord, out double[] parametricCoord)
            {
                unsafe
                {
                    double* closestCoord_ptr;
                    long closestCoord_n = 0;
                    double* parametricCoord_ptr;
                    long parametricCoord_n = 0;

                    Gmsh_Warp.GmshModelGetClosestPoint(dim, tag, coord, coord.LongLength, &closestCoord_ptr, ref closestCoord_n, &parametricCoord_ptr, ref parametricCoord_n, ref Gmsh._staticreff);
                    closestCoord = UnsafeHelp.ToDoubleArray(closestCoord_ptr, closestCoord_n);
                    parametricCoord = UnsafeHelp.ToDoubleArray(parametricCoord_ptr, parametricCoord_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Reparametrize the boundary entity (point or curve, i.e. with `dim' == 0 or
            /// `dim' == 1) of tag `tag' on the surface `surfaceTag'. If `dim' == 1,
            /// reparametrize all the points corresponding to the parametric coordinates
            /// `parametricCoord'. Multiple matches in case of periodic surfaces can be
            /// selected with `which'. This feature is only available for a subset of
            /// entities, depending on the underyling geometrical representation.
            /// </summary>
            public static void ReparametrizeOnSurface(int dim, int tag, double[] parametricCoord, int surfaceTag, out double[] surfaceParametricCoord, int which = 0)
            {
                unsafe
                {
                    double* surfaceParametricCoord_ptr;
                    long surfaceParametricCoord_n = 0;

                    Gmsh_Warp.GmshModelReparametrizeOnSurface(dim, tag, parametricCoord, parametricCoord.LongLength, surfaceTag, &surfaceParametricCoord_ptr, ref surfaceParametricCoord_n, which, ref Gmsh._staticreff);
                    surfaceParametricCoord = UnsafeHelp.ToDoubleArray(surfaceParametricCoord_ptr, surfaceParametricCoord_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Set the visibility of the model entities `dimTags' to `value'. Apply the
            /// visibility setting recursively if `recursive' is true.
            /// </summary>
            public static void SetVisibility(ValueTuple<int, int>[] dimTags, int value, bool recursive = false)
            {
                var dimTags_array = dimTags.ToIntArray();
                Gmsh_Warp.GmshModelSetVisibility(dimTags_array, dimTags_array.LongLength, value, Convert.ToInt32(recursive), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the visibility of the model entity of dimension `dim' and tag `tag'.
            /// </summary>
            public static int GetVisibility(int dim, int tag)
            {
                int value = 0;
                Gmsh_Warp.GmshModelGetVisibility(dim, tag, ref value, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return value;
            }

            public static void SetColor(ValueTuple<int, int>[] dimTags, Color color, bool recursive = false)
            {
                SetColor(dimTags, color.R, color.G, color.B, color.A, recursive);
            }

            /// <summary>
            /// Set the color of the model entities `dimTags' to the RGBA value (`r', `g',
            /// `b', `a'), where `r', `g', `b' and `a' should be integers between 0 and 255.
            /// Apply the color setting recursively if `recursive' is true.
            /// </summary>
            public static void SetColor(ValueTuple<int, int>[] dimTags, int r, int g, int b, int a = 255, bool recursive = false)
            {
                var dimarray = dimTags.ToIntArray();
                Gmsh_Warp.GmshModelSetColor(dimarray, dimarray.LongLength, r, g, b, a, Convert.ToInt32(recursive), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the color of the model entity of dimension `dim' and tag `tag'.
            /// </summary>
            public static void GetColor(int dim, int tag, out int r, out int g, out int b, out int a)
            {
                r = 0; g = 0; b = 0; a = 0;
                Gmsh_Warp.GmshModelGetColor(dim, tag, ref r, ref g, ref b, ref a, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            public static Color GetColor(int dim, int tag)
            {
                GetColor(dim, tag, out int r, out int g, out int b, out int a);
                return Color.FromArgb(a, r, g, b);
            }

            /// <summary>
            /// Set the `x', `y', `z' coordinates of a geometrical point.
            /// </summary>
            public static void SetCoordinates(int tag, double x, double y, double z)
            {
                Gmsh_Warp.GmshModelSetCoordinates(tag, x, y, z, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}