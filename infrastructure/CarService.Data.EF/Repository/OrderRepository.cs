using CarService.Data.EF.Data;
using CarService.Data.EF.Repository.Base;
using CarService.Entities.Orders;
using CarService.Repositories;

namespace CarService.Data.EF.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(CarServiceDbContext dbContext) : base(dbContext) { }
    }
}
