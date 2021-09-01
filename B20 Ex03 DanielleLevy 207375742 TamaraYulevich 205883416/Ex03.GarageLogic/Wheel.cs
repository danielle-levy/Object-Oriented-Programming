using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            m_ManufacturerName = string.Empty;
            m_CurrentAirPressure = 0f;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public void PumpAir(float i_AirToPump)
        {
            if (i_AirToPump + m_CurrentAirPressure > (int)m_MaxAirPressure || i_AirToPump < 0)
            {
                throw new ValueOutOfRangeException(0, (int)m_MaxAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirToPump;
            }
        }

        public void PumpAirToMaximum()
        {
            CurrentAirPressure = MaximumAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
@"Manufacturer is: {0} 
Current air pressure is: {1}
Maximum air pressure is: {2}",
m_ManufacturerName,
m_CurrentAirPressure,
m_MaxAirPressure);
        }
    }
}
