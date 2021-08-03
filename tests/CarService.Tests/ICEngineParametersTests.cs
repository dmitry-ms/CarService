using CarService.Entities.CarsServices.CarParameters.Engine;
using CarService.Entities.Vehicles;
using CarService.Entities.Vehicles.Parts.Engines;
using Xunit;

namespace CarService.Tests
{
    public class ICEngineParametersTests
    {
        [Fact]
        public void IsAvailableFor_DieselEngine_WithNoRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new DieselEngine() } };
            var engineParameters = new ICEngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_DieselEngine_WithRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new DieselEngine {
                EngineVolumeSquareCentimeter = 2400,
                NumberCylinders = 5,
                NumberValves = 10
            } } };
            var engineParameters = new ICEngineParameters {
                MaxEngineVolume = 2500, 
                MinEngineVolume=1900,
                MaxNumberCylinders=6,
                MinNumberCylinders=3,
                MaxNumberValves=12,
                MinNumberValves=3,
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
                    Engine = new DieselEngine
                    {
                        EngineVolumeSquareCentimeter = 2550,
                        NumberCylinders = 5,
                        NumberValves = 10
                    }
                }
            };
            var engineParameters = new ICEngineParameters
            {
                MaxEngineVolume = 2500,
                MinEngineVolume = 1900,
                MaxNumberCylinders = 6,
                MinNumberCylinders = 3,
                MaxNumberValves = 12,
                MinNumberValves = 3,
            };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsAvailableFor_ElectricEngine_WithRestrictions_ReturnFalse()
        {
            // Arrange
            var car = new ClientCar
            {
                Vehicle = new Vehicle
                {
                    Engine = new ElectricEngine()
                }
            };
            var engineParameters = new ICEngineParameters
            {
                MaxEngineVolume = 2500,
                MinEngineVolume = 1900,
                MaxNumberCylinders = 6,
                MinNumberCylinders = 3,
                MaxNumberValves = 12,
                MinNumberValves = 3,
            };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
    }
}
