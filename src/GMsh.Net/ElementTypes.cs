namespace GMshNet
{
    public enum ElementTypes
    {
        /// <summary>
        /// 2 node
        /// </summary>
        line = 1,
        /// <summary>
        /// 3-node
        /// </summary>
        triangle = 2,
        /// <summary>
        /// 4-node
        /// </summary>
        quadrangle = 3,
        /// <summary>
        /// 4-node
        /// </summary>
        tetrahedron = 4,
        /// <summary>
        /// 8-node
        /// </summary>
        hexahedron = 5,
        /// <summary>
        /// 6-node
        /// </summary>
        prism = 6,
        /// <summary>
        /// 5-node
        /// </summary>
        pyramid = 7,
        /// <summary>
        /// 3-node (2 nodes associated with the vertices and 1 with the edge)
        /// </summary>
        second_order_line = 8,
        /// <summary>
        /// 6-node (3 nodes associated with the vertices and 3 with the edges)
        /// </summary>
        second_order_triangle = 9,
        /// <summary>
        /// 9-node (4 nodes associated with the vertices, 4 with the edges and 1 with the face)
        /// </summary>
        second_order_quadrangle = 10,
        /// <summary>
        /// 10-node (4 nodes associated with the vertices and 6 with the edges).
        /// </summary>
        second_order_tetrahedron = 11,
        /// <summary>
        /// 27-node (8 nodes associated with the vertices, 12 with the edges, 6 with the faces and 1 with the volume).
        /// </summary>
        second_order_hexahedron = 12,
        /// <summary>
        /// 18-node (6 nodes associated with the vertices, 9 with the edges and 3 with the quadrangular faces).
        /// </summary>
        second_order_prism = 13,
        /// <summary>
        /// 14-node (5 nodes associated with the vertices, 8 with the edges and 1 with the quadrangular face).
        /// </summary>
        second_order_pyramid = 13,
        /// <summary>
        /// 1-node
        /// </summary>
        point = 15,
        /// <summary>
        /// 8-node (4 nodes associated with the vertices and 4 with the edges).
        /// </summary>
        second_order_quadrangle_2 = 16,
        /// <summary>
        /// 20-node (8 nodes associated with the vertices and 12 with the edges).
        /// </summary>
        second_order_hexahedron_2 = 17,
        /// <summary>
        /// 15-node (6 nodes associated with the vertices and 9 with the edges).
        /// </summary>
        second_order_prism_2 = 18,
        /// <summary>
        /// 13-node (5 nodes associated with the vertices and 8 with the edges).
        /// </summary>
        second_order_pyramid_2 = 19,
        /// <summary>
        /// 9-node (3 nodes associated with the vertices, 6 with the edges).
        /// </summary>
        third_order_incomplete_triangle = 20,
        /// <summary>
        /// 10-node (3 nodes associated with the vertices, 6 with the edges, 1 with the face)
        /// </summary>
        third_order_triangle = 21,
        /// <summary>
        /// 12-node (3 nodes associated with the vertices, 9 with the edges)
        /// </summary>
        fourth_order_incomplete_triangle = 22,
        /// <summary>
        /// 15-node (3 nodes associated with the vertices, 9 with the edges, 3 with the face)
        /// </summary>
        fourth_order_triangle = 23,
        /// <summary>
        /// 15-node (3 nodes associated with the vertices, 12 with the edges)
        /// </summary>
        fifth_order_incomplete_triangle = 24,
        /// <summary>
        /// 21-node (3 nodes associated with the vertices, 12 with the edges, 6 with the face)
        /// </summary>
        fifth_order_triangle = 25,
        /// <summary>
        /// 4-node (2 nodes associated with the vertices, 2 internal to the edge)
        /// </summary>
        third_order_edge = 26,
        /// <summary>
        /// 5-node (2 nodes associated with the vertices, 3 internal to the edge)
        /// </summary>
        fourth_order_edge = 27,
        /// <summary>
        /// 6-node (2 nodes associated with the vertices, 4 internal to the edge)
        /// </summary>
        fifth_order_edge = 28,
        /// <summary>
        /// 20-node (4 nodes associated with the vertices, 12 with the edges, 4 with the faces)
        /// </summary>
        third_order_tetrahedron = 29,
        /// <summary>
        /// 35-node (4 nodes associated with the vertices, 18 with the edges, 12 with the faces, 1 in the volume)
        /// </summary>
        fourth_order_tetrahedron = 30,
        /// <summary>
        /// 56-node (4 nodes associated with the vertices, 24 with the edges, 24 with the faces, 4 in the volume)
        /// </summary>
        fifth_order_tetrahedron = 31,
        /// <summary>
        /// 64-node (8 nodes associated with the vertices, 24 with the edges, 24 with the faces, 8 in the volume)
        /// </summary>
        third_order_hexahedron = 92,
        /// <summary>
        /// 125-node (8 nodes associated with the vertices, 36 with the edges, 54 with the faces, 27 in the volume)
        /// </summary>
        fourth_order_hexahedron = 92,
    }
}