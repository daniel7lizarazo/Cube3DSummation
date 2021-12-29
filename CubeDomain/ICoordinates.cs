using System;

namespace CubeDomain
{
    public interface ICoordinates<TId>: IEntity<TId>
        where TId : IComparable, IComparable<TId>
    {
        public int X { get; set; }
        public int W { get; set; }
        public ITheShapes<ICoordinates<TId>, TId> Shape { get; set; }
        public TId ShapeId { get; set; }
        
    }
}
