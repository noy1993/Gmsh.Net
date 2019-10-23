using System.Drawing;

namespace GMshNet
{
    public class Option
    {
        private int ierr = 0;
        /// <summary>
        /// Get the `value' of a numerical option. `name' is of the form
        /// "category.option" or "category[num].option". Available categories and
        /// options are listed in the Gmsh reference manual.
        /// </summary>
        public double GetNumber(string filename)
        {
            GMshNativeMethods.gmshOptionGetNumber(filename, out double num, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return num;
        }
        /// <summary>
        /// Set a string option to `value'. `name' is of the form "category.option" or
        /// "category[num].option". Available categories and options are listed in the
        /// Gmsh reference manual.
        /// </summary>
        public void SetNumber(string filename, double value)
        {
            GMshNativeMethods.gmshOptionSetNumber(filename, value, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        /// <summary>
        /// Set a string option to `value'. `name' is of the form "category.option" or
        /// "category[num].option". Available categories and options are listed in the
        /// Gmsh reference manual.
        /// </summary>
        public void SetString(string name,string value)
        {
            GMshNativeMethods.gmshOptionSetString(name, value, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }

        /// <summary>
        /// Get the `value' of a string option. `name' is of the form "category.option"
        /// or "category[num].option". Available categories and options are listed in
        /// the Gmsh reference manual.
        /// </summary>
        public void GetString(string name, string value)
        {
            GMshNativeMethods.gmshOptionGetString(name, value, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        public void SetColor(string name, Color color)
        {
            GMshNativeMethods.gmshOptionSetColor(name, color.R, color.G, color.B, color.A, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
        }
        public Color GetColor(string name)
        {
            GMshNativeMethods.gmshOptionGetColor(name, out int r, out int g, out int b, out int a, ref ierr);
            if (ierr != 0) throw new GMshException(ierr);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
