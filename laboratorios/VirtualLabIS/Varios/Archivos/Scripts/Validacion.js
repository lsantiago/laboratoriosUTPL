    var valFormulario=false;
    function ForzarEntrada(objField, Message)
    {
        
        var strField = new String(objField.value);
        if (tieneEspacioBlanco(strField)) {
            alert(Message);
            objField.focus();
            objField.select();
            return false;
        }
        return true;
    }
    
    function tieneEspacioBlanco (s)
    { 
        var i;
        s = s.replace(/ /g,""); //Para evitar el problema con la validacion del formato de los valores ingresados
        //alert(s.length);
        if (s.length==0){
            return true;
        }

        for (i = 0; i < s.length; i++)
        {
            
            var c = s.charAt(i);
            if (c == ' ') return true;
        }
        return false;
    }
    
    function validar()
    {
        var cansubmit = false;
        cansubmit = ForzarEntrada(document.frmMain.txtSectionDiameter,"Enter the SECTION DIAMETER!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtConvertLB,"Enter the COVER!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtLongBarDiameter,"Enter the LONGITUDINAL REBAR DIAMETER!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtNumberLongBars,"Enter the  NUMERO DE BARILLAS LONGITUDINAL!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtTransverseReinfDiam,"Enter the # LONGITUDINAL REBARS!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtSpacingTransSteel,"Enter the SPACING OF TRANSVERSE REBAR!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtConcrComprStrength,"Enter the UNCONFINED COMPRESION CONCRETE STRENGTH!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtLongRYS,"Enter the YIELD STRESS OF LONGITUDINAL REBAR!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtTransRYS,"Enter the YIELD STRESS OF TRANSVERSE REBAR!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtLongRMX,"Enter the ULIMATE TENSION STRENGTH OF LONGITUDINAL REBAR!");
        if (cansubmit) cansubmit = ForzarEntrada(document.frmMain.txtAxialLoad,"Enter the AXIAL LOAD!");
        
        return cansubmit;
    }
    
    function simular()
    {
        var doc = document.forms[0];

        var valid = validar();
        
        if (valid)
        {
            //alert("Todo esta bien");
            //document.frmMain.submit(); //se traslada el formulario al servidor
            doc.submit();
            return true;
        }
        else{
           //alert("algo esta mal");
           return false; 
        }
        
        
    }
  

  
  function formatoCorrecto (objField){
    
    var strField = new String(objField.value);
    if (isNaN(strField)){
        alert("Invalid Value");
        objField.focus();
        objField.value="";
        //objField.select();
    }
  }
  
  

function PermitirSoloNumeros(event)
 {	
	var nKey;
	nKey = window.event.keyCode;
    //alert(nKey);
	//Existe un error si permite ingresar los carcateres  que se encuentran sobre las teclas de la fila numerica del teclado
	if ((nKey >= 48 && nKey <= 57)  || (nKey == 190) || (nKey == 8)|| (nKey == 13)|| (nKey == 16)|| (nKey == 9)|| (nKey == 46) || (nKey == 189)|| (nKey==39)|| (nKey==37) || (nKey >= 96 && nKey <= 105) || (nKey==110)  ) //Para permitir número enteros  y decimales  ( 8 = punto; 13=enter; 190 = delete; 189 = -; 37 = <-; 39 = ->)
		{			
			window.event.keyCode = nKey;
		}
	else
	return false;
}





function PermitirNumeros(event){
	var nKey;
	nKey = window.event.keyCode;
	if ((nKey >= 48 && nKey <= 57) )
			{			
				var c = String.fromCharCode(nKey);
				//c = c.toLowerCase();			
				window.event.keyCode= c.charCodeAt(0);			
			}
	else return false;	
}
    