using BeYourMarket.Core.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

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

        public static string formatPhNumber(string phoneNum, string phoneFormat)
        {
            if (phoneFormat == "")
            {
                phoneFormat = "(##) #####-####";
            }
            Regex regex = new Regex(@"[^\d]");
            phoneNum = regex.Replace(phoneNum, "");
            if (phoneNum.Length > 0)
            {
                phoneNum = Convert.ToInt64(phoneNum).ToString(phoneFormat);
            }
            return phoneNum;
        }
    }

}