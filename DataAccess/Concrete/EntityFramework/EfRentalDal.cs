using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
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
            using(ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on r.CarId equals ca.CarId
                             join u in context.Users
                             on r.UserId equals u.UserId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId



                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = ca.CarId,
                                 UserId = u.UserId,
                                 CustomerId = cu.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();


            }
        }
    }
}
