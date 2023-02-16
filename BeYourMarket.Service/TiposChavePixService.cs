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
    public interface ITiposChavePixService : IService<TiposChavePix>
    {
    }

    public class TiposChavePixService : Service<TiposChavePix>, ITiposChavePixService
    {
        public TiposChavePixService(IRepositoryAsync<TiposChavePix> repository)
            : base(repository)
        {
        }
    }
}
