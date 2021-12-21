using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeDomain
{
public class TheCube<T>:ITheShapes<T>
        where T : CubeCoordinates, new()
    {
        public string Id { get; set; }
        public int Size { get; set; }
        public IList<T> Coordinates { get; set;}

        public TheCube() { }
        public TheCube(int size)
        {
            Size = size;
            Coordinates = CreateTheCoordinates(Size);
        }

    public IList<T> CreateTheCoordinates(int size)
        {
            IEnumerable<T> coordinates = from x in Enumerable.Range(1, size)
                                    from y in Enumerable.Range(1, size)
                                    from z in Enumerable.Range(1, size)
                                    select new T { X = x, Y = y, Z = z, W = 0, ShapeId = Id};
            return coordinates.ToList();

        }

    }
}
