using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Gas : EnergySource
    {
        private eGasType m_GasType;

        public enum eGasType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        public Gas(eGasType i_GasType, float i_MaxAmountOfGas) : base(i_MaxAmountOfGas)
        {
            m_GasType = i_GasType;
        }

        public void FillGas(eGasType i_GasType, float i_AmountOfGas)
        {
            if (i_GasType != m_GasType)
            {
                throw new ArgumentException(string.Format("The gas type dose not match the car vehicle gas type. chosen vehicle gas type is: {0}", m_GasType));
            }

            FillEnergy(i_AmountOfGas);
        }

        public override string ToString()
        {
            return string.Format(
@"Fuel type is: {0}
Current fuel in liters: {1}
Maximum fuel in liters: {2}",
m_GasType,
CurrentEnergyAmount,
MaxEnergyAmount);
        }
    }
}
