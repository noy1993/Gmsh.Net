namespace GMshNet
{
    public sealed class Fltk
    {
        private int ierr = 0;
        /// <summary>
        /// Create the FLTK graphical user interface. Can only be called in the main thread.
        /// </summary>
        public void Initialize()
        {
            GMshNativeMethods.gmshFltkInitialize(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Wait at most `time' seconds for user interface events and return. If `time'
        ///  0, wait indefinitely. First automatically create the user interface if it
        /// has not yet been initialized. Can only be called in the main thread.
        /// </summary>
        public void Wait(double time = -1)
        {
            GMshNativeMethods.gmshFltkWait(time, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Update the user interface (potentially creating new widgets and windows).
        /// First automatically create the user interface if it has not yet been
        /// initialized. Can only be called in the main thread: use `awake("update")' to
        /// trigger an update of the user interface from another thread.
        /// </summary>
        public void Update()
        {
            GMshNativeMethods.gmshFltkUpdate(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Awake the main user interface thread and process pending events, and
        /// optionally perform an action (currently the only `action' allowed is
        /// "update").
        /// </summary>
        public void Awake(string action = "")
        {
            GMshNativeMethods.gmshFltkAwake(action, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Block the current thread until it can safely modify the user interface.
        /// </summary>
        public void Lock()
        {
            GMshNativeMethods.gmshFltkLock(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Release the lock that was set using lock.
        /// </summary>
        public void Unlock()
        {
            GMshNativeMethods.gmshFltkUnlock(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Run the event loop of the graphical user interface, i.e. repeatedly call
        /// `wait()'. First automatically create the user interface if it has not yet
        /// been initialized. Can only be called in the main thread.
        /// </summary>
        public void Run()
        {
            GMshNativeMethods.gmshFltkRun(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
    }
}
