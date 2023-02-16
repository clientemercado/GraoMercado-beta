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
    public interface IUserBankDetailsService : IService<UserBankDetails>
    {
    }

    public class UserBankDetailsService : Service<UserBankDetails>, IUserBankDetailsService
    {
        public UserBankDetailsService(IRepositoryAsync<UserBankDetails> repository)
            : base(repository)
        {
        }
    }
}
