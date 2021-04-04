using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId 
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId

                             select new CarDetailDto()
                             {
                                 CarId = ca.CarId,
                                 DailyPrice = ca.DailyPrice,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName
                                 
                                 
                             };
                return result.ToList(); 
            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from car in context.Cars.Where(c => c.CarId == carId)

                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 MinFindexScore = car.MinFindexScore
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
