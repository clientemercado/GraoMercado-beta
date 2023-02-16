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
    public interface IModalidadesCompraService : IService<ModalidadesCompra>
    {

    }

    public class ModalidadesCompraService : Service<ModalidadesCompra>, IModalidadesCompraService
    {
        public ModalidadesCompraService(IRepositoryAsync<ModalidadesCompra> repository)
            : base(repository)
        {
        }
    }
}
