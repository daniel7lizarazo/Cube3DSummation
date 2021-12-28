using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeDomain
{
public class TheCube<T, TId>:ITheShapes<T, TId>
        where T : CubeCoordinates<TId>, new()
        where TId : IComparable, IComparable<TId>
    {
        public TId Id { get; set; }
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
                                    select new T { X = x, Y = y, Z = z, W = 0, Id = Id};
            return coordinates.ToList();

        }

    }
}
