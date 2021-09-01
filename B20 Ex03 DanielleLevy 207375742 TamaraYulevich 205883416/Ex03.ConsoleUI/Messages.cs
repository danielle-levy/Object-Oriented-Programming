using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    ////contatins repetitive messages
    internal class Messages
    {
        public const string k_WelcomeUserMessage = "Welcome to our garage management tool!";
        public const string k_EnterLicenseNumberMessage = "Please enter license plate number:";
        public const string k_PleasePressEnterMessage = "Please press enter";
        public const string k_EnterAmountToAddMessage = "Please enter amount to add:";
        public const string k_GoodByeMessage = "Hope to see you next time! Bye :)";
        public const string k_GarageIsEmptyMessage = "The garage is empty, there are no vehicles to display.";
        public const string k_RefuelSuccessMessage = "Your vehicle is succesfully fuled!";
        public const string k_RechargeSuccessMessage = "Your vehicle is succesfully charged!";
        public const string k_InvalidInputMessage = "The input you chose is not of a valid type. Please try again:";
        public const string k_ChooseVehicleStatusMessage = "Please choose a vehicle status:";
        public const string k_ChooseVehicleToChangeStatusMessage = "Please enter the license number of the vehicle you would like to change it's status:";
        public const string k_InvalidInputRangeMessage = "The input you chose is not of a valid range. Please enter an option in the valid range";
        public const string k_InvalidInputBooleanMessage = "The answer is invalid. Please answer With Y or N";
        public const string k_PumpedToMaxSuccessMessage = "Your vehicle wheels are pumped!";
        public const string k_CloseTheTerminalMessage = "Press enter close the terminal";
        public const string k_Menu = @"Please choose one of the following options by entering the option number:
1. Add a new vehicle.
2. Display all license plates numbers
3. Change vehicle status
4. Pump wheels to maximum
5. Refuel a vehicle
6. Recharge a vehicle 
7. Show vehicle's details
8. Exit
";

        public const string k_EmptyInputMessage = "The input you have entered is empty. Please try again";

        public enum eMainMenuOptions
        {
            AddNewVehicle = 1,
            DisplayAllLicensePlates = 2,
            ChangeStatus = 3,
            PumpWheelsToMax = 4,
            FillFuelGasEngine = 5,
            ChargeElectricEngine = 6,
            DisplayVehicleDetails = 7,
            Exit = 8,
        }

        public static string GetEnumAsString(Type i_EnumType)
        {
            int counter = 1;
            StringBuilder enumToString = new StringBuilder();

            foreach (Enum enumValue in Enum.GetValues(i_EnumType))
            {
                if (!enumValue.ToString().Equals("Undefined"))
                {
                    enumToString.Append(counter + ". " + enumValue + Environment.NewLine);
                    counter++;
                }
            }

            return enumToString.ToString();
        }
    }
}
