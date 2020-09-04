using GmshNet;
using System;

namespace x1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Usage: {args[0]} file");
                return;
            }

            Gmsh.Initialize();
            Gmsh.Option.SetNumber("General.Terminal", 1);

            //in the MSH format: `t1.exe file.msh'
            Gmsh.Open(args[0]);

            var name = Gmsh.Model.GetCurrent();
            Console.WriteLine($"Model {name} ({Gmsh.Model.GetDimension()}D)");
            var entities = Gmsh.Model.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                int dim = entities[i].Item1, tag = entities[i].Item2;
                Gmsh.Model.Mesh.GetNodes(out var nodeTags, out var nodeCoords, out var nodeParams, dim, tag);
                Gmsh.Model.Mesh.GetElements(out var elemTypes, out var elemTags, out var elemNodeTags, dim, tag);

                var type = Gmsh.Model.GetType(dim, tag);
                name = Gmsh.Model.GetEntitiesName(dim, tag);
                Console.WriteLine($"Entity {name} ({dim},{tag}) of type {type}");

                var boundary = Gmsh.Model.GetBoundary(new[] { (dim, tag) });
                if (boundary.Length > 0)
                {
                    Console.WriteLine(" - Boundary entities: ");
                    foreach (var item in boundary)
                    {
                        Console.Write($"({item.Item1},{item.Item2})");
                    }
                    Console.WriteLine();
                }
                var physicalTags = Gmsh.Model.GetPhysicalGroupsForEntity(dim, tag);
                if (physicalTags.Length > 0)
                {
                    Console.WriteLine(" - Physical group: ");
                    foreach (var item in physicalTags)
                    {
                        var n = Gmsh.Model.GetPhysicalName(dim, item);
                        Console.Write($"{n}({dim},{item})");
                    }
                    Console.WriteLine();
                }

                var partitions = Gmsh.Model.GetPartitions(dim, tag);
                if (partitions.Length > 0)
                {
                    Console.WriteLine(" - Partition tags: ");
                    foreach (var item in partitions)
                    {
                        Console.Write($" {item}");
                    }
                    Gmsh.Model.GetParent(dim, tag, out var parentDim, out var parentTag);
                    Console.WriteLine($" - parent entity ({parentDim},{parentTag})");
                }

                foreach (var elemType in elemTypes)
                {
                    Gmsh.Model.Mesh.GetElementProperties(elemType, out name, out var d, out var order,
                                         out var numv, out var param, out var numpv);
                    Console.WriteLine($" - Element type: {name}, order {order}");
                    Console.Write($"  with {numv} nodes in param coord: (");
                    foreach (var item in param)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
            }
            Gmsh.Clear();
            Gmsh.Finalize();
        }
    }
}