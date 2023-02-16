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
    public interface ITiposContaBancariaService : IService<TiposContaBancaria>
    {
    }

    public class TiposContaBancariaService : Service<TiposContaBancaria>, ITiposContaBancariaService
    {
        public TiposContaBancariaService(IRepositoryAsync<TiposContaBancaria> repository)
            : base(repository)
        {
        }
    }
}
