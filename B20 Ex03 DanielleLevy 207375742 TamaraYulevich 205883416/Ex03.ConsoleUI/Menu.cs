using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class Menu
    {
        private GarageController m_GarageController;
        private UserDisplay m_UserDisplay;

        public Menu()
        {
            m_GarageController = new GarageController(new Garage());
            m_UserDisplay = new UserDisplay();
        }

        public void ServeUser()
        {
            m_UserDisplay.DisplayMessage(Messages.k_WelcomeUserMessage);
            GetUserChoiceOfOptions();
        }

        public void GetUserChoiceOfOptions() 
        {
            int userChoise = 0;
            while (userChoise != (int)Messages.eMainMenuOptions.Exit)
            {
                m_UserDisplay.DisplayMessage(Messages.k_Menu);
                userChoise = ValidateUserInput.GetUserChoice();
                if (userChoise == (int)Messages.eMainMenuOptions.AddNewVehicle)
                {
                    m_GarageController.AddVehicleToGarage();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.DisplayAllLicensePlates)
                {
                    m_GarageController.DisplayLicenseNumbersList();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.ChangeStatus)
                {
                    m_GarageController.ChangeCarStatus();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.FillFuelGasEngine)
                {
                    m_GarageController.FillGasVehicle();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.ChargeElectricEngine)
                {
                    m_GarageController.ChargeElectricVehicle();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.PumpWheelsToMax)
                {
                    m_GarageController.InflateTires();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.DisplayVehicleDetails)
                {
                    m_GarageController.PrintVehicleDetails();
                }

                m_UserDisplay.Clear();
            }

            m_UserDisplay.GoodByePrinter();
        }
    }
}
