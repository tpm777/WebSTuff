

function OnPageLoad()
{    
    InitializeTrimBox();    

      InitializeTextbox("txbLoginID",InputType.AlphaNumeric);

      
    
 //   InitializeTextbox( "txtAcceptNonnegativeIntegerBox", InputType.NonnegativeInteger);
//    InitializeTextbox( "txtAcceptWholeNumberBox", InputType.WholeNumber);
//	InitializeMaskEdit( "txbTest", "$$A*$d$d$d$d$d");    
    
//    InitializeTextbox( "txtAcceptCurrencyBox", InputType.Currency);
        
//    InitializeMaskEdit( "txtPostalCode", "$A$d$A $d$A$d");
//	InitializeMaskEdit( "txtTelPhone", "($d$d$d)$d$d$d-$d$d$d$d");
//	InitializeMaskEdit( "txtCarNumber", "$$A*$d$d$d$d$d");
//	InitializeMaskEdit( "txtDateTime1", "$d$d$d$d-$d$d-$d$d");
//	InitializeMaskEdit( "txtDateTime2", "$d$d/$d$d/$d$d$d$d");
	
//	InitializeTipBox( "txtTipBox", "If you do not change the password, left blank.");
}

function OnPageRLoadLoad()
{    
      InitializeTrimBox();    

      InitializeTextbox("txbQuantity",InputType.NonnegativeInteger);

      
    
 //   InitializeTextbox( "txtAcceptNonnegativeIntegerBox", InputType.NonnegativeInteger);
//    InitializeTextbox( "txtAcceptWholeNumberBox", InputType.WholeNumber);
//	InitializeMaskEdit( "txbTest", "$$A*$d$d$d$d$d");    
    
//    InitializeTextbox( "txtAcceptCurrencyBox", InputType.Currency);
        
//    InitializeMaskEdit( "txtPostalCode", "$A$d$A $d$A$d");
//	InitializeMaskEdit( "txtTelPhone", "($d$d$d)$d$d$d-$d$d$d$d");
//	InitializeMaskEdit( "txtCarNumber", "$$A*$d$d$d$d$d");
//	InitializeMaskEdit( "txtDateTime1", "$d$d$d$d-$d$d-$d$d");
//	InitializeMaskEdit( "txtDateTime2", "$d$d/$d$d/$d$d$d$d");
	
//	InitializeTipBox( "txtTipBox", "If you do not change the password, left blank.");
}


// the first parameter is the XmlHttp parameter
// the sencond parameter is the custom parameter
function CallbackFunction(ajax)
{
    var objDoc = ajax.GetXmlDoc();
    //alert(objDoc.childNodes[0].nodeName );
    alert(ajax.GetResponse());
    //alert(ajax.GetCustomParam());
    
    //alert( objDom.selectSingleNode( "//xmlRoot/a" ).text );
   
    //alert(xmlHttp.responseText);
    //alert(xmlHttp.responseXML.xml);
    //alert(xmlHttp.status);
    //alert(xmlHttp.statusText);
    
    
}


function TestAjax()
{
    var ajax = new AJAX( GetAbsoluteUrl(".\\test.xml") );
    ajax.SetCallbackFun(CallbackFunction);
    ajax.SetCustomParam("Customer Parameter");
    ajax.AddUrlParameter( "Type", 1);
    ajax.AddUrlParameter( "Name", "Jerry");
    ajax.AddUrlParameter( "Card", "@#@@#=");
    ajax.Send(null);
}