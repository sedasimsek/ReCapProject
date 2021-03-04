using Core.Entities;
using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
