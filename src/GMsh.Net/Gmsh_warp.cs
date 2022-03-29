using System.Runtime.InteropServices;
using System.Security;

namespace Gmsh_warp
{
    internal unsafe partial class Gmsh_Warp
    {
        internal partial struct __Internal
        {
            private const string dllname = "gmsh-4.9.dll";

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFree")]
            internal static extern void GmshFree(global::System.IntPtr p);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshMalloc")]
            internal static extern global::System.IntPtr GmshMalloc(long n);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshInitialize")]
            internal static extern void GmshInitialize(int argc, byte** argv, int readConfigFiles, int run, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshIsInitialized")]
            internal static extern int GmshIsInizialized(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFinalize")]
            internal static extern void GmshFinalize(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOpen")]
            internal static extern void GmshOpen([MarshalAs(UnmanagedType.LPStr)] string fileName, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshMerge")]
            internal static extern void GmshMerge([MarshalAs(UnmanagedType.LPStr)] string fileName, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshWrite")]
            internal static extern void GmshWrite([MarshalAs(UnmanagedType.LPStr)] string fileName, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshClear")]
            internal static extern void GmshClear(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOptionSetNumber")]
            internal static extern void GmshOptionSetNumber([MarshalAs(UnmanagedType.LPStr)] string name, double value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOptionGetNumber")]
            internal static extern void GmshOptionGetNumber([MarshalAs(UnmanagedType.LPStr)] string name, double* value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOptionSetString")]
            internal static extern void GmshOptionSetString([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOptionGetString")]
            internal static extern void GmshOptionGetString([MarshalAs(UnmanagedType.LPStr)] string name, byte** value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOptionSetColor")]
            internal static extern void GmshOptionSetColor([MarshalAs(UnmanagedType.LPStr)] string name, int r, int g, int b, int a, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOptionGetColor")]
            internal static extern void GmshOptionGetColor([MarshalAs(UnmanagedType.LPStr)] string name, int* r, int* g, int* b, int* a, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelAdd")]
            internal static extern void GmshModelAdd([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelRemove")]
            internal static extern void GmshModelRemove(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelList")]
            internal static extern void GmshModelList(byte*** names, long* names_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetCurrent")]
            internal static extern void GmshModelGetCurrent(byte** name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetCurrent")]
            internal static extern void GmshModelSetCurrent([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetFileName")]
            internal static extern void GmshModelGetFileName(string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetFileName")]
            internal static extern void GmshModelSetFileName(string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetEntities")]
            internal static extern void GmshModelGetEntities(int** dimTags, long* dimTags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetEntityName")]
            internal static extern void GmshModelSetEntityName(int dim, int tag, [MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetEntityName")]
            internal static extern void GmshModelGetEntityName(int dim, int tag, byte** name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetPhysicalGroups")]
            internal static extern void GmshModelGetPhysicalGroups(int** dimTags, long* dimTags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetEntitiesForPhysicalGroup")]
            internal static extern void GmshModelGetEntitiesForPhysicalGroup(int dim, int tag, int** tags, long* tags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetPhysicalGroupsForEntity")]
            internal static extern void GmshModelGetPhysicalGroupsForEntity(int dim, int tag, int** physicalTags, long* physicalTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelAddPhysicalGroup")]
            internal static extern int GmshModelAddPhysicalGroup(int dim, int* tags, long tags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetPhysicalName")]
            internal static extern void GmshModelSetPhysicalName(int dim, int tag, [MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetPhysicalName")]
            internal static extern void GmshModelGetPhysicalName(int dim, int tag, byte** name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetBoundary")]
            internal static extern void GmshModelGetBoundary(int* dimTags, long dimTags_n, int** outDimTags, long* outDimTags_n, int combined, int oriented, int recursive, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetEntitiesInBoundingBox")]
            internal static extern void GmshModelGetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int** tags, long* tags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetBoundingBox")]
            internal static extern void GmshModelGetBoundingBox(int dim, int tag, double* xmin, double* ymin, double* zmin, double* xmax, double* ymax, double* zmax, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetDimension")]
            internal static extern int GmshModelGetDimension(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelAddDiscreteEntity")]
            internal static extern int GmshModelAddDiscreteEntity(int dim, int tag, int* boundary, long boundary_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelRemoveEntities")]
            internal static extern void GmshModelRemoveEntities(int* dimTags, long dimTags_n, int recursive, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelRemoveEntityName")]
            internal static extern void GmshModelRemoveEntityName([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelRemovePhysicalGroups")]
            internal static extern void GmshModelRemovePhysicalGroups(int* dimTags, long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelRemovePhysicalName")]
            internal static extern void GmshModelRemovePhysicalName([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetType")]
            internal static extern void GmshModelGetType(int dim, int tag, byte** entityType, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetParent")]
            internal static extern void GmshModelGetParent(int dim, int tag, int* parentDim, int* parentTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetPartitions")]
            internal static extern void GmshModelGetPartitions(int dim, int tag, int** partitions, long* partitions_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetValue")]
            internal static extern void GmshModelGetValue(int dim, int tag, double* parametricCoord, long parametricCoord_n, double** coord, long* coord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetSecondDerivative")]
            internal static extern void GmshModelGetSecondDerivative(int dim, int tag, double* parametricCoord, long parametricCoord_n, double** derivatives, long* derivatives_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetDerivative")]
            internal static extern void GmshModelGetDerivative(int dim, int tag, double* parametricCoord, long parametricCoord_n, double** derivatives, long* derivatives_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetCurvature")]
            internal static extern void GmshModelGetCurvature(int dim, int tag, double* parametricCoord, long parametricCoord_n, double** curvatures, long* curvatures_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetPrincipalCurvatures")]
            internal static extern void GmshModelGetPrincipalCurvatures(int tag, double* parametricCoord, long parametricCoord_n, double** curvatureMax, long* curvatureMax_n, double** curvatureMin, long* curvatureMin_n, double** directionMax, long* directionMax_n, double** directionMin, long* directionMin_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetNormal")]
            internal static extern void GmshModelGetNormal(int tag, double* parametricCoord, long parametricCoord_n, double** normals, long* normals_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetParametrization")]
            internal static extern void GmshModelGetParametrization(int dim, int tag, double* coord, long coord_n, double** parametricCoord, long* parametricCoord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetParametrizationBounds")]
            internal static extern void GmshModelGetParametrizationBounds(int dim, int tag, double** min, long* min_n, double** max, long* max_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelIsInside")]
            internal static extern int GmshModelIsInside(int dim, int tag, double* parametricCoord, long parametricCoord_n, int parametric, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetAdjacencies")]
            internal static extern int GmshModelGetAdjacencies(int dim, int tag, int* upward, long upward_n, int* downward, long downward_n);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetClosestPoint")]
            internal static extern void GmshModelGetClosestPoint(int dim, int tag, double* coord, long coord_n, double** closestCoord, long* closestCoord_n, double** parametricCoord, long* parametricCoord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelReparametrizeOnSurface")]
            internal static extern void GmshModelReparametrizeOnSurface(int dim, int tag, double* parametricCoord, long parametricCoord_n, int surfaceTag, double** surfaceParametricCoord, long* surfaceParametricCoord_n, int which, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetVisibility")]
            internal static extern void GmshModelSetVisibility(int* dimTags, long dimTags_n, int value, int recursive, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetVisibility")]
            internal static extern void GmshModelGetVisibility(int dim, int tag, int* value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetColor")]
            internal static extern void GmshModelSetColor(int* dimTags, long dimTags_n, int r, int g, int b, int a, int recursive, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetColor")]
            internal static extern void GmshModelGetColor(int dim, int tag, int* r, int* g, int* b, int* a, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelSetCoordinates")]
            internal static extern void GmshModelSetCoordinates(int tag, double x, double y, double z, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGmshModelSetTag")]
            internal static extern void GmshModelSetTag(int dim, int tag, int newTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGenerate")]
            internal static extern void GmshModelMeshGenerate(int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshPartition")]
            internal static extern void GmshModelMeshPartition(int numPart, long* elementTags, int elementTags_n, int* partitions, int partitions_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshUnpartition")]
            internal static extern void GmshModelMeshUnpartition(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshOptimize")]
            internal static extern void GmshModelMeshOptimize([MarshalAs(UnmanagedType.LPStr)] string method, int force, int niter, int* dimTags, long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRecombine")]
            internal static extern void GmshModelMeshRecombine(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRefine")]
            internal static extern void GmshModelMeshRefine(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetOrder")]
            internal static extern void GmshModelMeshSetOrder(int order, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetLastEntityError")]
            internal static extern void GmshModelMeshGetLastEntityError(int** dimTags, long* dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetLastNodeError")]
            internal static extern void GmshModelMeshGetLastNodeError(long** nodeTags, long* nodeTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshClear")]
            internal static extern void GmshModelMeshClear(int* dimTags, long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetNodes")]
            internal static extern void GmshModelMeshGetNodes(long** nodeTags, long* nodeTags_n, double** coord, long* coord_n, double** parametricCoord, long* parametricCoord_n, int dim, int tag, int includeBoundary, int returnParametricCoord, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetNodesByElementType")]
            internal static extern void GmshModelMeshGetNodesByElementType(int elementType, long** nodeTags, long* nodeTags_n, double** coord, long* coord_n, double** parametricCoord, long* parametricCoord_n, int tag, int returnParametricCoord, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetNode")]
            internal static extern void GmshModelMeshGetNode(long nodeTag, double** coord, long* coord_n, double** parametricCoord, long* parametricCoord_n, int* dim, int* tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetNode")]
            internal static extern void GmshModelMeshSetNode(long nodeTag, double* coord, long coord_n, double* parametricCoord, long parametricCoord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRebuildNodeCache")]
            internal static extern void GmshModelMeshRebuildNodeCache(int onlyIfNecessary, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRebuildElementCache")]
            internal static extern void GmshModelMeshRebuildElementCache(int onlyIfNecessary, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetNodesForPhysicalGroup")]
            internal static extern void GmshModelMeshGetNodesForPhysicalGroup(int dim, int tag, long** nodeTags, long* nodeTags_n, double** coord, long* coord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshAddNodes")]
            internal static extern void GmshModelMeshAddNodes(int dim, int tag, long* nodeTags, long nodeTags_n, double* coord, long coord_n, double* parametricCoord, long parametricCoord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshReclassifyNodes")]
            internal static extern void GmshModelMeshReclassifyNodes(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRelocateNodes")]
            internal static extern void GmshModelMeshRelocateNodes(int dim, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElements")]
            internal static extern void GmshModelMeshGetElements(int** elementTypes, long* elementTypes_n, long*** elementTags, long** elementTags_n, long* elementTags_nn, long*** nodeTags, long** nodeTags_n, long* nodeTags_nn, int dim, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElement")]
            internal static extern void GmshModelMeshGetElement(long elementTag, int* elementType, long** nodeTags, long* nodeTags_n, int* dim, int* tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementByCoordinates")]
            internal static extern void GmshModelMeshGetElementByCoordinates(double x, double y, double z, long* elementTag, int* elementType, long** nodeTags, long* nodeTags_n, double* u, double* v, double* w, int dim, int strict, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementsByCoordinates")]
            internal static extern void GmshModelMeshGetElementsByCoordinates(double x, double y, double z, long** elementTags, long* elementTags_n, int dim, int strict, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetLocalCoordinatesInElement")]
            internal static extern void GmshModelMeshGetLocalCoordinatesInElement(long elementTag, double x, double y, double z, double* u, double* v, double* w, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementTypes")]
            internal static extern void GmshModelMeshGetElementTypes(int** elementTypes, long* elementTypes_n, int dim, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementType")]
            internal static extern int GmshModelMeshGetElementType([MarshalAs(UnmanagedType.LPStr)] string familyName, int order, int serendip, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementProperties")]
            internal static extern void GmshModelMeshGetElementProperties(int elementType, byte** elementName, int* dim, int* order, int* numNodes, double** localNodeCoord, long* localNodeCoord_n, int* numPrimaryNodes, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementsByType")]
            internal static extern void GmshModelMeshGetElementsByType(int elementType, long** elementTags, long* elementTags_n, long** nodeTags, long* nodeTags_n, int tag, long task, long numTasks, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshPreallocateElementsByType")]
            internal static extern void GmshModelMeshPreallocateElementsByType(int elementType, int elementTag, int nodeTag, long** elementTags, long* elementTags_n, long** nodeTags, long* nodeTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshAddElements")]
            internal static extern void GmshModelMeshAddElements(int dim, int tag, int* elementTypes, long elementTypes_n, long** elementTags, long* elementTags_n, long elementTags_nn, long** nodeTags, long* nodeTags_n, long nodeTags_nn, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshAddElementsByType")]
            internal static extern void GmshModelMeshAddElementsByType(int tag, int elementType, long* elementTags, long elementTags_n, long* nodeTags, long nodeTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetIntegrationPoints")]
            internal static extern void GmshModelMeshGetIntegrationPoints(int elementType, [MarshalAs(UnmanagedType.LPStr)] string integrationType, double** localCoord, long* localCoord_n, double** weights, long* weights_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetJacobians")]
            internal static extern void GmshModelMeshGetJacobians(int elementType, double* localCoord, long localCoord_n, double** jacobians, long* jacobians_n, double** determinants, long* determinants_n, double** coord, long* coord_n, int tag, long task, long numTasks, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshPreallocateJacobians")]
            internal static extern void GmshModelMeshPreallocateJacobians(int elementType, int numEvaluationPoints, int allocateJacobians, int allocateDeterminants, int allocateCoord, double** jacobians, long* jacobians_n, double** determinants, long* determinants_n, double** coord, long* coord_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetJacobian")]
            internal static extern void GmshModelMeshGetJacobian(long elementTag, double* localCoord, long localCoord_n, double** jacobians, long* jacobians_n, double** determinants, long* determinants_n, double** coord, long* coord_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetBasisFunctions")]
            internal static extern void GmshModelMeshGetBasisFunctions(int elementType, double* localCoord, long localCoord_n, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int* numComponents, double** basisFunctions, long* basisFunctions_n, int* numOrientations, int* wantedOrientations, long wantedOrientations_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetBasisFunctionsOrientation")]
            internal static extern void GmshModelMeshGetBasisFunctionsOrientation(int elementType, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int** basisFunctionsOrientation, long* basisFunctionsOrientation_n, int tag, long task, long numTasks, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetBasisFunctionsOrientationForElement")]
            internal static extern void GmshModelMeshGetBasisFunctionsOrientationForElement(long elementTag, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int* basisFunctionsOrientation, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetNumberOfOrientations")]
            internal static extern int GmshModelMeshGetNumberOfOrientations(int elementType, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshPreallocateBasisFunctionsOrientation")]
            internal static extern void GmshModelMeshPreallocateBasisFunctionsOrientation(int elementType, int** basisFunctionsOrientation, long* basisFunctionsOrientation_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetEdges")]
            internal static extern void GmshModelMeshGetEdges(int* edgeNodes, long edgeNodes_n, int** edgeNum, long* edgeNum_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetFaces")]
            internal static extern void GmshModelMeshGetFaces(int faceType, int* nodeTags, long nodeTags_n, int** faceTags, long* faceTags_n, int** faceOrientations, long* faceOrientations_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetKeys")]
            internal static extern void GmshModelMeshGetKeys(int elementType, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int** keys, long* keys_n, double** coord, long* coord_n, int tag, int returnCoord, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetKeysForElement")]
            internal static extern void GmshModelMeshGetKeysForElement(long elementTag, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int** typeKeys, long* typeKeys_n, long** entityKeys, long* entityKeys_n, double** coord, long* coord_n, int returnCoord, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetNumberOfKeys")]
            internal static extern int GmshModelMeshGetNumberOfKeys(int elementType, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetKeysInformation")]
            internal static extern void GmshModelMeshGetKeysInformation(int* keys, long keys_n, int elementType, [MarshalAs(UnmanagedType.LPStr)] string functionSpaceType, int** infoKeys, long* infoKeys_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetBarycenters")]
            internal static extern void GmshModelMeshGetBarycenters(int elementType, int tag, int fast, int primary, double** barycenters, long* barycenters_n, long task, long numTasks, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshPreallocateBarycenters")]
            internal static extern void GmshModelMeshPreallocateBarycenters(int elementType, double** barycenters, long* barycenters_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementEdgeNodes")]
            internal static extern void GmshModelMeshGetElementEdgeNodes(int elementType, long** nodeTags, long* nodeTags_n, int tag, int primary, long task, long numTasks, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetElementFaceNodes")]
            internal static extern void GmshModelMeshGetElementFaceNodes(int elementType, int faceType, long** nodeTags, long* nodeTags_n, int tag, int primary, long task, long numTasks, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetGhostElements")]
            internal static extern void GmshModelMeshGetGhostElements(int dim, int tag, long** elementTags, long* elementTags_n, int** partitions, long* partitions_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetSize")]
            internal static extern void GmshModelMeshSetSize(int* dimTags, long dimTags_n, double size, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetSizeAtParametricPoints")]
            internal static extern void GmshModelMeshSetSizeAtParametricPoints(int dim, int tag, double* parametricCoord, long parametricCoord_n, double* sizes, long sizes_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetTransfiniteCurve")]
            internal static extern void GmshModelMeshSetTransfiniteCurve(int tag, int numNodes, [MarshalAs(UnmanagedType.LPStr)] string meshType, double coef, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetTransfiniteSurface")]
            internal static extern void GmshModelMeshSetTransfiniteSurface(int tag, [MarshalAs(UnmanagedType.LPStr)] string arrangement, int* cornerTags, long cornerTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetTransfiniteVolume")]
            internal static extern void GmshModelMeshSetTransfiniteVolume(int tag, int* cornerTags, long cornerTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetRecombine")]
            internal static extern void GmshModelMeshSetRecombine(int dim, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetSmoothing")]
            internal static extern void GmshModelMeshSetSmoothing(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetReverse")]
            internal static extern void GmshModelMeshSetReverse(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetAlgorithm")]
            internal static extern void GmshModelMeshSetAlgorithm(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetSizeFromBoundary")]
            internal static extern void GmshModelMeshSetSizeFromBoundary(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetCompound")]
            internal static extern void GmshModelMeshSetCompound(int dim, int* tags, long tags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetOutwardOrientation")]
            internal static extern void GmshModelMeshSetOutwardOrientation(int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshEmbed")]
            internal static extern void GmshModelMeshEmbed(int dim, int* tags, long tags_n, int inDim, int inTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRemoveEmbedded")]
            internal static extern void GmshModelMeshRemoveEmbedded(int* dimTags, long dimTags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshReorderElements")]
            internal static extern void GmshModelMeshReorderElements(int elementType, int tag, long* ordering, long ordering_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRenumberNodes")]
            internal static extern void GmshModelMeshRenumberNodes(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRenumberElements")]
            internal static extern void GmshModelMeshRenumberElements(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSetPeriodic")]
            internal static extern void GmshModelMeshSetPeriodic(int dim, int* tags, long tags_n, int* tagsMaster, long tagsMaster_n, double* affineTransform, long affineTransform_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetPeriodic")]
            internal static extern void GmshModelMeshGetPeriodic(int dim, int* tags, long tags_n, int** tagsMaster, int* tagsMaster_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetAllEdges")]
            internal static extern void GmshModelMeshGetAllEdges(long** edgeTags, long* edgeTags_n, long** edgeNodes, long* edgeNodes_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetAllFaces")]
            internal static extern void GmshModelMeshGetAllFaces(int faceType, long** faceTags, long* faceTags_n, long** faceNodes, long* faceNodes_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshAddEdges")]
            internal static extern void GmshModelMeshAddEdges(long* edgeTags, long edgeTagss_n, long* edgeNodes, long edgeNodes_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshAddFaces")]
            internal static extern void GmshModelMeshAddFaces(int faceType, long* edgeTags, long edgeTagss_n, long* edgeNodes, long edgeNodes_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetPeriodicNodes")]
            internal static extern void GmshModelMeshGetPeriodicNodes(int dim, int tag, int* tagMaster, long** nodeTags, long* nodeTags_n, long** nodeTagsMaster, long* nodeTagsMaster_n, double** affineTransform, long* affineTransform_n, int includeHighOrderNodes, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRemoveDuplicateNodes")]
            internal static extern void GmshModelMeshRemoveDuplicateNodes(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshSplitQuadrangles")]
            internal static extern void GmshModelMeshSplitQuadrangles(double quality, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshClassifySurfaces")]
            internal static extern void GmshModelMeshClassifySurfaces(double angle, int boundary, int forReparametrization, double curveAngle, int exportDiscrete, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshCreateGeometry")]
            internal static extern void GmshModelMeshCreateGeometry(int* dimTags, long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshCreateTopology")]
            internal static extern void GmshModelMeshCreateTopology(int makeSimplyConnected, int exportDiscrete, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshComputeHomology")]
            internal static extern void GmshModelMeshComputeHomology(int* domainTags, long domainTags_n, int* subdomainTags, long subdomainTags_n, int* dims, long dims_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshComputeCohomology")]
            internal static extern void GmshModelMeshComputeCohomology(int* domainTags, long domainTags_n, int* subdomainTags, long subdomainTags_n, int* dims, long dims_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshComputeCrossField")]
            internal static extern void GmshModelMeshComputeCrossField(int** viewTags, long* viewTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshReverse")]
            internal static extern void GmshModelMeshReverse(int* dimTags, long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshAffineTransform")]
            internal static extern void GmshModelMeshAffineTransform(double* affineTransform, long affineTransform_n, int* dimTags, long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetMaxNodeTag")]
            internal static extern void GmshModelMeshGetMaxNodeTag(long* maxTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetMaxElementTag")]
            internal static extern void GmshModelMeshGetMaxElementTag(long* maxTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGetNumberOfPartitions")]
            internal static extern int GmshModelGetNumberOfPartitions(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshImportStl")]
            internal static extern void GmshModelMeshImportStl(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetDuplicateNodes")]
            internal static extern int GmshModelMeshGetDuplicateNodes(int** tags, long* tags_n, int* dimTags, long dimTags_n, int* ierr);


            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetSizes")]
            internal static extern int GmshModelMeshGetSizes(int* dimTags, long dimTags_n, double** sizes, ref long* sizes_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldAdd")]
            internal static extern int GmshModelMeshFieldAdd([MarshalAs(UnmanagedType.LPStr)] string fieldType, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldRemove")]
            internal static extern void GmshModelMeshFieldRemove(int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldSetNumber")]
            internal static extern void GmshModelMeshFieldSetNumber(int tag, [MarshalAs(UnmanagedType.LPStr)] string option, double value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldSetString")]
            internal static extern void GmshModelMeshFieldSetString(int tag, [MarshalAs(UnmanagedType.LPStr)] string option, [MarshalAs(UnmanagedType.LPStr)] string value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldSetNumbers")]
            internal static extern void GmshModelMeshFieldSetNumbers(int tag, [MarshalAs(UnmanagedType.LPStr)] string option, double* value, long value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldSetAsBackgroundMesh")]
            internal static extern void GmshModelMeshFieldSetAsBackgroundMesh(int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldSetAsBoundaryLayer")]
            internal static extern void GmshModelMeshFieldSetAsBoundaryLayer(int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldList")]
            internal static extern void GmshModelMeshFieldList(int** tags, int* tags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldGetType")]
            internal static extern void GmshModelMeshFieldGetType(int tag, string fileType, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldGetNumber")]
            internal static extern void GmshModelMeshFieldGetNumber(int tag, string option, double number, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldGetNumbers")]
            internal static extern void GmshModelMeshFieldGetNumbers(int tag, string option, double** numbers, int* numbers_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshFieldGetString")]
            internal static extern void GmshModelMeshFieldGetString(int tag, string option, string value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshGetEdges")]
            internal static extern void GmshModelMeshGetEdges(long* nodeTags, long nodeTags_n, long* edgeTags, long edgeTags_n, int* edgeOrientations, long edgeOrientations_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshCreateEdges")]
            internal static extern void GmshModelMeshCreateEdges(int* nodeTags, long nodeTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshCreateFaces")]
            internal static extern void GmshModelMeshCreateFaces(int* nodeTags, long nodeTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRemoveConstraints")]
            internal static extern void GmshModelMeshRemoveConstraints(int* nodeTags, long nodeTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshRemoveConstraints")]
            internal static extern void GmshModelMeshGetEmbedded(int dim, int tag, int** nodeTags, long* nodeTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshTriangulate")]
            internal static extern void GmshModelMeshTriangulate(double* coord, long coord_n, long** dimTags, ref long dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelMeshTetrahedralize")]
            internal static extern void GmshModelMeshTetrahedralize(double* coord, long coord_n, long** dimTags, long* dimTags_n, int* ierr);            

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddPoint")]
            internal static extern int GmshModelGeoAddPoint(double x, double y, double z, double meshSize, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddLine")]
            internal static extern int GmshModelGeoAddLine(int startTag, int endTag, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddCircleArc")]
            internal static extern int GmshModelGeoAddCircleArc(int startTag, int centerTag, int endTag, int tag, double nx, double ny, double nz, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddEllipseArc")]
            internal static extern int GmshModelGeoAddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag, double nx, double ny, double nz, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddSpline")]
            internal static extern int GmshModelGeoAddSpline(int* pointTags, long pointTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddBSpline")]
            internal static extern int GmshModelGeoAddBSpline(int* pointTags, long pointTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddBezier")]
            internal static extern int GmshModelGeoAddBezier(int* pointTags, long pointTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddTrimmedSurface")]
            internal static extern int GmshModelOccAddTrimmedSurface(int surfaceTag, int* wireTags, long wireTags_n, int wire3D, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddPolyline")]
            internal static extern int GmshModelGeoAddPolyline(int* pointTags, long pointTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddCompoundSpline")]
            internal static extern int GmshModelGeoAddCompoundSpline(int* curveTags, long curveTags_n, int numIntervals, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddCompoundBSpline")]
            internal static extern int GmshModelGeoAddCompoundBSpline(int* curveTags, long curveTags_n, int numIntervals, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddCurveLoop")]
            internal static extern int GmshModelGeoAddCurveLoop(int* curveTags, long curveTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddCurveLoops")]
            internal static extern int GmshModelGeoAddCurveLoops(int* curveTags, long curveTags_n, int** tags, long* tags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddPlaneSurface")]
            internal static extern int GmshModelGeoAddPlaneSurface(int* wireTags, long wireTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddSurfaceFilling")]
            internal static extern int GmshModelGeoAddSurfaceFilling(int* wireTags, long wireTags_n, int tag, int sphereCenterTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddSurfaceLoop")]
            internal static extern int GmshModelGeoAddSurfaceLoop(int* surfaceTags, long surfaceTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoAddVolume")]
            internal static extern int GmshModelGeoAddVolume(int* shellTags, long shellTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoExtrude")]
            internal static extern void GmshModelGeoExtrude(int* dimTags, long dimTags_n, double dx, double dy, double dz, int** outDimTags, long* outDimTags_n, int* numElements, long numElements_n, double* heights, long heights_n, int recombine, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoRevolve")]
            internal static extern void GmshModelGeoRevolve(int* dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int** outDimTags, long* outDimTags_n, int* numElements, long numElements_n, double* heights, long heights_n, int recombine, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoTwist")]
            internal static extern void GmshModelGeoTwist(int* dimTags, long dimTags_n, double x, double y, double z, double dx, double dy, double dz, double ax, double ay, double az, double angle, int** outDimTags, long* outDimTags_n, int* numElements, long numElements_n, double* heights, long heights_n, int recombine, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoTranslate")]
            internal static extern void GmshModelGeoTranslate(int* dimTags, long dimTags_n, double dx, double dy, double dz, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoRotate")]
            internal static extern void GmshModelGeoRotate(int* dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoDilate")]
            internal static extern void GmshModelGeoDilate(int* dimTags, long dimTags_n, double x, double y, double z, double a, double b, double c, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMirror")]
            internal static extern void GmshModelGeoMirror(int* dimTags, long dimTags_n, double a, double b, double c, double d, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoSymmetrize")]
            internal static extern void GmshModelGeoSymmetrize(int* dimTags, long dimTags_n, double a, double b, double c, double d, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoCopy")]
            internal static extern void GmshModelGeoCopy(int* dimTags, long dimTags_n, int** outDimTags, long* outDimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoRemove")]
            internal static extern void GmshModelGeoRemove(int* dimTags, long dimTags_n, int recursive, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoRemoveAllDuplicates")]
            internal static extern void GmshModelGeoRemoveAllDuplicates(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoSplitCurve")]
            internal static extern void GmshModelGeoSplitCurve(int tag, int* pointTags, long pointTags_n, int** curveTags, long* curveTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoGetMaxTag")]
            internal static extern int GmshModelGeoGetMaxTag(int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoSetMaxTag")]
            internal static extern void GmshModelGeoSetMaxTag(int dim, int maxTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoSynchronize")]
            internal static extern void GmshModelGeoSynchronize(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetSize")]
            internal static extern void GmshModelGeoMeshSetSize(int* dimTags, long dimTags_n, double size, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetTransfiniteCurve")]
            internal static extern void GmshModelGeoMeshSetTransfiniteCurve(int tag, int nPoints, [MarshalAs(UnmanagedType.LPStr)] string meshType, double coef, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetTransfiniteSurface")]
            internal static extern void GmshModelGeoMeshSetTransfiniteSurface(int tag, [MarshalAs(UnmanagedType.LPStr)] string arrangement, int* cornerTags, long cornerTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetTransfiniteVolume")]
            internal static extern void GmshModelGeoMeshSetTransfiniteVolume(int tag, int* cornerTags, long cornerTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetRecombine")]
            internal static extern void GmshModelGeoMeshSetRecombine(int dim, int tag, double angle, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetSmoothing")]
            internal static extern void GmshModelGeoMeshSetSmoothing(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetReverse")]
            internal static extern void GmshModelGeoMeshSetReverse(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetAlgorithm")]
            internal static extern void GmshModelGeoMeshSetAlgorithm(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelGeoMeshSetSizeFromBoundary")]
            internal static extern void GmshModelGeoMeshSetSizeFromBoundary(int dim, int tag, int val, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddPoint")]
            internal static extern int GmshModelOccAddPoint(double x, double y, double z, double meshSize, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddLine")]
            internal static extern int GmshModelOccAddLine(int startTag, int endTag, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddCircleArc")]
            internal static extern int GmshModelOccAddCircleArc(int startTag, int centerTag, int endTag, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddCircle")]
            internal static extern int GmshModelOccAddCircle(double x, double y, double z, double r, int tag, double angle1, double angle2, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddEllipseArc")]
            internal static extern int GmshModelOccAddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddEllipse")]
            internal static extern int GmshModelOccAddEllipse(double x, double y, double z, double r1, double r2, int tag, double angle1, double angle2, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddSpline")]
            internal static extern int GmshModelOccAddSpline(int* pointTags, long pointTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBSpline")]
            internal static extern int GmshModelOccAddBSpline(int* pointTags, long pointTags_n, int tag, int degree, double* weights, long weights_n, double* knots, long knots_n, int* multiplicities, long multiplicities_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBezier")]
            internal static extern int GmshModelOccAddBezier(int* pointTags, long pointTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddWire")]
            internal static extern int GmshModelOccAddWire(int* curveTags, long curveTags_n, int tag, int checkClosed, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddCurveLoop")]
            internal static extern int GmshModelOccAddCurveLoop(int* curveTags, long curveTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddRectangle")]
            internal static extern int GmshModelOccAddRectangle(double x, double y, double z, double dx, double dy, int tag, double roundedRadius, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddDisk")]
            internal static extern int GmshModelOccAddDisk(double xc, double yc, double zc, double rx, double ry, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddPlaneSurface")]
            internal static extern int GmshModelOccAddPlaneSurface(int* wireTags, long wireTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddSurfaceFilling")]
            internal static extern int GmshModelOccAddSurfaceFilling(int wireTag, int tag, int* pointTags, long pointTags_n, int degree, int numPointsOnCurves, int numIter,
                    int anisotropic, double tol2d, double tol3d, double tolAng, double tolCurv, int maxDegree, int maxSegments, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBSplineFilling")]
            internal static extern int GmshModelOccAddBSplineFilling(int wireTag, int tag, [MarshalAs(UnmanagedType.LPStr)] string type, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBezierFilling")]
            internal static extern int GmshModelOccAddBezierFilling(int wireTag, int tag, [MarshalAs(UnmanagedType.LPStr)] string type, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBSplineSurface")]
            internal static extern int GmshModelOccAddBSplineSurface(int* pointTags, long pointTags_n, int numPointsU, int tag, int degreeU, int degreeV, 
                                                                    double* weights, long weights_n, double* knotsU, long knotsU_n, double* knotsV, long knotsV_n, 
                                                                    int* multiplicitiesU, long multiplicitiesU_n, int* multiplicitiesV, long multiplicitiesV_n,
                                                                    int* wireTags, long wireTags_n, int wire3D, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBezierSurface")]
            internal static extern int GmshModelOccAddBezierSurface(int* pointTags, long pointTags_n, int numPointsU, int tag, int* wireTags,
                                                                    long wireTags_n, int wire3D, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddSurfaceLoop")]
            internal static extern int GmshModelOccAddSurfaceLoop(int* surfaceTags, long surfaceTags_n, int tag, int sewing, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddVolume")]
            internal static extern int GmshModelOccAddVolume(int* shellTags, long shellTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddSphere")]
            internal static extern int GmshModelOccAddSphere(double xc, double yc, double zc, double radius, int tag, double angle1, double angle2, double angle3, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddBox")]
            internal static extern int GmshModelOccAddBox(double x, double y, double z, double dx, double dy, double dz, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddCylinder")]
            internal static extern int GmshModelOccAddCylinder(double x, double y, double z, double dx, double dy, double dz, double r, int tag, double angle, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddCone")]
            internal static extern int GmshModelOccAddCone(double x, double y, double z, double dx, double dy, double dz, double r1, double r2, int tag, double angle, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddWedge")]
            internal static extern int GmshModelOccAddWedge(double x, double y, double z, double dx, double dy, double dz, int tag, double ltx, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddTorus")]
            internal static extern int GmshModelOccAddTorus(double x, double y, double z, double r1, double r2, int tag, double angle, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddThruSections")]
            internal static extern void GmshModelOccAddThruSections(int* wireTags, long wireTags_n, int** outDimTags, long* outDimTags_n, int tag, int makeSolid, int makeRuled, int maxDegree, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddThickSolid")]
            internal static extern void GmshModelOccAddThickSolid(int volumeTag, int* excludeSurfaceTags, long excludeSurfaceTags_n, double offset, int** outDimTags, long* outDimTags_n, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccExtrude")]
            internal static extern void GmshModelOccExtrude(int* dimTags, long dimTags_n, double dx, double dy, double dz, int** outDimTags, long* outDimTags_n, int* numElements, long numElements_n, double* heights, long heights_n, int recombine, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccRevolve")]
            internal static extern void GmshModelOccRevolve(int* dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int** outDimTags, long* outDimTags_n, int* numElements, long numElements_n, double* heights, long heights_n, int recombine, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAddPipe")]
            internal static extern void GmshModelOccAddPipe(int* dimTags, long dimTags_n, int wireTag, int** outDimTags, long* outDimTags_n, [MarshalAs(UnmanagedType.LPStr)] string trihedron, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccFillet")]
            internal static extern void GmshModelOccFillet(int* volumeTags, long volumeTags_n, int* curveTags, long curveTags_n, double* radii, long radii_n, int** outDimTags, long* outDimTags_n, int removeVolume, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccChamfer")]
            internal static extern void GmshModelOccChamfer(int* volumeTags, long volumeTags_n, int* curveTags, long curveTags_n, int* surfaceTags, long surfaceTags_n, double* distances, long distances_n, int** outDimTags, long* outDimTags_n, int removeVolume, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccConvertToNURBS")]
            internal static extern void GmshModelOccConvertToNURBS(int* tags, long tags_n, int* ierr);
                       
            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccFuse")]
            internal static extern void GmshModelOccFuse(int* objectDimTags, long objectDimTags_n, int* toolDimTags, long toolDimTags_n, int** outDimTags, long* outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, long* outDimTagsMap_nn, int tag, int removeObject, int removeTool, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccIntersect")]
            internal static extern void GmshModelOccIntersect(int* objectDimTags, long objectDimTags_n, int* toolDimTags, long toolDimTags_n, int** outDimTags, long* outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, long* outDimTagsMap_nn, int tag, int removeObject, int removeTool, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccCut")]
            internal static extern void GmshModelOccCut(int* objectDimTags, long objectDimTags_n, int* toolDimTags, long toolDimTags_n, int** outDimTags, long* outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, long* outDimTagsMap_nn, int tag, int removeObject, int removeTool, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccFragment")]
            internal static extern void GmshModelOccFragment(int* objectDimTags, long objectDimTags_n, int* toolDimTags, long toolDimTags_n, int** outDimTags, long* outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, long* outDimTagsMap_nn, int tag, int removeObject, int removeTool, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccTranslate")]
            internal static extern void GmshModelOccTranslate(int* dimTags, long dimTags_n, double dx, double dy, double dz, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccRotate")]
            internal static extern void GmshModelOccRotate(int* dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccDilate")]
            internal static extern void GmshModelOccDilate(int* dimTags, long dimTags_n, double x, double y, double z, double a, double b, double c, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccMirror")]
            internal static extern void GmshModelOccMirror(int* dimTags, long dimTags_n, double a, double b, double c, double d, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccSymmetrize")]
            internal static extern void GmshModelOccSymmetrize(int* dimTags, long dimTags_n, double a, double b, double c, double d, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccAffineTransform")]
            internal static extern void GmshModelOccAffineTransform(int* dimTags, long dimTags_n, double* a, long a_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccCopy")]
            internal static extern void GmshModelOccCopy(int* dimTags, long dimTags_n, int** outDimTags, long* outDimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccRemove")]
            internal static extern void GmshModelOccRemove(int* dimTags, long dimTags_n, int recursive, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccRemoveAllDuplicates")]
            internal static extern void GmshModelOccRemoveAllDuplicates(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccHealShapes")]
            internal static extern void GmshModelOccHealShapes(int** outDimTags, long* outDimTags_n, int* dimTags, long dimTags_n, double tolerance, int fixDegenerated, int fixSmallEdges, int fixSmallFaces, int sewFaces, int makeSolids, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccImportShapes")]
            internal static extern void GmshModelOccImportShapes([MarshalAs(UnmanagedType.LPStr)] string fileName, int** outDimTags, long* outDimTags_n, int highestDimOnly, [MarshalAs(UnmanagedType.LPStr)] string format, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccImportShapesNativePointer")]
            internal static extern void GmshModelOccImportShapesNativePointer(global::System.IntPtr shape, int** outDimTags, long* outDimTags_n, int highestDimOnly, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetEntities")]
            internal static extern void GmshModelOccGetEntities(int** dimTags, long* dimTags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetEntitiesInBoundingBox")]
            internal static extern void GmshModelOccGetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int** tags, long* tags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetBoundingBox")]
            internal static extern void GmshModelOccGetBoundingBox(int dim, int tag, double* xmin, double* ymin, double* zmin, double* xmax, double* ymax, double* zmax, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetMass")]
            internal static extern void GmshModelOccGetMass(int dim, int tag, double* mass, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetCenterOfMass")]
            internal static extern void GmshModelOccGetCenterOfMass(int dim, int tag, double* x, double* y, double* z, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetMatrixOfInertia")]
            internal static extern void GmshModelOccGetMatrixOfInertia(int dim, int tag, double** mat, long* mat_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetMaxTag")]
            internal static extern int GmshModelOccGetMaxTag(int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccSetMaxTag")]
            internal static extern void GmshModelOccSetMaxTag(int dim, int maxTag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccSynchronize")]
            internal static extern void GmshModelOccSynchronize(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetCurveLoops")]
            internal static extern void GmshModelOccGetCurveLoops(int surfaceTag, int** dimTags, long* dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccGetSurfaceLoops")]
            internal static extern void GmshModelOccGetSurfaceLoops(int surfaceTag, int** dimTags, long* dimTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshModelOccMeshSetSize")]
            internal static extern void GmshModelOccMeshSetSize(int* dimTags, long dimTags_n, double size, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewAdd")]
            internal static extern int GmshViewAdd([MarshalAs(UnmanagedType.LPStr)] string name, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewRemove")]
            internal static extern void GmshViewRemove(int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewGetIndex")]
            internal static extern int GmshViewGetIndex(int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewGetTags")]
            internal static extern void GmshViewGetTags(int** tags, long* tags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewAddModelData")]
            internal static extern void GmshViewAddModelData(int tag, int step, [MarshalAs(UnmanagedType.LPStr)] string modelName, [MarshalAs(UnmanagedType.LPStr)] string dataType, long* tags, long tags_n, double** data, long* data_n, long data_nn, double time, int numComponents, int partition, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewAddHomogeneousModelData")]
            internal static extern void GmshViewAddHomogeneousModelData(int tag, int step, [MarshalAs(UnmanagedType.LPStr)] string modelName, [MarshalAs(UnmanagedType.LPStr)] string dataType, long* tags, long tags_n, double* data, long data_n, double time, int numComponents, int partition, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewGetModelData")]
            internal static extern void GmshViewGetModelData(int tag, int step, byte** dataType, long** tags, long* tags_n, double*** data, long** data_n, long* data_nn, double* time, int* numComponents, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewAddListData")]
            internal static extern void GmshViewAddListData(int tag, [MarshalAs(UnmanagedType.LPStr)] string dataType, int numEle, double* data, long data_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewGetListData")]
            internal static extern void GmshViewGetListData(int tag, byte*** dataType, long* dataType_n, int** numElements, long* numElements_n, double*** data, long** data_n, long* data_nn, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewAddListDataString")]
            internal static extern void GmshViewAddListDataString(int tag, double* coord, long coord_n, byte** data, long data_n, byte** style, long style_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewGetListDataStrings")]
            internal static extern void GmshViewGetListDataStrings(int tag, int dim, double** coord, long* coord_n, byte*** data, long* data_n, byte*** style, long* style_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewAddAlias")]
            internal static extern int GmshViewAddAlias(int refTag, int copyOptions, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionsCopy")]
            internal static extern void GmshViewOptionsCopy(int refTag, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionsSetNumber")]
            internal static extern void GmshViewOptionsSetNumber(int tag, string name, double value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionsGetNumber")]
            internal static extern void GmshViewOptionsGetNumber(int tag, string name, double value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionsSetString")]
            internal static extern void GmshViewOptionsSetString(int tag, string name, double value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionsGetString")]
            internal static extern void GmshViewOptionsGetString(int tag, string name, string value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewCombine")]
            internal static extern void GmshViewCombine([MarshalAs(UnmanagedType.LPStr)] string what, [MarshalAs(UnmanagedType.LPStr)] string how, int remove, int copyOptions, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewProbe")]
            internal static extern void GmshViewProbe(int tag, double x, double y, double z, double** value, long* value_n, double* distance, int step, int numComp, int gradient, double tolerance, double* xElemCoord, long xElemCoord_n, double* yElemCoord, long yElemCoord_n, double* zElemCoord, long zElemCoord_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewWrite")]
            internal static extern void GmshViewWrite(int tag, [MarshalAs(UnmanagedType.LPStr)] string fileName, int append, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionSetColor")]
            internal static extern void GmshViewOptionSetColor([MarshalAs(UnmanagedType.LPStr)] string name, int r, int g, int b, int a, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshViewOptionGetColor")]
            internal static extern void GmshViewOptionGetColor([MarshalAs(UnmanagedType.LPStr)] string name, int* r, int* g, int* b, int* a, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshPluginSetNumber")]
            internal static extern void GmshPluginSetNumber([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string option, double value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshPluginSetString")]
            internal static extern void GmshPluginSetString([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string option, [MarshalAs(UnmanagedType.LPStr)] string value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshPluginRun")]
            internal static extern void GmshPluginRun([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshGraphicsDraw")]
            internal static extern void GmshGraphicsDraw(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkInitialize")]
            internal static extern void GmshFltkInitialize(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkWait")]
            internal static extern void GmshFltkWait(double time, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkUpdate")]
            internal static extern void GmshFltkUpdate(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkAwake")]
            internal static extern void GmshFltkAwake([MarshalAs(UnmanagedType.LPStr)] string action, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkLock")]
            internal static extern void GmshFltkLock(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkUnlock")]
            internal static extern void GmshFltkUnlock(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkRun")]
            internal static extern void GmshFltkRun(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkIsAvailable")]
            internal static extern int GmshFltkIsAvailable(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkSelectEntities")]
            internal static extern int GmshFltkSelectEntities(int** dimTags, long* dimTags_n, int dim, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkSelectElements")]
            internal static extern int GmshFltkSelectElements(long** elementTags, long* elementTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkSelectViews")]
            internal static extern int GmshFltkSelectViews(int** viewTags, long* viewTags_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkSetStatusMessage")]
            internal static extern int GmshFltkSetStatusMessage(string message, int graphics, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkShowContextWindow")]
            internal static extern int GmshFltkShowContextWindow(int dim, int tag, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkOpenTreeItem")]
            internal static extern int GmshFltkOpenTreeItem(string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshFltkCloseTreeItem")]
            internal static extern int GmshFltkCloseTreeItem(string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabSet")]
            internal static extern void GmshOnelabSet([MarshalAs(UnmanagedType.LPStr)] string data, [MarshalAs(UnmanagedType.LPStr)] string format, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabGet")]
            internal static extern void GmshOnelabGet(byte** data, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string format, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabSetNumber")]
            internal static extern void GmshOnelabSetNumber([MarshalAs(UnmanagedType.LPStr)] string name, double* value, long value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabSetString")]
            internal static extern void GmshOnelabSetString([MarshalAs(UnmanagedType.LPStr)] string name, byte** value, long value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabGetNumber")]
            internal static extern void GmshOnelabGetNumber([MarshalAs(UnmanagedType.LPStr)] string name, double** value, long* value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabGetString")]
            internal static extern void GmshOnelabGetString([MarshalAs(UnmanagedType.LPStr)] string name, byte*** value, long* value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabClear")]
            internal static extern void GmshOnelabClear([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabGetChanged")]
            internal static extern int GmshOnelabGetChanged([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabSetChanged")]
            internal static extern int GmshOnelabSetChanged([MarshalAs(UnmanagedType.LPStr)] string name, int value, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabRun")]
            internal static extern void GmshOnelabRun([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string command, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshOnelabGetNames")]
            internal static extern void GmshOnelabGetNames([MarshalAs(UnmanagedType.LPStr)] string search, byte*** names, long* names_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerWrite")]
            internal static extern void GmshLoggerWrite([MarshalAs(UnmanagedType.LPStr)] string message, [MarshalAs(UnmanagedType.LPStr)] string level, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerStart")]
            internal static extern void GmshLoggerStart(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerGet")]
            internal static extern void GmshLoggerGet(byte*** log, long* log_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerStop")]
            internal static extern void GmshLoggerStop(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerGetWallTime")]
            internal static extern double GmshLoggerGetWallTime(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerGetCpuTime")]
            internal static extern double GmshLoggerGetCpuTime(int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshLoggerGetLastError")]
            internal static extern void GmshLoggerGetLastError(byte** error, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserSetNames")]
            internal static extern void GmshParserSetNames(byte*** names, int* names_n, [MarshalAs(UnmanagedType.LPStr)] string search, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserSetNumber")]
            internal static extern void GmshParserSetNumber([MarshalAs(UnmanagedType.LPStr)] string name, double* value, long value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserSetString")]
            internal static extern void GmshParserSetString([MarshalAs(UnmanagedType.LPStr)] string name, byte** value, long value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserGetNumber")]
            internal static extern void GmshParserGetNumber([MarshalAs(UnmanagedType.LPStr)] string name, double** value, long* value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserGetString")]
            internal static extern void GmshParserGetString([MarshalAs(UnmanagedType.LPStr)] string name, byte*** value, long* value_n, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserClear")]
            internal static extern void GmshParserClear([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(dllname, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "gmshParserParse")]
            internal static extern void GmshParserParse([MarshalAs(UnmanagedType.LPStr)] string name, int* ierr);
        }

        public static void GmshFree(global::System.IntPtr p)
        {
            __Internal.GmshFree(p);
        }

        public static global::System.IntPtr GmshMalloc(long n)
        {
            var __ret = __Internal.GmshMalloc(n);
            return __ret;
        }

        public static void GmshInitialize(int argc, byte** argv, int readConfigFiles, int run, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshInitialize(argc, argv, readConfigFiles, run, __arg3);
            }
        }

        public static int GmshIsInizialized(ref int ierr)
		{
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var value = __Internal.GmshIsInizialized(__arg3);
                return value;
            }
        }

        public static void GmshFinalize(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshFinalize(__arg0);
            }
        }

        public static void GmshOpen(string fileName, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshOpen(fileName, __arg1);
            }
        }

        public static void GmshMerge(string fileName, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshMerge(fileName, __arg1);
            }
        }

        public static void GmshWrite(string fileName, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshWrite(fileName, __arg1);
            }
        }

        public static void GmshClear(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshClear(__arg0);
            }
        }

        public static void GmshOptionSetNumber(string name, double value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshOptionSetNumber(name, value, __arg2);
            }
        }

        public static void GmshOptionGetNumber(string name, ref double value, ref int ierr)
        {
            fixed (double* __value1 = &value)
            {
                var __arg1 = __value1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshOptionGetNumber(name, __arg1, __arg2);
                }
            }
        }

        public static void GmshOptionSetString(string name, string value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshOptionSetString(name, value, __arg2);
            }
        }

        public static void GmshOptionGetString(string name, byte** value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshOptionGetString(name, value, __arg2);
            }
        }

        public static void GmshOptionSetColor(string name, int r, int g, int b, int a, ref int ierr)
        {
            fixed (int* __ierr5 = &ierr)
            {
                var __arg5 = __ierr5;
                __Internal.GmshOptionSetColor(name, r, g, b, a, __arg5);
            }
        }

        public static void GmshOptionGetColor(string name, ref int r, ref int g, ref int b, ref int a, ref int ierr)
        {
            fixed (int* __r1 = &r)
            {
                var __arg1 = __r1;
                fixed (int* __g2 = &g)
                {
                    var __arg2 = __g2;
                    fixed (int* __b3 = &b)
                    {
                        var __arg3 = __b3;
                        fixed (int* __a4 = &a)
                        {
                            var __arg4 = __a4;
                            fixed (int* __ierr5 = &ierr)
                            {
                                var __arg5 = __ierr5;
                                __Internal.GmshOptionGetColor(name, __arg1, __arg2, __arg3, __arg4, __arg5);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelAdd(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelAdd(name, __arg1);
            }
        }

        public static void GmshModelRemove(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelRemove(__arg0);
            }
        }

        public static void GmshModelList(byte*** names, ref long names_n, ref int ierr)
        {
            fixed (long* __names_n1 = &names_n)
            {
                var __arg1 = __names_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelList(names, __arg1, __arg2);
                }
            }
        }

        public static void GmshModelGetCurrent(byte** name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelGetCurrent(name, __arg1);
            }
        }

        public static void GmshModelSetCurrent(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelSetCurrent(name, __arg1);
            }
        }

        public static void GmshModelGetFileName(ref string fileName)
		{
            __Internal.GmshModelGetFileName(fileName);
		}

        public static void GmshModelSetFileName(string fileName)
        {
            __Internal.GmshModelSetFileName(fileName);
        }

        public static void GmshModelGetEntities(int** dimTags, ref long dimTags_n, int dim, ref int ierr)
        {
            fixed (long* __dimTags_n1 = &dimTags_n)
            {
                var __arg1 = __dimTags_n1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelGetEntities(dimTags, __arg1, dim, __arg3);
                }
            }
        }

        public static void GmshModelSetEntityName(int dim, int tag, string name, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelSetEntityName(dim, tag, name, __arg3);
            }
        }

        public static void GmshModelGetEntityName(int dim, int tag, byte** name, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGetEntityName(dim, tag, name, __arg3);
            }
        }

        public static void GmshModelGetPhysicalGroups(int** dimTags, ref long dimTags_n, int dim, ref int ierr)
        {
            fixed (long* __dimTags_n1 = &dimTags_n)
            {
                var __arg1 = __dimTags_n1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelGetPhysicalGroups(dimTags, __arg1, dim, __arg3);
                }
            }
        }

        public static void GmshModelGetEntitiesForPhysicalGroup(int dim, int tag, int** tags, ref long tags_n, ref int ierr)
        {
            fixed (long* __tags_n3 = &tags_n)
            {
                var __arg3 = __tags_n3;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelGetEntitiesForPhysicalGroup(dim, tag, tags, __arg3, __arg4);
                }
            }
        }

        public static void GmshModelGetPhysicalGroupsForEntity(int dim, int tag, int** physicalTags, ref long physicalTags_n, ref int ierr)
        {
            fixed (long* __physicalTags_n3 = &physicalTags_n)
            {
                var __arg3 = __physicalTags_n3;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelGetPhysicalGroupsForEntity(dim, tag, physicalTags, __arg3, __arg4);
                }
            }
        }

        public static int GmshModelAddPhysicalGroup(int dim, int[] tags, long tags_n, int tag, ref int ierr)
        {
            fixed (int* __tags1 = tags)
            {
                var __arg1 = __tags1;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelAddPhysicalGroup(dim, __arg1, tags_n, tag, __arg4);
                    return __ret;
                }
            }
        }

        public static void GmshModelSetPhysicalName(int dim, int tag, string name, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelSetPhysicalName(dim, tag, name, __arg3);
            }
        }

        public static void GmshModelGetPhysicalName(int dim, int tag, byte** name, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGetPhysicalName(dim, tag, name, __arg3);
            }
        }

        public static void GmshModelGetBoundary(int[] dimTags, long dimTags_n, int** outDimTags, ref long outDimTags_n, int combined, int oriented, int recursive, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n3 = &outDimTags_n)
                {
                    var __arg3 = __outDimTags_n3;
                    fixed (int* __ierr7 = &ierr)
                    {
                        var __arg7 = __ierr7;
                        __Internal.GmshModelGetBoundary(__arg0, dimTags_n, outDimTags, __arg3, combined, oriented, recursive, __arg7);
                    }
                }
            }
        }

        public static void GmshModelGetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int** tags, ref long tags_n, int dim, ref int ierr)
        {
            fixed (long* __tags_n7 = &tags_n)
            {
                var __arg7 = __tags_n7;
                fixed (int* __ierr9 = &ierr)
                {
                    var __arg9 = __ierr9;
                    __Internal.GmshModelGetEntitiesInBoundingBox(xmin, ymin, zmin, xmax, ymax, zmax, tags, __arg7, dim, __arg9);
                }
            }
        }

        public static void GmshModelGetBoundingBox(int dim, int tag, ref double xmin, ref double ymin, ref double zmin, ref double xmax, ref double ymax, ref double zmax, ref int ierr)
        {
            fixed (double* __xmin2 = &xmin)
            {
                var __arg2 = __xmin2;
                fixed (double* __ymin3 = &ymin)
                {
                    var __arg3 = __ymin3;
                    fixed (double* __zmin4 = &zmin)
                    {
                        var __arg4 = __zmin4;
                        fixed (double* __xmax5 = &xmax)
                        {
                            var __arg5 = __xmax5;
                            fixed (double* __ymax6 = &ymax)
                            {
                                var __arg6 = __ymax6;
                                fixed (double* __zmax7 = &zmax)
                                {
                                    var __arg7 = __zmax7;
                                    fixed (int* __ierr8 = &ierr)
                                    {
                                        var __arg8 = __ierr8;
                                        __Internal.GmshModelGetBoundingBox(dim, tag, __arg2, __arg3, __arg4, __arg5, __arg6, __arg7, __arg8);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static int GmshModelGetDimension(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                var __ret = __Internal.GmshModelGetDimension(__arg0);
                return __ret;
            }
        }

        public static int GmshModelAddDiscreteEntity(int dim, int tag, int[] boundary, long boundary_n, ref int ierr)
        {
            fixed (int* __boundary2 = boundary)
            {
                var __arg2 = __boundary2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelAddDiscreteEntity(dim, tag, __arg2, boundary_n, __arg4);
                    return __ret;
                }
            }
        }

        public static void GmshModelRemoveEntities(int[] dimTags, long dimTags_n, int recursive, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelRemoveEntities(__arg0, dimTags_n, recursive, __arg3);
                }
            }
        }

        public static void GmshModelRemoveEntityName(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelRemoveEntityName(name, __arg1);
            }
        }

        public static void GmshModelRemovePhysicalGroups(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelRemovePhysicalGroups(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelRemovePhysicalName(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelRemovePhysicalName(name, __arg1);
            }
        }

        public static void GmshModelGetType(int dim, int tag, byte** entityType, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGetType(dim, tag, entityType, __arg3);
            }
        }

        public static void GmshModelGetParent(int dim, int tag, ref int parentDim, ref int parentTag, ref int ierr)
        {
            fixed (int* __parentDim2 = &parentDim)
            {
                var __arg2 = __parentDim2;
                fixed (int* __parentTag3 = &parentTag)
                {
                    var __arg3 = __parentTag3;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelGetParent(dim, tag, __arg2, __arg3, __arg4);
                    }
                }
            }
        }

        public static void GmshModelGetPartitions(int dim, int tag, int** partitions, ref long partitions_n, ref int ierr)
        {
            fixed (long* __partitions_n3 = &partitions_n)
            {
                var __arg3 = __partitions_n3;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelGetPartitions(dim, tag, partitions, __arg3, __arg4);
                }
            }
        }

        public static void GmshModelGetValue(int dim, int tag, double[] parametricCoord, long parametricCoord_n, double** coord, ref long coord_n, ref int ierr)
        {
            fixed (double* parametricCoord2 = parametricCoord)
            {
                double* __arg2 = parametricCoord2;
                fixed (long* __coord_n5 = &coord_n)
                {
                    var __arg5 = __coord_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelGetValue(dim, tag, __arg2, parametricCoord_n, coord, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelGetDerivative(int dim, int tag, double[] parametricCoord, long parametricCoord_n, double** derivatives, ref long derivatives_n, ref int ierr)
        {
            fixed (double* __parametricCoord2 = parametricCoord)
            {
                var __arg2 = __parametricCoord2;
                fixed (long* __derivatives_n5 = &derivatives_n)
                {
                    var __arg5 = __derivatives_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelGetDerivative(dim, tag, __arg2, parametricCoord_n, derivatives, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelGetSecondDerivative(int dim, int tag, double[] parametricCoord, long parametricCoord_n, double** derivatives, ref long derivatives_n, ref int ierr)
        {
            fixed (double* __parametricCoord2 = parametricCoord)
            {
                var __arg2 = __parametricCoord2;
                fixed (long* __derivatives_n5 = &derivatives_n)
                {
                    var __arg5 = __derivatives_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelGetSecondDerivative(dim, tag, __arg2, parametricCoord_n, derivatives, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelGetCurvature(int dim, int tag, double[] parametricCoord, long parametricCoord_n, double** curvatures, ref long curvatures_n, ref int ierr)
        {
            fixed (double* __parametricCoord2 = parametricCoord)
            {
                var __arg2 = __parametricCoord2;
                fixed (long* __curvatures_n5 = &curvatures_n)
                {
                    var __arg5 = __curvatures_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelGetCurvature(dim, tag, __arg2, parametricCoord_n, curvatures, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelGetPrincipalCurvatures(int tag, double[] parametricCoord, long parametricCoord_n, double** curvatureMax, ref long curvatureMax_n, double** curvatureMin, ref long curvatureMin_n, double** directionMax, ref long directionMax_n, double** directionMin, ref long directionMin_n, ref int ierr)
        {
            fixed (double* __parametricCoord1 = parametricCoord)
            {
                var __arg1 = __parametricCoord1;
                fixed (long* __curvatureMax_n4 = &curvatureMax_n)
                {
                    var __arg4 = __curvatureMax_n4;
                    fixed (long* __curvatureMin_n6 = &curvatureMin_n)
                    {
                        var __arg6 = __curvatureMin_n6;
                        fixed (long* __directionMax_n8 = &directionMax_n)
                        {
                            var __arg8 = __directionMax_n8;
                            fixed (long* __directionMin_n10 = &directionMin_n)
                            {
                                var __arg10 = __directionMin_n10;
                                fixed (int* __ierr11 = &ierr)
                                {
                                    var __arg11 = __ierr11;
                                    __Internal.GmshModelGetPrincipalCurvatures(tag, __arg1, parametricCoord_n, curvatureMax, __arg4, curvatureMin, __arg6, directionMax, __arg8, directionMin, __arg10, __arg11);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelGetNormal(int tag, double[] parametricCoord, long parametricCoord_n, double** normals, ref long normals_n, ref int ierr)
        {
            fixed (double* __parametricCoord1 = parametricCoord)
            {
                var __arg1 = __parametricCoord1;
                fixed (long* __normals_n4 = &normals_n)
                {
                    var __arg4 = __normals_n4;
                    fixed (int* __ierr5 = &ierr)
                    {
                        var __arg5 = __ierr5;
                        __Internal.GmshModelGetNormal(tag, __arg1, parametricCoord_n, normals, __arg4, __arg5);
                    }
                }
            }
        }

        public static void GmshModelGetParametrization(int dim, int tag, double[] coord, long coord_n, double** parametricCoord, ref long parametricCoord_n, ref int ierr)
        {
            fixed (double* __coord2 = coord)
            {
                var __arg2 = __coord2;
                fixed (long* __parametricCoord_n5 = &parametricCoord_n)
                {
                    var __arg5 = __parametricCoord_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelGetParametrization(dim, tag, __arg2, coord_n, parametricCoord, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelGetParametrizationBounds(int dim, int tag, double** min, ref long min_n, double** max, ref long max_n, ref int ierr)
        {
            fixed (long* __min_n3 = &min_n)
            {
                var __arg3 = __min_n3;
                fixed (long* __max_n5 = &max_n)
                {
                    var __arg5 = __max_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelGetParametrizationBounds(dim, tag, min, __arg3, max, __arg5, __arg6);
                    }
                }
            }
        }

        public static int GmshModelIsInside(int dim, int tag, double[] parametricCoord, long parametricCoord_n, int parametric, ref int ierr)
        {
            fixed (double* __parametricCoord2 = parametricCoord)
            {
                var __arg2 = __parametricCoord2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelIsInside(dim, tag, __arg2, parametricCoord_n, parametric, __arg4);
                    return __ret;
                }
            }
        }

        public static void GmshModelGetAdjacencies(int dim, int tag, int[] upward, long upward_n, int[] downward, long downward_n)
		{
            fixed(int* __upward2 = upward)
			{
                var __arg3 = __upward2;
                fixed(int* __downward = downward)
				{
                    var __arg5 = __downward;
                    __Internal.GmshModelGetAdjacencies(dim, tag, __arg3, upward_n, __arg5, downward_n);

                }
			}
		}

        public static void GmshModelGetClosestPoint(int dim, int tag, double[] coord, long coord_n, double** closestCoord, ref long closestCoord_n, double** parametricCoord, ref long parametricCoord_n, ref int ierr)
        {
            fixed (double* __coord2 = coord)
            {
                var __arg2 = __coord2;
                fixed (long* __closestCoord_n5 = &closestCoord_n)
                {
                    var __arg5 = __closestCoord_n5;
                    fixed (long* __parametricCoord_n7 = &parametricCoord_n)
                    {
                        var __arg7 = __parametricCoord_n7;
                        fixed (int* __ierr8 = &ierr)
                        {
                            var __arg8 = __ierr8;
                            __Internal.GmshModelGetClosestPoint(dim, tag, __arg2, coord_n, closestCoord, __arg5, parametricCoord, __arg7, __arg8);
                        }
                    }
                }
            }
        }

        public static void GmshModelReparametrizeOnSurface(int dim, int tag, double[] parametricCoord, long parametricCoord_n, int surfaceTag, double** surfaceParametricCoord, ref long surfaceParametricCoord_n, int which, ref int ierr)
        {
            fixed (double* __parametricCoord2 = parametricCoord)
            {
                var __arg2 = __parametricCoord2;
                fixed (long* __surfaceParametricCoord_n6 = &surfaceParametricCoord_n)
                {
                    var __arg6 = __surfaceParametricCoord_n6;
                    fixed (int* __ierr8 = &ierr)
                    {
                        var __arg8 = __ierr8;
                        __Internal.GmshModelReparametrizeOnSurface(dim, tag, __arg2, parametricCoord_n, surfaceTag, surfaceParametricCoord, __arg6, which, __arg8);
                    }
                }
            }
        }

        public static void GmshModelSetVisibility(int[] dimTags, long dimTags_n, int value, int recursive, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelSetVisibility(__arg0, dimTags_n, value, recursive, __arg4);
                }
            }
        }

        public static void GmshModelGetVisibility(int dim, int tag, ref int value, ref int ierr)
        {
            fixed (int* __value2 = &value)
            {
                var __arg2 = __value2;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelGetVisibility(dim, tag, __arg2, __arg3);
                }
            }
        }

        public static void GmshModelSetColor(int[] dimTags, long dimTags_n, int r, int g, int b, int a, int recursive, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr7 = &ierr)
                {
                    var __arg7 = __ierr7;
                    __Internal.GmshModelSetColor(__arg0, dimTags_n, r, g, b, a, recursive, __arg7);
                }
            }
        }

        public static void GmshModelGetColor(int dim, int tag, ref int r, ref int g, ref int b, ref int a, ref int ierr)
        {
            fixed (int* __r2 = &r)
            {
                var __arg2 = __r2;
                fixed (int* __g3 = &g)
                {
                    var __arg3 = __g3;
                    fixed (int* __b4 = &b)
                    {
                        var __arg4 = __b4;
                        fixed (int* __a5 = &a)
                        {
                            var __arg5 = __a5;
                            fixed (int* __ierr6 = &ierr)
                            {
                                var __arg6 = __ierr6;
                                __Internal.GmshModelGetColor(dim, tag, __arg2, __arg3, __arg4, __arg5, __arg6);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelSetCoordinates(int tag, double x, double y, double z, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                __Internal.GmshModelSetCoordinates(tag, x, y, z, __arg4);
            }
        }

        public static void GmshModelSetTag(int dim, int tag, int newTag, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                __Internal.GmshModelSetTag(dim, tag, newTag, __arg4);
            }
        }

        public static void GmshModelMeshGenerate(int dim, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshGenerate(dim, __arg1);
            }
        }

        public static void GmshModelMeshPartition(int numPart, long[] elementTags, int elementTags_n, int[] partitions, int partitions_n, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                fixed (long* __elementTags = elementTags)
                {
                    var __arg2 = __elementTags;
                    fixed (int* __arg3 = partitions)
                    {
                        var __arg4 = __arg3;
                        __Internal.GmshModelMeshPartition(numPart, __arg2, elementTags_n, __arg4, partitions_n, __arg1);
                    }
                }
            }
        }

        public static void GmshModelMeshUnpartition(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshUnpartition(__arg0);
            }
        }

        public static void GmshModelMeshOptimize(string method, int force, int niter, int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags3 = dimTags)
            {
                var __arg3 = __dimTags3;
                fixed (int* __ierr5 = &ierr)
                {
                    var __arg5 = __ierr5;
                    __Internal.GmshModelMeshOptimize(method, force, niter, __arg3, dimTags_n, __arg5);
                }
            }
        }

        public static void GmshModelMeshRecombine(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshRecombine(__arg0);
            }
        }

        public static void GmshModelMeshRefine(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshRefine(__arg0);
            }
        }

        public static void GmshModelMeshSetOrder(int order, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshSetOrder(order, __arg1);
            }
        }

        public static void GmshModelMeshGetLastEntityError(int** dimTags, ref long dimTags_n, ref int ierr)
        {
            fixed (long* __dimTags_n1 = &dimTags_n)
            {
                var __arg1 = __dimTags_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshGetLastEntityError(dimTags, __arg1, __arg2);
                }
            }
        }

        public static void GmshModelMeshGetLastNodeError(long** nodeTags, ref long nodeTags_n, ref int ierr)
        {
            fixed (long* __nodeTags_n1 = &nodeTags_n)
            {
                var __arg1 = __nodeTags_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshGetLastNodeError(nodeTags, __arg1, __arg2);
                }
            }
        }

        public static void GmshModelMeshClear(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshClear(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshGetNodes(long** nodeTags, ref long nodeTags_n, double** coord, ref long coord_n, double** parametricCoord, ref long parametricCoord_n, int dim, int tag, int includeBoundary, int returnParametricCoord, ref int ierr)
        {
            fixed (long* __nodeTags_n1 = &nodeTags_n)
            {
                var __arg1 = __nodeTags_n1;
                fixed (long* __coord_n3 = &coord_n)
                {
                    var __arg3 = __coord_n3;
                    fixed (long* __parametricCoord_n5 = &parametricCoord_n)
                    {
                        var __arg5 = __parametricCoord_n5;
                        fixed (int* __ierr10 = &ierr)
                        {
                            var __arg10 = __ierr10;
                            __Internal.GmshModelMeshGetNodes(nodeTags, __arg1, coord, __arg3, parametricCoord, __arg5, dim, tag, includeBoundary, returnParametricCoord, __arg10);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetNodesByElementType(int elementType, long** nodeTags, ref long nodeTags_n, double** coord, ref long coord_n, double** parametricCoord, ref long parametricCoord_n, int tag, int returnParametricCoord, ref int ierr)
        {
            fixed (long* __nodeTags_n2 = &nodeTags_n)
            {
                var __arg2 = __nodeTags_n2;
                fixed (long* __coord_n4 = &coord_n)
                {
                    var __arg4 = __coord_n4;
                    fixed (long* __parametricCoord_n6 = &parametricCoord_n)
                    {
                        var __arg6 = __parametricCoord_n6;
                        fixed (int* __ierr9 = &ierr)
                        {
                            var __arg9 = __ierr9;
                            __Internal.GmshModelMeshGetNodesByElementType(elementType, nodeTags, __arg2, coord, __arg4, parametricCoord, __arg6, tag, returnParametricCoord, __arg9);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetNode(long nodeTag, double** coord, ref long coord_n, double** parametricCoord, ref long parametricCoord_n, ref int dim, ref int tag, ref int ierr)
        {
            fixed (long* __coord_n2 = &coord_n)
            {
                var __arg2 = __coord_n2;
                fixed (long* __parametricCoord_n4 = &parametricCoord_n)
                {
                    var __arg4 = __parametricCoord_n4;
                    fixed (int* __dim = &dim)
                    {
                        var __arg5 = __dim;
                        fixed (int* __tag = &tag)
                        {
                            var __arg6 = __tag;
                            fixed (int* __ierr5 = &ierr)
                            {
                                var __arg7 = __ierr5;
                                __Internal.GmshModelMeshGetNode(nodeTag, coord, __arg2, parametricCoord, __arg4, __arg5, __arg6, __arg7);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshSetNode(long nodeTag, double[] coord, long coord_n, double[] parametricCoord, long parametricCoord_n, ref int ierr)
        {
            fixed (double* __coord1 = coord)
            {
                var __arg1 = __coord1;
                fixed (double* __parametricCoord3 = parametricCoord)
                {
                    var __arg3 = __parametricCoord3;
                    fixed (int* __ierr5 = &ierr)
                    {
                        var __arg5 = __ierr5;
                        __Internal.GmshModelMeshSetNode(nodeTag, __arg1, coord_n, __arg3, parametricCoord_n, __arg5);
                    }
                }
            }
        }

        public static void GmshModelMeshRebuildNodeCache(int onlyIfNecessary, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshRebuildNodeCache(onlyIfNecessary, __arg1);
            }
        }

        public static void GmshModelMeshRebuildElementCache(int onlyIfNecessary, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshRebuildElementCache(onlyIfNecessary, __arg1);
            }
        }

        public static void GmshModelMeshGetNodesForPhysicalGroup(int dim, int tag, long** nodeTags, ref long nodeTags_n, double** coord, ref long coord_n, ref int ierr)
        {
            fixed (long* __nodeTags_n3 = &nodeTags_n)
            {
                var __arg3 = __nodeTags_n3;
                fixed (long* __coord_n5 = &coord_n)
                {
                    var __arg5 = __coord_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshGetNodesForPhysicalGroup(dim, tag, nodeTags, __arg3, coord, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshAddNodes(int dim, int tag, long[] nodeTags, long nodeTags_n, double[] coord, long coord_n, double[] parametricCoord, long parametricCoord_n, ref int ierr)
        {
            fixed (long* __nodeTags2 = nodeTags)
            {
                var __arg2 = __nodeTags2;
                fixed (double* __coord4 = coord)
                {
                    var __arg4 = __coord4;
                    fixed (double* __parametricCoord6 = parametricCoord)
                    {
                        var __arg6 = __parametricCoord6;
                        fixed (int* __ierr8 = &ierr)
                        {
                            var __arg8 = __ierr8;
                            __Internal.GmshModelMeshAddNodes(dim, tag, __arg2, nodeTags_n, __arg4, coord_n, __arg6, parametricCoord_n, __arg8);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshReclassifyNodes(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshReclassifyNodes(__arg0);
            }
        }

        public static void GmshModelMeshRelocateNodes(int dim, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshRelocateNodes(dim, tag, __arg2);
            }
        }

        public static void GmshModelMeshGetElements(int** elementTypes, ref long elementTypes_n, long*** elementTags, long** elementTags_n, ref long elementTags_nn, long*** nodeTags, long** nodeTags_n, ref long nodeTags_nn, int dim, int tag, ref int ierr)
        {
            fixed (long* __elementTypes_n1 = &elementTypes_n)
            {
                var __arg1 = __elementTypes_n1;
                fixed (long* __elementTags_nn4 = &elementTags_nn)
                {
                    var __arg4 = __elementTags_nn4;
                    fixed (long* __nodeTags_nn7 = &nodeTags_nn)
                    {
                        var __arg7 = __nodeTags_nn7;
                        fixed (int* __ierr10 = &ierr)
                        {
                            var __arg10 = __ierr10;
                            __Internal.GmshModelMeshGetElements(elementTypes, __arg1, elementTags, elementTags_n, __arg4, nodeTags, nodeTags_n, __arg7, dim, tag, __arg10);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetElement(long elementTag, ref int elementType, long** nodeTags, ref long nodeTags_n, ref int dim, ref int tag, ref int ierr)
        {
            fixed (int* __elementType1 = &elementType)
            {
                var __arg1 = __elementType1;
                fixed (long* __nodeTags_n3 = &nodeTags_n)
                {
                    var __arg3 = __nodeTags_n3;
                    fixed (int* __dim = &dim)
                    {
                        var __arg5 = __dim;
                        fixed (int* __tag = &tag)
                        {
                            var __arg6 = __tag;
                            fixed (int* __ierr4 = &ierr)
                            {
                                var __arg7 = __ierr4;
                                __Internal.GmshModelMeshGetElement(elementTag, __arg1, nodeTags, __arg3, __arg5, __arg6, __arg7);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetElementByCoordinates(double x, double y, double z, ref long elementTag, ref int elementType, long** nodeTags, ref long nodeTags_n, ref double u, ref double v, ref double w, int dim, int strict, ref int ierr)
        {
            fixed (long* __elementTag3 = &elementTag)
            {
                var __arg3 = __elementTag3;
                fixed (int* __elementType4 = &elementType)
                {
                    var __arg4 = __elementType4;
                    fixed (long* __nodeTags_n6 = &nodeTags_n)
                    {
                        var __arg6 = __nodeTags_n6;
                        fixed (double* __u7 = &u)
                        {
                            var __arg7 = __u7;
                            fixed (double* __v8 = &v)
                            {
                                var __arg8 = __v8;
                                fixed (double* __w9 = &w)
                                {
                                    var __arg9 = __w9;
                                    fixed (int* __ierr12 = &ierr)
                                    {
                                        var __arg12 = __ierr12;
                                        __Internal.GmshModelMeshGetElementByCoordinates(x, y, z, __arg3, __arg4, nodeTags, __arg6, __arg7, __arg8, __arg9, dim, strict, __arg12);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetElementsByCoordinates(double x, double y, double z, long** elementTags, ref long elementTags_n, int dim, int strict, ref int ierr)
        {
            fixed (long* __elementTags_n4 = &elementTags_n)
            {
                var __arg4 = __elementTags_n4;
                fixed (int* __ierr7 = &ierr)
                {
                    var __arg7 = __ierr7;
                    __Internal.GmshModelMeshGetElementsByCoordinates(x, y, z, elementTags, __arg4, dim, strict, __arg7);
                }
            }
        }

        public static void GmshModelMeshGetLocalCoordinatesInElement(long elementTag, double x, double y, double z, ref double u, ref double v, ref double w, ref int ierr)
        {
            fixed (double* __u4 = &u)
            {
                var __arg4 = __u4;
                fixed (double* __v5 = &v)
                {
                    var __arg5 = __v5;
                    fixed (double* __w6 = &w)
                    {
                        var __arg6 = __w6;
                        fixed (int* __ierr7 = &ierr)
                        {
                            var __arg7 = __ierr7;
                            __Internal.GmshModelMeshGetLocalCoordinatesInElement(elementTag, x, y, z, __arg4, __arg5, __arg6, __arg7);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetElementTypes(int** elementTypes, ref long elementTypes_n, int dim, int tag, ref int ierr)
        {
            fixed (long* __elementTypes_n1 = &elementTypes_n)
            {
                var __arg1 = __elementTypes_n1;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelMeshGetElementTypes(elementTypes, __arg1, dim, tag, __arg4);
                }
            }
        }

        public static int GmshModelMeshGetElementType(string familyName, int order, int serendip, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var __ret = __Internal.GmshModelMeshGetElementType(familyName, order, serendip, __arg3);
                return __ret;
            }
        }

        public static void GmshModelMeshGetElementProperties(int elementType, byte** elementName, ref int dim, ref int order, ref int numNodes, double** localNodeCoord, ref long localNodeCoord_n, ref int numPrimaryNodes, ref int ierr)
        {
            fixed (int* __dim2 = &dim)
            {
                var __arg2 = __dim2;
                fixed (int* __order3 = &order)
                {
                    var __arg3 = __order3;
                    fixed (int* __numNodes4 = &numNodes)
                    {
                        var __arg4 = __numNodes4;
                        fixed (long* __localNodeCoord_n6 = &localNodeCoord_n)
                        {
                            var __arg6 = __localNodeCoord_n6;
                            fixed (int* __numPrimaryNodes7 = &numPrimaryNodes)
                            {
                                var __arg7 = __numPrimaryNodes7;
                                fixed (int* __ierr8 = &ierr)
                                {
                                    var __arg8 = __ierr8;
                                    __Internal.GmshModelMeshGetElementProperties(elementType, elementName, __arg2, __arg3, __arg4, localNodeCoord, __arg6, __arg7, __arg8);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetElementsByType(int elementType, long** elementTags, ref long elementTags_n, long** nodeTags, ref long nodeTags_n, int tag, long task, long numTasks, ref int ierr)
        {
            fixed (long* __elementTags_n2 = &elementTags_n)
            {
                var __arg2 = __elementTags_n2;
                fixed (long* __nodeTags_n4 = &nodeTags_n)
                {
                    var __arg4 = __nodeTags_n4;
                    fixed (int* __ierr8 = &ierr)
                    {
                        var __arg8 = __ierr8;
                        __Internal.GmshModelMeshGetElementsByType(elementType, elementTags, __arg2, nodeTags, __arg4, tag, task, numTasks, __arg8);
                    }
                }
            }
        }

        public static void GmshModelMeshPreallocateElementsByType(int elementType, int elementTag, int nodeTag, long** elementTags, ref long elementTags_n, long** nodeTags, ref long nodeTags_n, int tag, ref int ierr)
        {
            fixed (long* __elementTags_n4 = &elementTags_n)
            {
                var __arg4 = __elementTags_n4;
                fixed (long* __nodeTags_n6 = &nodeTags_n)
                {
                    var __arg6 = __nodeTags_n6;
                    fixed (int* __ierr8 = &ierr)
                    {
                        var __arg8 = __ierr8;
                        __Internal.GmshModelMeshPreallocateElementsByType(elementType, elementTag, nodeTag, elementTags, __arg4, nodeTags, __arg6, tag, __arg8);
                    }
                }
            }
        }

        public static void GmshModelMeshAddElements(int dim, int tag, int[] elementTypes, long elementTypes_n, long** elementTags, long[] elementTags_n, long elementTags_nn, long** nodeTags, long[] nodeTags_n, long nodeTags_nn, ref int ierr)
        {
            fixed (int* __elementTypes2 = elementTypes)
            {
                var __arg2 = __elementTypes2;
                fixed (long* __elementTags_n5 = elementTags_n)
                {
                    var __arg5 = __elementTags_n5;
                    fixed (long* __nodeTags_n8 = nodeTags_n)
                    {
                        var __arg8 = __nodeTags_n8;
                        fixed (int* __ierr10 = &ierr)
                        {
                            var __arg10 = __ierr10;
                            __Internal.GmshModelMeshAddElements(dim, tag, __arg2, elementTypes_n, elementTags, __arg5, elementTags_nn, nodeTags, __arg8, nodeTags_nn, __arg10);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshAddElementsByType(int tag, int elementType, long[] elementTags, long elementTags_n, long[] nodeTags, long nodeTags_n, ref int ierr)
        {
            fixed (long* __elementTags2 = elementTags)
            {
                var __arg2 = __elementTags2;
                fixed (long* __nodeTags4 = nodeTags)
                {
                    var __arg4 = __nodeTags4;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshAddElementsByType(tag, elementType, __arg2, elementTags_n, __arg4, nodeTags_n, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshGetIntegrationPoints(int elementType, string integrationType, double** localCoord, ref long localCoord_n, double** weights, ref long weights_n, ref int ierr)
        {
            fixed (long* __localCoord_n3 = &localCoord_n)
            {
                var __arg3 = __localCoord_n3;
                fixed (long* __weights_n5 = &weights_n)
                {
                    var __arg5 = __weights_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshGetIntegrationPoints(elementType, integrationType, localCoord, __arg3, weights, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshGetJacobians(int elementType, double[] localCoord, long localCoord_n, double** jacobians, ref long jacobians_n, double** determinants, ref long determinants_n, double** coord, ref long coord_n, int tag, long task, long numTasks, ref int ierr)
        {
            fixed (double* __localCoord1 = localCoord)
            {
                var __arg1 = __localCoord1;
                fixed (long* __jacobians_n4 = &jacobians_n)
                {
                    var __arg4 = __jacobians_n4;
                    fixed (long* __determinants_n6 = &determinants_n)
                    {
                        var __arg6 = __determinants_n6;
                        fixed (long* __coord_n8 = &coord_n)
                        {
                            var __arg8 = __coord_n8;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelMeshGetJacobians(elementType, __arg1, localCoord_n, jacobians, __arg4, determinants, __arg6, coord, __arg8, tag, task, numTasks, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshPreallocateJacobians(int elementType, int numEvaluationPoints, int allocateJacobians, int allocateDeterminants, int allocateCoord, double** jacobians, ref long jacobians_n, double** determinants, ref long determinants_n, double** coord, ref long coord_n, int tag, ref int ierr)
        {
            fixed (long* __jacobians_n6 = &jacobians_n)
            {
                var __arg6 = __jacobians_n6;
                fixed (long* __determinants_n8 = &determinants_n)
                {
                    var __arg8 = __determinants_n8;
                    fixed (long* __coord_n10 = &coord_n)
                    {
                        var __arg10 = __coord_n10;
                        fixed (int* __ierr12 = &ierr)
                        {
                            var __arg12 = __ierr12;
                            __Internal.GmshModelMeshPreallocateJacobians(elementType, numEvaluationPoints, allocateJacobians, allocateDeterminants, allocateCoord, jacobians, __arg6, determinants, __arg8, coord, __arg10, tag, __arg12);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetJacobian(long elementTag, double[] localCoord, long localCoord_n, double** jacobians, ref long jacobians_n, double** determinants, ref long determinants_n, double** coord, ref long coord_n, ref int ierr)
        {
            fixed (double* __localCoord1 = localCoord)
            {
                var __arg1 = __localCoord1;
                fixed (long* __jacobians_n4 = &jacobians_n)
                {
                    var __arg4 = __jacobians_n4;
                    fixed (long* __determinants_n6 = &determinants_n)
                    {
                        var __arg6 = __determinants_n6;
                        fixed (long* __coord_n8 = &coord_n)
                        {
                            var __arg8 = __coord_n8;
                            fixed (int* __ierr9 = &ierr)
                            {
                                var __arg9 = __ierr9;
                                __Internal.GmshModelMeshGetJacobian(elementTag, __arg1, localCoord_n, jacobians, __arg4, determinants, __arg6, coord, __arg8, __arg9);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetBasisFunctions(int elementType, double[] localCoord, long localCoord_n, string functionSpaceType, ref int numComponents, double** basisFunctions, ref long basisFunctions_n, ref int numOrientations, int[] wantedOrientations, long wantedOrientations_n, ref int ierr)
        {
            fixed (double* __localCoord1 = localCoord)
            {
                var __arg1 = __localCoord1;
                fixed (int* __numComponents4 = &numComponents)
                {
                    var __arg4 = __numComponents4;
                    fixed (long* __basisFunctions_n6 = &basisFunctions_n)
                    {
                        var __arg6 = __basisFunctions_n6;
                        fixed (int* __numOrientations7 = &numOrientations)
                        {
                            var __arg7 = __numOrientations7;
                            fixed (int* __wantedOrientations8 = wantedOrientations)
                            {
                                var __arg8 = __wantedOrientations8;
                                fixed (int* __ierr10 = &ierr)
                                {
                                    var __arg10 = __ierr10;
                                    __Internal.GmshModelMeshGetBasisFunctions(elementType, __arg1, localCoord_n, functionSpaceType, __arg4, basisFunctions, __arg6, __arg7, __arg8, wantedOrientations_n, __arg10);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetBasisFunctionsOrientation(int elementType, string functionSpaceType, int** basisFunctionsOrientation, ref long basisFunctionsOrientation_n, int tag, long task, long numTasks, ref int ierr)
        {
            fixed (long* __basisFunctionsOrientation_n3 = &basisFunctionsOrientation_n)
            {
                var __arg3 = __basisFunctionsOrientation_n3;
                fixed (int* __ierr7 = &ierr)
                {
                    var __arg7 = __ierr7;
                    __Internal.GmshModelMeshGetBasisFunctionsOrientation(elementType, functionSpaceType, basisFunctionsOrientation, __arg3, tag, task, numTasks, __arg7);
                }
            }
        }

        public static void GmshModelMeshGetBasisFunctionsOrientationForElement(long elementTag, string functionSpaceType, ref int basisFunctionsOrientation, ref int ierr)
        {
            fixed (int* __basisFunctionsOrientation2 = &basisFunctionsOrientation)
            {
                var __arg2 = __basisFunctionsOrientation2;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelMeshGetBasisFunctionsOrientationForElement(elementTag, functionSpaceType, __arg2, __arg3);
                }
            }
        }

        public static int GmshModelMeshGetNumberOfOrientations(int elementType, string functionSpaceType, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                var __ret = __Internal.GmshModelMeshGetNumberOfOrientations(elementType, functionSpaceType, __arg2);
                return __ret;
            }
        }

        public static void GmshModelMeshPreallocateBasisFunctionsOrientation(int elementType, int** basisFunctionsOrientation, ref long basisFunctionsOrientation_n, int tag, ref int ierr)
        {
            fixed (long* __basisFunctionsOrientation_n2 = &basisFunctionsOrientation_n)
            {
                var __arg2 = __basisFunctionsOrientation_n2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelMeshPreallocateBasisFunctionsOrientation(elementType, basisFunctionsOrientation, __arg2, tag, __arg4);
                }
            }
        }

        public static void GmshModelMeshGetEdges(int[] edgeNodes, long edgeNodes_n, int** edgeNum, ref long edgeNum_n, ref int ierr)
        {
            fixed (int* __edgeNodes0 = edgeNodes)
            {
                var __arg0 = __edgeNodes0;
                fixed (long* __edgeNum_n3 = &edgeNum_n)
                {
                    var __arg3 = __edgeNum_n3;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelMeshGetEdges(__arg0, edgeNodes_n, edgeNum, __arg3, __arg4);
                    }
                }
            }
        }

        public static void GmshModelMeshGetGetFaces(int faceType, int[] nodeTags, long nodeTags_n, int** faceTags, ref long faceTags_n, int** faceOrientations, ref long faceOrientations_n, ref int ierr)
        {
            fixed (int* __nodeTags_n1 = nodeTags)
            {
                var __arg1 = __nodeTags_n1;
                fixed (long* __edgeNum_n3 = &faceTags_n)
                {
                    var __arg3 = __edgeNum_n3;
                    fixed (long* __faceOrientations_n5 = &faceOrientations_n)
                    {
                        var __arg5 = __faceOrientations_n5;
                        fixed (int* __ierr6 = &ierr)
                        {
                            var __arg6 = __ierr6;
                            __Internal.GmshModelMeshGetFaces(faceType, __arg1, nodeTags_n, faceTags, __arg3, faceOrientations, __arg5, __arg6);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetKeys(int elementType, string functionSpaceType, int** keys, ref long keys_n, double** coord, ref long coord_n, int tag, int returnCoord, ref int ierr)
        {
            fixed (long* __keys_n3 = &keys_n)
            {
                var __arg3 = __keys_n3;
                fixed (long* __coord_n5 = &coord_n)
                {
                    var __arg5 = __coord_n5;
                    fixed (int* __ierr8 = &ierr)
                    {
                        var __arg8 = __ierr8;
                        __Internal.GmshModelMeshGetKeys(elementType, functionSpaceType, keys, __arg3, coord, __arg5, tag, returnCoord, __arg8);
                    }
                }
            }
        }

        public static void GmshModelMeshGetKeysForElement(long elementTag, string functionSpaceType, int** typeKeys, ref long typeKeys_n, long** entityKeys, ref long entityKeys_n, double** coord, ref long coord_n, int returnCoord, ref int ierr)
        {
            fixed (long* __keys_n3 = &typeKeys_n)
            {
                var __arg3 = __keys_n3;
                fixed (long* __entityKeys_n = &entityKeys_n)
                {
                    var __arg4 = __entityKeys_n;
                    fixed (long* __coord_n5 = &coord_n)
                    {
                        var __arg5 = __coord_n5;
                        fixed (int* __ierr7 = &ierr)
                        {
                            var __arg7 = __ierr7;
                            __Internal.GmshModelMeshGetKeysForElement(elementTag, functionSpaceType, typeKeys, __arg3, entityKeys, __arg4, coord, __arg5, returnCoord, __arg7);
                        }
                    }
                }                
            }
        }

        public static int GmshModelMeshGetNumberOfKeys(int elementType, string functionSpaceType, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                var __ret = __Internal.GmshModelMeshGetNumberOfKeys(elementType, functionSpaceType, __arg2);
                return __ret;
            }
        }

        public static void GmshModelMeshGetKeysInformation(int[] keys, long keys_n, int elementType, string functionSpaceType, int** infoKeys, ref long infoKeys_n, ref int ierr)
        {
            fixed (int* __keys0 = keys)
            {
                var __arg0 = __keys0;
                fixed (long* __infoKeys_n5 = &infoKeys_n)
                {
                    var __arg5 = __infoKeys_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshGetKeysInformation(__arg0, keys_n, elementType, functionSpaceType, infoKeys, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshGetBarycenters(int elementType, int tag, int fast, int primary, double** barycenters, ref long barycenters_n, long task, long numTasks, ref int ierr)
        {
            fixed (long* __barycenters_n5 = &barycenters_n)
            {
                var __arg5 = __barycenters_n5;
                fixed (int* __ierr8 = &ierr)
                {
                    var __arg8 = __ierr8;
                    __Internal.GmshModelMeshGetBarycenters(elementType, tag, fast, primary, barycenters, __arg5, task, numTasks, __arg8);
                }
            }
        }

        public static void GmshModelMeshPreallocateBarycenters(int elementType, double** barycenters, ref long barycenters_n, int tag, ref int ierr)
        {
            fixed (long* __barycenters_n2 = &barycenters_n)
            {
                var __arg2 = __barycenters_n2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelMeshPreallocateBarycenters(elementType, barycenters, __arg2, tag, __arg4);
                }
            }
        }

        public static void GmshModelMeshGetElementEdgeNodes(int elementType, long** nodeTags, ref long nodeTags_n, int tag, int primary, long task, long numTasks, ref int ierr)
        {
            fixed (long* __nodeTags_n2 = &nodeTags_n)
            {
                var __arg2 = __nodeTags_n2;
                fixed (int* __ierr7 = &ierr)
                {
                    var __arg7 = __ierr7;
                    __Internal.GmshModelMeshGetElementEdgeNodes(elementType, nodeTags, __arg2, tag, primary, task, numTasks, __arg7);
                }
            }
        }

        public static void GmshModelMeshGetElementFaceNodes(int elementType, int faceType, long** nodeTags, ref long nodeTags_n, int tag, int primary, long task, long numTasks, ref int ierr)
        {
            fixed (long* __nodeTags_n3 = &nodeTags_n)
            {
                var __arg3 = __nodeTags_n3;
                fixed (int* __ierr8 = &ierr)
                {
                    var __arg8 = __ierr8;
                    __Internal.GmshModelMeshGetElementFaceNodes(elementType, faceType, nodeTags, __arg3, tag, primary, task, numTasks, __arg8);
                }
            }
        }

        public static void GmshModelMeshGetGhostElements(int dim, int tag, long** elementTags, ref long elementTags_n, int** partitions, ref long partitions_n, ref int ierr)
        {
            fixed (long* __elementTags_n3 = &elementTags_n)
            {
                var __arg3 = __elementTags_n3;
                fixed (long* __partitions_n5 = &partitions_n)
                {
                    var __arg5 = __partitions_n5;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshGetGhostElements(dim, tag, elementTags, __arg3, partitions, __arg5, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshSetSize(int[] dimTags, long dimTags_n, double size, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelMeshSetSize(__arg0, dimTags_n, size, __arg3);
                }
            }
        }

        public static void GmshModelMeshSetSizeAtParametricPoints(int dim, int tag, double[] parametricCoord, long parametricCoord_n, double[] sizes, long sizes_n, ref int ierr)
        {
            fixed (double* __parametricCoord2 = parametricCoord)
            {
                var __arg2 = __parametricCoord2;
                fixed (double* __sizes4 = sizes)
                {
                    var __arg4 = __sizes4;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshSetSizeAtParametricPoints(dim, tag, __arg2, parametricCoord_n, __arg4, sizes_n, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshSetTransfiniteCurve(int tag, int numNodes, string meshType, double coef, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                __Internal.GmshModelMeshSetTransfiniteCurve(tag, numNodes, meshType, coef, __arg4);
            }
        }

        public static void GmshModelMeshSetTransfiniteSurface(int tag, string arrangement, int[] cornerTags, long cornerTags_n, ref int ierr)
        {
            fixed (int* __cornerTags2 = cornerTags)
            {
                var __arg2 = __cornerTags2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelMeshSetTransfiniteSurface(tag, arrangement, __arg2, cornerTags_n, __arg4);
                }
            }
        }

        public static void GmshModelMeshSetTransfiniteVolume(int tag, int[] cornerTags, long cornerTags_n, ref int ierr)
        {
            fixed (int* __cornerTags1 = cornerTags)
            {
                var __arg1 = __cornerTags1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelMeshSetTransfiniteVolume(tag, __arg1, cornerTags_n, __arg3);
                }
            }
        }

        public static void GmshModelMeshSetRecombine(int dim, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshSetRecombine(dim, tag, __arg2);
            }
        }

        public static void GmshModelMeshSetSmoothing(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelMeshSetSmoothing(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelMeshSetReverse(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelMeshSetReverse(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelMeshSetAlgorithm(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelMeshSetAlgorithm(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelMeshSetSizeFromBoundary(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelMeshSetSizeFromBoundary(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelMeshSetCompound(int dim, int[] tags, long tags_n, ref int ierr)
        {
            fixed (int* __tags1 = tags)
            {
                var __arg1 = __tags1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelMeshSetCompound(dim, __arg1, tags_n, __arg3);
                }
            }
        }

        public static void GmshModelMeshSetOutwardOrientation(int tag, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshSetOutwardOrientation(tag, __arg1);
            }
        }

        public static void GmshModelMeshEmbed(int dim, int[] tags, long tags_n, int inDim, int inTag, ref int ierr)
        {
            fixed (int* __tags1 = tags)
            {
                var __arg1 = __tags1;
                fixed (int* __ierr5 = &ierr)
                {
                    var __arg5 = __ierr5;
                    __Internal.GmshModelMeshEmbed(dim, __arg1, tags_n, inDim, inTag, __arg5);
                }
            }
        }

        public static void GmshModelMeshRemoveEmbedded(int[] dimTags, long dimTags_n, int dim, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelMeshRemoveEmbedded(__arg0, dimTags_n, dim, __arg3);
                }
            }
        }

        public static void GmshModelMeshReorderElements(int elementType, int tag, long[] ordering, long ordering_n, ref int ierr)
        {
            fixed (long* __ordering2 = ordering)
            {
                var __arg2 = __ordering2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelMeshReorderElements(elementType, tag, __arg2, ordering_n, __arg4);
                }
            }
        }

        public static void GmshModelMeshRenumberNodes(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshRenumberNodes(__arg0);
            }
        }

        public static void GmshModelMeshRenumberElements(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshRenumberElements(__arg0);
            }
        }

        public static void GmshModelMeshSetPeriodic(int dim, int[] tags, long tags_n, int[] tagsMaster, long tagsMaster_n, double[] affineTransform, long affineTransform_n, ref int ierr)
        {
            fixed (int* __tags1 = tags)
            {
                var __arg1 = __tags1;
                fixed (int* __tagsMaster3 = tagsMaster)
                {
                    var __arg3 = __tagsMaster3;
                    fixed (double* __affineTransform5 = affineTransform)
                    {
                        var __arg5 = __affineTransform5;
                        fixed (int* __ierr7 = &ierr)
                        {
                            var __arg7 = __ierr7;
                            __Internal.GmshModelMeshSetPeriodic(dim, __arg1, tags_n, __arg3, tagsMaster_n, __arg5, affineTransform_n, __arg7);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshGetPeriodic(int dim, int[] tags, long tags_n, int** tagsMaster, ref int tagsMaster_n, ref int ierr)
        {
            fixed (int* __tags1 = tags)
            {
                var __arg1 = __tags1;
                fixed (int* __tagsMaster3 = &tagsMaster_n)
                {
                    var __arg3 = __tagsMaster3;
                    fixed (int* __ierr7 = &ierr)
                    {
                        var __arg7 = __ierr7;
                        __Internal.GmshModelMeshGetPeriodic(dim, __arg1, tags_n, tagsMaster, __arg3, __arg7);
                    }
                }
            }
        }

        public static void GmshModelMeshGetAllEdges(long** edgeTags, ref long edgeTags_n, long** edgeNodes, ref long edgeNodes_n, ref int ierr)
        {
            fixed (long* __tags1 = &edgeTags_n)
            {
                var __arg1 = __tags1;
                fixed (long* __tagsMaster3 = &edgeNodes_n)
                {
                    var __arg3 = __tagsMaster3;
                    fixed (int* __ierr7 = &ierr)
                    {
                        var __arg7 = __ierr7;
                        __Internal.GmshModelMeshGetAllEdges(edgeTags, __arg1, edgeNodes, __arg3, __arg7);
                    }
                }
            }
        }

        public static void GmshModelMeshGetAllFaces(int faceType, long** edgeTags, ref long edgeTags_n, long** edgeNodes, ref long edgeNodes_n, ref int ierr)
        {
            fixed (long* __tags1 = &edgeTags_n)
            {
                var __arg1 = __tags1;
                fixed (long* __tagsMaster3 = &edgeNodes_n)
                {
                    var __arg3 = __tagsMaster3;
                    fixed (int* __ierr7 = &ierr)
                    {
                        var __arg7 = __ierr7;
                        __Internal.GmshModelMeshGetAllFaces(faceType, edgeTags, __arg1, edgeNodes, __arg3, __arg7);
                    }
                }
            }
        }

        public static void GmshModelMeshAddEdges(long[] edgeTags, long edgeTags_n, long[] edgeNodes, long edgeNodes_n, ref int ierr)
		{
            fixed (long* __edgeTags2 = edgeTags)
            {
                var __arg0 = __edgeTags2;
                fixed (long* __edgeNodes2 = edgeNodes)
                {
                    var __arg2 = __edgeNodes2;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelMeshAddEdges(__arg0, edgeTags_n, __arg2, edgeNodes_n, __arg4);
                    }
                }
            }
        }

        public static void GmshModelMeshAddFaces(int faceType, long[] edgeTags, long edgeTags_n, long[] edgeNodes, long edgeNodes_n, ref int ierr)
        {
            fixed (long* __edgeTags2 = edgeTags)
            {
                var __arg0 = __edgeTags2;
                fixed (long* __edgeNodes2 = edgeNodes)
                {
                    var __arg2 = __edgeNodes2;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelMeshAddFaces(faceType, __arg0, edgeTags_n, __arg2, edgeNodes_n, __arg4);
                    }
                }
            }
        }

        public static void GmshModelMeshGetPeriodicNodes(int dim, int tag, ref int tagMaster, long** nodeTags, ref long nodeTags_n, long** nodeTagsMaster, ref long nodeTagsMaster_n, double** affineTransform, ref long affineTransform_n, int includeHighOrderNodes, ref int ierr)
        {
            fixed (int* __tagMaster2 = &tagMaster)
            {
                var __arg2 = __tagMaster2;
                fixed (long* __nodeTags_n4 = &nodeTags_n)
                {
                    var __arg4 = __nodeTags_n4;
                    fixed (long* __nodeTagsMaster_n6 = &nodeTagsMaster_n)
                    {
                        var __arg6 = __nodeTagsMaster_n6;
                        fixed (long* __affineTransform_n8 = &affineTransform_n)
                        {
                            var __arg8 = __affineTransform_n8;
                            fixed (int* __ierr10 = &ierr)
                            {
                                var __arg10 = __ierr10;
                                __Internal.GmshModelMeshGetPeriodicNodes(dim, tag, __arg2, nodeTags, __arg4, nodeTagsMaster, __arg6, affineTransform, __arg8, includeHighOrderNodes, __arg10);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshRemoveDuplicateNodes(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelMeshRemoveDuplicateNodes(__arg0);
            }
        }

        public static void GmshModelMeshSplitQuadrangles(double quality, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshSplitQuadrangles(quality, tag, __arg2);
            }
        }

        public static void GmshModelMeshClassifySurfaces(double angle, int boundary, int forReparametrization, double curveAngle, int exportDiscrete, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                __Internal.GmshModelMeshClassifySurfaces(angle, boundary, forReparametrization, curveAngle, exportDiscrete,__arg4);
            }
        }

        public static void GmshModelMeshCreateGeometry(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshCreateGeometry(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshCreateTopology(int makeSimplyConnected, int exportDiscrete, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshCreateTopology(makeSimplyConnected, exportDiscrete, __arg2);
            }
        }

        public static void GmshModelMeshComputeHomology(int[] domainTags, long domainTags_n, int[] subdomainTags, long subdomainTags_n, int[] dims, long dims_n, ref int ierr)
        {
            fixed (int* __domainTags0 = domainTags)
            {
                var __arg0 = __domainTags0;
                fixed (int* __subdomainTags2 = subdomainTags)
                {
                    var __arg2 = __subdomainTags2;
                    fixed (int* __dims4 = dims)
                    {
                        var __arg4 = __dims4;
                        fixed (int* __ierr6 = &ierr)
                        {
                            var __arg6 = __ierr6;
                            __Internal.GmshModelMeshComputeHomology(__arg0, domainTags_n, __arg2, subdomainTags_n, __arg4, dims_n, __arg6);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshComputeCohomology(int[] domainTags, long domainTags_n, int[] subdomainTags, long subdomainTags_n, int[] dims, long dims_n, ref int ierr)
        {
            fixed (int* __domainTags0 = domainTags)
            {
                var __arg0 = __domainTags0;
                fixed (int* __subdomainTags2 = subdomainTags)
                {
                    var __arg2 = __subdomainTags2;
                    fixed (int* __dims4 = dims)
                    {
                        var __arg4 = __dims4;
                        fixed (int* __ierr6 = &ierr)
                        {
                            var __arg6 = __ierr6;
                            __Internal.GmshModelMeshComputeCohomology(__arg0, domainTags_n, __arg2, subdomainTags_n, __arg4, dims_n, __arg6);
                        }
                    }
                }
            }
        }

        public static void GmshModelMeshComputeCrossField(int** viewTags, ref long viewTags_n, ref int ierr)
        {
            fixed (long* __viewTags_n1 = &viewTags_n)
            {
                var __arg1 = __viewTags_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshComputeCrossField(viewTags, __arg1, __arg2);
                }
            }
        }

        public static void GmshModelMeshReverse(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshReverse(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshAffineTransform(double[] affineTransform, long affineTransform_n, int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (double* __domainTags0 = affineTransform)
            {
                var __arg0 = __domainTags0;
                fixed (int* __subdomainTags2 = dimTags)
                {
                    var __arg2 = __subdomainTags2;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshAffineTransform(__arg0, affineTransform_n, __arg2, dimTags_n, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshGetMaxNodeTag(ref long maxtag, ref int ierr)
        {
            fixed (long* __domainTags0 = &maxtag)
            {
                var __maxTag = __domainTags0;   
                fixed (int* __ierr6 = &ierr)
                {
                    var __arg6 = __ierr6;
                    __Internal.GmshModelMeshGetMaxNodeTag(__maxTag, __arg6);
                }
            }
        }

        public static void GmshModelMeshGetMaxElementTag(ref long maxtag, ref int ierr)
        {
            fixed (long* __domainTags0 = &maxtag)
            {
                var __maxTag = __domainTags0;
                fixed (int* __ierr6 = &ierr)
                {
                    var __arg6 = __ierr6;
                    __Internal.GmshModelMeshGetMaxElementTag(__maxTag, __arg6);
                }
            }
        }

        public static int GmshModelGetNumberOfPartitions(ref int ierr)
        {
            fixed (int* __ierr6 = &ierr)
            {
                var __arg6 = __ierr6;
                var __ret = __Internal.GmshModelGetNumberOfPartitions(__arg6);
                return __ret;
            }
        }

        public static void GmshModelMeshImportStl(ref int ierr)
        {
            fixed (int* __ierr6 = &ierr)
            {
                var __arg6 = __ierr6;
                 __Internal.GmshModelMeshImportStl(__arg6);
            }
        }

        public static void GmshModelMeshGetDuplicateNodes(int** tags, ref long tags_n, int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (long* __domainTags0 = &tags_n)
            {
                var __arg0 = __domainTags0;
                fixed (int* __subdomainTags2 = dimTags)
                {
                    var __arg2 = __subdomainTags2;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshGetDuplicateNodes(tags, __arg0, __arg2, dimTags_n, __arg6);
                    }
                }
            }
        }

        public static void GmshModelMeshGetSizes(int[] dimTags, long dimTags_n, double** sizes, ref long sizes_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __sizes_n = &sizes_n)
                {
                    var __arg2 = __sizes_n;
                    fixed (int* __ierr6 = &ierr)
                    {
                        var __arg6 = __ierr6;
                        __Internal.GmshModelMeshGetSizes(__arg0, dimTags_n, sizes, ref __arg2, __arg6);
                    }
                }
            }
        }

        public static int GmshModelMeshFieldAdd(string fieldType, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                var __ret = __Internal.GmshModelMeshFieldAdd(fieldType, tag, __arg2);
                return __ret;
            }
        }

        public static void GmshModelMeshFieldRemove(int tag, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshFieldRemove(tag, __arg1);
            }
        }

        public static void GmshModelMeshFieldSetNumber(int tag, string option, double value, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelMeshFieldSetNumber(tag, option, value, __arg3);
            }
        }

        public static void GmshModelMeshFieldSetString(int tag, string option, string value, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelMeshFieldSetString(tag, option, value, __arg3);
            }
        }

        public static void GmshModelMeshFieldSetNumbers(int tag, string option, double[] value, long value_n, ref int ierr)
        {
            fixed (double* __value2 = value)
            {
                var __arg2 = __value2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelMeshFieldSetNumbers(tag, option, __arg2, value_n, __arg4);
                }
            }
        }

        public static void GmshModelMeshFieldSetAsBackgroundMesh(int tag, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshFieldSetAsBackgroundMesh(tag, __arg1);
            }
        }

        public static void GmshModelMeshFieldSetAsBoundaryLayer(int tag, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshModelMeshFieldSetAsBoundaryLayer(tag, __arg1);
            }
        }

        public static void GmshModelMeshFieldList(int** tags, ref int tags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = &tags_n)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshFieldList(tags, __arg0, __arg2);
                }
            }
        }

        public static void GmshModelMeshFieldGetType(int tag, ref string fileType, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshFieldGetType(tag, fileType, __arg2);
            }
        }

        public static void GmshModelMeshFieldGetNumber(int tag, string option, ref double number, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshFieldGetNumber(tag, option, number, __arg2);
            }
        }

        public static void GmshModelMeshFieldGetNumbers(int tag, string option, double** number, ref int number_n, ref int ierr)
        {
            fixed (int* __number = &number_n)
            {
                var _arg4 = __number;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshFieldGetNumbers(tag, option, number, _arg4, __arg2);
                }
			}            
        }

        public static void GmshModelMeshFieldGetString(int tag, string option, ref string value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelMeshFieldGetString(tag, option, value, __arg2);
            }
        }

        public static void GmshModelMeshCreateEdges(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshCreateEdges(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshCreateFaces(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshCreateFaces(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshRemoveConstraints(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshRemoveConstraints(__arg0, dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshGetEmbedded(int dim, int tag, int** dimTags, ref long dimTags_n, ref int ierr)
        {
            fixed (long* __dimTags0 = &dimTags_n)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshGetEmbedded(dim, tag, dimTags, __arg0, __arg2);
                }
            }
        }

        public static void GmshModelMeshTriangulate(double[] coord, long coord_n, long** dimTags, ref long dimTags_n, ref int ierr)
        {
            fixed (double* __coords_n = coord)
            {
                var _arg = __coords_n;

                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshModelMeshTriangulate(_arg, coord_n, dimTags, ref dimTags_n, __arg2);
                }
            }
        }

        public static void GmshModelMeshTetrahedralize(double[] coord, long coord_n, long** dimTags, ref long dimTags_n, ref int ierr)
        {
            fixed (double* __coords_n = coord)
            {
                var _arg = __coords_n;
                fixed (long* __dimTags_n = &dimTags_n)
                {
                    var __arg4 = __dimTags_n;
                    fixed (int* __ierr2 = &ierr)
                    {
                        var __arg2 = __ierr2;
                        __Internal.GmshModelMeshTetrahedralize(_arg, coord_n, dimTags, __arg4, __arg2);
                    }
                }
            }
        }

        public static int GmshModelGeoAddPoint(double x, double y, double z, double meshSize, int tag, ref int ierr)
        {
            fixed (int* __ierr5 = &ierr)
            {
                var __arg5 = __ierr5;
                var __ret = __Internal.GmshModelGeoAddPoint(x, y, z, meshSize, tag, __arg5);
                return __ret;
            }
        }

        public static int GmshModelGeoAddLine(int startTag, int endTag, int tag, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var __ret = __Internal.GmshModelGeoAddLine(startTag, endTag, tag, __arg3);
                return __ret;
            }
        }

        public static int GmshModelGeoAddCircleArc(int startTag, int centerTag, int endTag, int tag, double nx, double ny, double nz, ref int ierr)
        {
            fixed (int* __ierr7 = &ierr)
            {
                var __arg7 = __ierr7;
                var __ret = __Internal.GmshModelGeoAddCircleArc(startTag, centerTag, endTag, tag, nx, ny, nz, __arg7);
                return __ret;
            }
        }

        public static int GmshModelGeoAddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag, double nx, double ny, double nz, ref int ierr)
        {
            fixed (int* __ierr8 = &ierr)
            {
                var __arg8 = __ierr8;
                var __ret = __Internal.GmshModelGeoAddEllipseArc(startTag, centerTag, majorTag, endTag, tag, nx, ny, nz, __arg8);
                return __ret;
            }
        }

        public static int GmshModelGeoAddSpline(int[] pointTags, long pointTags_n, int tag, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddSpline(__arg0, pointTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddBSpline(int[] pointTags, long pointTags_n, int tag, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddBSpline(__arg0, pointTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddBezier(int[] pointTags, long pointTags_n, int tag, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddBezier(__arg0, pointTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddPolyline(int[] pointTags, long pointTags_n, int tag, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddPolyline(__arg0, pointTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddCompoundSpline(int[] curveTags, long curveTags_n, int numIntervals, int tag, ref int ierr)
        {
            fixed (int* __curveTags0 = curveTags)
            {
                var __arg0 = __curveTags0;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelGeoAddCompoundSpline(__arg0, curveTags_n, numIntervals, tag, __arg4);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddCompoundBSpline(int[] curveTags, long curveTags_n, int numIntervals, int tag, ref int ierr)
        {
            fixed (int* __curveTags0 = curveTags)
            {
                var __arg0 = __curveTags0;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelGeoAddCompoundBSpline(__arg0, curveTags_n, numIntervals, tag, __arg4);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddCurveLoop(int[] curveTags, long curveTags_n, int tag, ref int ierr)
        {
            fixed (int* __curveTags0 = curveTags)
            {
                var __arg0 = __curveTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddCurveLoop(__arg0, curveTags_n, tag, __arg3);

                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddCurveLoops(int[] curveTags, long curveTags_n, int** tags, ref long tags_n, ref int ierr)
        {
            fixed (int* __curveTags0 = curveTags)
            {
                var __arg0 = __curveTags0;
                fixed(long* __tags = &tags_n)
				{
                    var __arg4 = __tags;
                    fixed (int* __ierr3 = &ierr)
                    {
                        var __arg3 = __ierr3;
                        var __ret = __Internal.GmshModelGeoAddCurveLoops(__arg0, curveTags_n, tags, __arg4, __arg3);

                        return __ret;
                    }
                }                
            }
        }

        public static int GmshModelGeoAddPlaneSurface(int[] wireTags, long wireTags_n, int tag, ref int ierr)
        {
            fixed (int* __wireTags0 = wireTags)
            {
                var __arg0 = __wireTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddPlaneSurface(__arg0, wireTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddSurfaceFilling(int[] wireTags, long wireTags_n, int tag, int sphereCenterTag, ref int ierr)
        {
            fixed (int* __wireTags0 = wireTags)
            {
                var __arg0 = __wireTags0;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelGeoAddSurfaceFilling(__arg0, wireTags_n, tag, sphereCenterTag, __arg4);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddSurfaceLoop(int[] surfaceTags, long surfaceTags_n, int tag, ref int ierr)
        {
            fixed (int* __surfaceTags0 = surfaceTags)
            {
                var __arg0 = __surfaceTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddSurfaceLoop(__arg0, surfaceTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelGeoAddVolume(int[] shellTags, long shellTags_n, int tag, ref int ierr)
        {
            fixed (int* __shellTags0 = shellTags)
            {
                var __arg0 = __shellTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelGeoAddVolume(__arg0, shellTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static void GmshModelGeoExtrude(int[] dimTags, long dimTags_n, double dx, double dy, double dz, int** outDimTags, ref long outDimTags_n, int[] numElements, long numElements_n, double[] heights, long heights_n, int recombine, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n6 = &outDimTags_n)
                {
                    var __arg6 = __outDimTags_n6;
                    fixed (int* __numElements7 = numElements)
                    {
                        var __arg7 = __numElements7;
                        fixed (double* __heights9 = heights)
                        {
                            var __arg9 = __heights9;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelGeoExtrude(__arg0, dimTags_n, dx, dy, dz, outDimTags, __arg6, __arg7, numElements_n, __arg9, heights_n, recombine, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelGeoRevolve(int[] dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int** outDimTags, ref long outDimTags_n, int[] numElements, long numElements_n, double[] heights, long heights_n, int recombine, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n10 = &outDimTags_n)
                {
                    var __arg10 = __outDimTags_n10;
                    fixed (int* __numElements11 = numElements)
                    {
                        var __arg11 = __numElements11;
                        fixed (double* __heights13 = heights)
                        {
                            var __arg13 = __heights13;
                            fixed (int* __ierr16 = &ierr)
                            {
                                var __arg16 = __ierr16;
                                __Internal.GmshModelGeoRevolve(__arg0, dimTags_n, x, y, z, ax, ay, az, angle, outDimTags, __arg10, __arg11, numElements_n, __arg13, heights_n, recombine, __arg16);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelGeoTwist(int[] dimTags, long dimTags_n, double x, double y, double z, double dx, double dy, double dz, double ax, double ay, double az, double angle, int** outDimTags, ref long outDimTags_n, int[] numElements, long numElements_n, double[] heights, long heights_n, int recombine, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n13 = &outDimTags_n)
                {
                    var __arg13 = __outDimTags_n13;
                    fixed (int* __numElements14 = numElements)
                    {
                        var __arg14 = __numElements14;
                        fixed (double* __heights16 = heights)
                        {
                            var __arg16 = __heights16;
                            fixed (int* __ierr19 = &ierr)
                            {
                                var __arg19 = __ierr19;
                                __Internal.GmshModelGeoTwist(__arg0, dimTags_n, x, y, z, dx, dy, dz, ax, ay, az, angle, outDimTags, __arg13, __arg14, numElements_n, __arg16, heights_n, recombine, __arg19);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelGeoTranslate(int[] dimTags, long dimTags_n, double dx, double dy, double dz, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr5 = &ierr)
                {
                    var __arg5 = __ierr5;
                    __Internal.GmshModelGeoTranslate(__arg0, dimTags_n, dx, dy, dz, __arg5);
                }
            }
        }

        public static void GmshModelGeoRotate(int[] dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr9 = &ierr)
                {
                    var __arg9 = __ierr9;
                    __Internal.GmshModelGeoRotate(__arg0, dimTags_n, x, y, z, ax, ay, az, angle, __arg9);
                }
            }
        }

        public static void GmshModelGeoDilate(int[] dimTags, long dimTags_n, double x, double y, double z, double a, double b, double c, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr8 = &ierr)
                {
                    var __arg8 = __ierr8;
                    __Internal.GmshModelGeoDilate(__arg0, dimTags_n, x, y, z, a, b, c, __arg8);
                }
            }
        }

        public static void GmshModelGeoMirror(int[] dimTags, long dimTags_n, double a, double b, double c, double d, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr6 = &ierr)
                {
                    var __arg6 = __ierr6;
                    __Internal.GmshModelGeoMirror(__arg0, dimTags_n, a, b, c, d, __arg6);
                }
            }
        }

        public static void GmshModelGeoSymmetrize(int[] dimTags, long dimTags_n, double a, double b, double c, double d, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr6 = &ierr)
                {
                    var __arg6 = __ierr6;
                    __Internal.GmshModelGeoSymmetrize(__arg0, dimTags_n, a, b, c, d, __arg6);
                }
            }
        }

        public static void GmshModelGeoCopy(int[] dimTags, long dimTags_n, int** outDimTags, ref long outDimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n3 = &outDimTags_n)
                {
                    var __arg3 = __outDimTags_n3;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelGeoCopy(__arg0, dimTags_n, outDimTags, __arg3, __arg4);
                    }
                }
            }
        }

        public static void GmshModelGeoRemove(int[] dimTags, long dimTags_n, int recursive, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelGeoRemove(__arg0, dimTags_n, recursive, __arg3);
                }
            }
        }

        public static void GmshModelGeoRemoveAllDuplicates(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelGeoRemoveAllDuplicates(__arg0);
            }
        }

        public static void GmshModelGeoSplitCurve(int tag, int[] pointTags, long pointTags_n, int** curveTags, ref long curveTags_n, ref int ierr)
        {
            fixed (int* __pointTags1 = pointTags)
            {
                var __arg1 = __pointTags1;
                fixed (long* __curveTags_n4 = &curveTags_n)
                {
                    var __arg4 = __curveTags_n4;
                    fixed (int* __ierr5 = &ierr)
                    {
                        var __arg5 = __ierr5;
                        __Internal.GmshModelGeoSplitCurve(tag, __arg1, pointTags_n, curveTags, __arg4, __arg5);
                    }
                }
            }
        }

        public static int GmshModelGeoGetMaxTag(int dim, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                var __ret = __Internal.GmshModelGeoGetMaxTag(dim, __arg1);
                return __ret;
            }
        }

        public static void GmshModelGeoSetMaxTag(int dim, int maxTag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelGeoSetMaxTag(dim, maxTag, __arg2);
            }
        }

        public static void GmshModelGeoSynchronize(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelGeoSynchronize(__arg0);
            }
        }

        public static void GmshModelGeoMeshSetSize(int[] dimTags, long dimTags_n, double size, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelGeoMeshSetSize(__arg0, dimTags_n, size, __arg3);
                }
            }
        }

        public static void GmshModelGeoMeshSetTransfiniteCurve(int tag, int nPoints, string meshType, double coef, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                __Internal.GmshModelGeoMeshSetTransfiniteCurve(tag, nPoints, meshType, coef, __arg4);
            }
        }

        public static void GmshModelGeoMeshSetTransfiniteSurface(int tag, string arrangement, int[] cornerTags, long cornerTags_n, ref int ierr)
        {
            fixed (int* __cornerTags2 = cornerTags)
            {
                var __arg2 = __cornerTags2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelGeoMeshSetTransfiniteSurface(tag, arrangement, __arg2, cornerTags_n, __arg4);
                }
            }
        }

        public static void GmshModelGeoMeshSetTransfiniteVolume(int tag, int[] cornerTags, long cornerTags_n, ref int ierr)
        {
            fixed (int* __cornerTags1 = cornerTags)
            {
                var __arg1 = __cornerTags1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelGeoMeshSetTransfiniteVolume(tag, __arg1, cornerTags_n, __arg3);
                }
            }
        }

        public static void GmshModelGeoMeshSetRecombine(int dim, int tag, double angle, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGeoMeshSetRecombine(dim, tag, angle, __arg3);
            }
        }

        public static void GmshModelGeoMeshSetSmoothing(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGeoMeshSetSmoothing(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelGeoMeshSetReverse(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGeoMeshSetReverse(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelGeoMeshSetAlgorithm(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGeoMeshSetAlgorithm(dim, tag, val, __arg3);
            }
        }

        public static void GmshModelGeoMeshSetSizeFromBoundary(int dim, int tag, int val, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshModelGeoMeshSetSizeFromBoundary(dim, tag, val, __arg3);
            }
        }

        public static int GmshModelOccAddPoint(double x, double y, double z, double meshSize, int tag, ref int ierr)
        {
            fixed (int* __ierr5 = &ierr)
            {
                var __arg5 = __ierr5;
                var __ret = __Internal.GmshModelOccAddPoint(x, y, z, meshSize, tag, __arg5);
                return __ret;
            }
        }

        public static int GmshModelOccAddLine(int startTag, int endTag, int tag, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var __ret = __Internal.GmshModelOccAddLine(startTag, endTag, tag, __arg3);
                return __ret;
            }
        }

        public static int GmshModelOccAddCircleArc(int startTag, int centerTag, int endTag, int tag, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                var __ret = __Internal.GmshModelOccAddCircleArc(startTag, centerTag, endTag, tag, __arg4);
                return __ret;
            }
        }

        public static int GmshModelOccAddCircle(double x, double y, double z, double r, int tag, double angle1, double angle2, ref int ierr)
        {
            fixed (int* __ierr7 = &ierr)
            {
                var __arg7 = __ierr7;
                var __ret = __Internal.GmshModelOccAddCircle(x, y, z, r, tag, angle1, angle2, __arg7);
                return __ret;
            }
        }

        public static int GmshModelOccAddEllipseArc(int startTag, int centerTag, int majorTag, int endTag, int tag, ref int ierr)
        {
            fixed (int* __ierr5 = &ierr)
            {
                var __arg5 = __ierr5;
                var __ret = __Internal.GmshModelOccAddEllipseArc(startTag, centerTag, majorTag, endTag, tag, __arg5);
                return __ret;
            }
        }

        public static int GmshModelOccAddEllipse(double x, double y, double z, double r1, double r2, int tag, double angle1, double angle2, ref int ierr)
        {
            fixed (int* __ierr8 = &ierr)
            {
                var __arg8 = __ierr8;
                var __ret = __Internal.GmshModelOccAddEllipse(x, y, z, r1, r2, tag, angle1, angle2, __arg8);
                return __ret;
            }
        }

        public static int GmshModelOccAddSpline(int[] pointTags, long pointTags_n, int tag, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelOccAddSpline(__arg0, pointTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddBSpline(int[] pointTags, long pointTags_n, int tag, int degree, double[] weights, long weights_n, double[] knots, long knots_n, int[] multiplicities, long multiplicities_n, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (double* __weights4 = weights)
                {
                    var __arg4 = __weights4;
                    fixed (double* __knots6 = knots)
                    {
                        var __arg6 = __knots6;
                        fixed (int* __multiplicities8 = multiplicities)
                        {
                            var __arg8 = __multiplicities8;
                            fixed (int* __ierr10 = &ierr)
                            {
                                var __arg10 = __ierr10;
                                var __ret = __Internal.GmshModelOccAddBSpline(__arg0, pointTags_n, tag, degree, __arg4, weights_n, __arg6, knots_n, __arg8, multiplicities_n, __arg10);
                                return __ret;
                            }
                        }
                    }
                }
            }
        }

        public static int GmshModelOccAddBezier(int[] pointTags, long pointTags_n, int tag, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelOccAddBezier(__arg0, pointTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddTrimmedSurface(int surfaceTag, int[] wireTags, long wireTags_n, int wire3D, int tag, ref int ierr)
        {
            fixed (int* __wireTags0 = wireTags)
            {
                var __arg0 = __wireTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelOccAddTrimmedSurface(surfaceTag, __arg0, wireTags_n, wire3D, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddWire(int[] curveTags, long curveTags_n, int tag, int checkClosed, ref int ierr)
        {
            fixed (int* __curveTags0 = curveTags)
            {
                var __arg0 = __curveTags0;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelOccAddWire(__arg0, curveTags_n, tag, checkClosed, __arg4);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddCurveLoop(int[] curveTags, long curveTags_n, int tag, ref int ierr)
        {
            fixed (int* __curveTags0 = curveTags)
            {
                var __arg0 = __curveTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelOccAddCurveLoop(__arg0, curveTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddRectangle(double x, double y, double z, double dx, double dy, int tag, double roundedRadius, ref int ierr)
        {
            fixed (int* __ierr7 = &ierr)
            {
                var __arg7 = __ierr7;
                var __ret = __Internal.GmshModelOccAddRectangle(x, y, z, dx, dy, tag, roundedRadius, __arg7);
                return __ret;
            }
        }

        public static int GmshModelOccAddDisk(double xc, double yc, double zc, double rx, double ry, int tag, ref int ierr)
        {
            fixed (int* __ierr6 = &ierr)
            {
                var __arg6 = __ierr6;
                var __ret = __Internal.GmshModelOccAddDisk(xc, yc, zc, rx, ry, tag, __arg6);
                return __ret;
            }
        }

        public static int GmshModelOccAddPlaneSurface(int[] wireTags, long wireTags_n, int tag, ref int ierr)
        {
            fixed (int* __wireTags0 = wireTags)
            {
                var __arg0 = __wireTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelOccAddPlaneSurface(__arg0, wireTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddSurfaceFilling(int wireTag, int tag, int[] pointTags, long pointTags_n, int degree, int numPointsOnCurves, int numIter,
                    int anisotropic, double tol2d, double tol3d, double tolAng, double tolCurv, int maxDegree, int maxSegments, ref int ierr)
        {
            fixed (int* __pointTags2 = pointTags)
            {
                var __arg2 = __pointTags2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelOccAddSurfaceFilling(wireTag, tag, __arg2, pointTags_n, degree, numPointsOnCurves, numIter,
                    anisotropic, tol2d, tol3d, tolAng, tolCurv, maxDegree, maxSegments, __arg4);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddBSplineFilling(int wireTag, int tag, string type, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var __ret = __Internal.GmshModelOccAddBSplineFilling(wireTag, tag, type, __arg3);
                return __ret;
            }
        }

        public static int GmshModelOccAddBezierFilling(int wireTag, int tag, string type, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var __ret = __Internal.GmshModelOccAddBezierFilling(wireTag, tag, type, __arg3);
                return __ret;
            }
        }

        public static int GmshModelOccAddBSplineSurface(int[] pointTags, long pointTags_n, int numPointsU, int tag, int degreeU, int degreeV, double[] weights, 
            long weights_n, double[] knotsU, long knotsU_n, double[] knotsV, long knotsV_n, int[] multiplicitiesU, long multiplicitiesU_n, int[] multiplicitiesV, 
            long multiplicitiesV_n, int[] wireTags, long wireTags_n, int wire3D, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (double* __weights6 = weights)
                {
                    var __arg6 = __weights6;
                    fixed (double* __knotsU8 = knotsU)
                    {
                        var __arg8 = __knotsU8;
                        fixed (double* __knotsV10 = knotsV)
                        {
                            var __arg10 = __knotsV10;
                            fixed (int* __multiplicitiesU12 = multiplicitiesU)
                            {
                                var __arg12 = __multiplicitiesU12;
                                fixed (int* __multiplicitiesV14 = multiplicitiesV)
                                {
                                    var __arg14 = __multiplicitiesV14;
                                    fixed (int* __wireTags0 = wireTags)
                                    {
                                        var __arg16 = __wireTags0;
                                        fixed (int* __ierr19 = &ierr)
                                        {
                                            var __arg19 = __ierr19;
                                            var __ret = __Internal.GmshModelOccAddBSplineSurface(__arg0, pointTags_n, numPointsU, tag, degreeU, degreeV, __arg6, weights_n, __arg8, 
                                                knotsU_n, __arg10, knotsV_n, __arg12, multiplicitiesU_n, __arg14, multiplicitiesV_n, __arg16, wireTags_n, wire3D, __arg19);
                                            return __ret;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static int GmshModelOccAddBezierSurface(int[] pointTags, long pointTags_n, int numPointsU, int tag, int[] wireTags,
            long wireTags_n, int wire3D, ref int ierr)
        {
            fixed (int* __pointTags0 = pointTags)
            {
                var __arg0 = __pointTags0;
                fixed (int* __wireTags0 = wireTags)
                {
                    var __arg4 = __wireTags0;
                    fixed (int* __ierr7 = &ierr)
                    {
                        var __arg7 = __ierr7;
                        var __ret = __Internal.GmshModelOccAddBezierSurface(__arg0, pointTags_n, numPointsU, tag,  __arg4, wireTags_n, wire3D, __arg7);
                        return __ret;
                    }
                }
            }
        }

        public static int GmshModelOccAddSurfaceLoop(int[] surfaceTags, long surfaceTags_n, int tag, int sewing, ref int ierr)
        {
            fixed (int* __surfaceTags0 = surfaceTags)
            {
                var __arg0 = __surfaceTags0;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    var __ret = __Internal.GmshModelOccAddSurfaceLoop(__arg0, surfaceTags_n, tag, sewing, __arg4);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddVolume(int[] shellTags, long shellTags_n, int tag, ref int ierr)
        {
            fixed (int* __shellTags0 = shellTags)
            {
                var __arg0 = __shellTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshModelOccAddVolume(__arg0, shellTags_n, tag, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshModelOccAddSphere(double xc, double yc, double zc, double radius, int tag, double angle1, double angle2, double angle3, ref int ierr)
        {
            fixed (int* __ierr8 = &ierr)
            {
                var __arg8 = __ierr8;
                var __ret = __Internal.GmshModelOccAddSphere(xc, yc, zc, radius, tag, angle1, angle2, angle3, __arg8);
                return __ret;
            }
        }

        public static int GmshModelOccAddBox(double x, double y, double z, double dx, double dy, double dz, int tag, ref int ierr)
        {
            fixed (int* __ierr7 = &ierr)
            {
                var __arg7 = __ierr7;
                var __ret = __Internal.GmshModelOccAddBox(x, y, z, dx, dy, dz, tag, __arg7);
                return __ret;
            }
        }

        public static int GmshModelOccAddCylinder(double x, double y, double z, double dx, double dy, double dz, double r, int tag, double angle, ref int ierr)
        {
            fixed (int* __ierr9 = &ierr)
            {
                var __arg9 = __ierr9;
                var __ret = __Internal.GmshModelOccAddCylinder(x, y, z, dx, dy, dz, r, tag, angle, __arg9);
                return __ret;
            }
        }

        public static int GmshModelOccAddCone(double x, double y, double z, double dx, double dy, double dz, double r1, double r2, int tag, double angle, ref int ierr)
        {
            fixed (int* __ierr10 = &ierr)
            {
                var __arg10 = __ierr10;
                var __ret = __Internal.GmshModelOccAddCone(x, y, z, dx, dy, dz, r1, r2, tag, angle, __arg10);
                return __ret;
            }
        }

        public static int GmshModelOccAddWedge(double x, double y, double z, double dx, double dy, double dz, int tag, double ltx, ref int ierr)
        {
            fixed (int* __ierr8 = &ierr)
            {
                var __arg8 = __ierr8;
                var __ret = __Internal.GmshModelOccAddWedge(x, y, z, dx, dy, dz, tag, ltx, __arg8);
                return __ret;
            }
        }

        public static int GmshModelOccAddTorus(double x, double y, double z, double r1, double r2, int tag, double angle, ref int ierr)
        {
            fixed (int* __ierr7 = &ierr)
            {
                var __arg7 = __ierr7;
                var __ret = __Internal.GmshModelOccAddTorus(x, y, z, r1, r2, tag, angle, __arg7);
                return __ret;
            }
        }

        public static void GmshModelOccAddThruSections(int[] wireTags, long wireTags_n, int** outDimTags, ref long outDimTags_n, int tag, int makeSolid, int makeRuled, int maxDegree, ref int ierr)
        {
            fixed (int* __wireTags0 = wireTags)
            {
                var __arg0 = __wireTags0;
                fixed (long* __outDimTags_n3 = &outDimTags_n)
                {
                    var __arg3 = __outDimTags_n3;
                    fixed (int* __ierr8 = &ierr)
                    {
                        var __arg8 = __ierr8;
                        __Internal.GmshModelOccAddThruSections(__arg0, wireTags_n, outDimTags, __arg3, tag, makeSolid, makeRuled, maxDegree, __arg8);
                    }
                }
            }
        }

        public static void GmshModelOccAddThickSolid(int volumeTag, int[] excludeSurfaceTags, long excludeSurfaceTags_n, double offset, int** outDimTags, ref long outDimTags_n, int tag, ref int ierr)
        {
            fixed (int* __excludeSurfaceTags1 = excludeSurfaceTags)
            {
                var __arg1 = __excludeSurfaceTags1;
                fixed (long* __outDimTags_n5 = &outDimTags_n)
                {
                    var __arg5 = __outDimTags_n5;
                    fixed (int* __ierr7 = &ierr)
                    {
                        var __arg7 = __ierr7;
                        __Internal.GmshModelOccAddThickSolid(volumeTag, __arg1, excludeSurfaceTags_n, offset, outDimTags, __arg5, tag, __arg7);
                    }
                }
            }
        }

        public static void GmshModelOccExtrude(int[] dimTags, long dimTags_n, double dx, double dy, double dz, int** outDimTags, ref long outDimTags_n, int[] numElements, long numElements_n, double[] heights, long heights_n, int recombine, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n6 = &outDimTags_n)
                {
                    var __arg6 = __outDimTags_n6;
                    fixed (int* __numElements7 = numElements)
                    {
                        var __arg7 = __numElements7;
                        fixed (double* __heights9 = heights)
                        {
                            var __arg9 = __heights9;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelOccExtrude(__arg0, dimTags_n, dx, dy, dz, outDimTags, __arg6, __arg7, numElements_n, __arg9, heights_n, recombine, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccRevolve(int[] dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, int** outDimTags, ref long outDimTags_n, int[] numElements, long numElements_n, double[] heights, long heights_n, int recombine, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n10 = &outDimTags_n)
                {
                    var __arg10 = __outDimTags_n10;
                    fixed (int* __numElements11 = numElements)
                    {
                        var __arg11 = __numElements11;
                        fixed (double* __heights13 = heights)
                        {
                            var __arg13 = __heights13;
                            fixed (int* __ierr16 = &ierr)
                            {
                                var __arg16 = __ierr16;
                                __Internal.GmshModelOccRevolve(__arg0, dimTags_n, x, y, z, ax, ay, az, angle, outDimTags, __arg10, __arg11, numElements_n, __arg13, heights_n, recombine, __arg16);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccAddPipe(int[] dimTags, long dimTags_n, int wireTag, int** outDimTags, ref long outDimTags_n, string trihedron, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n4 = &outDimTags_n)
                {
                    var __arg4 = __outDimTags_n4;
                    fixed (int* __ierr5 = &ierr)
                    {
                        var __arg5 = __ierr5;
                        __Internal.GmshModelOccAddPipe(__arg0, dimTags_n, wireTag, outDimTags, __arg4, trihedron, __arg5);
                    }
                }
            }
        }

        public static void GmshModelOccFillet(int[] volumeTags, long volumeTags_n, int[] curveTags, long curveTags_n, double[] radii, long radii_n, int** outDimTags, ref long outDimTags_n, int removeVolume, ref int ierr)
        {
            fixed (int* __volumeTags0 = volumeTags)
            {
                var __arg0 = __volumeTags0;
                fixed (int* __curveTags2 = curveTags)
                {
                    var __arg2 = __curveTags2;
                    fixed (double* __radii4 = radii)
                    {
                        var __arg4 = __radii4;
                        fixed (long* __outDimTags_n7 = &outDimTags_n)
                        {
                            var __arg7 = __outDimTags_n7;
                            fixed (int* __ierr9 = &ierr)
                            {
                                var __arg9 = __ierr9;
                                __Internal.GmshModelOccFillet(__arg0, volumeTags_n, __arg2, curveTags_n, __arg4, radii_n, outDimTags, __arg7, removeVolume, __arg9);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccChamfer(int[] volumeTags, long volumeTags_n, int[] curveTags, long curveTags_n, int[] surfaceTags, long surfaceTags_n, double[] distances, long distances_n, int** outDimTags, ref long outDimTags_n, int removeVolume, ref int ierr)
        {
            fixed (int* __volumeTags0 = volumeTags)
            {
                var __arg0 = __volumeTags0;
                fixed (int* __curveTags2 = curveTags)
                {
                    var __arg2 = __curveTags2;
                    fixed (int* __surfaceTags4 = surfaceTags)
                    {
                        var __arg4 = __surfaceTags4;
                        fixed (double* __distances6 = distances)
                        {
                            var __arg6 = __distances6;
                            fixed (long* __outDimTags_n9 = &outDimTags_n)
                            {
                                var __arg9 = __outDimTags_n9;
                                fixed (int* __ierr11 = &ierr)
                                {
                                    var __arg11 = __ierr11;
                                    __Internal.GmshModelOccChamfer(__arg0, volumeTags_n, __arg2, curveTags_n, __arg4, surfaceTags_n, __arg6, distances_n, outDimTags, __arg9, removeVolume, __arg11);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccConvertToNURBS(int[] dimTags, long dimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr16 = &ierr)
                {
                    var __arg16 = __ierr16;
                    __Internal.GmshModelOccConvertToNURBS(__arg0, dimTags_n, __arg16);
                }
            }
        }

        public static void GmshModelOccFuse(int[] objectDimTags, long objectDimTags_n, int[] toolDimTags, long toolDimTags_n, int** outDimTags, ref long outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, ref long outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr)
        {
            fixed (int* __objectDimTags0 = objectDimTags)
            {
                var __arg0 = __objectDimTags0;
                fixed (int* __toolDimTags2 = toolDimTags)
                {
                    var __arg2 = __toolDimTags2;
                    fixed (long* __outDimTags_n5 = &outDimTags_n)
                    {
                        var __arg5 = __outDimTags_n5;
                        fixed (long* __outDimTagsMap_nn8 = &outDimTagsMap_nn)
                        {
                            var __arg8 = __outDimTagsMap_nn8;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelOccFuse(__arg0, objectDimTags_n, __arg2, toolDimTags_n, outDimTags, __arg5, outDimTagsMap, outDimTagsMap_n, __arg8, tag, removeObject, removeTool, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccIntersect(int[] objectDimTags, long objectDimTags_n, int[] toolDimTags, long toolDimTags_n, int** outDimTags, ref long outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, ref long outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr)
        {
            fixed (int* __objectDimTags0 = objectDimTags)
            {
                var __arg0 = __objectDimTags0;
                fixed (int* __toolDimTags2 = toolDimTags)
                {
                    var __arg2 = __toolDimTags2;
                    fixed (long* __outDimTags_n5 = &outDimTags_n)
                    {
                        var __arg5 = __outDimTags_n5;
                        fixed (long* __outDimTagsMap_nn8 = &outDimTagsMap_nn)
                        {
                            var __arg8 = __outDimTagsMap_nn8;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelOccIntersect(__arg0, objectDimTags_n, __arg2, toolDimTags_n, outDimTags, __arg5, outDimTagsMap, outDimTagsMap_n, __arg8, tag, removeObject, removeTool, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccCut(int[] objectDimTags, long objectDimTags_n, int[] toolDimTags, long toolDimTags_n, int** outDimTags, ref long outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, ref long outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr)
        {
            fixed (int* __objectDimTags0 = objectDimTags)
            {
                var __arg0 = __objectDimTags0;
                fixed (int* __toolDimTags2 = toolDimTags)
                {
                    var __arg2 = __toolDimTags2;
                    fixed (long* __outDimTags_n5 = &outDimTags_n)
                    {
                        var __arg5 = __outDimTags_n5;
                        fixed (long* __outDimTagsMap_nn8 = &outDimTagsMap_nn)
                        {
                            var __arg8 = __outDimTagsMap_nn8;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelOccCut(__arg0, objectDimTags_n, __arg2, toolDimTags_n, outDimTags, __arg5, outDimTagsMap, outDimTagsMap_n, __arg8, tag, removeObject, removeTool, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccFragment(int[] objectDimTags, long objectDimTags_n, int[] toolDimTags, long toolDimTags_n, int** outDimTags, ref long outDimTags_n, int*** outDimTagsMap, long** outDimTagsMap_n, ref long outDimTagsMap_nn, int tag, int removeObject, int removeTool, ref int ierr)
        {
            fixed (int* __objectDimTags0 = objectDimTags)
            {
                var __arg0 = __objectDimTags0;
                fixed (int* __toolDimTags2 = toolDimTags)
                {
                    var __arg2 = __toolDimTags2;
                    fixed (long* __outDimTags_n5 = &outDimTags_n)
                    {
                        var __arg5 = __outDimTags_n5;
                        fixed (long* __outDimTagsMap_nn8 = &outDimTagsMap_nn)
                        {
                            var __arg8 = __outDimTagsMap_nn8;
                            fixed (int* __ierr12 = &ierr)
                            {
                                var __arg12 = __ierr12;
                                __Internal.GmshModelOccFragment(__arg0, objectDimTags_n, __arg2, toolDimTags_n, outDimTags, __arg5, outDimTagsMap, outDimTagsMap_n, __arg8, tag, removeObject, removeTool, __arg12);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccTranslate(int[] dimTags, long dimTags_n, double dx, double dy, double dz, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr5 = &ierr)
                {
                    var __arg5 = __ierr5;
                    __Internal.GmshModelOccTranslate(__arg0, dimTags_n, dx, dy, dz, __arg5);
                }
            }
        }

        public static void GmshModelOccRotate(int[] dimTags, long dimTags_n, double x, double y, double z, double ax, double ay, double az, double angle, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr9 = &ierr)
                {
                    var __arg9 = __ierr9;
                    __Internal.GmshModelOccRotate(__arg0, dimTags_n, x, y, z, ax, ay, az, angle, __arg9);
                }
            }
        }

        public static void GmshModelOccDilate(int[] dimTags, long dimTags_n, double x, double y, double z, double a, double b, double c, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr8 = &ierr)
                {
                    var __arg8 = __ierr8;
                    __Internal.GmshModelOccDilate(__arg0, dimTags_n, x, y, z, a, b, c, __arg8);
                }
            }
        }

        public static void GmshModelOccMirror(int[] dimTags, long dimTags_n, double a, double b, double c, double d, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr6 = &ierr)
                {
                    var __arg6 = __ierr6;
                    __Internal.GmshModelOccMirror(__arg0, dimTags_n, a, b, c, d, __arg6);
                }
            }
        }

        public static void GmshModelOccSymmetrize(int[] dimTags, long dimTags_n, double a, double b, double c, double d, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr6 = &ierr)
                {
                    var __arg6 = __ierr6;
                    __Internal.GmshModelOccSymmetrize(__arg0, dimTags_n, a, b, c, d, __arg6);
                }
            }
        }

        public static void GmshModelOccAffineTransform(int[] dimTags, long dimTags_n, double[] a, long a_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (double* __a2 = a)
                {
                    var __arg2 = __a2;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelOccAffineTransform(__arg0, dimTags_n, __arg2, a_n, __arg4);
                    }
                }
            }
        }

        public static void GmshModelOccCopy(int[] dimTags, long dimTags_n, int** outDimTags, ref long outDimTags_n, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (long* __outDimTags_n3 = &outDimTags_n)
                {
                    var __arg3 = __outDimTags_n3;
                    fixed (int* __ierr4 = &ierr)
                    {
                        var __arg4 = __ierr4;
                        __Internal.GmshModelOccCopy(__arg0, dimTags_n, outDimTags, __arg3, __arg4);
                    }
                }
            }
        }

        public static void GmshModelOccRemove(int[] dimTags, long dimTags_n, int recursive, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelOccRemove(__arg0, dimTags_n, recursive, __arg3);
                }
            }
        }

        public static void GmshModelOccRemoveAllDuplicates(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelOccRemoveAllDuplicates(__arg0);
            }
        }

        public static void GmshModelOccHealShapes(int** outDimTags, ref long outDimTags_n, int[] dimTags, long dimTags_n, double tolerance, int fixDegenerated, int fixSmallEdges, int fixSmallFaces, int sewFaces, int makeSolids, ref int ierr)
        {
            fixed (long* __outDimTags_n1 = &outDimTags_n)
            {
                var __arg1 = __outDimTags_n1;
                fixed (int* __dimTags2 = dimTags)
                {
                    var __arg2 = __dimTags2;
                    fixed (int* __ierr10 = &ierr)
                    {
                        var __arg10 = __ierr10;
                        __Internal.GmshModelOccHealShapes(outDimTags, __arg1, __arg2, dimTags_n, tolerance, fixDegenerated, fixSmallEdges, fixSmallFaces, sewFaces, makeSolids, __arg10);
                    }
                }
            }
        }

        public static void GmshModelOccImportShapes(string fileName, int** outDimTags, ref long outDimTags_n, int highestDimOnly, string format, ref int ierr)
        {
            fixed (long* __outDimTags_n2 = &outDimTags_n)
            {
                var __arg2 = __outDimTags_n2;
                fixed (int* __ierr5 = &ierr)
                {
                    var __arg5 = __ierr5;
                    __Internal.GmshModelOccImportShapes(fileName, outDimTags, __arg2, highestDimOnly, format, __arg5);
                }
            }
        }

        public static void GmshModelOccImportShapesNativePointer(global::System.IntPtr shape, int** outDimTags, ref long outDimTags_n, int highestDimOnly, ref int ierr)
        {
            fixed (long* __outDimTags_n2 = &outDimTags_n)
            {
                var __arg2 = __outDimTags_n2;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelOccImportShapesNativePointer(shape, outDimTags, __arg2, highestDimOnly, __arg4);
                }
            }
        }

        public static void GmshModelOccGetEntities(int** dimTags, ref long dimTags_n, int dim, ref int ierr)
        {
            fixed (long* __dimTags_n1 = &dimTags_n)
            {
                var __arg1 = __dimTags_n1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelOccGetEntities(dimTags, __arg1, dim, __arg3);
                }
            }
        }

        public static void GmshModelOccGetEntitiesInBoundingBox(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax, int** tags, ref long tags_n, int dim, ref int ierr)
        {
            fixed (long* __tags_n7 = &tags_n)
            {
                var __arg7 = __tags_n7;
                fixed (int* __ierr9 = &ierr)
                {
                    var __arg9 = __ierr9;
                    __Internal.GmshModelOccGetEntitiesInBoundingBox(xmin, ymin, zmin, xmax, ymax, zmax, tags, __arg7, dim, __arg9);
                }
            }
        }

        public static void GmshModelOccGetBoundingBox(int dim, int tag, ref double xmin, ref double ymin, ref double zmin, ref double xmax, ref double ymax, ref double zmax, ref int ierr)
        {
            fixed (double* __xmin2 = &xmin)
            {
                var __arg2 = __xmin2;
                fixed (double* __ymin3 = &ymin)
                {
                    var __arg3 = __ymin3;
                    fixed (double* __zmin4 = &zmin)
                    {
                        var __arg4 = __zmin4;
                        fixed (double* __xmax5 = &xmax)
                        {
                            var __arg5 = __xmax5;
                            fixed (double* __ymax6 = &ymax)
                            {
                                var __arg6 = __ymax6;
                                fixed (double* __zmax7 = &zmax)
                                {
                                    var __arg7 = __zmax7;
                                    fixed (int* __ierr8 = &ierr)
                                    {
                                        var __arg8 = __ierr8;
                                        __Internal.GmshModelOccGetBoundingBox(dim, tag, __arg2, __arg3, __arg4, __arg5, __arg6, __arg7, __arg8);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshModelOccGetMass(int dim, int tag, ref double mass, ref int ierr)
        {
            fixed (double* __mass2 = &mass)
            {
                var __arg2 = __mass2;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelOccGetMass(dim, tag, __arg2, __arg3);
                }
            }
        }

        public static void GmshModelOccGetCenterOfMass(int dim, int tag, ref double x, ref double y, ref double z, ref int ierr)
        {
            fixed (double* __x2 = &x)
            {
                var __arg2 = __x2;
                fixed (double* __y3 = &y)
                {
                    var __arg3 = __y3;
                    fixed (double* __z4 = &z)
                    {
                        var __arg4 = __z4;
                        fixed (int* __ierr5 = &ierr)
                        {
                            var __arg5 = __ierr5;
                            __Internal.GmshModelOccGetCenterOfMass(dim, tag, __arg2, __arg3, __arg4, __arg5);
                        }
                    }
                }
            }
        }

        public static void GmshModelOccGetMatrixOfInertia(int dim, int tag, double** mat, ref long mat_n, ref int ierr)
        {
            fixed (long* __mat_n3 = &mat_n)
            {
                var __arg3 = __mat_n3;
                fixed (int* __ierr4 = &ierr)
                {
                    var __arg4 = __ierr4;
                    __Internal.GmshModelOccGetMatrixOfInertia(dim, tag, mat, __arg3, __arg4);
                }
            }
        }

        public static int GmshModelOccGetMaxTag(int dim, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                var __ret = __Internal.GmshModelOccGetMaxTag(dim, __arg1);
                return __ret;
            }
        }

        public static void GmshModelOccSetMaxTag(int dim, int maxTag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshModelOccSetMaxTag(dim, maxTag, __arg2);
            }
        }

        public static void GmshModelOccSynchronize(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshModelOccSynchronize(__arg0);
            }
        }

        public static void GmshModelOccMeshSetSize(int[] dimTags, long dimTags_n, double size, ref int ierr)
        {
            fixed (int* __dimTags0 = dimTags)
            {
                var __arg0 = __dimTags0;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshModelOccMeshSetSize(__arg0, dimTags_n, size, __arg3);
                }
            }
        }

        public static void GmshModelOccGetCurveLoops(int surfaceTag, int** outDimTags, ref long outDimTags_n, ref int ierr)
        {
            fixed (long* __outDimTags_n5 = &outDimTags_n)
            {
                var __arg5 = __outDimTags_n5;
                fixed (int* __ierr12 = &ierr)
                {
                    var __arg12 = __ierr12;
                    __Internal.GmshModelOccGetCurveLoops(surfaceTag, outDimTags, __arg5, __arg12);
                }
            }
        }

        public static void GmshModelOccGetSurfaceLoops(int surfaceTag, int** outDimTags, ref long outDimTags_n, ref int ierr)
        {
            fixed (long* __outDimTags_n5 = &outDimTags_n)
            {
                var __arg5 = __outDimTags_n5;
                fixed (int* __ierr12 = &ierr)
                {
                    var __arg12 = __ierr12;
                    __Internal.GmshModelOccGetSurfaceLoops(surfaceTag, outDimTags, __arg5, __arg12);
                }
            }
        }

        public static int GmshViewAdd(string name, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                var __ret = __Internal.GmshViewAdd(name, tag, __arg2);
                return __ret;
            }
        }

        public static void GmshViewRemove(int tag, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshViewRemove(tag, __arg1);
            }
        }

        public static int GmshViewGetIndex(int tag, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                var __ret = __Internal.GmshViewGetIndex(tag, __arg1);
                return __ret;
            }
        }

        public static void GmshViewGetTags(int** tags, ref long tags_n, ref int ierr)
        {
            fixed (long* __tags_n1 = &tags_n)
            {
                var __arg1 = __tags_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshViewGetTags(tags, __arg1, __arg2);
                }
            }
        }

        public static void GmshViewAddModelData(int tag, int step, string modelName, string dataType, long[] tags, long tags_n, double** data, long[] data_n, long data_nn, double time, int numComponents, int partition, ref int ierr)
        {
            fixed (long* __tags4 = tags)
            {
                var __arg4 = __tags4;
                fixed (long* __data_n7 = data_n)
                {
                    var __arg7 = __data_n7;
                    fixed (int* __ierr12 = &ierr)
                    {
                        var __arg12 = __ierr12;
                        __Internal.GmshViewAddModelData(tag, step, modelName, dataType, __arg4, tags_n, data, __arg7, data_nn, time, numComponents, partition, __arg12);
                    }
                }
            }
        }

        public static void GmshViewAddHomogeneousModelData(int tag, int step, string modelName, string dataType, long[] tags, long tags_n, double[] data, long data_n, double time, int numComponents, int partition, ref int ierr)
        {
            fixed (long* __tags4 = tags)
            {
                var __arg4 = __tags4;
                fixed (double* __data6 = data)
                {
                    var __arg6 = __data6;
                    fixed (int* __ierr11 = &ierr)
                    {
                        var __arg11 = __ierr11;
                        __Internal.GmshViewAddHomogeneousModelData(tag, step, modelName, dataType, __arg4, tags_n, __arg6, data_n, time, numComponents, partition, __arg11);
                    }
                }
            }
        }

        public static void GmshViewGetModelData(int tag, int step, byte** dataType, long** tags, ref long tags_n, double*** data, long** data_n, ref long data_nn, ref double time, ref int numComponents, ref int ierr)
        {
            fixed (long* __tags_n4 = &tags_n)
            {
                var __arg4 = __tags_n4;
                fixed (long* __data_nn7 = &data_nn)
                {
                    var __arg7 = __data_nn7;
                    fixed (double* __time8 = &time)
                    {
                        var __arg8 = __time8;
                        fixed (int* __numComponents9 = &numComponents)
                        {
                            var __arg9 = __numComponents9;
                            fixed (int* __ierr10 = &ierr)
                            {
                                var __arg10 = __ierr10;
                                __Internal.GmshViewGetModelData(tag, step, dataType, tags, __arg4, data, data_n, __arg7, __arg8, __arg9, __arg10);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshViewAddListData(int tag, string dataType, int numEle, double[] data, long data_n, ref int ierr)
        {
            fixed (double* __data3 = data)
            {
                var __arg3 = __data3;
                fixed (int* __ierr5 = &ierr)
                {
                    var __arg5 = __ierr5;
                    __Internal.GmshViewAddListData(tag, dataType, numEle, __arg3, data_n, __arg5);
                }
            }
        }

        public static void GmshViewGetListData(int tag, byte*** dataType, ref long dataType_n, int** numElements, ref long numElements_n, double*** data, long** data_n, ref long data_nn, ref int ierr)
        {
            fixed (long* __dataType_n2 = &dataType_n)
            {
                var __arg2 = __dataType_n2;
                fixed (long* __numElements_n4 = &numElements_n)
                {
                    var __arg4 = __numElements_n4;
                    fixed (long* __data_nn7 = &data_nn)
                    {
                        var __arg7 = __data_nn7;
                        fixed (int* __ierr8 = &ierr)
                        {
                            var __arg8 = __ierr8;
                            __Internal.GmshViewGetListData(tag, dataType, __arg2, numElements, __arg4, data, data_n, __arg7, __arg8);
                        }
                    }
                }
            }
        }

        public static void GmshViewAddListDataString(int tag, double[] coord, long coord_n, byte** data, long data_n, byte** style, long style_n, ref int ierr)
        {
            fixed (double* __coord1 = coord)
            {
                var __arg1 = __coord1;
                fixed (int* __ierr7 = &ierr)
                {
                    var __arg7 = __ierr7;
                    __Internal.GmshViewAddListDataString(tag, __arg1, coord_n, data, data_n, style, style_n, __arg7);
                }
            }
        }

        public static void GmshViewGetListDataStrings(int tag, int dim, double** coord, ref long coord_n, byte*** data, ref long data_n, byte*** style, ref long style_n, ref int ierr)
        {
            fixed (long* __coord_n3 = &coord_n)
            {
                var __arg3 = __coord_n3;
                fixed (long* __data_n5 = &data_n)
                {
                    var __arg5 = __data_n5;
                    fixed (long* __style_n7 = &style_n)
                    {
                        var __arg7 = __style_n7;
                        fixed (int* __ierr8 = &ierr)
                        {
                            var __arg8 = __ierr8;
                            __Internal.GmshViewGetListDataStrings(tag, dim, coord, __arg3, data, __arg5, style, __arg7, __arg8);
                        }
                    }
                }
            }
        }

        public static int GmshViewAddAlias(int refTag, int copyOptions, int tag, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                var __ret = __Internal.GmshViewAddAlias(refTag, copyOptions, tag, __arg3);
                return __ret;
            }
        }

        public static void GmshViewOptionsCopy(int refTag, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshViewOptionsCopy(refTag, tag, __arg2);
            }
        }

        public static void GmshViewOptionsSetNumber(int tag, string name, double value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshViewOptionsSetNumber(tag, name, value, __arg2);
            }
        }

        public static void GmshViewOptionsGetNumber(int tag, string name, ref double value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshViewOptionsGetNumber(tag, name, value, __arg2);
            }
        }

        public static void GmshViewOptionsSetString(int tag, string name, double value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshViewOptionsSetString(tag, name, value, __arg2);
            }
        }

        public static void GmshViewOptionsGetString(int tag, string name, ref string value, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshViewOptionsGetString(tag, name, value, __arg2);
            }
        }

        public static void GmshViewCombine(string what, string how, int remove, int copyOptions, ref int ierr)
        {
            fixed (int* __ierr4 = &ierr)
            {
                var __arg4 = __ierr4;
                __Internal.GmshViewCombine(what, how, remove, copyOptions, __arg4);
            }
        }

        public static void GmshViewProbe(int tag, double x, double y, double z, double** value, ref long value_n, ref double distance, int step, int numComp, int gradient, double tolerance, double[] xElemCoord, long xElemCoord_n, double[] yElemCoord, long yElemCoord_n, double[] zElemCoord, long zElemCoord_n, int dim, ref int ierr)
        {
            fixed (long* __value_n5 = &value_n)
            {
                var __arg5 = __value_n5;
                fixed (double* __xElemCoord10 = xElemCoord)
                {
                    var __arg10 = __xElemCoord10;
                    fixed (double* __yElemCoord12 = yElemCoord)
                    {
                        var __arg12 = __yElemCoord12;
                        fixed (double* __zElemCoord14 = zElemCoord)
                        {
                            var __arg14 = __zElemCoord14;
                            fixed (int* __ierr17 = &ierr)
                            {
                                var __arg17 = __ierr17;
                                fixed (double* __arg18 = &distance)
                                {
                                    var __dist = __arg18;
                                    __Internal.GmshViewProbe(tag, x, y, z, value, __arg5, __dist, step, numComp, gradient, tolerance, __arg10, xElemCoord_n, __arg12, yElemCoord_n, __arg14, zElemCoord_n, dim, __arg17);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GmshViewWrite(int tag, string fileName, int append, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshViewWrite(tag, fileName, append, __arg3);
            }
        }

        public static void GmshViewOptionSetColor(string name, int r, int g, int b, int a, ref int ierr)
        {
            fixed (int* __ierr5 = &ierr)
            {
                var __arg5 = __ierr5;
                __Internal.GmshViewOptionSetColor(name, r, g, b, a, __arg5);
            }
        }

        public static void GmshViewOptionGetColor(string name, ref int r, ref int g, ref int b, ref int a, ref int ierr)
        {
            fixed (int* __r1 = &r)
            {
                var __arg1 = __r1;
                fixed (int* __g2 = &g)
                {
                    var __arg2 = __g2;
                    fixed (int* __b3 = &b)
                    {
                        var __arg3 = __b3;
                        fixed (int* __a4 = &a)
                        {
                            var __arg4 = __a4;
                            fixed (int* __ierr5 = &ierr)
                            {
                                var __arg5 = __ierr5;
                                __Internal.GmshViewOptionGetColor(name, __arg1, __arg2, __arg3, __arg4, __arg5);
                            }
                        }
                    }
                }
            }
        }

        public static void GmshPluginSetNumber(string name, string option, double value, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshPluginSetNumber(name, option, value, __arg3);
            }
        }

        public static void GmshPluginSetString(string name, string option, string value, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshPluginSetString(name, option, value, __arg3);
            }
        }

        public static void GmshPluginRun(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshPluginRun(name, __arg1);
            }
        }

        public static void GmshGraphicsDraw(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshGraphicsDraw(__arg0);
            }
        }

        public static void GmshFltkInitialize(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshFltkInitialize(__arg0);
            }
        }

        public static void GmshFltkWait(double time, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshFltkWait(time, __arg1);
            }
        }

        public static void GmshFltkUpdate(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshFltkUpdate(__arg0);
            }
        }

        public static void GmshFltkAwake(string action, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshFltkAwake(action, __arg1);
            }
        }

        public static void GmshFltkLock(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshFltkLock(__arg0);
            }
        }

        public static void GmshFltkUnlock(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshFltkUnlock(__arg0);
            }
        }

        public static void GmshFltkRun(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshFltkRun(__arg0);
            }
        }

        public static int GmshFltkIsAvailable(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                var __ret = __Internal.GmshFltkIsAvailable(__arg0);
                return __ret;
            }
        }

        public static int GmshFltkSelectEntities(int** dimTags, ref long dimTags_n, int dim, ref int ierr)
        {
            fixed (long* __dimTags_n1 = &dimTags_n)
            {
                var __arg1 = __dimTags_n1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    var __ret = __Internal.GmshFltkSelectEntities(dimTags, __arg1, dim, __arg3);
                    return __ret;
                }
            }
        }

        public static int GmshFltkSelectElements(long** elementTags, ref long elementTags_n, ref int ierr)
        {
            fixed (long* __elementTags_n1 = &elementTags_n)
            {
                var __arg1 = __elementTags_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    var __ret = __Internal.GmshFltkSelectElements(elementTags, __arg1, __arg2);
                    return __ret;
                }
            }
        }

        public static int GmshFltkSelectViews(int** viewTags, ref long viewTags_n, ref int ierr)
        {
            fixed (long* __viewTags_n1 = &viewTags_n)
            {
                var __arg1 = __viewTags_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    var __ret = __Internal.GmshFltkSelectViews(viewTags, __arg1, __arg2);
                    return __ret;
                }
            }
        }

        public static void GmshFltkSetStatusMessage(string action, int graphics, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshFltkSetStatusMessage(action, graphics, __arg2);
            }
        }

        public static void GmshFltkShowContextWindow(int dim, int tag, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshFltkShowContextWindow(dim, tag, __arg2);
            }
        }

        public static void GmshFltkOpenTreeItem(string name, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshFltkOpenTreeItem(name, __arg2);
            }
        }

        public static void GmshFltkCloseTreeItem(string name, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshFltkCloseTreeItem(name, __arg2);
            }
        }

        public static void GmshOnelabSet(string data, string format, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshOnelabSet(data, format, __arg2);
            }
        }

        public static void GmshOnelabGet(byte** data, string name, string format, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshOnelabGet(data, name, format, __arg3);
            }
        }

        public static void GmshOnelabSetNumber(string name, double[] value, long value_n, ref int ierr)
        {
            fixed (double* __value1 = value)
            {
                var __arg1 = __value1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshOnelabSetNumber(name, __arg1, value_n, __arg3);
                }
            }
        }

        public static void GmshOnelabSetString(string name, byte** value, long value_n, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshOnelabSetString(name, value, value_n, __arg3);
            }
        }

        public static void GmshOnelabGetNumber(string name, double** value, ref long value_n, ref int ierr)
        {
            fixed (long* __value_n2 = &value_n)
            {
                var __arg2 = __value_n2;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshOnelabGetNumber(name, value, __arg2, __arg3);
                }
            }
        }

        public static void GmshOnelabGetString(string name, byte*** value, ref long value_n, ref int ierr)
        {
            fixed (long* __value_n2 = &value_n)
            {
                var __arg2 = __value_n2;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshOnelabGetString(name, value, __arg2, __arg3);
                }
            }
        }

        public static void GmshOnelabClear(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshOnelabClear(name, __arg1);
            }
        }

        public static void GmshOnelabRun(string name, string command, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshOnelabRun(name, command, __arg2);
            }
        }

        public static void GmshOnelabGetNames(string search, byte*** value, ref long value_n, ref int ierr)
        {
            fixed (long* __value_n2 = &value_n)
            {
                var __arg2 = __value_n2;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshOnelabGetString(search, value, __arg2, __arg3);
                }
            }
        }

        public static int GmshOnelabGetChanged(string name, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                var value = __Internal.GmshOnelabGetChanged(name, __arg1);
                return value;
            }
        }

        public static void GmshOnelabSetChanged(string name, int value, ref int ierr)
        {
            fixed (int* __ierr1 = &ierr)
            {
                var __arg1 = __ierr1;
                __Internal.GmshOnelabSetChanged(name, value, __arg1);
            }
        }

        public static void GmshLoggerWrite(string message, string level, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshLoggerWrite(message, level, __arg2);
            }
        }

        public static void GmshLoggerStart(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshLoggerStart(__arg0);
            }
        }

        public static void GmshLoggerGet(byte*** log, ref long log_n, ref int ierr)
        {
            fixed (long* __log_n1 = &log_n)
            {
                var __arg1 = __log_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshLoggerGet(log, __arg1, __arg2);
                }
            }
        }

        public static void GmshLoggerStop(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshLoggerStop(__arg0);
            }
        }

        public static double GmshLoggerGetWallTime(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                var __ret = __Internal.GmshLoggerGetWallTime(__arg0);
                return __ret;
            }
        }

        public static double GmshLoggerGetCpuTime(ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                var __ret = __Internal.GmshLoggerGetCpuTime(__arg0);
                return __ret;
            }
        }

        public static void GmshLoggerGetLastError(byte** error, ref int ierr)
        {
            fixed (int* __ierr0 = &ierr)
            {
                var __arg0 = __ierr0;
                __Internal.GmshLoggerGetLastError(error, __arg0);
            }
        }

        public static void GmshParserGetNames(string search, byte*** names, ref int names_n, ref int ierr)
        {
            fixed (int* __log_n1 = &names_n)
            {
                var __arg1 = __log_n1;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshParserSetNames(names, __arg1, search, __arg2);
                }
            }
        }

        public static void GmshParserSetNumber(string name, double[] value, long value_n, ref int ierr)
        {
            fixed (double* __value1 = value)
            {
                var __arg1 = __value1;
                fixed (int* __ierr3 = &ierr)
                {
                    var __arg3 = __ierr3;
                    __Internal.GmshParserSetNumber(name, __arg1, value_n, __arg3);
                }
            }
        }

        public static void GmshParserSetString(string name, byte** value, long value_n, ref int ierr)
        {
            fixed (int* __ierr3 = &ierr)
            {
                var __arg3 = __ierr3;
                __Internal.GmshParserSetString(name, value, value_n, __arg3);
            }
        }

        public static void GmshParserGetNumber(string name, double** number, ref long number_n, ref int ierr)
        {
            fixed (long* __number = &number_n)
            {
                var _arg4 = __number;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshParserGetNumber(name, number, _arg4, __arg2);
                }
            }
        }

        public static void GmshParserGetString(string name, byte*** value, ref long number_n, ref int ierr)
        {
            fixed (long* __number = &number_n)
            {
                var _arg4 = __number;
                fixed (int* __ierr2 = &ierr)
                {
                    var __arg2 = __ierr2;
                    __Internal.GmshParserGetString(name, value, _arg4, __arg2);
                }
            }
        }

        public static void GmshParserClear(string name, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshParserClear(name, __arg2);
            }
        }

        public static void GmshParserParse(string name, ref int ierr)
        {
            fixed (int* __ierr2 = &ierr)
            {
                var __arg2 = __ierr2;
                __Internal.GmshParserClear(name, __arg2);
            }
        }
    }
}