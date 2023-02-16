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
    public interface IRespostaFornecedoresCotacaoService : IService<Resposta_FornecedoresCotacao>
    {

    }

    public class RespostaFornecedoresCotacaoService : Service<Resposta_FornecedoresCotacao>, IRespostaFornecedoresCotacaoService
    {
        public RespostaFornecedoresCotacaoService(IRepositoryAsync<Resposta_FornecedoresCotacao> repository)
            : base(repository)
        {
        }
    }
}
