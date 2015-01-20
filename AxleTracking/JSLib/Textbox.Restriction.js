/************************************************************
 * Javascript Lib V1.2
 * CONTACT: jerry.wang@clochase.com
 *
 * These are textbox with restriction
 *
 * InitializeTextbox( "TextboxID", InputType.NonnegativeInteger);
 * InitializeTextbox( "TextboxID", InputType.WholeNumber);
 * InitializeTextbox( "TextboxID", InputType.Currency); 
 ************************************************************/




$import( "Textbox.Common.js" );



// the input type of the text box
InputType =
{
    NonnegativeInteger   : 0,
    WholeNumber          : 1,
    AlphaNumeric         : 2,
    Currency             : 3

};
 


//-------------------------------------------------------------------------
// Function Name    :InitializeTextbox
// Parameter(s)     :ctrl         the ctrl id or the ctrl instance
//                  :emType     the InputType
// Return           :bool
//-------------------------------------------------------------------------
function InitializeTextbox( ctrl, emType)
{
    var obj = typeof(ctrl) == "string" ? document.getElementById(ctrl) : ctrl;
    if( obj == null )
    {
        alert( "Error:ctrl {" + ctrl + "} does not exist!" );
        return false;    
    }
    
    obj.attachEvent( 'onkeydown', function(){ eval('__SaveKeyCode(event);') });
    
    // disbale the actocomplete & paste & drag & drop for IE
    if( document.all )
    {
        obj.setAttribute( "autocomplete",  "off");
        obj.onpaste = function(){ return false; };
        obj.ondrag = function(){ return false; };
        obj.ondrop = function(){ return false; };
    }
    

    switch(emType)
    {
        case InputType.NonnegativeInteger:
            obj.attachEvent( 'onkeypress', function(){ eval('__AcceptNonnegativeInteger(event);'); });
            break;
            
        case InputType.WholeNumber:
            obj.attachEvent( 'onkeypress', function(){ eval('__AcceptWholeNumber(event);'); });
            break;
            
        case InputType.AlphaNumeric:
            obj.attachEvent( 'onkeypress', function(){ eval('__AcceptAlphaNumeric(event);'); });
            break;


        case InputType.Currency:
            obj.attachEvent( 'onkeypress', function(){ eval('__AcceptCurrency(event);'); });
               

            obj.attachEvent( 'onblur', (function(p) 
            { 
		        return function()
		        {
		            if( p.value.length == 0 )
		                p.value = "0.00";		
		            else
		            {
		                var nIndex = p.value.indexOf('.');
		                if( nIndex == 0 )
		                {
		                    p.value = "0" + p.value;
		                    p.value = p.value.substring( 0, nIndex + 3);
		                }
		                else if( nIndex > 0 )
		                {
	                        p.value = p.value.substring( 0, nIndex + 3);            
		                }
		                else
		                {
		                    p.value = p.value + ".00";			        
		                }
    			        
		                var offset = p.value.length - p.value.lastIndexOf('.') - 1;
		                for( var k = offset; k < 2; k++)
		                {
		                    p.value = p.value + "0";		        
		                };
		            }
		        };    			
	        }) (obj)
	        );
            break;            
            
        default:
            alert( "Error:unknown input type {" + emType + "}!" );
            return false; 
    }; 
    
    return true;
 }



///////////////////////////////////////////////////////////////////////////////////////////////


