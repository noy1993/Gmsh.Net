using Gmsh_warp;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// Post-processing view functions
        /// </summary>
        public static partial class View
        {
            /// <summary>
            /// Add a new post-processing view, with name `name'. If `tag' is positive use
            /// it (and remove the view with that tag if it already exists), otherwise
            /// associate a new tag. Return the view tag.
            /// </summary>
            public static int Add(string name, int tag = -1)
            {
                var index = Gmsh_Warp.GmshViewAdd(name, tag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return index;
            }

            /// <summary>
            /// Remove the view with tag `tag'.
            /// </summary>
            public static void Remove(int tag)
            {
                Gmsh_Warp.GmshViewRemove(tag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the index of the view with tag `tag' in the list of currently loaded
            /// views. This dynamic index (it can change when views are removed) is used to
            /// access view options.
            /// </summary>
            public static void GetIndex(int tag)
            {
                Gmsh_Warp.GmshViewGetIndex(tag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the tags of all views.
            /// </summary>
            public static int[] GetTags()
            {
                unsafe
                {
                    int* tags_ptr;
                    long tags_n = 0;
                    Gmsh_Warp.GmshViewGetTags(&tags_ptr, ref tags_n, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return UnsafeHelp.ToIntArray(tags_ptr, tags_n);
                }
            }

            /// <summary>
            /// Add model-based post-processing data to the view with tag `tag'. `modelName'
            /// identifies the model the data is attached to. `dataType' specifies the type
            /// of data, currently either "NodeData", "ElementData" or "ElementNodeData".
            /// `step' specifies the identifier (>= 0) of the data in a sequence. `tags'
            /// gives the tags of the nodes or elements in the mesh to which the data is
            /// associated. `data' is a vector of the same length as `tags': each entry is
            /// the vector of double precision numbers representing the data associated with
            /// the corresponding tag. The optional `time' argument associate a time value
            /// with the data. `numComponents' gives the number of data components (1 for
            /// scalar data, 3 for vector data, etc.) per entity; if negative, it is
            /// automatically inferred (when possible) from the input data. `partition'
            /// allows to specify data in several sub-sets.
            /// </summary>
            public static void AddModelData(int tag, int step, string modelName, string dataType, long[] tags, double[][] data, double time = 0, int numComponents = -1, int partition = 0)
            {
                unsafe
                {
                    var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
                    Gmsh_Warp.GmshViewAddModelData(tag, step, modelName, dataType, tags, tags.LongLength, (double**)ptr.ToPointer(), data.Select(d => d.LongLength).ToArray(), data.LongLength, time, numComponents, partition, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Add homogeneous model-based post-processing data to the view with tag `tag'.
            /// The arguments have the same meaning as in `addModelData', except that `data'
            /// is supposed to be homogeneous and is thus flattened in a single vector. For
            /// data types that can lead to different data sizes per tag (like
            /// "ElementNodeData"), the data should be padded.
            /// </summary>
            public static void AddHomogeneousModelData(int tag, int step, string modelName, string dataType, long[] tags, double[] data, double time = 0, int numComponents = -1, int partition = 0)
            {
                Gmsh_Warp.GmshViewAddHomogeneousModelData(tag, step, modelName, dataType, tags, tags.LongLength, data, data.LongLength, time, numComponents, partition, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Add homogeneous model-based post-processing data to the view with tag `tag'.
            /// The arguments have the same meaning as in `addModelData', except that `data'
            /// is supposed to be homogeneous and is thus flattened in a single vector. For
            /// data types that can lead to different data sizes per tag (like
            /// "ElementNodeData"), the data should be padded.
            /// </summary>
            public static void GetModelData(int tag, int step, out string dataType, out long[] tags, out double[][] data, out double time, out int numComponents)
            {
                unsafe
                {
                    byte* dataType_ptr;
                    long* tags_ptr;
                    long tags_n = 0;
                    double** data_ptr;
                    long* data_n_ptr;
                    long data_nn = 0;
                    time = 0; numComponents = 0;

                    Gmsh_Warp.GmshViewGetModelData(tag, step, &dataType_ptr, &tags_ptr, ref tags_n, &data_ptr, &data_n_ptr, ref data_nn, ref time, ref numComponents, ref Gmsh._staticreff);
                    dataType = UnsafeHelp.ToString(dataType_ptr);
                    tags = UnsafeHelp.ToLongArray(tags_ptr, tags_n);
                    data = UnsafeHelp.ToDoubleArray(data_ptr, data_n_ptr, data_nn);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Add list-based post-processing data to the view with tag `tag'. List-based
            /// datasets are independent from any model and any mesh. `dataType' identifies
            /// the data by concatenating the field type ("S" for scalar, "V" for vector,
            /// "T" for tensor) and the element type ("P" for point, "L" for line, "T" for
            /// triangle, "S" for tetrahedron, "I" for prism, "H" for hexaHedron, "Y" for
            /// pyramid). For example `dataType' should be "ST" for a scalar field on
            /// triangles. `numEle' gives the number of elements in the data. `data'
            /// contains the data for the `numEle' elements, concatenated, with node
            /// coordinates followed by values per node, repeated for each step: [e1x1, ...,
            /// e1xn, e1y1, ..., e1yn, e1z1, ..., e1zn, e1v1..., e1vN, e2x1, ...].
            /// </summary>
            public static void AddListData(int tag, string dataType, int numEle, double[] data)
            {
                Gmsh_Warp.GmshViewAddListData(tag, dataType, numEle, data, data.LongLength, ref Gmsh._staticreff);

                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Add homogeneous model-based post-processing data to the view with tag `tag'.
            /// The arguments have the same meaning as in `addModelData', except that `data'
            /// is supposed to be homogeneous and is thus flattened in a single vector. For
            /// data types that can lead to different data sizes per tag (like
            /// "ElementNodeData"), the data should be padded.
            /// </summary>
            public static void GetListData(int tag, out string[] dataType, out int[] numElements, out double[][] data)
            {
                unsafe
                {
                    byte** dataType_ptr;
                    long dataType_n = 0;
                    int* numElements_ptr;
                    long numElements_n = 0;
                    double** data_ptr;
                    long* data_n_ptr;
                    long data_nn = 0;

                    Gmsh_Warp.GmshViewGetListData(tag, &dataType_ptr, ref dataType_n, &numElements_ptr, ref numElements_n, &data_ptr, &data_n_ptr, ref data_nn, ref Gmsh._staticreff);
                    dataType = UnsafeHelp.ToString(dataType_ptr, dataType_n);
                    numElements = UnsafeHelp.ToIntArray(numElements_ptr, numElements_n);
                    data = UnsafeHelp.ToDoubleArray(data_ptr, data_n_ptr, data_nn);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Add a string to a list-based post-processing view with tag `tag'. If `coord'
            /// contains 3 coordinates the string is positioned in the 3D model space ("3D
            /// string"); if it contains 2 coordinates it is positioned in the 2D graphics
            /// viewport ("2D string"). `data' contains one or more (for multistep views)
            /// strings. `style' contains key-value pairs of styling parameters,
            /// concatenated. Available keys are "Font" (possible values: "Times-Roman",
            /// "Times-Bold", "Times-Italic", "Times-BoldItalic", "Helvetica", "Helvetica-
            /// Bold", "Helvetica-Oblique", "Helvetica-BoldOblique", "Courier", "Courier-
            /// Bold", "Courier-Oblique", "Courier-BoldOblique", "Symbol", "ZapfDingbats",
            /// "Screen"), "FontSize" and "Align" (possible values: "Left" or "BottomLeft",
            /// "Center" or "BottomCenter", "Right" or "BottomRight", "TopLeft",
            /// "TopCenter", "TopRight", "CenterLeft", "CenterCenter", "CenterRight").
            /// </summary>
            public static void AddListDataString(int tag, double[] coord, string[] data, string[] style = default)
            {
                unsafe
                {
                    byte* dataptr = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
                    if (style == default) style = new string[0];
                    byte* styleptr = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(style, 0);
                    Gmsh_Warp.GmshViewAddListDataString(tag, coord, coord.LongLength, &dataptr, data.LongLength, &styleptr, style.LongLength, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Get list-based post-processing data strings (2D strings if `dim' = 2, 3D
            /// strings if `dim' = 3) from the view with tag `tag'. Return the coordinates
            /// in `coord', the strings in `data' and the styles in `style'.
            /// </summary>
            public static void GetListDataStrings(int tag, int dim, out double[] coord, out string[] data, out string[] style)
            {
                unsafe
                {
                    double* coord_ptr;
                    long coord_n = 0;
                    byte** data_ptr;
                    long data_n = 0;
                    byte** style_ptr;
                    long style_n = 0;

                    Gmsh_Warp.GmshViewGetListDataStrings(tag, dim, &coord_ptr, ref coord_n, &data_ptr, ref data_n, &style_ptr, ref style_n, ref Gmsh._staticreff);
                    coord = UnsafeHelp.ToDoubleArray(coord_ptr, coord_n);
                    data = UnsafeHelp.ToString(data_ptr, data_n);
                    style = UnsafeHelp.ToString(style_ptr, style_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Add a post-processing view as an `alias' of the reference view with tag
            /// `refTag'. If `copyOptions' is set, copy the options of the reference view.
            /// If `tag' is positive use it (and remove the view with that tag if it already
            /// exists), otherwise associate a new tag. Return the view tag.
            /// </summary>
            public static void AddAlias(int refTag, bool copyOptions = false, int tag = -1)
            {
                Gmsh_Warp.GmshViewAddAlias(refTag, Convert.ToInt32(copyOptions), tag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Combine elements (if `what' == "elements") or steps (if `what' == "steps")
            /// of all views (`how' == "all"), all visible views (`how' == "visible") or all
            /// views having the same name (`how' == "name"). Remove original views if
            /// `remove' is set.
            /// </summary>
            public static void Combine(string what, string how, bool remove = true, bool copyOptions = true)
            {
                Gmsh_Warp.GmshViewCombine(what, how, Convert.ToInt32(remove), Convert.ToInt32(copyOptions), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Probe the view `tag' for its `value' at point (`x', `y', `z'). If no match
            /// is found, `value' is returned empty. Return only the value at step `step' is
            /// `step' is positive. Return only values with `numComp' if `numComp' is
            /// positive. Return the gradient of the `value' if `gradient' is set. If
            /// `distanceMax' is zero, only return a result if an exact match inside an
            /// element in the view is found; if `distanceMax' is positive and an exact
            /// match is not found, return the value at the closest node if it is closer
            /// than `distanceMax'; if `distanceMax' is negative and an exact match is not
            /// found, always return the value at the closest node. The distance to the
            /// match is returned in `distance'. Return the result from the element
            /// described by its coordinates if `xElementCoord', `yElementCoord' and
            /// `zElementCoord' are provided. If `dim' is >= 0, return only matches from
            /// elements of the specified dimension.
            /// </summary>
            public static void Probe(int tag, double x, double y, double z, out double[] value, out double distance, int step = -1, int numComp = -1, bool gradient = false, double tolerance = 0, 
                double[] xElemCoord = default, double[] yElemCoord = default, double[] zElemCoord = default, int dim = -1)
            {
                unsafe
                {
                    double* value_ptr;
                    long value_n = 0;
                    if (xElemCoord == default) xElemCoord = new double[0];
                    if (yElemCoord == default) yElemCoord = new double[0];
                    if (zElemCoord == default) zElemCoord = new double[0];
                    distance = -1;
                    Gmsh_Warp.GmshViewProbe(tag, x, y, z, &value_ptr, ref value_n, ref distance, step, numComp, Convert.ToInt32(gradient), tolerance, xElemCoord, xElemCoord.LongLength, 
                        yElemCoord, yElemCoord.LongLength, zElemCoord, zElemCoord.LongLength, dim, ref Gmsh._staticreff);
                    value = UnsafeHelp.ToDoubleArray(value_ptr, value_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Write the view to a file `fileName'. The export format is determined by the
            /// file extension. Append to the file if `append' is set.
            /// </summary>
            public static void Write(int tag, string fileName, bool append = true)
            {
                Gmsh_Warp.GmshViewWrite(tag, fileName, Convert.ToInt32(append), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}