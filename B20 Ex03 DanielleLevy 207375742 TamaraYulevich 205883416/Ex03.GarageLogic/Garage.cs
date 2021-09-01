using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_VehiclesList;

        public Garage()
        {
            r_VehiclesList = new Dictionary<string, Vehicle>();
        }

        public void InsertVehicleToGarage(Vehicle i_Vehicle)
        {
            if (IsVehicleInGarage(i_Vehicle.LicenseNumber))
            {
                r_VehiclesList[i_Vehicle.LicenseNumber].VehicleGarageStatus = Vehicle.eVehicleGarageStatus.InRepair;
                throw new Exception("This vehicle is already in the garage! Vehicle status changed to being fixed");
            }

            r_VehiclesList.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        }

        public Vehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
            IsVehicleInGarageException(i_LicenseNumber);
            return r_VehiclesList[i_LicenseNumber];
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool vehicleIsInGarage = false;

            if (r_VehiclesList.ContainsKey(i_LicenseNumber))
            {
                vehicleIsInGarage = true;
            }

            return vehicleIsInGarage;
        }

        public void IsVehicleInGarageException(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This Vehicle is not in the garage!");
            }
        }

        public List<string> GetLicenseNumberList(Vehicle.eVehicleGarageStatus i_VehicleStatus)
        {
            List<string> licenseNumbersList = new List<string>();

            foreach (KeyValuePair<string, Vehicle> vehicle in r_VehiclesList)
            {
                if (vehicle.Value.VehicleGarageStatus == i_VehicleStatus)
                {
                    licenseNumbersList.Add(vehicle.Key);
                }
            }

            return licenseNumbersList;
        }

        public List<string> GetLicenseNumberList()
        {
            List<string> licenseNumbersList = new List<string>();
            foreach (string licenseNumber in r_VehiclesList.Keys)
            {
                licenseNumbersList.Add(licenseNumber);
            }

            return licenseNumbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, Vehicle.eVehicleGarageStatus i_NewStatus)
        {
            GetVehicleByLicenseNumber(i_LicenseNumber).VehicleGarageStatus = i_NewStatus;
        }

        public void PumpVehiclesWheelsToMax(string i_LicenseNumber)
        {
            GetVehicleByLicenseNumber(i_LicenseNumber).PumpAllWheelsAirToMaximum();
        }

        ////Assume that the given vehicle is gas type.
        public void FillVehicleWithGas(string i_LicenseNumber, Gas.eGasType i_GasType, float i_AmountToFill)
        {
            if (GetVehicleByLicenseNumber(i_LicenseNumber).EnergySource is Gas)
            { 
               (GetVehicleByLicenseNumber(i_LicenseNumber).EnergySource as Gas).FillGas(i_GasType, i_AmountToFill);
               GetVehicleByLicenseNumber(i_LicenseNumber).SetEnergyPercentge();
            }
            else
            {
                throw new ArgumentException("This is an electric vehicle, you can't fill it with gas.");
            }
        }
 
        public void ChargeElectricVehicle(string i_LicenseNumber, int i_NumberOfMinuetsToCharge)
        {
            const float numberOfMinutesInOneHour = 60f;
            if (GetVehicleByLicenseNumber(i_LicenseNumber).EnergySource is Electric)
            {
                (GetVehicleByLicenseNumber(i_LicenseNumber).EnergySource as Electric).Charge(i_NumberOfMinuetsToCharge / numberOfMinutesInOneHour);
                GetVehicleByLicenseNumber(i_LicenseNumber).SetEnergyPercentge();
            }
            else
            {
                throw new ArgumentException("This is a gas vehicle, you can't charge it.");
            }
        }

        public string GetVehicleData(string i_LicenseNumber)
        {
            return GetVehicleByLicenseNumber(i_LicenseNumber).ToString();
        }
    }
}
