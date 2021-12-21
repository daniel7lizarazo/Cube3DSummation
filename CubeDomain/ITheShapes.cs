using System;
using System.Collections.Generic;

namespace CubeDomain
{
    public interface ITheShapes<T>
    {
        string Id { get; set; }
        int Size { get; set; }
        IList<T> Coordinates { get; set; }
        IList<T> CreateTheCoordinates(int size);

    }
}
