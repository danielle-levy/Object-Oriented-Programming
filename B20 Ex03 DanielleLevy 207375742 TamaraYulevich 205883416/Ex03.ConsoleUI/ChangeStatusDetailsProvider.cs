using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class ChangeStatusDetailsProvider
    {
        private UserDisplay m_UserDisplay;

        public ChangeStatusDetailsProvider()
        {
            m_UserDisplay = new UserDisplay();
        }
        
        public string GetLicenseNumberForChangingStatus()
        {
            m_UserDisplay.DisplayMessage(Messages.k_ChooseVehicleToChangeStatusMessage);
            return ValidateUserInput.GetLicensePlateFromUser();
        }

        public Vehicle.eVehicleGarageStatus GetGarageStatus()
        {
            return ValidateUserInput.GetStateFromUser();
        }
    }
}
