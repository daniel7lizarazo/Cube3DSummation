using CubeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeApplication
{
    public class CubeCrudOperation<Tcoordinate, Tshape, TId> : IOperations<Tcoordinate, Tshape>
        where Tcoordinate : CubeCoordinates<TId>, new()
        where Tshape : TheCube<CubeCoordinates<TId>, TId>, new()
        where TId : IComparable, IComparable<TId>

    {
        private readonly IRepository<Tcoordinate, TId> _repositoryCoordinates;
        private readonly IRepository<Tshape, TId> _repositoryShapes;

        public CubeCrudOperation(IRepository<Tcoordinate, TId> repositoryCoordinates, IRepository<Tshape, TId> repositoryShapes)
        {
            _repositoryCoordinates = repositoryCoordinates;
            _repositoryShapes = repositoryShapes;
        }

        public int QueryTheShape(Tshape shape, Tcoordinate coordinate1, Tcoordinate coordinate2)
        {
            int sum = 0;
            if (GreaterThanCeroLowerThanSize(shape.Size, coordinate1) && GreaterThanCeroLowerThanSize(shape.Size, coordinate2))
            {
                int[] xCoordinates = OrganizeDescending(coordinate1.X, coordinate2.X);
                int[] yCoordinates = OrganizeDescending(coordinate1.Y, coordinate2.Y);
                int[] zCoordinates = OrganizeDescending(coordinate1.Z, coordinate2.Z);

                sum = _repositoryCoordinates.GetByExpression(c => c.X <= xCoordinates[0] && c.X >= xCoordinates[1] && c.Y <= yCoordinates[0] && c.Y >= yCoordinates[1] && c.Z <= zCoordinates[0] && c.Z >= zCoordinates[1]).Select(c=> c.W).Sum();    

                return sum;
            }
            throw new Exception("The coordinate values are outside of the valid range");
        }

        public void UpdateACoordinateValue(Tshape shape, Tcoordinate coordinate)
        {
            if (GreaterThanCeroLowerThanSize(shape.Size, coordinate))
            {
                _repositoryCoordinates.Update(coordinate);
            }
            throw new Exception("The coordinate values are outside of the valid range");
            
        }

        public void CreateTheShape(Tshape shape)
        {
             IEnumerable<Tcoordinate> coordinates = from x in Enumerable.Range(1, shape.Size)
                                          from y in Enumerable.Range(1, shape.Size)
                                          from z in Enumerable.Range(1, shape.Size)
                                          select new Tcoordinate { X = x, Y = y, Z = z, W = 0, ShapeId = shape.Id};

            _repositoryShapes.InsertOne(shape);
            _repositoryCoordinates.InsertGroup(coordinates);

        }

        private bool GreaterThanCeroLowerThanSize(int size, Tcoordinate coordinate)
        {
            if (coordinate == null) throw new Exception($"Please enter a coordinate within valid values 0,{size}");
            if (coordinate.X < 0 || coordinate.X > size) throw new Exception($"Please enter a coordinate within valid values 0,{size}");
            if (coordinate.Y < 0 || coordinate.Y > size) throw new Exception($"Please enter a coordinate within valid values 0,{size}");
            if (coordinate.Z < 0 || coordinate.Z > size) throw new Exception($"Please enter a coordinate within valid values 0,{size}");
            return true;
        }
        private static int[] OrganizeDescending(int n1, int n2)
        {
            if (n1 >= n2) return new int[] { n1, n2 };
            return new int[] { n2, n1 };
        }
    }
}
