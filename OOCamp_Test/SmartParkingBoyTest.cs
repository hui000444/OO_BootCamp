using OOCamp.Park;
using Xunit;

namespace OOCamp_Test
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void should_stopped_to_first_park_when_two_parks_have_same_empty_position()
        {
            Park firstPark = new Park(1);
            Park secondPark = new Park(1);
            Car car = new Car("JP123");
            SmartParkingBoy boy = new SmartParkingBoy(firstPark, secondPark);

            boy.StopCar(car);

            Assert.Same(car, firstPark.PickUpCar(car.CarNumber));

        }

        [Fact]
        public void should_stopped_to_more_empty_poisition_park_when_two_parks_have_different_empty_position()
        {
            Park lessEmptyPoisitionPark = new Park(1);
            Park moreEmptyPoisitionPark = new Park(2);
            Car car = new Car("JP123");
            SmartParkingBoy boy = new SmartParkingBoy(lessEmptyPoisitionPark, moreEmptyPoisitionPark);

            boy.StopCar(car);

            Assert.Same(car, moreEmptyPoisitionPark.PickUpCar(car.CarNumber));

        }

        [Fact]
        public void should_pick_up_car_from_first_park_when_two_parks_have_same_empty_position()
        {
            Park firstPark = new Park(1);
            Park secondPark = new Park(1);
            Car car = new Car("JP123");
            SmartParkingBoy boy = new SmartParkingBoy(firstPark, secondPark);

            boy.StopCar(car);

            Assert.Same(car, boy.PickUpCar(car.CarNumber));

        }

        [Fact]
        public void should_pick_up_from_more_empty_poisition_park_when_two_parks_have_different_empty_position()
        {
            Park lessEmptyPoisitionPark = new Park(1);
            Park moreEmptyPoisitionPark = new Park(2);
            Car car = new Car("JP123");
            SmartParkingBoy boy = new SmartParkingBoy(lessEmptyPoisitionPark, moreEmptyPoisitionPark);

            boy.StopCar(car);

            Assert.Same(car, boy.PickUpCar(car.CarNumber));

        }

        [Fact]
        public void should_not_pick_up_car_when_repeat_pick_up()
        {
            Park firstPark = new Park(1);
            Park secondPark = new Park(1);
            Car car = new Car("JP123");
            SmartParkingBoy boy = new SmartParkingBoy(firstPark, secondPark);

            boy.StopCar(car);
            boy.PickUpCar(car.CarNumber);

            Assert.Same(null, boy.PickUpCar(car.CarNumber));

        }
    }
}