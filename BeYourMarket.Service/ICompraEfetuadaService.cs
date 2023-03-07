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
    public interface ICompraEfetuadaService : IService<CompraEfetuada>
    {
    }

    public class CompraEfetuadaService : Service<CompraEfetuada>, ICompraEfetuadaService
    {
        public CompraEfetuadaService(IRepositoryAsync<CompraEfetuada> repository)
            : base(repository)
        {
        }
    }
}
