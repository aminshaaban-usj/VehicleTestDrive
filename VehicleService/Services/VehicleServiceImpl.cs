using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleServiceAPI.Data;
using VehicleServiceAPI.Interfaces;
using VehicleServiceAPI.Models;

namespace VehicleServiceAPI.Services
{
    public class VehicleServiceImpl : IVehicleService
    {
        VehicleTestDriveDbContext context = new VehicleTestDriveDbContext();

        public Task<bool> AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            {
                var newVehicle = context.Vehicles.Add(vehicle);
                context.SaveChanges();
                return Task.FromResult(true);
            }
        }

        public async Task<bool> DeleteVehicle(int vehicleId)
        {
            var vehicle = await context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null) throw new KeyNotFoundException("Vehicle not found!!!!");

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            var vehicleFound = await context.Vehicles.FindAsync(vehicleId);
            if (vehicleFound == null) throw new KeyNotFoundException("Vehicle not found!!!!!!!!");

            return vehicleFound;
        }
        public Task<List<Vehicle>> GetVehicles()
        {
            
               return Task.FromResult(context.Vehicles.ToList());
            
        }

        public async Task<bool> UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));

            var oldVehicle = await context.Vehicles.FindAsync(vehicleId);
            if (oldVehicle == null) throw new KeyNotFoundException("Vehicle not found!!!!!");

            
            oldVehicle.Name = vehicle.Name;
            oldVehicle.Price = vehicle.Price;
            oldVehicle.ImageUrl = vehicle.ImageUrl;
            oldVehicle.MaxSpeed = vehicle.MaxSpeed;

            context.Vehicles.Update(oldVehicle);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
