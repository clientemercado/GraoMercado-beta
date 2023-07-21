using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeYourMarket.Core.Controllers
{
    public class UploadFilesResult
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string CaminhoArquivoVideo { get; set; }
    }
}
