using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMshNet
{
    public static class Extension
    {
        public static void GmshFree(this IntPtr ptr)
        {
            GMshNativeMethods.gmshFree(ptr);
        }
        public static uint ToUint(this int value)
        {
            return Convert.ToUInt32(value);
        }
        public static ulong ToUlong(this int value)
        {
            return Convert.ToUInt64(value);
        }
        public static int Toint(this uint value)
        {
            return Convert.ToInt32(value);
        }
        public static int Toint(this long value)
        {
            return Convert.ToInt32(value);
        }
        public static int Toint(this ulong value)
        {
            return Convert.ToInt32(value);
        }
        public static int Toint(this bool value)
        {
            return Convert.ToInt32(value);
        }
    }
}
