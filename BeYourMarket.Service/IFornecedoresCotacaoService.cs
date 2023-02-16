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
    public interface IFornecedoresCotacaoService : IService<FornecedoresCotacao>
    {
    }

    public class FornecedoresCotacaoService : Service<FornecedoresCotacao>, IFornecedoresCotacaoService
    {
        public FornecedoresCotacaoService(IRepositoryAsync<FornecedoresCotacao> repository)
            : base(repository)
        {
        }
    }
}
