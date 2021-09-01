using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Electric : EnergySource
    {
        public Electric(float i_MaxAmountOfHours) : base(i_MaxAmountOfHours)
        {
            EnergyType = eEnergyTypes.Electric;
        }

        public void Charge(float i_AmountOfHoursToAdd)
        {
            FillEnergy(i_AmountOfHoursToAdd);
        }
    }
}
