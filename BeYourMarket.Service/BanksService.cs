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
    public interface IBanksService : IService<Banks>
    {
    }

    public class BanksService : Service<Banks>, IBanksService
    {
        public BanksService(IRepositoryAsync<Banks> repository)
            : base(repository)
        {
        }
    }
}
