using BeYourMarket.Model.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Service
{
    public interface IAspNetUsersService : IService<AspNetUser>
    {

    }

    public class AspNetUsersService : Service<AspNetUser>, IAspNetUsersService
    {
        public AspNetUsersService(IRepositoryAsync<AspNetUser> repository)
            : base(repository)
        {
        }
    }
}
