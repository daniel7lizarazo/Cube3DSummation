using CubeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeApplication
{
    public class CubeOperations<Tcoordinate, Tshape>:IOperations<Tcoordinate, Tshape>
        where Tcoordinate : CubeCoordinates
        where Tshape : TheCube<CubeCoordinates>
    {

        public void UpdateACoordinateValue(Tshape shape, Tcoordinate coordinate)
        {
            if (GreaterThanCeroLowerThanSize(shape.Size, coordinate))
                {
                //T foundCoordinate = Shape.Coordinates.FirstOrDefault(c=> c.X == newValueCoordinate.X && c.Y == newValueCoordinate.Y && c.Z == newValueCoordinate.Z);
                //Shape.Coordinates.FirstOrDefault(c => c.X == newValueCoordinate.X && c.Y == newValueCoordinate.Y && c.Z == newValueCoordinate.Z).W = newValueCoordinate.W;
                //foundCoordinate.W = newValueCoordinate.W;

                int index = 0;

                foreach(CubeCoordinates shapeCoordinate in shape.Coordinates)
                {
                    if (shapeCoordinate.X != coordinate.X) continue;
                    if (shapeCoordinate.Y != coordinate.Y) continue;
                    if (shapeCoordinate.Z != coordinate.Z) continue;
                    index = shape.Coordinates.IndexOf(shapeCoordinate);
                }

                shape.Coordinates[index].W = coordinate.W;

                }
        }

        public int QueryTheShape(Tshape shape, Tcoordinate coordinate1, Tcoordinate coordinate2)
        {
            int sum = 0;

            if (GreaterThanCeroLowerThanSize(shape.Size,coordinate1) && GreaterThanCeroLowerThanSize(shape.Size,coordinate2))
            {
                int[] xCoordinates = OrganizeDescending(coordinate1.X, coordinate2.X);
                int[] yCoordinates = OrganizeDescending(coordinate1.Y, coordinate2.Y);
                int[] zCoordinates = OrganizeDescending(coordinate1.Z, coordinate2.Z);

                sum = shape.Coordinates.Where(c => c.X <= xCoordinates[0] && c.X >= xCoordinates[1] && c.Y <= yCoordinates[0] && c.Y >= yCoordinates[1] && c.Z <= zCoordinates[0] && c.Z >= zCoordinates[1]).Sum(c => c.W);
/*                foreach (var item in Shape.Coordinates)
                {
                    if (item.Key[0] > xCoordinates[0] || item.Key[0] < xCoordinates[1]) continue;
                    if (item.Key[1] > yCoordinates[0] || item.Key[1] < yCoordinates[1]) continue;
                    if (item.Key[2] > zCoordinates[0] || item.Key[2] < zCoordinates[1]) continue;
                    sum += item.Value;
                }*/
            }


           return sum;
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
