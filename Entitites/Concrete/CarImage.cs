using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites.Concrete
{
    public class CarImage : IEntity
    {
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

