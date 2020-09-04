using System;

namespace GmshNet
{
    public class GmshSmart : IDisposable
    {
        private bool _finalize = false;

        public GmshSmart()
        {
            Gmsh.Initialize();
        }

        public void Dispose()
        {
            if (!_finalize)
            {
                Gmsh.Finalize();
                _finalize = true;
            }
        }
    }
}