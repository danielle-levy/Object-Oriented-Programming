using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        private const Gas.eGasType k_FuleType = Gas.eGasType.Octan95;
        private const int k_FuleTankCapacity = 7;

        public GasMotorcycle()
        {
            EnergySource = new Gas(k_FuleType, k_FuleTankCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Motorcycle
{0}",
base.ToString());
        }
    }
}
