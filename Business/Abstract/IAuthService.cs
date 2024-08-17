﻿using Core.Utilities.Results.Abstract;
using Entities.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IResult> RegisterAsync(RegisterDTO registerDTO);
        Task<IResult> LoginAsync(LoginDTO loginDTO);



    }
}
