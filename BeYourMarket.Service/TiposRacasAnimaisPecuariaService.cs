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
    public interface ITiposRacasAnimaisPecuariaService : IService<TiposRacasAnimaisPecuaria>
    {
    }

    public class TiposRacasAnimaisPecuariaService : Service<TiposRacasAnimaisPecuaria>, ITiposRacasAnimaisPecuariaService
    {
        public TiposRacasAnimaisPecuariaService(IRepositoryAsync<TiposRacasAnimaisPecuaria> repository)
            : base(repository)
        {
        }
    }
}
