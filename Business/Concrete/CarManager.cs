using Business.Abstract;
using Business.BusinessAspects;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes
            //validation 

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }



        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.delete,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        [CacheAspect]
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

        [CacheAspect]
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

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
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

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.BrandId == brandId));
        }


        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.ColorId == colorId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }


        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetails(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(carId));
        }


        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColor(int brandId, int colorId)
        {
            List<CarDetailDto> car = (_carDal.GetCarsDetails(c => c.BrandId == brandId && c.ColorId == colorId));

            if (car == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCar);
            }

            return new SuccessDataResult<List<CarDetailDto>>(car);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }
    }
}