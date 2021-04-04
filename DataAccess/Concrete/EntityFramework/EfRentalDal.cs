using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on r.CarId equals ca.CarId

                             join b in context.Brands
                             on ca.BrandId equals b.BrandId

                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId

                             join u in context.Users
                             on cu.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = ca.CarId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }

        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from r in context.Rentals.Where(r => r.RentalId == rentalId)

                             join ca in context.Cars
                             on r.CarId equals ca.CarId

                             join b in context.Brands
                             on r.BrandId equals b.BrandId

                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId

                             join u in context.Users
                             on cu.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = ca.CarId,
                                 BrandName = b.BrandName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
