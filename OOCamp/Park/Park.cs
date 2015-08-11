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

    public abstract class ParkingBoyBase
    {
        protected List<Park> ParkList { get; set; }

        protected ParkingBoyBase(params Park[] parks)
        {
            ParkList = parks.ToList();
        }

        public abstract bool StopCar(Car car);

        public virtual Car PickUpCar(string carNumber)
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

    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(params Park[] parks)
            : base(parks)
        {
        }

        public override bool StopCar(Car car)
        {
            var park = ParkList.FirstOrDefault(p => p.StopCar(car));
            return park != null;
        }
    }

    public class SmartParkingBoy : ParkingBoyBase
    {

        public SmartParkingBoy(params Park[] parks)
            : base(parks)
        {
        }

        public override bool StopCar(Car car)
        {
            var park =
                ParkList.Select(p => new { Park = p, Position = p.GetEmptyPositionCount() })
                    .OrderByDescending(r => r.Position)
                    .First()
                    .Park;
            if (park == null) return false;
            return park.StopCar(car);
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
