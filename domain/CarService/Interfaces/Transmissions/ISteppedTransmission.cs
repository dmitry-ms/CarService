namespace CarService.Interfaces
{
    public interface ISteppedTransmission : ITransmission
    {
        public int NumberOfGears { get; set; }
    }
}
