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
    public interface IModosPagamentoService : IService<ModosPagamento>
    {
    }

    public class ModosPagamentoService : Service<ModosPagamento>, IModosPagamentoService
    {
        public ModosPagamentoService(IRepositoryAsync<ModosPagamento> repository)
            : base(repository)
        {
        }
    }
}