//-------------------------------------------------------------------------
// Function Name    :__AcceptNonnegativeInteger
// Parameter(s)     :evt        event
// Return           :bool
// Memo             :Only accepted nonnegative integer
//-------------------------------------------------------------------------
function __AcceptNonnegativeInteger(evt)
{
    if( evt.shiftKey )
    {
        __EnableKeys( evt,
            [ 
                VKeyCode.VK_LEFT,
                VKeyCode.VK_RIGHT,
                VKeyCode.VK_BACK,
                VKeyCode.VK_DELETE,
                VKeyCode.VK_NUMLOCK,
                VKeyCode.VK_HOME,
                VKeyCode.VK_END,
                VKeyCode.VK_TAB
            ]
            );
    }
    else
    {
        __EnableKeys( evt,
            [ 
                VKeyCode.VK_0,
                VKeyCode.VK_1,
                VKeyCode.VK_2,
                VKeyCode.VK_3,
                VKeyCode.VK_4,
                VKeyCode.VK_5,
                VKeyCode.VK_6,
                VKeyCode.VK_7,
                VKeyCode.VK_8,
                VKeyCode.VK_9,
                VKeyCode.VK_NUMPAD0,
                VKeyCode.VK_NUMPAD1,                     
                VKeyCode.VK_NUMPAD2,
                VKeyCode.VK_NUMPAD3,
                VKeyCode.VK_NUMPAD4,
                VKeyCode.VK_NUMPAD5,
                VKeyCode.VK_NUMPAD6,
                VKeyCode.VK_NUMPAD7,
                VKeyCode.VK_NUMPAD8,
                VKeyCode.VK_NUMPAD9,
                VKeyCode.VK_LEFT,
                VKeyCode.VK_RIGHT,
                VKeyCode.VK_BACK,
                VKeyCode.VK_DELETE,
                VKeyCode.VK_NUMLOCK,
                VKeyCode.VK_HOME,
                VKeyCode.VK_END,
                VKeyCode.VK_TAB
            ]
            );    
    }// if_else    
}// __AcceptNonnegativeInteger


//-------------------------------------------------------------------------
// Function Name    :__AcceptWholeNumber
// Parameter(s)     :evt        event
// Return           :bool
// Memo             :Accepted whole numbers
//-------------------------------------------------------------------------
function __AcceptWholeNumber(evt)
{   
    var obj = evt.srcElement == null ? evt.target : evt.srcElement;
    if( __GetKeyCode(evt) == VKeyCode.VK_SUBTRACT ||
        __GetKeyCode(evt) == VKeyCode.VK_OEM_MINUS )
    {
        if( __GetCursorStartPos(evt) == 0 &&
            __GetCursorEndPos(evt) == 0 &&
            obj.value.indexOf('-') < 0 &&
            !evt.shiftKey )
        {
            return true;
        };
        
        if( __GetCursorStartPos(evt) == 0 &&
            __GetCursorEndPos(evt) > 0 &&
            !evt.shiftKey )
        {
            return true;
        };
            
        if( evt.preventDefault ) { evt.preventDefault(); }
        evt.returnValue = false;
        return false;
    }

    return __AcceptNonnegativeInteger(evt);
}// __AcceptWholeNumber


