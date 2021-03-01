using Core.Utilities.Results;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<Car> GetById(int carId);
        IDataResult<Car> Get(int CarId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
