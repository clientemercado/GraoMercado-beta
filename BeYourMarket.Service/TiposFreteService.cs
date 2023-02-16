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
    public interface ITiposFreteService : IService<TiposFrete>
    {

    }

    public class TiposFreteService : Service<TiposFrete>, ITiposFreteService
    {
        public TiposFreteService(IRepositoryAsync<TiposFrete> repository)
            : base(repository)
        {
        }
    }
}
