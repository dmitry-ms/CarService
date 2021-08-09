namespace CarService.App.Models
{
    public class CommonEditServiceModel
    {
        public EditServiceModel service { get; set; }

        public CostsModel baseCost { get; set; }
        public CostsByDriveUnitModel costsByDriveUnit { get; set; }
        public CostsByOneCylinderModel costsByOneCylinder { get; set; }

        public EngineParametersModel parameterEngine { get; set; }
        public ICEngineParametersModel parameterICEngine { get; set; }
        public DieselEngineParametersModel parameterDieselEngine { get; set; }
        public PetrolEngineParametersModel parameterPetrolEngine { get; set; }
        public ElectricEngineParametersModel parameterElectricEngine { get; set; }
    }
}
