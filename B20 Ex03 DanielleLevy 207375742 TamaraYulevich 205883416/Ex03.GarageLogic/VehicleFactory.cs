using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleTypes i_VehicleType)
        {
            Vehicle createdVehicle;
            switch (i_VehicleType)
            {
                case eVehicleTypes.GasCar:
                    createdVehicle = new GasCar();
                    break;
                case eVehicleTypes.GasTruck:
                    createdVehicle = new GasTruck();
                    break;
                case eVehicleTypes.GasMotorcycle:
                    createdVehicle = new GasMotorcycle();
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    createdVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleTypes.ElectricCar:
                    createdVehicle = new ElectricCar();
                    break;
                default:
                    throw new Exception("The vehicle you requested is not treatable in this garage. sorry! :(");
            }

            return createdVehicle;
        }

        public enum eVehicleTypes
        {
            GasCar = 1,
            GasTruck = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            ElectricCar = 5,
        }
    }
}