using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleServiceAPI.Interfaces;
using VehicleServiceAPI.Models;
using VehicleServiceAPI.Services;

namespace VehicleServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            this._vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            List<Vehicle> vehicles = await this._vehicleService.GetVehicles();
            return vehicles;
        }

        [Authorize]
        [HttpGet("{id}")]
        
        public async Task<Vehicle> GetVehicle(int id)
        {
            Vehicle retVal = await this._vehicleService.GetVehicleById(id);
            return retVal;
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> AddNewVehicle([FromBody] Vehicle vehicle)
        {
            return await this._vehicleService.AddVehicle(vehicle);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<bool> UpdateVehicle(int id, [FromBody] Vehicle vehicle)
        {
            return await this._vehicleService.UpdateVehicle(id, vehicle);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<bool> DeleteVehicle(int id)
        {
            return await _vehicleService.DeleteVehicle(id);
        }

    }
}
