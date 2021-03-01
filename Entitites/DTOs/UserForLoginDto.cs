using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
