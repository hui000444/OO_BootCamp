using OOCamp.Park;
using Xunit;

namespace OOCamp_Test
{
    public class SuperParkingBoyTest
    {
        [Fact]
        public void should_stopped_to_park()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            SuperParkingBoy boy = new SuperParkingBoy(park);

            boy.StopCar(car);

            Assert.Same(car, park.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_pick_up_car_from_park()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            SuperParkingBoy boy = new SuperParkingBoy(park);

            boy.StopCar(car);

            Assert.Same(car, boy.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_pick_up_car_from_first_park_when_two_parks_have_same_empty_rate()
        {
            Park firstPark = new Park(1);
            Park secondPark = new Park(1);
            Car car = new Car("JP123");
            SuperParkingBoy boy = new SuperParkingBoy(firstPark, secondPark);

            boy.StopCar(car);

            Assert.Same(car, firstPark.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_pick_up_from_more_empty_rate_park_when_two_parks_have_different_empty_rate()
        {
            Park lessEmptyRatePark = new Park(2);
            Park moreEmptyRatePark = new Park(1);
            lessEmptyRatePark.StopCar(new Car("JP123"));

            SuperParkingBoy boy = new SuperParkingBoy(lessEmptyRatePark, moreEmptyRatePark);
            
            Car car = new Car("JP456");
            boy.StopCar(car);

            Assert.Same(car, moreEmptyRatePark.PickUpCar(car.CarNumber));
        }
        
        [Fact]
        public void should_not_stop_when_park_have_zero_position()
        {
            Park park = new Park(0);
            SuperParkingBoy boy = new SuperParkingBoy(park);
            
            Car car = new Car("JP456");
            boy.StopCar(car);

            Assert.Same(null, park.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_not_pick_up_car_when_repeat_pick_up()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            SuperParkingBoy boy = new SuperParkingBoy(park);

            boy.StopCar(car);
            boy.PickUpCar(car.CarNumber);

            Assert.Same(null, boy.PickUpCar(car.CarNumber));

        }

    }
}