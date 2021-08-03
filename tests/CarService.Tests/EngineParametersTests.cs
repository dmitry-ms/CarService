using CarService.Entities.CarsServices.CarParameters.Engine;
using CarService.Entities.Vehicles;
using CarService.Entities.Vehicles.Parts.Engines;
using System.Collections.Generic;
using Xunit;

namespace CarService.Tests
{
    public class EngineParametersTests
    {
        [Fact]
        public void IsAvailableFor_DieselEngine_WithNoRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new DieselEngine() } };
            var engineParameters = new EngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_PetrolEngine_WithNoRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new PetrolEngine { NameEngine = "qwer"} } };
            var engineParameters = new EngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_ElectricEngine_WithNoRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new ElectricEngine() } };
            var engineParameters = new EngineParameters();

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_DieselEngine_WithNameRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new DieselEngine { NameEngine = "asdf" } } };
            var engineParameters = new EngineParameters {EngineNames = new List<string>{"asdf"}  };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_DieselEngine_WithNameRestrictions_ReturnFalse()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new DieselEngine { NameEngine = "qwer" } } };
            var engineParameters = new EngineParameters { EngineNames = new List<string> { "asdf" } };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsAvailableFor_PetrolEngine_WithNameRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new DieselEngine { NameEngine = "jz21" } } };
            var engineParameters = new EngineParameters { EngineNames = new List<string> { "zxcv","jz21" } };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_PetrolEngine_WithNameRestrictions_ReturnFalse()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new PetrolEngine { NameEngine = "qwer" } } };
            var engineParameters = new EngineParameters { EngineNames = new List<string> { "asdf", "zxcv" } };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsAvailableFor_ElectricEngine_WithNameRestrictions_ReturnTrue()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new ElectricEngine { NameEngine = "aaa" } } };
            var engineParameters = new EngineParameters { EngineNames = new List<string> { "zxcv", "jz21","aaa" } };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAvailableFor_ElectricEngine_WithNameRestrictions_ReturnFalse()
        {
            // Arrange
            var car = new ClientCar { Vehicle = new Vehicle { Engine = new ElectricEngine { NameEngine = "wsx" } } };
            var engineParameters = new EngineParameters { EngineNames = new List<string> { "asdf", "zxcv" } };

            // Act
            var result = engineParameters.IsAvailableFor(car);

            // Assert
            Assert.False(result);
        }
    }
}
