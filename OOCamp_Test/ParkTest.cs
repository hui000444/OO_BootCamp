using Xunit;
using OOCamp.Park;

namespace OOCamp_Test
{
    public class ParkTest
    {
        [Fact]
        public void should_to_stop_and_pick_up_car_when_park_have_one_empty_parking_position()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");

            Assert.True(park.StopCar(car));
            Assert.Same(car, park.PickUpCar(car.CarNumber));
        }

        [Fact]
        public void should_not_to_stop_car_when_park_have_one_parking_position_is_not_empty()
        {
            Park park = new Park(1);
            Car car = new Car("JP123");
            park.StopCar(car);

            Car secondCar = new Car("JP456");
            Assert.False(park.StopCar(secondCar));
        }


        [Fact]
        public void should_not_to_pick_up_car_when_car_number_not_right()
        {
            Car car = new Car("JP123");
            Park park = new Park(1);
            park.StopCar(car);

            Car otherCar = new Car("JP456");
            Assert.Same(null, park.PickUpCar(otherCar.CarNumber));
        }

        [Fact]
        public void should_not_to_stop_car_when_park_no_empty_parking_position()
        {
            Park park = new Park(2);
            park.StopCar(new Car("JP123"));
            park.StopCar(new Car("JP456"));

            Car thirdCar = new Car("JP789");
            Assert.False(park.StopCar(thirdCar));
        }

    }
}
