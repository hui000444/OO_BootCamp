using System;
using System.Collections.Generic;
using System.Linq;

namespace OOCamp.Park
{
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

        protected bool ChooseParkBy<T>(Car car, Func<Park, T> selector)
        {
            var park = ParkList
                .OrderByDescending(selector)
                .FirstOrDefault();
            if (park == null) return false;
            return park.StopCar(car);
        }
    }
}