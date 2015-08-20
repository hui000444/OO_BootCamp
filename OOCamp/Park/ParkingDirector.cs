using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOCamp.Park
{
    public class ParkingDirector
    {
        private readonly ParkingManager manager;

        public ParkingDirector(ParkingManager manager)
        {
            this.manager = manager;
        }

        public string GenerateReport()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format(
                "M {0} {1}",
                manager.Boys.Sum(boy => boy.GetEmptyPosition()) + manager.GetEmptyPosition(),
                manager.Boys.Sum(boy => boy.GetParkPositionTotalNumber()) + +manager.GetParkPositionTotalNumber()));

            builder.AppendLine(manager.CalculateParkingReport());

            manager.Boys.ForEach(boy => builder.AppendLine(boy.CalculateParkingReport()));

            return builder.ToString();
        }

    }
}
