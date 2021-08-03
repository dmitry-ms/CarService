using CarService.Entities.CarsServices.CarParameters.Engine;
using CarService.Entities.Vehicles;
using CarService.Entities.Vehicles.Parts.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Tests
{
    public class ElectricEngineParametersTests
    {
        [Fact]
        public void IsAvailableFor_ElectricEngine_WithNoRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar
            {
                Vehicle = new Vehicle
                {
                    Engine = new ElectricEngine()
                }
            };
            var engineParameters = new ElectricEngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAvailableFor_DieselEngine_WithRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar
            {
                Vehicle = new Vehicle
                {
                    Engine = new ElectricEngine
                    {
                        BatteryCapacity = 2500
                    }
                }
            };
            var engineParameters = new ElectricEngineParameters 
            {
                MaxBatteryCapacity = 2600,
                MinBatteryCapacity = 2100
            };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_DieselEngine_WithRestrictions_ReturnFalse()
        {
            // Arrange
            var car = new ClientCar
            {
                Vehicle = new Vehicle
                {
                    Engine = new ElectricEngine
                    {
                        BatteryCapacity = 2000
                    }
                }
            };
            var engineParameters = new ElectricEngineParameters
            {
                MaxBatteryCapacity = 2600,
                MinBatteryCapacity = 2100
            };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsAvailableFor_DieselEngine_WithNoRestrictions_ReturnFalse()
        {
            // Arrange
            var car = new ClientCar
            {
                Vehicle = new Vehicle
                {
                    Engine = new DieselEngine
                    {
                        DEF = true
                    }
                }
            };
            var engineParameters = new ElectricEngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
    }
}
