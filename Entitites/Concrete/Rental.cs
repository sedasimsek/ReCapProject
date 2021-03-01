﻿using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites.Concrete
{
    public class Rental : IEntity
    {
        public int RentalId { get; set; }
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
