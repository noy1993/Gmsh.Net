using System;
using System.Runtime.InteropServices;

namespace GMshNet
{
    public class GeoFunc
    {
        private int ierr = 0;
        public int AddVolume(int[] shellTags, int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelGeoAddVolume(shellTags, shellTags.Length.ToUlong(), tag, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        public int AddSurfaceLoop(int[] surfaceTags,int tag = -1)
        {
            var api = GMshNativeMethods.gmshModelGeoAddSurfaceLoop(surfaceTags, surfaceTags.Length.ToUlong(), tag,ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return api;
        }
        public void Synchronize()
        {
            GMshNativeMethods.gmshModelGeoSynchronize(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
    }
}
