using System;
using System.Runtime.InteropServices;

namespace GMshNet
{
    public sealed class Logger
    {
        private int ierr = 0;
        /// <summary>
        /// Write a `message'. `level' can be "info", "warning" or "error".
        /// </summary>
        public void Write(string message,string level = "info" )
        {
            GMshNativeMethods.gmshLoggerWrite(message, level, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Start logging messages.
        /// </summary>
        public void Start()
        {
            GMshNativeMethods.gmshLoggerStart(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }


        /// <summary>
        ///  Get logged messages.
        /// </summary>
        public string[] Get()
        {
            IntPtr log = IntPtr.Zero;
            uint log_n = 0;
            GMshNativeMethods.gmshLoggerGet(ref log, ref log_n, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);

            IntPtr[] str = new IntPtr[log_n];
            Marshal.Copy(log, str, 0, log_n.Toint());
            string[] messages = new string[log_n];

            for (int i = 0; i < log_n; i++)
            {
                messages[i] = Marshal.PtrToStringAnsi(str[i]);
            }
            log.GmshFree();
            return messages;
        }
        /// <summary>
        ///  Stop logging messages.
        /// </summary>
        public void Stop()
        {
            GMshNativeMethods.gmshLoggerTime(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Return wall clock time.
        /// </summary>
        public double Time()
        {
            var time = GMshNativeMethods.gmshLoggerTime(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return time;
        }
        /// <summary>
        /// Return CPU time.
        /// </summary>
        public double Cputime()
        {
            var time = GMshNativeMethods.gmshLoggerCputime(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return time;
        }
    }
}