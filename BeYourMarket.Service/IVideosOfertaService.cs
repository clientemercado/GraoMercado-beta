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
    public interface IVideosOfertaService : IService<VideosOferta>
    {
    }

    public class VideosOfertaService : Service<VideosOferta>, IVideosOfertaService
    {
        public VideosOfertaService(IRepositoryAsync<VideosOferta> repository)
            : base(repository)
        {
        }
    }
}
