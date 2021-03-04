using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes
            //validation 

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        //[SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        
        public IDataResult<Car> Get(int carId)
        {
            Car car = _carDal.Get(p => p.CarId == carId);
            if (car == null)
            {
                return new ErrorDataResult<Car>();
            }
            else
            {
                return new SuccessDataResult<Car>(car);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            List<Car> cars = _carDal.GetAll();
            if (cars.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }
            else
            {
                return new SuccessDataResult<List<Car>>(cars);
            }
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));
        }

        //[SecuredOperation("car.update,admin")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.FailedBrandAddOrUpdate);
            }
        }
    }
}