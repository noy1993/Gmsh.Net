using System;

namespace GMshNet
{
    public sealed class GMsh : IDisposable
    {
        private int ierr = 0;
        /// <summary>
        /// Initialize Gmsh.
        /// </summary>
        public GMsh()
        {
            GMshNativeMethods.gmshInitialize(0, null, 1, ref ierr);
            if (ierr != 0)
            {
                throw new GMshException(ierr);
            }
        }
        /// <summary>
        /// Finalize Gmsh. This must be called when you are done using the Gmsh API.
        /// </summary>
        public void Dispose()
        {
            GMshNativeMethods.gmshFinalize(ref ierr);
            if (ierr != 0)
            {
                throw new GMshException(ierr);
            }
        }

        /// <summary>
        /// Open a file. Equivalent to the `File->Open' menu in the Gmsh app. Handling of
        /// the file depends on its extension and/or its contents: opening a file with
        /// model data will create a new model.
        /// </summary>
        public void Open(string filename)
        {
            GMshNativeMethods.gmshOpen(filename, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Merge a file. Equivalent to the `File->Merge' menu in the Gmsh app. Handling
        /// of the file depends on its extension and/or its contents. Merging a file with
        /// model data will add the data to the current model.
        /// </summary>
        public void Merge(string filename)
        {
            GMshNativeMethods.gmshMerge(filename, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        /// <summary>
        /// Write a file. The export format is determined by the file extension.
        /// </summary>
        public void Write(string filename)
        {
            GMshNativeMethods.gmshWrite(filename, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Clear all loaded models and post-processing data, and add a new empty model.
        /// </summary>
        public void Clear()
        {
            GMshNativeMethods.gmshClear(ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        public Model Model { get; } = new Model();
        public Fltk Fltk { get; } = new Fltk();
        public MeshOption MeshOption { get; } = new MeshOption();
        public Logger Logger { get; } = new Logger();
    }
}