//-------------------------------------------------------------------------
// Function Name    :__AcceptAlphaNumeric
// Parameter(s)     :evt        event
// Return           :bool
// Memo             :Accepted whole numbers
//-------------------------------------------------------------------------
function __AcceptAlphaNumeric(evt)
{   
    if( evt.shiftKey )
    {
        __EnableKeys( evt,
            [ 
                VKeyCode.VK_A,
                VKeyCode.VK_B,
                VKeyCode.VK_C,
                VKeyCode.VK_D,
                VKeyCode.VK_E,
                VKeyCode.VK_F,
                VKeyCode.VK_G,
                VKeyCode.VK_H,
                VKeyCode.VK_I,
                VKeyCode.VK_J,
                VKeyCode.VK_K,
                VKeyCode.VK_M,
                VKeyCode.VK_A,
                VKeyCode.VK_B,
                VKeyCode.VK_C,
                VKeyCode.VK_D,
                VKeyCode.VK_E,
                VKeyCode.VK_F,
                VKeyCode.VK_G,
                VKeyCode.VK_H,
                VKeyCode.VK_I,
                VKeyCode.VK_J,
                VKeyCode.VK_K,
                VKeyCode.VK_M,
                VKeyCode.VK_N,
                VKeyCode.VK_O,
                VKeyCode.VK_P,
                VKeyCode.VK_Q,
                VKeyCode.VK_R,
                VKeyCode.VK_S,
                VKeyCode.VK_T,
                VKeyCode.VK_U,
                VKeyCode.VK_V,
                VKeyCode.VK_W,
                VKeyCode.VK_X,
                VKeyCode.VK_Y,
                VKeyCode.VK_Z,
                VKeyCode.VK_LEFT,
                VKeyCode.VK_RIGHT,
                VKeyCode.VK_BACK,
                VKeyCode.VK_DELETE,
                VKeyCode.VK_NUMLOCK,
                VKeyCode.VK_HOME,
                VKeyCode.VK_END,
                VKeyCode.VK_TAB
            ]
            );
    }
    else
    {
        __EnableKeys( evt,
            [ 
                VKeyCode.VK_0,
                VKeyCode.VK_1,
                VKeyCode.VK_2,
                VKeyCode.VK_3,
                VKeyCode.VK_4,
                VKeyCode.VK_5,
                VKeyCode.VK_6,
                VKeyCode.VK_7,
                VKeyCode.VK_8,
                VKeyCode.VK_9,
                VKeyCode.VK_A,
                VKeyCode.VK_B,
                VKeyCode.VK_C,
                VKeyCode.VK_D,
                VKeyCode.VK_E,
                VKeyCode.VK_F,
                VKeyCode.VK_G,
                VKeyCode.VK_H,
                VKeyCode.VK_I,
                VKeyCode.VK_J,
                VKeyCode.VK_K,
                VKeyCode.VK_M,
                VKeyCode.VK_A,
                VKeyCode.VK_B,
                VKeyCode.VK_C,
                VKeyCode.VK_D,
                VKeyCode.VK_E,
                VKeyCode.VK_F,
                VKeyCode.VK_G,
                VKeyCode.VK_H,
                VKeyCode.VK_I,
                VKeyCode.VK_J,
                VKeyCode.VK_K,
                VKeyCode.VK_M,
                VKeyCode.VK_N,
                VKeyCode.VK_O,
                VKeyCode.VK_P,
                VKeyCode.VK_Q,
                VKeyCode.VK_R,
                VKeyCode.VK_S,
                VKeyCode.VK_T,
                VKeyCode.VK_U,
                VKeyCode.VK_V,
                VKeyCode.VK_W,
                VKeyCode.VK_X,
                VKeyCode.VK_Y,
                VKeyCode.VK_Z,
                VKeyCode.VK_NUMPAD0,
                VKeyCode.VK_NUMPAD1,                     
                VKeyCode.VK_NUMPAD2,
                VKeyCode.VK_NUMPAD3,
                VKeyCode.VK_NUMPAD4,
                VKeyCode.VK_NUMPAD5,
                VKeyCode.VK_NUMPAD6,
                VKeyCode.VK_NUMPAD7,
                VKeyCode.VK_NUMPAD8,
                VKeyCode.VK_NUMPAD9,
                VKeyCode.VK_LEFT,
                VKeyCode.VK_RIGHT,
                VKeyCode.VK_BACK,
                VKeyCode.VK_DELETE,
                VKeyCode.VK_NUMLOCK,
                VKeyCode.VK_HOME,
                VKeyCode.VK_END,
                VKeyCode.VK_TAB
            ]
            );    
    }// if_else    
}// __AcceptAlphaNumeric




//-------------------------------------------------------------------------
// Function Name    :__AcceptCurrency
// Parameter(s)     :evt        event
// Return           :bool
// Memo             :Accepted Currency
//-------------------------------------------------------------------------
function __AcceptCurrency(evt)
{
    var obj = evt.srcElement == null ? evt.target : evt.srcElement;
   
    if( evt.shiftKey )
    {
        return __EnableKeys( evt,
            [ 
                VKeyCode.VK_LEFT,
                VKeyCode.VK_RIGHT,
                VKeyCode.VK_BACK,
                VKeyCode.VK_DELETE,
                VKeyCode.VK_NUMLOCK,
                VKeyCode.VK_HOME,
                VKeyCode.VK_END,
                VKeyCode.VK_TAB
            ]
            );
    }
    
    if( __GetKeyCode(evt) == VKeyCode.VK_OEM_PERIOD ||
        __GetKeyCode(evt) == VKeyCode.VK_DECIMAL )
    {
        if( evt.shiftKey )
        {
            if( evt.preventDefault ) { evt.preventDefault(); }
            evt.returnValue = false;
            return false;
        }
            
        if( obj.value.indexOf('.') < 0 )
            return true;
            
        if( obj.value.indexOf('.') >= 0 )
        {
            if( __GetCursorStartPos(evt) <= obj.value.indexOf('.') &&
                __GetCursorEndPos(evt) >= obj.value.indexOf('.') )
            {
                return true;           
            };
           
            if( evt.preventDefault ) { evt.preventDefault(); }
            evt.returnValue = false;
            return false;
        }
        else
        {
            return true;
        }
    }
       
    
    return __AcceptNonnegativeInteger(evt);
}// __AcceptCurrency

