using System;
using System.Collections.Generic;
using OOCamp.Park;
using Xunit;

namespace OOCamp_Test
{
    public class ParkingDirectorTest
    {
        [Fact]
        public void when_manager_have_one_full_parking()
        {
            ParkingManager manager = new ParkingManager(new List<Park> { new Park(1) }, null);
            manager.StopCar(new Car("JP123"));

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(string.Format("{0}P 0 1", Utils.SpaceTwo), array[1]);
            Assert.Equal("M 0 1", array[0]);
        }


        [Fact]
        public void when_manager_have_one_empty_parking()
        {
            ParkingManager manager = new ParkingManager(new List<Park> { new Park(1) }, null);

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(string.Format("{0}P 1 1", Utils.SpaceTwo), array[1]);
            Assert.Equal("M 1 1", array[0]);
        }

        [Fact]
        public void when_manager_have_two_empty_parking()
        {
            ParkingManager manager = new ParkingManager(new List<Park> { new Park(1), new Park(1) }, null);

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var spaceTwo = Utils.SpaceTwo;
            Assert.Equal(string.Format("{0}P 1 1", spaceTwo), array[1]);
            Assert.Equal(string.Format("{0}P 1 1", spaceTwo), array[2]);
            Assert.Equal("M 2 2", array[0]);
        }

        [Fact]
        public void when_manager_have_one_boy_with_one_empty_parking()
        {
            var parkingBoy = new ParkingBoy(new Park(1));
            ParkingManager manager = new ParkingManager(null, new List<ParkingBoyBase> { parkingBoy });

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(string.Format("{0}B 1 1", Utils.SpaceTwo), array[1]);
            Assert.Equal(string.Format("{0}P 1 1", Utils.SpaceFour), array[2]);
            Assert.Equal("M 1 1", array[0]);
        }

        [Fact]
        public void when_manager_have_one_boy_with_no_parking()
        {
            var parkingBoy = new ParkingBoy();
            ParkingManager manager = new ParkingManager(null, new List<ParkingBoyBase> { parkingBoy });

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(string.Format("{0}B 0 0", Utils.SpaceTwo), array[1]);
            Assert.Equal("M 0 0", array[0]);
        }

        [Fact]
        public void when_manager_have_one_boy_with_first_boy_have_full_parking_and_second_boy_have_one_empty()
        {
            var parkingBoy = new ParkingBoy(new Park(1));
            parkingBoy.StopCar(new Car("JP123"));
            var smartBoy = new SmartParkingBoy(new Park(1));
            ParkingManager manager = new ParkingManager(null, new List<ParkingBoyBase> { parkingBoy, smartBoy });

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var spaceTwo = Utils.SpaceTwo;
            Assert.Equal(string.Format("{0}B 0 1", spaceTwo), array[1]);
            var spaceFour = Utils.SpaceFour;
            Assert.Equal(string.Format("{0}P 0 1", spaceFour), array[2]);
            Assert.Equal(string.Format("{0}B 1 1", spaceTwo), array[3]);
            Assert.Equal(string.Format("{0}P 1 1", spaceFour), array[4]);
            Assert.Equal("M 1 2", array[0]);
        }

        [Fact]
        public void when_manager_with_one_parking_and_one_boy_with_one_full_parking()
        {
            var parkingBoy = new ParkingBoy(new Park(1));
            parkingBoy.StopCar(new Car("JP123"));
            ParkingManager manager = new ParkingManager(new List<Park>{new Park(1)}, new List<ParkingBoyBase> { parkingBoy });

            ParkingDirector director = new ParkingDirector(manager);

            string report = director.GenerateReport();
            string[] array = report.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var spaceTwo = Utils.SpaceTwo;
            Assert.Equal(string.Format("{0}P 1 1", spaceTwo), array[1]);
            Assert.Equal(string.Format("{0}B 0 1", spaceTwo), array[2]);
            Assert.Equal(string.Format("{0}P 0 1", Utils.SpaceFour), array[3]);
            Assert.Equal("M 1 2", array[0]);
        }
    }
}