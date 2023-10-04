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

        /// <summary>
        /// Remove acentos e caracteres especiais de uma string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoverAcentosECaracteresEspeciais(string str)
        {
            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }
            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°", "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?", "[", "]", "{", "}", "=", "+", "§", "´", "`", "^", "~" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }

            /** Troca os caracteres especiais da string por " " **/
            str = Regex.Replace(str, @"[^\w\.@-]", " ",
                                RegexOptions.None, TimeSpan.FromSeconds(1.5));

            return str.Trim();
        }

        /// <summary>
        /// Coloca no formato correto uma data recebida por POST
        /// </summary>
        /// <param name="data">String contendo a data separada por barras / </param>
        /// <returns></returns>
        public static string FormatarDataFormPost(string data)
        {
            var dataPost = data.Split('/');
            var dataFormat = dataPost[2] + "-" + dataPost[1] + "-" + dataPost[0];

            return dataFormat;
        }
    }
}