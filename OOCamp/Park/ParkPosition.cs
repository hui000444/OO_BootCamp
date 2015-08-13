namespace OOCamp.Park
{
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
}