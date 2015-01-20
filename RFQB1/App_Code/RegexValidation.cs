using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for RegexValidation
/// </summary>
/// 
namespace RFQDBFunctions
{
    public class RegexValidation
    {
        private string m_strRegexTestString;
        public RegexValidation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public RegexValidation(string strTestString)
        {
            //
            // TODO: Add constructor logic here
            //
            m_strRegexTestString = strTestString;
        }

        public bool IsValid(string strSource, string strRegexTestString)
        {
            Regex reg = new Regex(strRegexTestString);

            return reg.IsMatch(strSource);

        }

        public bool IsValid(string strSource)
        {
            Regex reg = new Regex(m_strRegexTestString);

            return reg.IsMatch(strSource);

        }

    }
}