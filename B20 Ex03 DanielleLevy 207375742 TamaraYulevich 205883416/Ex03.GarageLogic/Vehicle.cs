using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentage = 0;
        private List<Wheel> m_Wheels;
        private EnergySource m_EnergySource;
        private Dictionary<string, Type> m_Features;
        private Dictionary<string, object> m_SetFeatures;

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleGarageStatus m_VehicleGarageStatus;

        public enum eVehicleGarageStatus
        {
            Undefined = 0,  
            InRepair = 1,
            Repaired = 2,
            PayedFor = 3,
        }

        public Vehicle()
        {
            m_ModelName = string.Empty;
            m_LicenseNumber = string.Empty;
            m_EnergyPercentage = 0;
            m_Wheels = new List<Wheel>();
            m_EnergySource = null;
            m_VehicleGarageStatus = eVehicleGarageStatus.InRepair;
        }
               
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public Dictionary<string, Type> features
        {
            get
            {
                return m_Features;
            }

            set
            {
                m_Features = value;
            }
        }

        public Dictionary<string, object> setFeatures
        {
            get
            {
                return m_SetFeatures;
            }

            set
            {
                m_SetFeatures = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public float EnergyPercentge
        {
            get
            {
                return this.m_EnergyPercentage;
            }
        }

        public abstract void GetFeatures();

        public abstract void SetFeatures(Dictionary<string, object> i_SetVehicleFeatures);

        public void SetEnergyPercentge()
        {
            m_EnergyPercentage = (m_EnergySource.CurrentEnergyAmount / m_EnergySource.MaxEnergyAmount) * 100;
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }

            set
            {
                m_EnergySource = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public eVehicleGarageStatus VehicleGarageStatus
        {
            get
            {
                return m_VehicleGarageStatus;
            }

            set
            {
                m_VehicleGarageStatus = value;
            }
        }

        public void PumpAllWheelsAirToMaximum()
        {
            foreach (Wheel wheel in this.m_Wheels)
            {
                wheel.PumpAirToMaximum();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"License number is: {0}
Model name is: {1}
Owner name is: {2}
Current state in garage: {3}
{4}
Current energy percentage is: {5}%
{6}",
m_LicenseNumber,
m_ModelName,
m_OwnerName,
m_VehicleGarageStatus,
m_Wheels[0].ToString(),
m_EnergyPercentage,
m_EnergySource.ToString());
        }
    }
}