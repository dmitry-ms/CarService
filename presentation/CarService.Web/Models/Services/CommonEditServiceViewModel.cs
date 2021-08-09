namespace CarService.Web.Models
{
    public class CommonEditServiceViewModel
    {
        public EditServiceViewModel service { get; set; }

        public BaseCostsViewModel baseCost { get; set; }
        public CostsByDriveUnitViewModel costsByDriveUnit { get; set; }
        public CostsByOneCylinderViewModel costsByOneCylinder { get; set; }

        public EngineParameterViewModel parameterEngine { get; set; }
        public ICEngineParameterViewModel parameterICEngine { get; set; }
        public DieselEngineParameterViewModel parameterDieselEngine { get; set; }               
        public PetrolEngineParameterViewModel parameterPetrolEngine { get; set; }
        public ElectricEngineParameterViewModel parameterElectricEngine { get; set; }
    }
}
