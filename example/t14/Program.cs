using GmshNet;
using System.Linq;

namespace t14
{
    using geo = Gmsh.Model.Geo;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);
            Gmsh.Model.Add("t14");

            double ms = 0.5; // mesh characteristic length
            double h = 2;

            geo.AddPoint(0, 0, 0, ms, 1);
            geo.AddPoint(10, 0, 0, ms, 2);
            geo.AddPoint(10, 10, 0, ms, 3);
            geo.AddPoint(0, 10, 0, ms, 4);

            geo.AddPoint(4, 4, 0, ms, 5);
            geo.AddPoint(6, 4, 0, ms, 6);
            geo.AddPoint(6, 6, 0, ms, 7);
            geo.AddPoint(4, 6, 0, ms, 8);

            geo.AddPoint(2, 0, 0, ms, 9);
            geo.AddPoint(8, 0, 0, ms, 10);
            geo.AddPoint(2, 10, 0, ms, 11);
            geo.AddPoint(8, 10, 0, ms, 12);

            geo.AddLine(1, 9, 1);
            geo.AddLine(9, 10, 2);
            geo.AddLine(10, 2, 3);

            geo.AddLine(2, 3, 4);
            geo.AddLine(3, 12, 5);
            geo.AddLine(12, 11, 6);

            geo.AddLine(11, 4, 7);
            geo.AddLine(4, 1, 8);
            geo.AddLine(5, 6, 9);

            geo.AddLine(6, 7, 10);
            geo.AddLine(7, 8, 11);
            geo.AddLine(8, 5, 12);

            geo.AddCurveLoop(new[] { 6, 7, 8, 1, 2, 3, 4, 5 }, 13);
            geo.AddCurveLoop(new[] { 11, 12, 9, 10 }, 14);
            geo.AddPlaneSurface(new[] { 13, 14 }, 15);

            geo.Extrude(new[] { (2, 15) }, 0, 0, h, out (int, int)[] e);

            int domain_tag = e[1].Item2;
            int domain_physical_tag = 1001;
            Gmsh.Model.AddPhysicalGroup(3, new[] { domain_tag }, domain_physical_tag);
            Gmsh.Model.SetPhysicalName(3, domain_physical_tag, "Whole domain");

            int[] terminal_tags = new[] { e[3].Item2, e[5].Item2, e[7].Item2, e[9].Item2 };
            int terminals_physical_tag = 2001;
            Gmsh.Model.AddPhysicalGroup(2, terminal_tags, terminals_physical_tag);
            Gmsh.Model.SetPhysicalName(2, terminals_physical_tag, "Terminals");

            var boundary_dimtags = Gmsh.Model.GetBoundary(new[] { (3, domain_tag) }, false, false);

            var complement_tags = boundary_dimtags.Select(b => b.Item2);
            var boundary_tags = boundary_dimtags.Select(b => b.Item2);

            complement_tags = complement_tags.Distinct();

            int boundary_physical_tag = 2002;
            Gmsh.Model.AddPhysicalGroup(2, boundary_tags.ToArray(), boundary_physical_tag);
            Gmsh.Model.SetPhysicalName(2, boundary_physical_tag, "Boundary");

            // Complement of the domain surface with respect to the four terminals
            int complement_physical_tag = 2003;
            Gmsh.Model.AddPhysicalGroup(2, complement_tags.ToArray(), complement_physical_tag);
            Gmsh.Model.SetPhysicalName(2, complement_physical_tag, "Complement");

            geo.Synchronize();

            Gmsh.Model.Mesh.ComputeHomology(new[] { domain_physical_tag }, new[] { terminals_physical_tag }, new[] { 0, 1, 2, 3 });

            Gmsh.Model.Mesh.ComputeHomology(new[] { domain_physical_tag }, new[] { complement_physical_tag }, new[] { 0, 1, 2, 3 });

            Gmsh.Model.Mesh.ComputeCohomology(new[] { domain_physical_tag }, new[] { terminals_physical_tag }, new[] { 0, 1, 2, 3 });

            Gmsh.Model.Mesh.Generate(3);
            Gmsh.Write("t14.msh");
            Gmsh.Finalize();
        }
    }
}