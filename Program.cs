using CubeApplication;
using CubeDomain;
using CubeInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cube3D
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Container startCube = Container.Instance();
            startCube.Register<IOperations<CubeCoordinates, TheCube<CubeCoordinates>>, CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>>>();
            var theOperator = startCube.Create<IOperations<CubeCoordinates, TheCube<CubeCoordinates>>>();

            int size = 3;
            TheCube<CubeCoordinates> myCube = new(size);

            CubeCoordinates testCoordinates = new CubeCoordinates(1,2,3,12);

            theOperator.UpdateACoordinateValue(myCube, testCoordinates);

            int updatedValue = myCube.Coordinates.FirstOrDefault(c=> c.X == testCoordinates.X && c.Y == testCoordinates.Y && c.Z == testCoordinates.Z).W;

            Console.WriteLine($"The expected value is {testCoordinates.W} and the actual value is {updatedValue}");


        }
    }
}
