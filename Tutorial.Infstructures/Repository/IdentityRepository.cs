using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.GenricRepository;
using Tutorial.Infstructures.Interfaces;
using Tutorials.Data.Context;
using Tutorials.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Http;

namespace Tutorial.Infstructures.Repository
{
    public  class IdentityRepository : IIdentityRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityRepository(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string  GetUserID()
        {
            return  httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ;
      
        
        }


    }

}
