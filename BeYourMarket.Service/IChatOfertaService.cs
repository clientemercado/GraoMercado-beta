﻿using BeYourMarket.Model.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Service
{
    public interface IChatOfertaService : IService<ChatOferta>
    {
    }

    public class ChatOfertaService : Service<ChatOferta>, IChatOfertaService
    {
        public ChatOfertaService(IRepositoryAsync<ChatOferta> repository)
            : base(repository)
        {
        }
    }
}
