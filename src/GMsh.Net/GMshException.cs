using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace GMshNet
{
    public class GMshException : Exception
    {
        private string _message;
        public GMshException()
        {
        }
        public GMshException(int ierr)
        {
            if (ierr == -1)
            {
                _message = "Mesh initialization failed";
            }
            else
            {
                _message = "Meshing failed";
            }
        }
        public GMshException(string message)
        {
            _message = message;
        }
        public override string Message => _message;
    }
}
