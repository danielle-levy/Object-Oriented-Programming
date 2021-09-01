using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxButteryHours = 1.2f;

        public ElectricMotorcycle()
        {
            EnergySource = new Electric(k_MaxButteryHours);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Electric Motorcycle
{0}",
base.ToString());
        }
    }
}
