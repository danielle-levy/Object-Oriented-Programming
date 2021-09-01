using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class RefuelGasDetailsProvider
    {
        private UserDisplay m_UserDisplay;

        public RefuelGasDetailsProvider()
        {
            m_UserDisplay = new UserDisplay();
        }

        public float GetAmountOfLitersToFuel()
        {
            m_UserDisplay.DisplayMessage("Please enter the amount of fuel you would like to refuel");
            return ValidateUserInput.ParseInputToFloat();
        }

        public string GetLicenseNumberForRefuel()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the license number of the vehicle you would like to refuel");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        public Gas.eGasType GetFuelTypeForRefuel()
        {
            m_UserDisplay.DisplayMessage("Please enter the type of fuel of the vehicle you would like to refuel");
            return (Gas.eGasType)ValidateUserInput.InputIsInRangeOfEnum(typeof(Gas.eGasType));
        }
    }
}
