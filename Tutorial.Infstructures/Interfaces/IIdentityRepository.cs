using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;
using System.Security.Claims;


namespace Tutorial.Infstructures.Interfaces
{
    public interface IIdentityRepository 
    {
         string GetUserID();


    }
}
