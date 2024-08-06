﻿using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:BaseEntity
    {
    
        public ICollection<CategoryLanguage> CategoryLanguages { get; set; }

    }
}
