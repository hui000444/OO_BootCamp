using System.Collections.Generic;
using System.Linq;

namespace OOCamp.Park
{
    public class Park
    {
        public Park(int parkPositionTotalNumber)
        {
            ParkPositions = new List<ParkPosition>();
            for (int i = 0; i < parkPositionTotalNumber; i++)
            {
                ParkPositions.Add(new ParkPosition(i + 1));
            }
        }

        public List<ParkPosition> ParkPositions { get; private set; }

        public int GetEmptyPositionCount()
        {
            return ParkPositions.Count(d => d.Car == null);
        }

        public bool IsExistEmptyPosition()
        {
            return ParkPositions.Any(d => d.Car == null);
        }

        public bool StopCar(Car car)
        {
            var emptyPosition = ParkPositions.FirstOrDefault(d => d.Car == null);
            if (emptyPosition != null)
            {
                emptyPosition.Car = car;
                return true;
            }
            return false;
        }

        public bool IsExistCar(Car car)
        {
            return ParkPositions.Any(d => d.Car != null && d.Car.CarNumber == car.CarNumber);
        }

        public Car PickUpCar(string carNo)
        {
            var carPosition = ParkPositions.Where(p => p.Car != null).FirstOrDefault(d => d.Car.CarNumber == carNo);
            if (carPosition == null) return null;
            var resultCar = carPosition.Car;
            carPosition.Car = null;
            return resultCar;
        }
    }

    public class ParkingBoy
    {
        private List<Park> ParkList { get; set; }

        public ParkingBoy(params Park[] parks)
        {
            ParkList = parks.ToList();
        }
        public bool StopCar(Car car)
        {
            var park = ParkList.FirstOrDefault(p => p.StopCar(car));
            return park != null;
        }

        public Car PickUpCar(string carNumber)
        {
            foreach (var park in ParkList)
            {
                var carResult = park.PickUpCar(carNumber);
                if (carResult != null)
                {
                    return carResult;
                }
            }
            return null;
        }
    }

    public class SmartParkingBoy
    {

        private List<Park> ParkList { get; set; }

        public SmartParkingBoy(params Park[] parks)
        {
            ParkList = parks.ToList();
        }
        public bool StopCar(Car car)
        {
            var park =
                ParkList.Select(p => new { Park = p, Position = p.GetEmptyPositionCount() })
                    .OrderByDescending(r => r.Position)
                    .First()
                    .Park;
            if (park == null) return false;
            return park.StopCar(car);
        }

        public Car PickUpCar(string carNumber)
        {
            foreach (var park in ParkList)
            {
                var carResult = park.PickUpCar(carNumber);
                if (carResult != null)
                {
                    return carResult;
                }
            }
            return null;

        }
    }

    public class ParkPosition
    {
        public ParkPosition(int id, Car car = null)
        {
            Id = id;
            Car = car;
        }

        public int Id { get; private set; }
        public Car Car { get; set; }
    }

    public class Car
    {
        public Car(string carNumber)
        {
            CarNumber = carNumber;
        }

        public string CarNumber { get; private set; }
    }

}
