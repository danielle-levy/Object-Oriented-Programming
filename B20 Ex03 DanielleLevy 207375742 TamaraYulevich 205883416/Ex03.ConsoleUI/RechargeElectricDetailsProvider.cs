using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class RechargeElectricDetailsProvider
    {
        private UserDisplay m_UserDisplay;

        public RechargeElectricDetailsProvider()
        {
            m_UserDisplay = new UserDisplay();
        }

        public int GetAmountOfMinutesToCharge()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the number of minutes to charge");
            return ValidateUserInput.ParseInputToInt();
        }

        public string GetLicenseNumberForCharging()
        {
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle you would like to charge");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }
    }
}
