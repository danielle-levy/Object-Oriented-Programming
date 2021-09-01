using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxButteryHours = 2.1f;

        public ElectricCar() 
        {
            EnergySource = new Electric(k_MaxButteryHours);
        }
         
        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Electric Car
{0}",
base.ToString());
        }
    }
}
