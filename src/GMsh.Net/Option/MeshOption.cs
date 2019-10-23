namespace GMshNet
{
    public sealed class MeshOption : Option
    {
        /// <summary>
        /// CPU time (in seconds) for the generation of the current mesh (read-only)
        /// </summary>
        public double CpuTime { get => GetNumber("Mesh.CpuTime"); }
        /// <summary>
        /// Mesh output format (1: msh, 2: unv, 10: auto, 16: vtk, 19: vrml, 21: mail, 26: pos stat, 27: stl, 
        ///28: p3d, 30: mesh, 31: bdf, 32: cgns, 33: med, 34: diff, 38: ir3, 39: inp, 40: ply2, 41: celum, 42: su2, 47: tochnog, 49: neu, 50: matlab)
        /// </summary>
        public MeshFormat Format { get => (MeshFormat)GetNumber("Mesh.Format"); set => SetNumber("Mesh.Format", (double)value); }
        #region Get Number of Meshes (Read only)
        /// <summary>
        /// Number of triangles in the current mesh (read-only)
        /// </summary>
        public double NbTriangles { get => GetNumber("Mesh.NbTriangles"); }
        /// <summary>
        /// Number of tetrahedra in the current mesh (read-only)
        /// </summary>
        public double NbTetrahedra { get => GetNumber("Mesh.NbTetrahedra"); }
        /// <summary>
        /// Number of quadrangles in the current mesh (read-only)
        /// </summary>
        public double NbQuadrangles { get => GetNumber("Mesh.NbTriangles"); }
        /// <summary>
        /// Number of trihedra in the current mesh (read-only)
        /// </summary>
        public double NbTrihedra { get => GetNumber("Mesh.NbTrihedra"); }
        /// <summary>
        /// Number of pyramids in the current mesh (read-only)
        /// </summary>
        public double NbPyramids { get => GetNumber("Mesh.NbPyramids"); }
        /// <summary>
        /// Number of prisms in the current mesh (read-only)
        /// </summary>
        public double NbPrisms { get => GetNumber("Mesh.NbPrisms"); }
        /// <summary>
        /// Number of partitions
        /// </summary>
        public double NbPartitions { get => GetNumber("Mesh.NbPartitions"); set => SetNumber("Mesh.NbPartitions", value); }
        /// <summary>
        /// Number of nodes in the current mesh (read-only)
        /// </summary>
        public double NbNodes { get => GetNumber("Mesh.NbNodes"); }
        /// <summary>
        /// Number of hexahedra in the current mesh (read-only)
        /// </summary>
        public double NbHexahedra { get => GetNumber("Mesh.NbHexahedra"); }
        #endregion
        #region 3DMeshing
        /// <summary>
        /// Tolerance for initial 3D Delaunay mesher
        /// </summary>
        public double ToleranceInitialDelaunay { get => GetNumber("Mesh.ToleranceInitialDelaunay"); set => SetNumber("Mesh.ToleranceInitialDelaunay", value); }
        /// <summary>
        /// Skip a model edge in mesh generation if its length is less than user’s defined tolerance
        /// </summary>
        public double ToleranceEdgeLength { get => GetNumber("Mesh.ToleranceEdgeLength"); set => SetNumber("Mesh.ToleranceEdgeLength", value); }

        #region Optimization
        /// <summary>
        /// Optimize the mesh to improve the quality of tetrahedral elements
        /// </summary>
        public double Optimize { get => GetNumber("Mesh.Optimize"); set => SetNumber("Mesh.Optimize", value); }
        /// <summary>
        /// Optimize the mesh to improve the quality of tetrahedral elements
        /// </summary>
        public double OptimizeThreshold { get => GetNumber("Mesh.OptimizeThreshold"); set => SetNumber("Mesh.OptimizeThreshold", value); }
        /// <summary>
        /// Optimize the mesh to improve the quality of tetrahedral elements
        /// </summary>
        public double OptimizeNetgen { get => GetNumber("Mesh.OptimizeNetgen"); set => SetNumber("Mesh.OptimizeNetgen", value); }
        #endregion
        #endregion
        #region Smoothing
        /// <summary>
        /// Number of smoothing steps applied to the final mesh
        /// </summary>
        public double Smoothing { get => GetNumber("Mesh.Smoothing"); set => SetNumber("Mesh.Smoothing", value); }
        /// <summary>
        /// Ratio between mesh sizes at nodes of a same edge (used in BAMG)
        /// </summary>
        public double SmoothRatio { get => GetNumber("Mesh.SmoothRatio"); set => SetNumber("Mesh.SmoothRatio", value); }
        /// <summary>
        /// Smooth the mesh normals?
        /// </summary>
        public double SmoothNormals { get => GetNumber("Mesh.SmoothNormals"); set => SetNumber("Mesh.SmoothNormals", value); }
        /// <summary>
        /// Use closest point to compute 2D crossfield
        /// </summary>
        public double CrossFieldClosestPoint { get => GetNumber("Mesh.CrossFieldClosestPoint"); set => SetNumber("Mesh.CrossFieldClosestPoint", value); }
        /// <summary>
        /// Apply n barycentric smoothing passes to the 3D cross field
        /// </summary>
        public double SmoothCrossField { get => GetNumber("Mesh.SmoothCrossField"); set => SetNumber("Mesh.SmoothCrossField", value); }
        #endregion
        /// <summary>
        /// Should second order nodes (as well as nodes generated with subdivision algorithms) simply be created by linear interpolation?
        /// </summary>
        public double SecondOrderLinear { get => GetNumber("Mesh.SecondOrderLinear"); set => SetNumber("Mesh.SecondOrderLinear", value); }
        #region Meshing Parameters
        /// <summary>
        /// Minimum mesh element size
        /// </summary>
        public double LengthMin { get => GetNumber("Mesh.CharacteristicLengthMin"); set => SetNumber("Mesh.CharacteristicLengthMin", value); }
        /// <summary>
        /// Maximum mesh element size
        /// </summary>
        public double LengthMax { get => GetNumber("Mesh.CharacteristicLengthMax"); set => SetNumber("Mesh.CharacteristicLengthMax", value); }
        /// <summary>
        /// Maximum anisotropy of the mesh
        /// </summary>
        public double AnisoMax { get => GetNumber("Mesh.AnisoMax"); set => SetNumber("Mesh.AnisoMax", value); }
        /// <summary>
        /// Threshold angle (in degrees) between faces normals under which we allow an edge swap
        /// </summary>
        public double AllowSwapAngle { get => GetNumber("Mesh.AllowSwapAngle"); set => SetNumber("Mesh.AllowSwapAngle", value); }
        /// <summary>
        /// Threshold angle below which normals are not smoothed
        /// </summary>
        public double AngleSmoothNormals { get => GetNumber("Mesh.AngleSmoothNormals"); set => SetNumber("Mesh.AngleSmoothNormals", value); }
        /// <summary>
        /// Consider connected facets as overlapping when the dihedral angle between the facets is smaller than the user’s defined tolerance
        /// </summary>
        public double AngleToleranceFacetOverlap { get => GetNumber("Mesh.AngleToleranceFacetOverlap"); set => SetNumber("Mesh.AngleToleranceFacetOverlap", value); }
        #endregion
        /// <summary>
        /// 2D mesh algorithm (MeshAdapt, Automatic, Delaunay, Frontal-Delaunay, BAMG, Frontal-Delaunay for Quads, Packing of Parallelograms)
        /// </summary>
        public Algorithm2d MeshAlgorithm2d { get => (Algorithm2d)GetNumber("Mesh.Algorithm"); set => SetNumber("Mesh.Algorithm", (double)value); }
        /// <summary>
        /// 3D mesh algorithm (Delaunay, Frontal, MMG3D, R-tree, HXT)
        /// </summary>
        public Algorithm3d MeshAlgorithm3d { get => (Algorithm3d)GetNumber("Mesh.Algorithm3D"); set => SetNumber("Mesh.Algorithm3D", (double)value); }

        /// <summary>
        /// Mesh subdivision algorithm (0: none, 1: all quadrangles, 2: all hexahedra)
        /// </summary>
        public SubdivisionAlgorithm SubdivisionAlgorithm { get => (SubdivisionAlgorithm)GetNumber("Mesh.SubdivisionAlgorithm"); set => SetNumber("Mesh.SubdivisionAlgorithm", (double)value); }
    }

    /// <summary>
    /// Mesh output format (1: msh, 2: unv, 10: auto, 16: vtk, 19: vrml, 21: mail, 26: pos stat, 27: stl, 
    ///28: p3d, 30: mesh, 31: bdf, 32: cgns, 33: med, 34: diff, 38: ir3, 39: inp, 40: ply2, 41: celum, 42: su2, 47: tochnog, 49: neu, 50: matlab)
    /// </summary>
    public enum MeshFormat
    {
        msh = 1,
        unv = 2,
        auto = 10,
        vtk = 16,
        vrml = 19,
        mail = 21,
        pos_stat = 26,
        stl = 27,
        p3d = 28,
        mesh = 30,
        bdf = 31,
        cgns = 32,
        med = 33,
        diff = 34,
        ir3 = 38,
        inp = 39,
        ply2 = 40,
        celum = 41,
        su2 = 42,
        tochnog = 47,
        neu = 49,
        matlab = 50
    }
    /// <summary>
    /// Default value: none
    /// </summary>
    public enum SubdivisionAlgorithm
    {
        none = 0,
        all_quadrangles = 1,
        all_hexahedra = 2
    }
    /// <summary>
    /// Default value: Automatic
    /// </summary>
    public enum Algorithm2d
    {
        MeshAdapt = 1,
        Automatic = 2,
        Delaunay = 5,
        Frontal_Delaunay = 6,
        BAMG = 7,
        Frontal_Delaunay_Quads = 8,
        Packing_of_Parallelograms = 9,
    }
    /// <summary>
    /// Default value: Delaunay
    /// </summary>
    public enum Algorithm3d
    {
        Delaunay = 1,
        Frontal = 4,
        MMG3D = 7,
        R_tree = 9,
        HXT = 10,
    }
}
