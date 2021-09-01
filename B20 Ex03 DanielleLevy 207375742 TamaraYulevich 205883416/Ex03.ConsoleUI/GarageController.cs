using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class GarageController
    {
        private Garage m_Garage;
        private VehicleAdder m_VehicleAdder;
        private UserDisplay m_UserDisplay;
        private VehicleStatusFilterProvider m_LicenseNumberFilter;
        private ChangeStatusDetailsProvider m_ChangeStatus;
        private RechargeElectricDetailsProvider m_ChargeElectricVehicle;
        private RefuelGasDetailsProvider m_RefuelGasVehicle;

        public GarageController(Garage i_Garage)
        {
            m_Garage = i_Garage;
            m_VehicleAdder = new VehicleAdder();
            m_UserDisplay = new UserDisplay();
            m_LicenseNumberFilter = new VehicleStatusFilterProvider();
            m_ChangeStatus = new ChangeStatusDetailsProvider();
            m_ChargeElectricVehicle = new RechargeElectricDetailsProvider();
            m_RefuelGasVehicle = new RefuelGasDetailsProvider();
        }

        public void ChargeElectricVehicle()
        {
            m_UserDisplay.ClearAndDisplayMessage("You chose to charge an electric vehicle");
            string licenseNumber = m_ChargeElectricVehicle.GetLicenseNumberForCharging();
            int amountOfTimeToCharge = m_ChargeElectricVehicle.GetAmountOfMinutesToCharge();

            try
            {
                m_Garage.ChargeElectricVehicle(licenseNumber, amountOfTimeToCharge);
                m_UserDisplay.ClearAndDisplayMessage(string.Format("Vehicle with license number: {0}, with amount: {1} successfuly!", licenseNumber, amountOfTimeToCharge));
                m_UserDisplay.PressEnterToContinue();
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);

                if (exception is ValueOutOfRangeException)
                {
                    m_UserDisplay.DisplayMessage(Messages.k_PleasePressEnterMessage);
                    m_UserDisplay.ReadLine();
                    ChargeElectricVehicle();
                }
                else
                {
                    m_UserDisplay.PressEnterToContinue();
                }
            }
        }

        public void PrintVehicleDetails()
        {
            m_UserDisplay.ClearAndDisplayMessage("You chose to print the details of a vehicle");
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle to show it's details");

            try
            {
                string licenseNumber = ValidateUserInput.GetLicensePlateFromUser();
                m_Garage.IsVehicleInGarageException(licenseNumber);
                m_UserDisplay.Clear();
                m_UserDisplay.DisplayMessage(m_Garage.GetVehicleByLicenseNumber(licenseNumber).ToString());
            }
            catch (ArgumentException exception)
            {
                m_UserDisplay.DisplayExceptionMessage(exception);
            }
            finally
            {
                m_UserDisplay.PressEnterToContinue();
            }
        }

        public void ChangeCarStatus()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to change the status of a vehicle which is in the garage");
            try
            {
                m_Garage.ChangeVehicleStatus(m_ChangeStatus.GetLicenseNumberForChangingStatus(), m_ChangeStatus.GetGarageStatus());
                m_UserDisplay.ClearAndDisplayMessage("Vehicle status was changed successfully!");
            }
            catch (Exception exception)
            {
                m_UserDisplay.DisplayExceptionMessage(exception);
            }
            finally
            {
                m_UserDisplay.PressEnterToContinue();
            }
        }

        public void DisplayLicenseNumbersList()
        {
            Vehicle.eVehicleGarageStatus vehicleStatus = m_LicenseNumberFilter.GetFilter();
            List<string> licenseNumbers;

            if (vehicleStatus.Equals(Vehicle.eVehicleGarageStatus.Undefined))
            {
                licenseNumbers = m_Garage.GetLicenseNumberList();
            }
            else
            {
                licenseNumbers = m_Garage.GetLicenseNumberList(vehicleStatus);
            }

            m_UserDisplay.Clear();
            m_UserDisplay.DisplayAccordingToSize(licenseNumbers, "There are no vehicles for your choice in the garage! sorry", "The list of plates that you requested: ");
            m_UserDisplay.DisplayMessage(Messages.k_PleasePressEnterMessage);
            Console.ReadLine();
        }

        public void AddVehicleToGarage()
        {
            try
            {
                Vehicle vehicle = m_VehicleAdder.GetVitalDetailsFromUser();
                m_Garage.InsertVehicleToGarage(vehicle);
                vehicle = m_VehicleAdder.PopulateVehicleWithDetails(vehicle);
                m_UserDisplay.ClearAndDisplayMessage("Vehicle was added to the garage successfully");
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);
            }
            finally
            {
                m_UserDisplay.PressEnterToContinue();
            }
        }

        public void InflateTires()
        {
            m_UserDisplay.ClearAndDisplayMessage("You chose to pump a vehicle's wheels to maximum");
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle you would like to pump it's wheels to");
            string licensePlate = ValidateUserInput.GetLicensePlateFromUser();

            try
            {
                m_Garage.PumpVehiclesWheelsToMax(licensePlate);
                m_UserDisplay.ClearAndDisplayMessage(string.Format("{0}'s wheels were pumped to maximum!", licensePlate));
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);
            }
            finally
            {
                m_UserDisplay.PressEnterToContinue();
            }
        }

        public void FillGasVehicle()
        {
            string licenseNumber = m_RefuelGasVehicle.GetLicenseNumberForRefuel();
            Gas.eGasType fuelType = m_RefuelGasVehicle.GetFuelTypeForRefuel();
            float amountOfFuel = m_RefuelGasVehicle.GetAmountOfLitersToFuel();

            try
            {
                m_Garage.FillVehicleWithGas(licenseNumber, fuelType, amountOfFuel);
                m_UserDisplay.ClearAndDisplayMessage(string.Format("Vehicle with license number: {0}, was fuled with gas type: {1}, and amount: {2} successfuly!", licenseNumber, fuelType, amountOfFuel));
                m_UserDisplay.PressEnterToContinue();
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);

                if (exception is ValueOutOfRangeException)
                {
                    m_UserDisplay.DisplayMessage(Messages.k_PleasePressEnterMessage);
                    m_UserDisplay.ReadLine();
                    FillGasVehicle();
                }
                else
                {
                    m_UserDisplay.PressEnterToContinue();
                }
            }
        }
    }
}
