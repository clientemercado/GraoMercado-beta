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
    public interface ICotacaoMasterService : IService<Cotacao_Master>
    {

    }

    public class CotacaoMasterService : Service<Cotacao_Master>, ICotacaoMasterService
    {
        public CotacaoMasterService(IRepositoryAsync<Cotacao_Master> repository)
            : base(repository)
        {
        }
    }
}
