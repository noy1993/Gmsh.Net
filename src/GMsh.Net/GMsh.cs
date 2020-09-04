using Gmsh_warp;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GmshNet
{
    public static partial class Gmsh
    {
        static Gmsh()
        {
            UnsafeEx.UnsafeHelp.Free += Gmsh_Warp.GmshFree;
        }

        internal static int _staticreff = 0;

        /// <summary>
        ///  Initialize Gmsh. This must be called before any call to the other functions in
        /// the API. If `argc' and `argv' (or just `argv' in Python or Julia) are
        /// provided, they will be handled in the same way as the command line arguments
        /// in the Gmsh app. If `readConfigFiles' is set, read system Gmsh configuration
        /// files (gmshrc and gmsh-options).
        /// </summary>
        public static void Initialize(char[] args = null, bool readConfigFiles = true)
        {
            unsafe
            {
                if (args == null)
                {
                    Gmsh_Warp.GmshInitialize(0, null, Convert.ToInt32(readConfigFiles), ref _staticreff);
                }
                else
                {
                    var array = Marshal.UnsafeAddrOfPinnedArrayElement(args, 0);
                    Gmsh_Warp.GmshInitialize(args.Length, (byte**)array.ToPointer(), Convert.ToInt32(readConfigFiles), ref _staticreff);
                }
                CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }

#pragma warning disable CS0465

        /// <summary>
        /// Finalize Gmsh. This must be called when you are done using the Gmsh API.
        /// </summary>
        public static void Finalize()
#pragma warning restore CS0465 // 引入 "Finalize" 方法可能会妨碍析构函数调用
        {
            Gmsh_Warp.GmshFinalize(ref _staticreff);
            CheckException(MethodBase.GetCurrentMethod().MethodHandle);
        }

        /// <summary>
        /// Open a file. Equivalent to the `File->Open' menu in the Gmsh app. Handling of
        /// the file depends on its extension and/or its contents: opening a file with
        /// model data will create a new model.
        /// </summary>
        public static void Open(string fileName)
        {
            Gmsh_Warp.GmshOpen(fileName, ref _staticreff);
            CheckException(MethodBase.GetCurrentMethod().MethodHandle);
        }

        /// <summary>
        /// Merge a file. Equivalent to the `File->Merge' menu in the Gmsh app. Handling
        /// of the file depends on its extension and/or its contents. Merging a file with
        /// model data will add the data to the current model.
        /// </summary>
        public static void Merge(string fileName)
        {
            Gmsh_Warp.GmshMerge(fileName, ref _staticreff);
            CheckException(MethodBase.GetCurrentMethod().MethodHandle);
        }

        /// <summary>
        /// Write a file. The export format is determined by the file extension.
        /// </summary>
        public static void Write(string fileName)
        {
            Gmsh_Warp.GmshWrite(fileName, ref _staticreff);
            CheckException(MethodBase.GetCurrentMethod().MethodHandle);
        }

        /// <summary>
        /// Clear all loaded models and post-processing data, and add a new empty model.
        /// </summary>
        public static void Clear()
        {
            Gmsh_Warp.GmshClear(ref _staticreff);
            CheckException(MethodBase.GetCurrentMethod().MethodHandle);
        }

        internal static void CheckException(RuntimeMethodHandle handle)
        {
            if (_staticreff != 0)
            {
                var method = MethodBase.GetMethodFromHandle(handle);
                var where = $"{method.DeclaringType.FullName}.{method.Name}";
                unsafe
                {
                    byte* errorptr;
                    int ieff = 0;

                    Gmsh_Warp.GmshLoggerGetLastError(&errorptr, ref ieff);
                    if (ieff != 0)
                    {
                        throw new GmshException("Could not get last error", where, _staticreff);
                    }
                    else
                    {
                        var ptr = new IntPtr(errorptr);
                        var error = Marshal.PtrToStringAnsi(ptr);
                        Gmsh_Warp.GmshFree(ptr);
                        throw new GmshException(error, where, _staticreff);
                    }
                }
            }
        }
    }

    public class GmshException : SystemException
    {
        public GmshException(string error, string where, int reff) : base($"error code: {reff},where: {where}\n{error}")
        {
        }

        public GmshException(string error, string where, int reff, Exception innerException) : base($"error code: {reff},where: {where}\n{error}", innerException)
        {
        }
    }
}