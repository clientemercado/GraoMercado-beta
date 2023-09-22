using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BeYourMarket.Web.Utilities
{
    public class Utilitarios
    {
        /// <summary>
        /// Formatar o CPF
        /// </summary>
        /// <param name="CPF">string contendo o CPF a ser formatado</param>
        /// <returns></returns>
        public static string FormatCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        /// <summary>
        /// Formatar o CNPJ
        /// </summary>
        /// <param name="CNPJ">CNPJ a ser formatado</param>
        /// <returns></returns>
        public static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Formatar número de Telefone
        /// </summary>
        /// <param name="phoneNum">Número do telefone a formatar</param>
        /// <param name="phoneFormat">Chega vazio</param>
        /// <returns></returns>
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