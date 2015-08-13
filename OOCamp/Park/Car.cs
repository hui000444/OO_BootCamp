namespace OOCamp.Park
{
    public class Car
    {
        public Car(string carNumber)
        {
            CarNumber = carNumber;
        }

        public string CarNumber { get; private set; }
    }
}