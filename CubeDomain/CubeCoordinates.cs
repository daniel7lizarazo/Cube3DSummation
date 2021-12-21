using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeDomain
{
    public class CubeCoordinates : ICoordinates
    {
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int W { get; set; }
        public ITheShapes<ICoordinates> Shape { get; set; }
        public string ShapeId { get; set; }

        public CubeCoordinates() { }
        public CubeCoordinates(int x, int y, int z, int w) 
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

    }
}
