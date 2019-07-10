$(document).ready(function () {

    

    $('.visualizacionTitulo').hide();
    $('.visualizacion-medicina-mixta').hide();
    $('.visualizacion-boleta-ve02').hide();
    $('.btnGenerarReporte').hide();
    

    $(".seleccionReporte").on("change", function () {
        $('.visualizacionTitulo').show();
        $('.btnGenerarReporte').show();
    });
    
    $(".seleccionReporte").on("change", function () {
        if (this.value == "ve02") {
            
            $('.visualizacion-boleta-ve02').show();
        } else {
            
            $('.visualizacion-boleta-ve02').hide();
        }
    });

    $(".seleccionReporte").on("change", function () {
        if (this.value == "medicinaMixta") {
            
            $('.visualizacion-medicina-mixta').show();
        } else {
            
            $('.visualizacion-medicina-mixta').hide();
        }
    });

    

    $('.datepicker').datepicker({
        uiLibrary: 'bootstrap4',
        locale: 'es-es',
        format: 'dd/mm/yyyy'
    });

});