namespace GMshNet
{
    public class GField
    {
        private int ierr = 0;
        /// <summary>
        /// Add a new mesh size field of type `fieldType'. If `tag' is positive,
        /// assign the tag explicitly; otherwise a new tag is assigned
        /// automatically. Return the field tag.
        /// </summary>
        public void Add(string fieldType, int tag = -1)
        {
            GMshNativeMethods.gmshModelMeshFieldAdd(fieldType, tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Remove the field with tag `tag'.
        /// </summary>
        public void Remove(int tag)
        {
            GMshNativeMethods.gmshModelMeshFieldRemove(tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set the numerical option `option' to value `value' for field `tag'.
        /// </summary>
        public void SetNumber(int tag, string option, double value)
        {
            GMshNativeMethods.gmshModelMeshFieldSetNumber(tag, option, value, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set the string option `option' to value `value' for field `tag'.
        /// </summary>
        public void SetString(int tag, string option, string value)
        {
            GMshNativeMethods.gmshModelMeshFieldSetString(tag, option, value, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set the numerical list option `option' to value `value' for field `tag'.
        /// </summary>
        public void SetNumbers(int tag, string option, double[] value)
        {
            GMshNativeMethods.gmshModelMeshFieldSetNumbers(tag, option, value, value.Length.ToUlong(), ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set the field `tag' as the background mesh size field.
        /// </summary>
        public void SetAsBackgroundMesh(int tag)
        {
            GMshNativeMethods.gmshModelMeshFieldSetAsBackgroundMesh(tag,ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set the field `tag' as a boundary layer size field.
        /// </summary>
        public void SetAsBoundaryLayer(int tag)
        {
            GMshNativeMethods.gmshModelMeshFieldSetAsBoundaryLayer(tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
    }
}