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
    public interface IInsurersService : IService<Insurers>
    {
    }

    public class InsurersService : Service<Insurers>, IInsurersService
    {
        public InsurersService(IRepositoryAsync<Insurers> repository)
            : base(repository)
        {
        }
    }
}
