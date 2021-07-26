using CarService.Data.EF.Data;
using CarService.Data.EF.Repository;
using CarService.Repositories;
using System;

namespace CarService.Data.EF
{
    //public class DataManager : IDataManager, IDisposable
    //{
    //    private bool _disposed = false;
    //    private readonly CarServiceDbContext _dbContext;
    //    private IVehicleRepository _vehicleRepository;

    //    public DataManager(CarServiceDbContext dbContext) => _dbContext = dbContext;

    //    public IVehicleRepository VehicleRepository
    //    {
    //        get
    //        {
    //            if(_vehicleRepository == null)
    //                _vehicleRepository = new VehicleRepository(_dbContext);
    //            return _vehicleRepository;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!_disposed)
    //            if (disposing)
    //                _dbContext.Dispose();
    //        _disposed = true;
    //    }
    //}
}
