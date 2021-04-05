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
        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from ca in context.Cars.Where(c => c.CarId == carId)

                             join c in context.Colors
                             on ca.ColorId equals c.ColorId

                             join b in context.Brands
                             on ca.BrandId equals b.BrandId

                             select new CarDetailDto()
                             {
                                 CarId = ca.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 MinFindexScore = ca.MinFindexScore
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
