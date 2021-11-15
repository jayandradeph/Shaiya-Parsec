﻿using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.OBJ3DC;

namespace Parsec.Shaiya.Common
{
    /// <summary>
    /// Class that represents a Polygon used in 3DC files to form the mesh. It's composed by 3 vertices only, so polygons can only be triangles.
    /// </summary>
    public class Polygon : IBinary
    {
        /// <summary>
        /// The index of the first vertex
        /// </summary>
        public ushort VertexIndex1 { get; set; }

        /// <summary>
        /// The <see cref="Vertex3DC"/> instance of the first vertex
        /// </summary>
        public Vertex3DC Vertex1 { get; set; }

        /// <summary>
        /// The index of the second vertex
        /// </summary>
        public ushort VertexIndex2 { get; set; }

        /// <summary>
        /// The <see cref="Vertex3DC"/> instance of the second vertex
        /// </summary>
        public Vertex3DC Vertex2 { get; set; }

        /// <summary>
        /// The index of the third vertex
        /// </summary>
        public ushort VertexIndex3 { get; set; }

        /// <summary>
        /// The <see cref="Vertex3DC"/> instance of the third vertex
        /// </summary>
        public Vertex3DC Vertex3 { get; set; }

        public Polygon(ShaiyaBinaryReader binaryReader)
        {
            VertexIndex1 = binaryReader.Read<ushort>();
            VertexIndex2 = binaryReader.Read<ushort>();
            VertexIndex3 = binaryReader.Read<ushort>();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(VertexIndex1));
            buffer.AddRange(BitConverter.GetBytes(VertexIndex2));
            buffer.AddRange(BitConverter.GetBytes(VertexIndex3));
            return buffer.ToArray();
        }
    }
}