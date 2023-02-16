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
    public interface ITipoAnimalProducaoService : IService<TipoAnimalProducao>
    {
    }

    public class TipoAnimalProducaoService : Service<TipoAnimalProducao>, ITipoAnimalProducaoService
    {
        public TipoAnimalProducaoService(IRepositoryAsync<TipoAnimalProducao> repository)
            : base(repository)
        {
        }
    }
}
