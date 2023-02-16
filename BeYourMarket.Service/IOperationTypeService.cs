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
    public interface IOperationTypeService : IService<OperationType>
    {
    }

    public class OperationTypeService : Service<OperationType>, IOperationTypeService
    {
        public OperationTypeService(IRepositoryAsync<OperationType> repository)
            : base(repository)
        {
        }
    }
}
