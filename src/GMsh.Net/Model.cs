using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GMshNet
{
    public sealed class Model
    {
        public OccFunc Occ { get; } = new OccFunc();
        public GeoFunc Geo { get; } = new GeoFunc();
        public GMesh Mesh { get; } = new GMesh();

        private int ierr = 0;
        /// <summary>
        /// Add a new model, with name `name', and set it as the current model.
        /// </summary>
        public void Add(string name)
        {
            GMshNativeMethods.gmshModelAdd(name, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Remove the current model.
        /// </summary>
        public void Remove(string name)
        {
            GMshNativeMethods.gmshModelRemove(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        ///// <summary>
        ///// List the names of all models.
        ///// </summary>
        //public void List(List<string> names)
        //{
        //    GMshNativeMethods.gmshModelList();
        //}


        /// <summary>
        ///  Set the current model to the model with name `name'. If several models have
        ///  the same name, select the one that was added first.
        /// </summary>
        public void SetCurrent(string name)
        {
            GMshNativeMethods.gmshModelSetCurrent(name, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        /// <summary>
        ///  Get all the entities in the current model. If `dim' is >= 0, return only the
        ///  entities of the specified dimension (e.g. points if `dim' == 0). The
        ///  entities are returned as a vector of (dim, tag) integer pairs.
        /// </summary>
        public int[][] GetEntities(int dim = -1)
        {
            IntPtr dimTagsPtr = IntPtr.Zero;
            uint dimTags_n = 0;
            GMshNativeMethods.gmshModelGetEntities(ref dimTagsPtr, ref dimTags_n, dim, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            int[] dimlist = new int[dimTags_n];
            Marshal.Copy(dimTagsPtr, dimlist, 0, dimTags_n.Toint());
            dimTagsPtr.GmshFree();
            int[][] api_dimtags = new int[2][];
            api_dimtags[0] = new int[dimTags_n / 2];
            api_dimtags[1] = new int[dimTags_n / 2];
            for (int i = 0; i < dimTags_n / 2; i++)
            {
                var index = i * 2;
                api_dimtags[0][i] = dimlist[index];
                api_dimtags[1][i] = dimlist[index + 1];
            }
            return api_dimtags;
        }
        /// <summary>
        /// Set the name of the entity of dimension `dim' and tag `tag'.
        /// </summary>
        public void SetEntityName(string name)
        {

        }
        /// <summary>
        /// Get the name of the entity of dimension `dim' and tag `tag'.
        /// </summary>
        public void GetEntityName(string name)
        {

        }
        /// <summary>
        /// Get all the physical groups in the current model. If `dim' is >= 0, return
        /// only the entities of the specified dimension (e.g. physical points if `dim'
        /// == 0). The entities are returned as a vector of (dim, tag) integer pairs.
        /// </summary>
        public void GetPhysicalGroups(string name)
        {

        }

        /// <summary>
        /// Get the tags of the model entities making up the physical group of dimension
        /// `dim' and tag `tag'.
        /// </summary>
        public void getEntitiesForPhysicalGroup(string name)
        {

        }
    }
}
