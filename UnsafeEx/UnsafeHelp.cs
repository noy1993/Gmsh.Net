using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnsafeEx
{
    public delegate void Free(IntPtr ptr);

    public delegate IntPtr Malloc(long n);
    public static class UnsafeCPPHelp
    {
        public static event Free Delete;
        public static event Free DeleteArray;
        public static event Malloc New;
        public static byte[] StructToBytes<TStruct>(this TStruct obj) where TStruct : struct
        {
            int size = Marshal.SizeOf(obj);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(obj, buffer, true);
                byte[] bytes = new byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        public static TStruct BytesToStruct<TStruct>(this byte[] bytes) where TStruct : struct
        {
            int size = Marshal.SizeOf<TStruct>();
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure<TStruct>(buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }

    public static class UnsafeHelp
    {
        public static event Free Free;

        public static event Malloc Malloc;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static long[][] ToLongArray(long** array_ptr, long* count_ptr, long length)
        {
            var array_count = ToLongArray(count_ptr, length);
            var array = new long[array_count.Length][];
            for (int i = 0; i < array_count.Length; i++)
            {
                array[i] = ToLongArray(array_ptr[i], array_count[i]);
            }
            Free(new IntPtr(array_ptr));
            return array;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int[][] ToIntArray(int** array_ptr, long* count_ptr, long length)
        {
            var array_count = ToLongArray(count_ptr, length);
            var array = new int[array_count.Length][];
            for (int i = 0; i < array_count.Length; i++)
            {
                array[i] = ToIntArray(array_ptr[i], array_count[i]);
            }
            Free(new IntPtr(array_ptr));
            return array;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static double[][] ToDoubleArray(double** array_ptr, long* count_ptr, long length)
        {
            var array_count = ToLongArray(count_ptr, length);
            var array = new double[array_count.Length][];
            for (int i = 0; i < array_count.Length; i++)
            {
                array[i] = ToDoubleArray(array_ptr[i], array_count[i]);
            }
            Free(new IntPtr(array_ptr));
            return array;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static string ToString(byte* strptr)
        {
            var ptr = new IntPtr(strptr);
            var str = Marshal.PtrToStringAnsi(ptr);
            Free(ptr);
            return str;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static string[] ToString(byte** strptr, long string_n)
        {
            var messages = new string[string_n];
            for (int i = 0; i < string_n; i++)
            {
                messages[i] = ToString(strptr[i]);
            }
            Free(new IntPtr(strptr));
            return messages;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static IntPtr[] ToIntPtrArray(IntPtr ptr, long length)
        {
            var arr = new IntPtr[length];
            Marshal.Copy(ptr, arr, 0, arr.Length);
            Free(ptr);
            return arr;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int[] ToIntArray(int* ptr, long length)
        {
            var array_ptr = new IntPtr(ptr);
            var arr = new int[length];
            Marshal.Copy(array_ptr, arr, 0, arr.Length);
            Free(array_ptr);
            return arr;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static double[] ToDoubleArray(double* ptr, long length)
        {
            var array_ptr = new IntPtr(ptr);
            var arr = new double[length];
            Marshal.Copy(array_ptr, arr, 0, arr.Length);
            Free(array_ptr);
            return arr;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static long[] ToLongArray(long* ptr, long length)
        {
            var array_ptr = new IntPtr(ptr);
            var arr = new long[length];
            Marshal.Copy(array_ptr, arr, 0, arr.Length);
            Free(array_ptr);
            return arr;
        }
    }
}