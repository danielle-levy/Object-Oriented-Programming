using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const int k_MaxWheelAirPressure = 32;
        private eCarColor m_CarColor; 
        private eAmountOfDoors m_AmountOfDoors;
        
        public enum eCarColor
        {
            Red = 1,
            White = 2,
            Black = 3,
            Silver = 4,
        }

        public enum eAmountOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
        }

        public Car()
        {
            SetNumOfWheels();
            GetFeatures();
        }

        public override void GetFeatures()
        {
            features = new Dictionary<string, Type>();
            features.Add("a car color", typeof(eCarColor));
            features.Add("number of doors", typeof(eAmountOfDoors));
        }

        public override void SetFeatures(Dictionary<string, object> i_CarFeatures)
        {
            m_CarColor = (eCarColor)i_CarFeatures["a car color"];
            m_AmountOfDoors = (eAmountOfDoors)i_CarFeatures["number of doors"];
        }

        public void SetNumOfWheels()
        {
            Wheels = new List<Wheel>(k_NumOfWheels);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaxWheelAirPressure));
            }
        }

        public eCarColor Color
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public eAmountOfDoors AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }

            set
            {
                m_AmountOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The amount of doors is: {1}
The car color is: {2}",
base.ToString(),
m_AmountOfDoors,
m_CarColor);
        }
    }
}
