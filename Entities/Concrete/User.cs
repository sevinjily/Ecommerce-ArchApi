﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:AppUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
