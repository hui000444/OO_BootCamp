using System.Collections.Generic;
using System.Linq;

namespace OOCamp.Park
{
    public class Park
    {
        public Park(int parkPositionTotalNumber)
        {
            CarsInPark = new List<Car>();
            ParkPositionTotalNumber = parkPositionTotalNumber;
        }

        private int ParkPositionTotalNumber { get; set; }
        public List<Car> CarsInPark { get; private set; }

        public int GetEmptyPositionCount()
        {
            return ParkPositionTotalNumber - CarsInPark.Count;
        }

        public decimal GetEmptyRate()
        {
            if (ParkPositionTotalNumber <= 0) return 0;
            return (decimal)GetEmptyPositionCount() / ParkPositionTotalNumber;
        }

        public bool StopCar(Car car)
        {
            if (CarsInPark.Count >= ParkPositionTotalNumber) return false;
            CarsInPark.Add(car);
            return true;
        }

        public Car PickUpCar(string carNo)
        {
            var car = CarsInPark.FirstOrDefault(d => d.CarNumber == carNo);
            if (car == null) return null;
            CarsInPark.Remove(car);
            return car;
        }
    }
}
