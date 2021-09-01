using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GasTruck : Truck
    {
        private const Gas.eGasType k_FuleType = Gas.eGasType.Soler;
        private const int k_FuleTankCapacity = 120;

        public GasTruck()
        {
            EnergySource = new Gas(k_FuleType, k_FuleTankCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Truck
{0}",
base.ToString());
        }
    }
}
