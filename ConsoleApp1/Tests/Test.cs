using BuildingLibrary.DomainObject;
using BuildingLibrary.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingLibrary.Tests
{
    internal class UnitTest
    {
        /// <summary>
        /// Triangular room volume calculation test
        /// </summary>
        public void TestTriangularRoom()
        {
            new TriangularRoom(-5, 0.7).CalculateVolume().ShouldBe(41.66666624999999);
            new TriangularRoom(5, 5).CalculateVolume().ShouldBe(41.66666624999999);
        }

        /// <summary>
        /// Cubical room volume calculation test
        /// </summary>
        public void TestCubicalRoom()
        {
            new CubicalRoom(6, 3, 99).CalculateVolume().ShouldBe(1782);
        }

        /// <summary>
        /// Greenhouse room volume calculation test
        /// </summary>
        public void TestGreenhouseRoom()
        {
            new GreenhouseRoom(1, 2, 3).CalculateVolume().ShouldBe(10.712388975d);
        }

        /// <summary>
        /// Test the full building calculation for multiple buildings with various rooms
        /// </summary>
        public void TestBuildingsVolume()
        {
            // build out the list of buildings
            var buildings = new List<Building>()
            {
                new Building(new List<IRoom>
                {
                    new CubicalRoom(1,2,3),
                    new TriangularRoom(7,6),
                    new GreenhouseRoom(8,8,8),
                    new GreenhouseRoom(8,8,8),
                }),
                new Building(new List<IRoom>
                {
                    new CubicalRoom(1,2,3),
                    new CubicalRoom(1,2,3),
                    new CubicalRoom(1,2,3),
                    new TriangularRoom(7,6),
                    new TriangularRoom(7,6),
                    new GreenhouseRoom(7,6.38,12.12),
                    new GreenhouseRoom(8,8,8),
                }),
                new Building(new List<IRoom>
                {
                    new GreenhouseRoom(8,8,8),
                }),
            };

            new BuildingService().CalculateTotalVolume(buildings).ShouldBe(3905.26003091193d);

        }


    }
}
