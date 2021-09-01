using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("The amount is out of range. The range is: {0} to {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}