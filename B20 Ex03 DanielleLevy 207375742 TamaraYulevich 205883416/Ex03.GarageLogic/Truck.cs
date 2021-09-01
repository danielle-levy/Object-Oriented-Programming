using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const int k_MaxWheelAirPressure = 28;
        private bool m_CarryingHazardousMaterials;
        private float m_TrunkVolume;

        public Truck()
        {
            SetNumOfWheels();
            GetFeatures();
        }

        public override void GetFeatures()
        {
            features = new Dictionary<string, Type>();
            features.Add("if the truck is carrying hazardous materials (answer with Y or N)", typeof(bool));
            features.Add("trunk volume", typeof(float));
        }

        public override void SetFeatures(Dictionary<string, object> i_TruckFeatures)
        {
            m_CarryingHazardousMaterials = (bool)i_TruckFeatures["if the truck is carrying hazardous materials (answer with Y or N)"];
            m_TrunkVolume = (float)i_TruckFeatures["trunk volume"];
         }
  
        public void SetNumOfWheels()
        {
            Wheels = new List<Wheel>(k_NumOfWheels);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaxWheelAirPressure));
            }
        }

        public bool CarryingHazardousMaterials
        {
            get
            {
                return m_CarryingHazardousMaterials;
            }

            set
            {
                m_CarryingHazardousMaterials = value;
            }
        }

        public float TrunkVolume
        {
            get
            {
                return m_TrunkVolume;
            }

            set
            {
                m_TrunkVolume = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The truck is{1} carrying hazardous materials
The truck maximum allowed cargo weight is: {2}",
base.ToString(),
m_CarryingHazardousMaterials == true ? string.Empty : " not",
m_TrunkVolume);
        }
    }
}
