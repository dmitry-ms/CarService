using CarService.Entities.CarsServices.CarParameters.Engine;
using CarService.Entities.Vehicles;
using CarService.Entities.Vehicles.Parts.Engines;
using Xunit;

namespace CarService.Tests
{
    public class DieselEngineParametersTests
    {
        [Fact]
        public void IsAvailableFor_DieselEngineWithDEF_WithNoRestrictions_ReturnTrue()
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
            var engineParameters = new DieselEngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_DieselEngine_WithNoRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar
            {
                Vehicle = new Vehicle
                {
                    Engine = new DieselEngine
                    {
                        DEF = false
                    }
                }
            };
            var engineParameters = new DieselEngineParameters();

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
                    Engine = new DieselEngine
                    {
                        DEF = true
                    }
                }
            };
            var engineParameters = new DieselEngineParameters {
                DEF = true
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
                        DEF = true
                    }
                }
            };
            var engineParameters = new DieselEngineParameters
            {
                DEF = false
            };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
    }
}
