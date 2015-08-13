﻿using OOCamp;
using OOCamp.Park;
using Xunit;

namespace OOCamp_Test
{
    public class ParkingManagerTest
    {
        [Fact]
        public void should_success_to_stop_car()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingManager manager = new ParkingManager(park);

            manager.StopCar(car);

            Assert.Same(car, park.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_success_to_pick_car()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingManager manager = new ParkingManager(park);

            manager.StopCar(car);

            Assert.Same(car, manager.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_success_to_ask_parkingboy_to_stop_car_when_one_boy()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy parkingBoy = new ParkingBoy(park);
            ParkingManager manager = new ParkingManager(parkingBoy);

            manager.AskBoyStopCar(car);

            Assert.Same(car, park.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_success_to_ask_parkingboy_to_pick_car_when_one_boy()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy parkingBoy = new ParkingBoy(park);
            ParkingManager manager = new ParkingManager(parkingBoy);

            manager.AskBoyStopCar(car);

            Assert.Same(car, manager.AskBoyPickCar(car.CarNumber));
        }

        [Fact]
        public void should_success_to_ask_parkingboy_to_pick_car_when_two_boys()
        {
            ParkingBoy parkingBoy = new ParkingBoy(new Park(1));
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(new Park(1));
            Car car = new Car("JP123");
            
            ParkingManager manager = new ParkingManager(parkingBoy, smartParkingBoy);

            manager.AskBoyStopCar(car);

            Assert.Same(car, manager.AskBoyPickCar(car.CarNumber));
        }
    }
}