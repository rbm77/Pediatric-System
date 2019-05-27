
$(document).ready(function () {
    $(".datosReporteMedicinaMixta").hide();
    $(".opciones-primera-vez").hide();
    $(".datosReferenciaPrivada").hide();
    $(".guardarReferencia").hide();
    
    $("#reporte-medicina-mixta").on("change", function () {
        if ($('#reporte-medicina-mixta').prop('checked')) {
            $('.datosReporteMedicinaMixta').show();
            $(".guardarReferencia").show();
        } else {
            $('.datosReporteMedicinaMixta').hide();
            $(".guardarReferencia").hide();
        }
    });

    $("#referencia-consulta-privada").on("change", function () {
        if ($('#referencia-consulta-privada').prop('checked')) {
            $('.datosReferenciaPrivada').show();
            $(".guardarReferencia").show();
        } else {
            $('.datosReferenciaPrivada').hide();
            $(".guardarReferencia").hide();
        }
    });

    $("input[name='frecuencia-medicina-mixta']").on("change", function () {
        if ($("input[name='frecuencia-medicina-mixta']:checked").val() == "primera") {
            $('.opciones-primera-vez').show();
            $(".guardarReferencia").show();
        } else {
            $('.opciones-primera-vez').hide();
            $(".guardarReferencia").hide();
        }
    });

    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

});
