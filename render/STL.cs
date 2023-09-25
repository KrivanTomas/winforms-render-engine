using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace render
{
    class STL
    {
        public byte[] header;
        public Int32 trisCount;
        public Tris[] tris;
        
        public STL(Stream fileStream)
        {
            using(BinaryReader br = new BinaryReader(fileStream))
            {
                header = br.ReadBytes(80);
                trisCount = br.ReadInt32();
                tris = new Tris[trisCount];
                for(int tris = 0; tris < trisCount; tris++)
                {
                    Vector3 normal = new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                    Vector3[] vertex = new Vector3[] {
                        new Vector3(br.ReadInt32(),br.ReadInt32(),br.ReadInt32()),
                        new Vector3(br.ReadInt32(),br.ReadInt32(),br.ReadInt32()),
                        new Vector3(br.ReadInt32(),br.ReadInt32(),br.ReadInt32())
                    };
                    br.ReadInt16();
                    this.tris[tris] = new Tris(normal, vertex);
                }
            }
        }
    }

    struct Tris
    {
        public Vector3 normal;
        public Vector3[] vertex;

        public Tris(Vector3 normal, Vector3[] vertex)
        {
            this.normal = normal;
            this.vertex = vertex;
        }
        public override string ToString()
        {
            return String.Format("Normal: {0}\r\nVert1: {1}\r\nVert2: {2}\r\nVert3: {3}",
                normal.ToString(), vertex[0].ToString(), vertex[1].ToString(), vertex[2].ToString());
        }
    }
}
