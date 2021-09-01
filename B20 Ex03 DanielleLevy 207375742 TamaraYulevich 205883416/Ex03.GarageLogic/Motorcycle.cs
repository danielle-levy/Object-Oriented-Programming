using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const int k_MaxWheelAirPressure = 30;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public enum eLicenseType
        {
            B = 1,
            AA = 2,
            A1 = 3,
            A = 4,
        }

        public Motorcycle()
        {
            SetNumOfWheels();
            GetFeatures();
        }

        public override void GetFeatures()
        {
            features = new Dictionary<string, Type>();
            features.Add("license type", typeof(eLicenseType));
            features.Add("engine volume", typeof(int));
        }

        public override void SetFeatures(Dictionary<string, object> i_MotorcycleFeatures)
        {
            m_LicenseType = (eLicenseType)i_MotorcycleFeatures["license type"];
            m_EngineVolume = (int)i_MotorcycleFeatures["engine volume"];
        }
     
        public void SetNumOfWheels()
        {
            Wheels = new List<Wheel>(k_NumOfWheels);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaxWheelAirPressure));
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The license type is: {1}
The motorcycle engine volume is: {2}",
base.ToString(),
m_LicenseType,
m_EngineVolume);
        }
    }
}
