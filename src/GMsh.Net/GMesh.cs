using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace GMshNet
{
    public sealed class GMesh
    {
        public GField Field { get; } = new GField();

        private int ierr = 0;
        /// <summary>
        /// Generate a mesh of the current model, up to dimension `dim' (0, 1, 2 or 3).
        /// </summary>
        public void Generate(int dim = 3)
        {
            GMshNativeMethods.gmshModelMeshGenerate(dim, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Partition the mesh of the current model into `numPart' partitions.
        /// </summary>
        public void Partition(int numPart)
        {
            GMshNativeMethods.gmshModelMeshPartition(numPart, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Unpartition the mesh of the current model.
        /// </summary>
        public void Unpartition()
        {
            GMshNativeMethods.gmshModelMeshUnpartition(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Optimize the mesh of the current model using `method' (empty for default
        /// tetrahedral mesh optimizer, "Netgen" for Netgen optimizer, "HighOrder" for
        /// direct high-order mesh optimizer, "HighOrderElastic" for high-order
        /// elastic smoother). If `force' is set apply the optimization also to
        /// discrete entities.
        /// </summary>
        public void Optimize(string method, bool force = false)
        {
            GMshNativeMethods.gmshModelMeshOptimize(method, force.Toint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Recombine the mesh of the current model.
        /// </summary>
        public void Recombine()
        {
            GMshNativeMethods.gmshModelMeshRecombine(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Refine the mesh of the current model by uniformly splitting the elements.
        /// </summary>
        public void Refine()
        {
            GMshNativeMethods.gmshModelMeshRefine(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Smooth the mesh of the current model.
        /// </summary>
        public void Smooth()
        {
            GMshNativeMethods.gmshModelMeshSmooth(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set the order of the elements in the mesh of the current model to `order'.
        /// </summary>
        public void SetOrder(int order)
        {
            GMshNativeMethods.gmshModelMeshSetOrder(order, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        public void GetNode(uint nodeTag, out double[] coord, out double[] parametricCoord)
        {
            IntPtr api_coordPtr = IntPtr.Zero;
            IntPtr api_parametricCoordPtr = IntPtr.Zero;

            ulong api_coord_n = 0;
            ulong api_parametricCoord_n = 0;

            GMshNativeMethods.gmshModelMeshGetNode(nodeTag, ref api_coordPtr, ref api_coord_n, ref api_parametricCoordPtr, ref api_parametricCoord_n, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);

            coord = new double[api_coord_n];
            parametricCoord = new double[api_parametricCoord_n];

            if (api_coord_n != 0)
            {
                Marshal.Copy(api_coordPtr, coord, 0, api_coord_n.Toint());
            }
            if (api_coord_n != 0)
            {
                Marshal.Copy(api_parametricCoordPtr, parametricCoord, 0, api_parametricCoord_n.Toint());
            }

            api_coordPtr.GmshFree();
            api_parametricCoordPtr.GmshFree();
        }

        /// <summary>
        /// 获取网格顶点
        /// </summary>
        public void GetNodes(out long[] nodeTags, out double[] coord, out double[] parametricCoord, int dim = -1, int tag = -1, bool includeBoundary = false, bool returnParametricCoord = true)
        {
            IntPtr api_nodeTagsPtr = IntPtr.Zero;
            IntPtr api_coordPtr = IntPtr.Zero;
            IntPtr api_parametricCoordPtr = IntPtr.Zero;

            ulong api_nodeTags_n = 0;
            ulong api_coord_n = 0;
            ulong api_parametricCoord_n = 0;
            GMshNativeMethods.gmshModelMeshGetNodes(ref api_nodeTagsPtr, ref api_nodeTags_n, ref api_coordPtr, ref api_coord_n, ref api_parametricCoordPtr, ref api_parametricCoord_n, dim, tag, includeBoundary.Toint(), returnParametricCoord.Toint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);

            nodeTags = new long[api_nodeTags_n];
            coord = new double[api_coord_n];
            parametricCoord = new double[api_parametricCoord_n];


            if (api_nodeTags_n != 0)
            {
                Marshal.Copy(api_nodeTagsPtr, nodeTags, 0, api_nodeTags_n.Toint());
            }
            if (api_coord_n != 0)
            {
                Marshal.Copy(api_coordPtr, coord, 0, api_coord_n.Toint());
            }
            if (api_coord_n != 0)
            {
                Marshal.Copy(api_parametricCoordPtr, parametricCoord, 0, api_parametricCoord_n.Toint());
            }

            api_nodeTagsPtr.GmshFree();
            api_coordPtr.GmshFree();
            api_parametricCoordPtr.GmshFree();
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
        public void AddNodes(int dim, long[] nodeTags, double[] coord, double[] parametricCoord, int tag = -1)
        {
            var numNodes = coord.Length / 3;
            if (numNodes != nodeTags.Length) throw new GMshException("Wrong number of coordinates");

            GMshNativeMethods.gmshModelMeshAddNodes(dim, tag, nodeTags.Select(n=> Convert.ToUInt32(n)).ToArray(), nodeTags.Length.ToUint(), coord, coord.Length.ToUint(), parametricCoord, parametricCoord.Length.ToUint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        public void GetElements(out ElementTypes[] elementTypes, out long[][] elementTags, out long[][] nodeTags, int dim = -1, int tag = -1)
        {
            IntPtr api_elementTypesPtr = IntPtr.Zero;

            IntPtr api_elementTagsPtr = IntPtr.Zero;
            IntPtr api_elementTags_nPtr = IntPtr.Zero;

            IntPtr api_nodeTags_Ptr = IntPtr.Zero;
            IntPtr api_nodeTags_nPtr = IntPtr.Zero;

            ulong api_api_elementTypes_n = 0;
            ulong api_elementTags_nn = 0;
            ulong api_nodeTags_nn = 0;

            GMshNativeMethods.gmshModelMeshGetElements(ref api_elementTypesPtr, ref api_api_elementTypes_n, ref api_elementTagsPtr, ref api_elementTags_nPtr, ref api_elementTags_nn, ref api_nodeTags_Ptr, ref api_nodeTags_nPtr, ref api_nodeTags_nn, dim, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);

            int[] elementTypesInt = new int[api_api_elementTypes_n];
            if (api_api_elementTypes_n != 0)
            {
                Marshal.Copy(api_elementTypesPtr, elementTypesInt, 0, api_api_elementTypes_n.Toint());
            }
            elementTypes = elementTypesInt.Select(e => (ElementTypes)e).ToArray();

            api_elementTypesPtr.GmshFree();

            long[] api_elementTags_n = new long[api_elementTags_nn];
            elementTags = new long[api_elementTags_nn][];
            if (api_elementTags_nn != 0)
            {
                var n = api_elementTags_nn.Toint();
                Marshal.Copy(api_elementTags_nPtr, api_elementTags_n, 0, n);

                IntPtr[] ptrs = new IntPtr[api_elementTags_nn];
                Marshal.Copy(api_elementTagsPtr, ptrs, 0, n);

                for (int i = 0; i < ptrs.Length; i++)
                {
                    long[] ss = new long[api_elementTags_n[i]];
                    Marshal.Copy(ptrs[i], ss, 0, api_elementTags_n[i].Toint());
                    elementTags[i] = ss;

                    ptrs[i].GmshFree();
                }
            }
            api_elementTagsPtr.GmshFree();
            api_elementTags_nPtr.GmshFree();

            long[] api_nodeTags_n = new long[api_nodeTags_nn];
            nodeTags = new long[api_nodeTags_nn][];
            if (api_nodeTags_nn != 0)
            {
                var n = api_nodeTags_nn.Toint();
                Marshal.Copy(api_nodeTags_nPtr, api_nodeTags_n, 0, n);

                IntPtr[] ptrs = new IntPtr[api_nodeTags_nn];
                Marshal.Copy(api_nodeTags_Ptr, ptrs, 0, n);

                for (int i = 0; i < ptrs.Length; i++)
                {
                    long[] ss = new long[api_nodeTags_n[i]];
                    Marshal.Copy(ptrs[i], ss, 0, api_nodeTags_n[i].Toint());
                    nodeTags[i] = ss;
                    ptrs[i].GmshFree();
                }
            }
            api_nodeTags_Ptr.GmshFree();
            api_nodeTags_nPtr.GmshFree();
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
        //public void AddElements(int dim, int tag, ElementTypes[] elementTypes, long[][] elementTags, long[][] nodeTags)
        //{
        //    GMshNativeMethods.gmshModelMeshAddNodes(dim, tag, nodeTags, nodeTags.Length.ToUint(), coord, coord.Length.ToUint(), parametricCoord, parametricCoord.Length.ToUint(), ref ierr);
        //}

        public void AddElementsByType(ElementTypes elementType, long[] elementTags, long[] nodeTags, int tag = -1)
        {
            GMshNativeMethods.gmshModelMeshAddElementsByType(tag, (int)elementType, elementTags, elementTags.Length.ToUint(), nodeTags, nodeTags.Length.ToUint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        public void GetElementsByType(ElementTypes elementTypes, out long[] elementTags, out long[] nodeTags, int tag = -1, ulong task = 0, ulong numTasks = 1)
        {
            IntPtr elementTagsPtr = IntPtr.Zero;
            IntPtr nodeTagsPtr = IntPtr.Zero;

            ulong elementTags_n = 0;
            ulong nodeTags_n = 0;

            GMshNativeMethods.gmshModelMeshGetElementsByType((int)elementTypes, ref elementTagsPtr, ref elementTags_n, ref nodeTagsPtr, ref nodeTags_n, tag, task, numTasks, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);

            elementTags = new long[elementTags_n];
            nodeTags = new long[nodeTags_n];

            if (elementTags_n != 0)
            {
                Marshal.Copy(elementTagsPtr, elementTags, 0, elementTags_n.Toint());
            }
            if (nodeTags_n != 0)
            {
                Marshal.Copy(nodeTagsPtr, nodeTags, 0, nodeTags_n.Toint());
            }

            elementTagsPtr.GmshFree();
            nodeTagsPtr.GmshFree();
        }

        /// <summary>
        /// Clear the mesh, i.e. delete all the nodes and elements.
        /// </summary>
        public void Clear()
        {
            GMshNativeMethods.gmshModelMeshClear(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        public void CreateGeometry()
        {
            GMshNativeMethods.gmshModelMeshCreateGeometry(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        public void CreateTopology()
        {
            GMshNativeMethods.gmshModelMeshCreateTopology(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        public void ClassifySurfaces(double angle, bool boundary = true, bool forReparametrization = false)
        {
            angle *= Math.PI / 180;
            GMshNativeMethods.gmshModelMeshClassifySurfaces(angle, boundary.Toint(), forReparametrization.Toint(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
    }
}
