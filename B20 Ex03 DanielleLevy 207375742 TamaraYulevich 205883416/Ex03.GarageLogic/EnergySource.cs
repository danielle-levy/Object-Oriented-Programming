using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrentAmountOfEnergy;
        private float m_MaxAmountOfEnergy;
        private eEnergyTypes m_EnergyType;

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }

            set
            {
                if (m_CurrentAmountOfEnergy + value > m_MaxAmountOfEnergy)
                {
                    throw new ValueOutOfRangeException(0f, m_MaxAmountOfEnergy);
                }

                m_CurrentAmountOfEnergy += value;
            }
        }

        public float MaxEnergyAmount
        {
            get
            {
                return m_MaxAmountOfEnergy;
            }
        }

        protected EnergySource(float i_MaxAmount)
        {
            m_CurrentAmountOfEnergy = 0;
            m_MaxAmountOfEnergy = i_MaxAmount;
        }

        public void FillEnergy(float i_AmountOfEnergy)
        {
            if (i_AmountOfEnergy < 0 || i_AmountOfEnergy + m_CurrentAmountOfEnergy > m_MaxAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(0f, m_MaxAmountOfEnergy - m_CurrentAmountOfEnergy);
            }
            else
            {
                m_CurrentAmountOfEnergy += i_AmountOfEnergy;
            }
        }

        public eEnergyTypes EnergyType
        {
            get
            {
                return m_EnergyType;
            }

            set
            {
                m_EnergyType = value;
            }
        }

        public enum eEnergyTypes
        {
            Gas,
            Electric,
        }

        public override string ToString()
        {
            return string.Format(
@"Engine type is: {0}
Current amount of energy: {1}
Maximum amount of energy: {2}",
m_EnergyType,
m_CurrentAmountOfEnergy,
m_MaxAmountOfEnergy);
        }
    }
}
