using System.Runtime.CompilerServices;
using VehicleServiceAPI.Models;

namespace VehicleServiceAPI.Interfaces
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicleById(int vehicleId);

        Task<bool> AddVehicle(Vehicle vehicle);

        Task<bool> UpdateVehicle(int vehicleId, Vehicle vehicle);

        Task<bool> DeleteVehicle(int vehicleId);

    }
}
