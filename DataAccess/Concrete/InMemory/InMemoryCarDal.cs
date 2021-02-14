using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
    public class InMemoryCarDal
    {
        //List<Car> _cars;

        //    public InMemoryCarDal
        //   {
        //        _cars = cars;
        //    }

        //    public InMemoryCarDal()
        //    {
        //        _cars = new List<Car>
        //        {
        //            new Car{CarId=1, BrandId=2, ColorId=127, DailyPrice=1000, Description="Yeni", ModelYear="2005"},
        //            new Car{CarId=2, BrandId=4, ColorId=128, DailyPrice=3500, Description="Son model", ModelYear="2015"},
        //            new Car{CarId=3, BrandId=6, ColorId=129, DailyPrice=1800, Description="Mini Couper", ModelYear="2008"},
        //            new Car{CarId=4, BrandId=8, ColorId=130, DailyPrice=6000, Description="Son model Range Rover", ModelYear="2020"},
        //            new Car{CarId=5, BrandId=10, ColorId=131, DailyPrice=15000, Description="Jaguar", ModelYear="2017"},
        //            new Car{CarId=6, BrandId=4, ColorId=132, DailyPrice=4500, Description="En yeni", ModelYear="2017"},
        //            new Car{CarId=7, BrandId=8, ColorId=129, DailyPrice=7500, Description="Yeni", ModelYear="2020"},
        //            new Car{CarId=8, BrandId=2, ColorId=131, DailyPrice=2000, Description="İyi", ModelYear="2009"}
        //        };
        //    }

        //    public void Add(Car car)
        //    {
        //        _cars.Add(car);
        //    }

        //    public void Delete(Car car)
        //    {
        //        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

        //        _cars.Remove(carToDelete);
        //    }

        //    public Car Get(Expression<Func<Car, bool>> filter = null)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public List<Car> GetById(int carId)
        //    {
        //        return _cars.Where(c=>c.CarId == carId).ToList();
        //    }

        //    public void Update(Car car)
        //    {
        //        Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId == car.CarId );
        //        carToUpdate.ColorId = car.ColorId;
        //        carToUpdate.BrandId = car.BrandId;
        //        carToUpdate.DailyPrice = car.DailyPrice;
        //        carToUpdate.Description = car.Description;
        //        carToUpdate.ModelYear = car.ModelYear;
        //    }

        //    public List<CarDetailDto> GetCarDetails()
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
      
