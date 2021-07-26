
namespace CarService.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
