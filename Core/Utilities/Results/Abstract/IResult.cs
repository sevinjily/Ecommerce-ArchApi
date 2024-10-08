﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {

         string Message { get; }
         bool Success { get; }
         HttpStatusCode StatusCode { get; }
    }
}
