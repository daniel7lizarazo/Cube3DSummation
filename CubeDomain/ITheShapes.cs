using System;
using System.Collections.Generic;

namespace CubeDomain
{
    public interface ITheShapes<T>
    {
        string Id { get; set; }
        int Size { get; set; }
        IEnumerable<T> Coordinates { get; set; }
        IEnumerable<T> CreateTheCoordinates(int size);

    }
}
