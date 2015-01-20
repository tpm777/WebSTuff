/************************************************************
 * Javascript Lib V1.2
 * CONTACT: jerry.wang@clochase.com
 *
 * This is the Auto-Trim box
 *
 * InitializeTrimBox( "TextboxID" );
 * InitializeTrimBox( null );
 ************************************************************/
 
$import( "Firefox.outerHTML.js" );



//-------------------------------------------------------------------------
// Function Name    :InitializeTipBox
// Parameter(s)     :ctrl            The ID of the textbox or textbox instance
//                  :strTip          The tip will be shown if the it is empty
//-------------------------------------------------------------------------
function InitializeTipBox( ctrl, strTip)
{
    var obj = typeof(ctrl) == "string" ? document.getElementById(ctrl) : ctrl;
    if( obj == null )
    {
        alert( "Error:ctrl {" + ctrl + "} does not exist!" );
        return false;    
    }

     obj.outerHTML += "<input type='text' id='" + ctrl + "_brother'/>";
     
     obj = document.getElementById(ctrl);     
     var objBrother = document.getElementById(ctrl+"_brother");
     
     __CloneStyle( obj.style, objBrother.style);
     objBrother.className = obj.className;
     objBrother.disabled = obj.disabled;
     objBrother.size = obj.size;
     objBrother.style.color = "#666666";
     objBrother.value = strTip;
     
     
     objBrother.attachEvent( 'onfocus', (function(p) 
        { 
	        return function()
	        {
	            var obj = document.getElementById(ctrl);  
	            var objBrother = document.getElementById(ctrl+"_brother");
	            obj.style.display = "";
	            objBrother.style.display = "none";
	            obj.focus();
	        };    			
        }) (ctrl)
        );
     
     obj.attachEvent( 'onblur', (function(p) 
        { 
	        return function()
	        {
	            var obj = document.getElementById(ctrl);  
	            var objBrother = document.getElementById(ctrl+"_brother");
	            
	            if( obj.value.length > 0 )
	                return;
	                
	            objBrother.style.display = "";
	            obj.style.display = "none";
	        };    			
        }) (ctrl)
        );
     
     if( obj.value.length == 0 )
     {
        obj.style.display = "none";
        objBrother.style.display = "";
     }
     else
     {
        obj.style.display = "";
        objBrother.style.display = "none";
     }   
}


function __CloneStyle( objSrc, objDest)
{
    for( obj in objSrc)
    {   
        if( obj == null || 
            objSrc[obj] == null || 
            objSrc[obj] == "" ||
            obj == "display")
        {
            continue;
        }
        
        if( typeof(obj) == 'function' )
            continue;
        
        try
        {
            objDest[obj] = objSrc[obj];  
        }
        catch(e) { }
     }
}

