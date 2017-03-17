/**
 * Rutas de imagenes - Tipo de Material & Excitación
 * Autor: Santiago Quiñones
*/
var RUTA_ESQUEMA_MATERIAL_ELASTICO = "../Imagenes/General/VersiónEN/FigTM1_EN.png";
var RUTA_ESQUEMA_MATERIAL_BILINEAR_1 = "../Imagenes/General/VersiónEN/FigTM2_EN.png";
var RUTA_ESQUEMA_MATERIAL_BILINEAR_2 = "../Imagenes/General/VersiónEN/FigTM3_EN.png";

var RUTA_ESQUEMA_EXITACION_LINEAR = "../Imagenes/General/VersiónEN/FigTE1_EN.png";
var RUTA_ESQUEMA_EXITACION_TRI_LINEAR = "../Imagenes/General/VersiónEN/FigTE2_EN.png";
var RUTA_ESQUEMA_EXITACION_HARMONIC = "../Imagenes/General/VersiónEN/FigTE3_EN.png";
var RUTA_ESQUEMA_EXITACION_ACCELERATION = "../Imagenes/General/VersiónEN/FigTE4_EN.png";

/**
 * Configuración inicial en tipo de material
 * Autor: Santiago Quiñones
*/
$("#FigMat1").attr("src", RUTA_ESQUEMA_MATERIAL_ELASTICO);
$('#panBlineal1').hide("fast");
$('#panBlineal2').hide("fast");

/**
* Show and Hide Ctrl. Tipo Material
* Autor: Santiago Quiñones
*/
function HideCtrlsTipoMaterial() {
    var categoria = Number(document.getElementById("DDLmatTyp").value);
    console.log(categoria);

    if (categoria == 0) {
        $("#FigMat1").attr("src", RUTA_ESQUEMA_MATERIAL_ELASTICO);
        $('#panBlineal1').hide("fast");
        $('#panBlineal2').hide("fast");
    } else if (categoria == 1) {
        $("#FigMat1").attr("src", RUTA_ESQUEMA_MATERIAL_BILINEAR_1);
        $('#panBlineal1').show("fast");
        $('#panBlineal2').hide("fast");
    } else {
        $("#FigMat1").attr("src", RUTA_ESQUEMA_MATERIAL_BILINEAR_2);
        $('#panBlineal1').hide("fast");
        $('#panBlineal2').show("fast");

    }
}

/**
 * Configuración inicial en tipo de excitación
 * Autor: Santiago Quiñones
*/
$("#FigExi1").attr("src", RUTA_ESQUEMA_EXITACION_LINEAR);
$('#panFL').show("fast");
$('#panFT').hide("fast");
$('#panFS').hide("fast");
$('#panAC').hide("fast");

/**
* Show and Hide Ctrl. Tipo Excitación
* Autor: Santiago Quiñones
*/
function HideCtrlsTipoExcitation() {
    var categoria = Number(document.getElementById("DDLexiTyp").value);
    console.log(categoria);


   

    if (categoria == 0) {
        $("#FigExi1").attr("src", RUTA_ESQUEMA_EXITACION_LINEAR);
        $('#panFL').show("fast");
        $('#panFT').hide("fast");
        $('#panFS').hide("fast");
        $('#panAC').hide("fast");
        
    } else if (categoria == 1) {
        $("#FigExi1").attr("src", RUTA_ESQUEMA_EXITACION_TRI_LINEAR);
        $('#panFL').hide("fast");
        $('#panFT').show("fast");
        $('#panFS').hide("fast");
        $('#panAC').hide("fast");
        
    } else if (categoria == 2) {
        $("#FigExi1").attr("src", RUTA_ESQUEMA_EXITACION_HARMONIC);
        $('#panFL').hide("fast");
        $('#panFT').hide("fast");
        $('#panFS').show("fast");
        $('#panAC').hide("fast");

    } else {
        $("#FigExi1").attr("src", RUTA_ESQUEMA_EXITACION_ACCELERATION);
        $('#panFL').hide("fast");
        $('#panFT').hide("fast");
        $('#panFS').hide("fast");
        $('#panAC').show("fast");
    }
}



function loadExample() {


}


$(document).ready(function () {
    /**
    * Cargar el ejemplo
    * Autor: Santiago Quiñones
    */
    $('#ibtnLoadExample').click(function () {
        console.log("Cargando ejemplo.");
        $('#txtM1').val(10);
        $('#txtM2').val(9);
        $('#txtK1').val(5000);
        $('#txtK2').val(4000);

        $('#txtC1').val(50);
        $('#txtC2').val(40);
        $('#txtDA').val(15);
        

        Fy = 200;
        r = 0.02;
        Ro = 14;

        I = 10;
        DI = 11;

        Pmax = 100;
        t1 = 3;
        t2 = 5;
        t3 = 7;

        Pomax = 70;
        w = 10;

        Dace = 10;
        Pace = 0.01;
        face = 9.81;

        var categoriaMaterial = Number(document.getElementById("DDLmatTyp").value);
        var categoriaExitacion = Number(document.getElementById("DDLexiTyp").value);

        switch (categoriaExitacion) {
            case 0:
                $('#txtI').val(I);
                $('#txtDI').val(DI);
                break;
            case 1:
                $('#txtFmax').val(Pmax);
                $('#txtT1').val(t1);
                $('#txtT2').val(t2);
                $('#txtT3').val(t3);
                break;
            case 2:
                $('#txtFo').val(Pomax);
                $('#txtWa').val(w);
                break;
            case 3:
                $('#txtdAC').val(Dace);
                $('#txtpasoAC').val(Pace);
                $('#txtfacAC').val(face);
                break;
            
        }
        
        switch (categoriaMaterial) {
            case 1:
                $('#txtFy1').val(Fy);
                $('#txtr1').val(r);
                $('#txtFy2').val(Fy - 100);
                $('#txtr2').val(r);
                break;
            case 2:
                $('#txtFy1M3').val(Fy);
                $('#txtr1M3').val(r);
                $('#txtFy2M3').val(Fy - 100);
                $('#txtr2M3').val(r);
                $('#txtRo1').val(Ro + 2);
                $('#txtRo2').val(Ro);
                break;
            case 3:
                $('#txtdAC').val(Dace);
                $('#txtpasoAC').val(Pace);
                $('#txtfacAC').val(face);
                break;

        }
        
        
    });
});