using System;
using System.Collections.Generic;

namespace CubeDomain
{
    public interface ITheShapes<T, TId>: IEntity<TId>
        where T : ICoordinates<TId>
        where TId : IComparable, IComparable<TId>
    {
        int Size { get; set; }
        IList<T> Coordinates { get; set; }
        IList<T> CreateTheCoordinates(int size);

    }
}
