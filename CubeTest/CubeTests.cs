using CubeApplication;
using CubeDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeTest
{
    [TestClass]
    public class CubeTests
    {

        [TestMethod]
        public void TestTheCubeSize()
        {
            int size = 6;
            TheCube<CubeCoordinates> myCube = new(size);
            Assert.AreEqual(6, myCube.Size);
        }

        [TestMethod]
        public void TestTheCubeCoordinatesListLength()
        {
            var rand = new Random();
            int size = rand.Next(1, 20);
            TheCube<CubeCoordinates> myCube = new(size);
            double expectedLength = Math.Pow(size, 3);
            Assert.AreEqual(expectedLength, myCube.Coordinates.Count());

        }

        [TestMethod]
        public void TestTheCubeDictionaryValuesCero()
        {
            var rand = new Random();
            int size = rand.Next(1, 20);
            TheCube<CubeCoordinates> myCube = new(size);
            bool validator = true;
            foreach (var coordinate in myCube.Coordinates)
            {
                if (coordinate.W != 0)
                {
                    validator = false;
                    break;
                }
            }
            Assert.IsTrue(validator);
        }

        [TestMethod]
        public void TheCubeUpdateCheckValue()
        {
            int size = 3;
            TheCube<CubeCoordinates> myCube = new(size);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new ();

            CubeCoordinates testCoordinates = new CubeCoordinates(1,2,3,5);

            theOperator.UpdateACoordinateValue(myCube, testCoordinates);

            int updatedValue = myCube.Coordinates.Where(c => c.X == testCoordinates.X && c.Y == testCoordinates.Y && c.Z == testCoordinates.Z).Select(c => c.W).FirstOrDefault();
            //int updatedValue = myCube.Coordinates.Where(c => c.X == 1 && c.Y == 2 && c.Z == 3).Select(c => c.W).FirstOrDefault();

            Assert.AreEqual(5, updatedValue);

        }

        [TestMethod]
        public void TheCubeQueryNoUpdate()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(4, 4, 4, 0);

            int queryResult = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(0, queryResult);
        }

        [TestMethod]
        public void TheCubeQueryWithUpdateCheckingIntoUpdateRange()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate = new(2, 2, 2, 5);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(4, 4, 4, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int queryResult = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(5, queryResult);
        }

        [TestMethod]
        public void TheCubeQueryWithUpdateCheckingIntoUpdateRangeDisorganizedCoordinates()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();
            CubeCoordinates updateCoordinate = new(2, 2, 2, 5);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(4, 4, 4, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int queryResult = theOperator.QueryTheShape(myCube, finalQueryCoordinate, initialQueryCoordinate);

            Assert.AreEqual(5, queryResult);
        }

        [TestMethod]
        public void TheCubeQueryWithUpdateCheckingOutsideUpdateRange()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();
            CubeCoordinates updateCoordinate = new(3, 3, 3, 5);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(2, 2, 2, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int queryResult = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(0, queryResult);
        }

        [TestMethod]
        public void TheCubeQueryWithUpdateCheckingOutsideUpdateRangeDisorganizedCoordinates()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();
            CubeCoordinates updateCoordinate = new(3, 3, 3, 5);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(2, 2, 2, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int queryResult = theOperator.QueryTheShape(myCube, finalQueryCoordinate, initialQueryCoordinate);

            Assert.AreEqual(0, queryResult);

        }

        [TestMethod]
        public void ProposedExcerciseHackerRankTillQuery1()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate = new(2, 2, 2, 4);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(3, 3, 3, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int res = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void ProposedExcerciseHackerRankTillQuery2()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate1 = new(2, 2, 2, 4);
            CubeCoordinates updateCoordinate2 = new(1, 1, 1, 23);
            CubeCoordinates initialQueryCoordinate = new(2, 2, 2, 0);
            CubeCoordinates finalQueryCoordinate = new(4, 4, 4, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate1);
            theOperator.UpdateACoordinateValue(myCube, updateCoordinate2);
            int res = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void ProposedExcerciseHackerRankTillQuery3()
        {
            TheCube<CubeCoordinates> myCube = new(4);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate1 = new(2, 2, 2, 4);
            CubeCoordinates updateCoordinate2 = new(1, 1, 1, 23);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(3, 3, 3, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate1);
            theOperator.UpdateACoordinateValue(myCube, updateCoordinate2);
            int res = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(27, res);
        }

        [TestMethod]
        public void ProposedExcerciseHackerRankTillQuery4()
        {
            TheCube<CubeCoordinates> myCube = new(2);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate = new(2, 2, 2, 1);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int res = theOperator.QueryTheShape(myCube, initialQueryCoordinate, initialQueryCoordinate);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void ProposedExcerciseHackerRankTillQuery5()
        {
            TheCube<CubeCoordinates> myCube = new(2);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate = new(2, 2, 2, 1);
            CubeCoordinates initialQueryCoordinate = new(1, 1, 1, 0);
            CubeCoordinates finalQueryCoordinate = new(2, 2, 2, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int res = theOperator.QueryTheShape(myCube, initialQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(1, res);
        }


        [TestMethod]
        public void ProposedExcerciseHackerRankTillQuery6()
        {
            TheCube<CubeCoordinates> myCube = new(2);
            CubeOperations<CubeCoordinates, TheCube<CubeCoordinates>> theOperator = new();

            CubeCoordinates updateCoordinate = new(2, 2, 2, 1);
            CubeCoordinates finalQueryCoordinate = new(2, 2, 2, 0);

            theOperator.UpdateACoordinateValue(myCube, updateCoordinate);
            int res = theOperator.QueryTheShape(myCube, finalQueryCoordinate, finalQueryCoordinate);

            Assert.AreEqual(1, res);
        }




    }
}
