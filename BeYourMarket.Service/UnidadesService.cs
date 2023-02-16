using BeYourMarket.Model.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace BeYourMarket.Service
{
    public interface IUnidadesService : IService<Unidades>
    {

    }

    public class UnidadesService : Service<Unidades>, IUnidadesService
    {
        public UnidadesService(IRepositoryAsync<Unidades> repository)
            : base(repository)
        {
        }
    }
}
