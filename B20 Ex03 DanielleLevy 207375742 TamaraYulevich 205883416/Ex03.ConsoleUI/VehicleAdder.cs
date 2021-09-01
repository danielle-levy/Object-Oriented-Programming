using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehicleAdder
    {
        private UserDisplay m_UserDisplay;

        public VehicleAdder()
        {
            m_UserDisplay = new UserDisplay();
        }

        public Vehicle GetVitalDetailsFromUser()
        {
            m_UserDisplay.ClearAndDisplayMessage("You chose to add a new vehicle");
            VehicleFactory.eVehicleTypes type = getVehicleType();
            Vehicle m_CreatedVehicle = createVehicleFromFactory(type);
            m_CreatedVehicle.LicenseNumber = getLicensePlateNumber();
            return m_CreatedVehicle;
        }

        public Vehicle PopulateVehicleWithDetails(Vehicle i_Vehicle)
        {
            i_Vehicle.ModelName = getCarModel();
            setCurrentAmountOfEnergy(i_Vehicle);
            i_Vehicle.SetEnergyPercentge();
            addWheelsManufacturer(i_Vehicle.Wheels);
            setWheelsCurrentAirPressure(i_Vehicle.Wheels);
            i_Vehicle.OwnerName = getUsersName();
            i_Vehicle.OwnerPhoneNumber = getUsersPhoneNumber();
            i_Vehicle = createSpecificTypeOfVehicle(i_Vehicle);

            return i_Vehicle;
        }
        
        private Vehicle createSpecificTypeOfVehicle(Vehicle i_Vehicle)
        {
            Dictionary<string, object> SetFeaturesDictionary = new Dictionary<string, object>();
            object answer;
            foreach (KeyValuePair<string, Type> feature in i_Vehicle.features)
            { 
                m_UserDisplay.ClearAndDisplayMessage(string.Format("Please choose {0}:", feature.Key));
                if (feature.Value.IsEnum)
                {
                    answer = ValidateUserInput.InputIsInRangeOfEnum((Type)feature.Value);
                    SetFeaturesDictionary.Add(feature.Key, answer);
                }
                else if (feature.Value.ToString() == typeof(int).ToString())
                {
                    answer = ValidateUserInput.ParseInputToInt();
                    SetFeaturesDictionary.Add(feature.Key, answer);
                }
                else if (feature.Value.ToString() == typeof(float).ToString())
                {
                    answer = ValidateUserInput.ParseInputToFloat();
                    SetFeaturesDictionary.Add(feature.Key, answer);
                }
                else if (feature.Value.ToString() == typeof(bool).ToString())
                {
                    answer = ValidateUserInput.ValidateYesOrNo();
                    SetFeaturesDictionary.Add(feature.Key, answer);
                }
                else
                {
                    throw new Exception("This type is not supported in this system, sorry!");
                }
            }

            i_Vehicle.SetFeatures(SetFeaturesDictionary);

            return i_Vehicle;
        }

        private string getLicensePlateNumber()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the license number of the vehicle you would like to add");
            return ValidateUserInput.GetLicensePlateFromUser();
        }

        private VehicleFactory.eVehicleTypes getVehicleType()
        {
            m_UserDisplay.DisplayMessage("Please choose one of the following vehicle types:");
            return (VehicleFactory.eVehicleTypes)ValidateUserInput.InputIsInRangeOfEnum(typeof(VehicleFactory.eVehicleTypes));
        }

        private Vehicle createVehicleFromFactory(VehicleFactory.eVehicleTypes i_VehicleType)
        {
            return VehicleFactory.CreateVehicle(i_VehicleType);
        }

        private string getCarModel()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the vehicle model name:");
            string carModelName = ValidateUserInput.ValidateInputInNotEmpty();
            return carModelName;
        }

        private void addWheelsManufacturer(List<Wheel> i_Wheels)
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter wheels manufacturer name:");
            string ManufacturerOfWheels = ValidateUserInput.ValidateInputInNotEmpty();

            foreach (Wheel wheel in i_Wheels)
            {
                wheel.Manufacturer = ManufacturerOfWheels;
            }
        }

        private void setWheelsCurrentAirPressure(List<Wheel> i_Wheels)
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the current air pressure of the wheels:");

            float currentAirPressure = ValidateUserInput.ParseInputToFloat();

            try
            {
                foreach (Wheel wheel in i_Wheels)
                {
                    wheel.PumpAir(currentAirPressure);
                }
            }
            catch (Exception exception)
            {
                m_UserDisplay.DisplayExceptionMessage(exception);
                m_UserDisplay.ReadLine();
                setWheelsCurrentAirPressure(i_Wheels);
            }
        }

        private string getUsersName()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter your name:");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        private string getUsersPhoneNumber()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter your phone number:");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        private void setCurrentAmountOfEnergy(Vehicle i_Vehicle)
        {
            if (i_Vehicle.EnergySource is Gas)
            {
                m_UserDisplay.ClearAndDisplayMessage("Please enter current amount of fuel in liters:");
            }
            else
            {
                m_UserDisplay.ClearAndDisplayMessage("Please enter remaining electric engine battery hours:");
            }

            float amountOfEnergy = ValidateUserInput.ParseInputToFloat();

            try
            {
                i_Vehicle.EnergySource.FillEnergy(amountOfEnergy);
            }
            catch (Exception exception)
            {
                m_UserDisplay.DisplayExceptionMessage(exception);
                m_UserDisplay.ReadLine();
                setCurrentAmountOfEnergy(i_Vehicle);
            }
        }
    }
}
