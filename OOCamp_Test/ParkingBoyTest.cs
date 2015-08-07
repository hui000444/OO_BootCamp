using OOCamp.Park;
using Xunit;

namespace OOCamp_Test
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_can_stop_and_customer_can_pick_up_car_when_park_have_one_empty_parking_position()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy boy = new ParkingBoy(park);

            Assert.True(boy.StopCar(car));
            Assert.Same(car, park.PickUpCar(car.CarNumber));
        }
        [Fact]
        public void should_can_pick_up_when_customer_stopped_car()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy boy = new ParkingBoy(park);

            Assert.True(park.StopCar(car));
            Assert.Same(car, boy.PickUpCar(car.CarNumber));
        }
        [Fact]
        public void should_can_stop_and_pick_up_when_park_have_one_empty_parking_position()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy boy = new ParkingBoy(park);

            Assert.True(boy.StopCar(car));
            Assert.Same(car, boy.PickUpCar(car.CarNumber));
        }
        [Fact]
        public void should_can_stop_and_pick_up_when_two_park_both_have_empty_parking_position()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy boy = new ParkingBoy(park, new Park(1));

            Assert.True(boy.StopCar(car));
            Assert.Same(car, park.PickUpCar(car.CarNumber));
        }
        [Fact]
        public void should_can_stop_and_pick_up_when_first_park_full_and_second_park_empty()
        {
            Park firstPark = new Park(0);
            Park secondPark = new Park(1);
            Car car = new Car("JP123");
            ParkingBoy boy = new ParkingBoy(firstPark, secondPark);

            Assert.True(boy.StopCar(car));
            Assert.Same(car, secondPark.PickUpCar(car.CarNumber));
        }
        [Fact]
        public void should_can_stop_and_pick_up_when_first_park_empty_and_second_park_full()
        {
            Park firstPark = new Park(1);
            Park secondPark = new Park(0);
            Car car = new Car("JP123");
            ParkingBoy boy = new ParkingBoy(firstPark, secondPark);

            Assert.True(boy.StopCar(car));
            Assert.Same(car, firstPark.PickUpCar(car.CarNumber));
        }
    }
}