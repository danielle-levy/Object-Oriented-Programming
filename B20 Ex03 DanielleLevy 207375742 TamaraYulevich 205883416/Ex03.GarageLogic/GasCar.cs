using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GasCar : Car
    {
        private const Gas.eGasType k_FuleType = Gas.eGasType.Octan96;
        private const int k_FuleTankCapacity = 60;

        public GasCar()
        {
            EnergySource = new Gas(k_FuleType, k_FuleTankCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Car
{0}",
base.ToString());
        }
    }
}
