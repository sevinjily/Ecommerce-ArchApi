﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CategoryDTOs
{
    public class GetCategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string LangCode { get; set; }
    }
}
