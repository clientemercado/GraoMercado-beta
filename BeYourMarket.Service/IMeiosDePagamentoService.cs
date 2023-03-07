using System;
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
    public interface IMeiosDePagamentoService : IService<MeiosDePagamento>
    {
    }

    public class MeiosDePagamentoService : Service<MeiosDePagamento>, IMeiosDePagamentoService
    {
        public MeiosDePagamentoService(IRepositoryAsync<MeiosDePagamento> repository)
            : base(repository)
        {
        }
    }
}
