using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Progress.Open4GL.DynamicAPI;
using Progress.Open4GL.Proxy;
using Progress.Open4GL;

/// <summary>
/// Summary description for EpicorData
/// </summary>
/// 
namespace EpicorDataFunctions
{
    public class EpicorData
    {
        public EpicorData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string GetQuoteNum(string strRFQID)  // for Epicor
        {
            WSProgressASP objProgress = new WSProgressASP();
            ParamArray paramSysTaskProc = new ParamArray(3);

            // need routine to get company id when hull has converted to Epicor

            paramSysTaskProc.AddCharacter(0, "95735", ParamArrayMode.INPUT);
            paramSysTaskProc.AddCharacter(1, strRFQID, ParamArrayMode.INPUT);

            paramSysTaskProc.AddCharacter(2, null, ParamArrayMode.OUTPUT);

            objProgress.CallProgressProcedure("CmpGetQuoteInfoFromRFQID.p", paramSysTaskProc, "string");




            string strResult = objProgress.ReturnMessage;

            strResult = strResult.ToUpper();
            return strResult;


        }

    }
}