using Tutorial.Infstructures.Interfaces;
using System.Security.Claims;
using Tutorials.Data.Context ;


using Microsoft.AspNetCore.Http;

namespace Tutorial.Infstructures.Repository
{
    public  class IdentityRepository : IIdentityRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly TutorialDbContext _tutorialDbContext;

        public IdentityRepository(IHttpContextAccessor httpContextAccessor  , TutorialDbContext tutorialDbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            _tutorialDbContext = tutorialDbContext;
        }

        public string  GetUserID()
        {
            return  httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ;
      
        
        }
        public int  GetTeacherID  ()
        {
            return _tutorialDbContext.Teachers.Where(i=>i.UserId == GetUserID()).Select(i=>i.TeacherId).FirstOrDefault();
        }


    }

}
