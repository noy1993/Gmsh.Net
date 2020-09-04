using Gmsh_warp;
using System.Reflection;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// Graphics functions
        /// </summary>
        public static class Graphics
        {
            /// <summary>
            /// Draw all the OpenGL scenes.
            /// </summary>
            public static void Draw()
            {
                Gmsh_Warp.GmshGraphicsDraw(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}