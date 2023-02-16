using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Utilities
{
    public static class MiscellaneousUtilitiesHelper
    {
        /// <summary>
        /// Tratamento de milhar, facilitando a formatação do valor a ser persistido no banco
        /// </summary>
        /// <param name="v">Valor a ser tratado</param>
        /// <returns></returns>
        public static string TratamentoMilharMonetario(string v)
        {
            var parts = v.Split('.');
            var f = ((parts.Length > 1) ? parts[0].ToString() + parts[1].ToString() : v);
            return f;
        }
    }
}