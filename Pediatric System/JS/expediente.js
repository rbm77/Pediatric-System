
$(document).ready(function () {

    $('.complicacionPerinatal').hide();
    $('.descripcionPatologicos').hide();
    $('.descripcionQuirurgico').hide();
    $('.descripcionTraumatico').hide();
    $('.descripcionOtros').hide();
    $('.descripcionAlergia').hide();
    $('.descripcionVacuna').hide();


   

    $(".estadoPerinatal").on("change", function () {
        if (this.value == "ausentes") {
            $('.complicacionPerinatal').hide();
        } else {
            $('.complicacionPerinatal').show();
        }
    });

    $(".antecedentePatologico").on("change", function () {
        if (this.value == "ausentesPat") {
            $('.descripcionPatologicos').hide();
        } else {
            $('.descripcionPatologicos').show();
        }
    });

    $(".antecedenteQuirurgico").on("change", function () {
        if (this.value == "ausentesQui") {
            $('.descripcionQuirurgico').hide();
        } else {
            $('.descripcionQuirurgico').show();
        }
    });

    $(".antecedenteTraumatico").on("change", function () {
        if (this.value == "ausentesTrau") {
            $('.descripcionTraumatico').hide();
        } else {
            $('.descripcionTraumatico').show();
        }
    });

    $("#otrosCheck").on("change", function () {
        if ($('#otrosCheck').prop('checked')) {
            $('.descripcionOtros').show();
        } else {
            $('.descripcionOtros').hide();
        }
    });

    $(".alergiasExpediente").on("change", function () {
        if (this.value == "ausentesAlergia") {
            $('.descripcionAlergia').hide();
        } else {
            $('.descripcionAlergia').show();
        }
    });

    $(".vacunasExpediente").on("change", function () {
        if (this.value == "esquemaAlDia") {
            $('.descripcionVacuna').hide();
        } else {
            $('.descripcionVacuna').show();
        }
    });

    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

    //$('#datepicker').datepicker({
    //    uiLibrary: 'bootstrap4',
    //    locale: 'es-es',
    //    format: 'dd/mm/yyyy'
    //});
});
