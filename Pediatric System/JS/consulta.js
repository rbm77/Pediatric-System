
$(document).ready(function () {
    //$(".datosReporteMedicinaMixta").hide();
    //$(".opciones-primera-vez").hide();
    //$(".datosReferenciaPrivada").hide();
    //$(".guardarReferencia").hide();

    $(".datosReporteMedicinaMixta").find("*").prop('disabled', true); 
    $(".datosReferenciaPrivada").find("*").prop('disabled', true); 

    if ($('#reporte_medicina_mixta').prop('checked')) {
        $("#btnGenerarReferencia").prop('disabled', false);
    }

    $("#reporte_medicina_mixta").on("change", function () {
        if ($('#reporte_medicina_mixta').prop('checked')) {
            $(".datosReporteMedicinaMixta").find("*").prop('disabled', false); 
        } else {
            $(".datosReporteMedicinaMixta").find("*").prop('disabled', true); 
        }
    });

    $("#referencia_consulta_privada").on("change", function () {
        if ($('#referencia_consulta_privada').prop('checked')) {
            $(".datosReferenciaPrivada").find("*").prop('disabled', false); 
        } else {
            $(".datosReferenciaPrivada").find("*").prop('disabled', true); 
        }
    });

    $("#calcIM").on("click", function () {
        if (parseInt($("#tallaPac").val()) == 0 || parseInt($("#pesoPac").val()) == 0) {
            $("#imcPac").val("0");
        } else {
            var temp = (parseInt($("#tallaPac").val()) * parseInt($("#pesoPac").val()));
            $("#imcPac").val(temp);
        }
    });


    //$("input[name='frecuencia-medicina-mixta']").on("change", function () {
    //    if ($("input[name='frecuencia-medicina-mixta']:checked").val() == "primera") {
    //        $('.opciones-primera-vez').show();
    //        $(".guardarReferencia").show();
    //    } else {
    //        $('.opciones-primera-vez').hide();
    //        $(".guardarReferencia").hide();
    //    }
    //});

    //$(".custom-file-input").on("change", function () {
    //    var fileName = $(this).val().split("\\").pop();
    //    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    //});

});
