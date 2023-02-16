using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.AdaptedModels
{
    public class ListOffersforSale
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string UrlPicture { get; set; }
        public string Description { get; set; }

        //Adicionado por Edwilson Curti em 14/10/2022
        //OBS: Armazena o cód. da Categoria e o Link de Vídeo, registrado pelo ofertante
        public int CategoryID { get; set; }
        public string LinkCam { get; set; }
    }
}
