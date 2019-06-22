
$(document).ready(function () {

    //$('.complicacionPerinatal').hide();
    //$('textarea[name="descripcionPatologicos"]').attr('disabled', true);
    document.getElementById("complicacionPerinatal").disabled = "true";
    document.getElementById("descripcionPatologicos").disabled = "true";
    document.getElementById("descripcionQuirurgico").disabled = "true";
    document.getElementById("descripcionTraumatico").disabled = "true";
    document.getElementById("descripcionOtros").disabled = "false";
    document.getElementById("descripcionAlergia").disabled = "true";
  //  document.getElementById("txtCodigo").disabled = "true";
  //  document.getElementById("descripcionVacuna").disabled = "true";
    //$('.descripcionVacuna').hide();
   
    


    $(".estadoPerinatal").on("change", function () {
        if (this.value == "ausentes") {
            document.getElementById('complicacionPerinatal').setAttribute("disabled", "disabled");
        } else {
            document.getElementById("complicacionPerinatal").removeAttribute("disabled");
        }
    });

    $(".antecedentePatologico").on("change", function () {
        if (this.value == "ausentesPat") {

            document.getElementById('descripcionPatologicos').setAttribute("disabled", "disabled");
        } else {
            document.getElementById("descripcionPatologicos").removeAttribute("disabled");
        }
    });

    $(".antecedenteQuirurgico").on("change", function () {
        if (this.value == "ausentesQui") {
            document.getElementById('descripcionQuirurgico').setAttribute("disabled", "disabled");
        } else {
            document.getElementById("descripcionQuirurgico").removeAttribute("disabled");
        }
    });
    
    $(".antecedenteTraumatico").on("change", function () {
        if (this.value == "ausentesTrau") {
            document.getElementById('descripcionTraumatico').setAttribute("disabled", "disabled");
        } else {
            document.getElementById("descripcionTraumatico").removeAttribute("disabled");
        }
    });
    

    //$(".SeleccionarRol").on("change", function () {
    //    if (this.value == "Medico") {
    //        document.getElementById('txtCodigo').disabled = false;
    //    } else {
    //        document.getElementById("txtCodigo").disabled = true;
    //    }
    //});


    $("#otrosCheck").on("change", function () {
        if ($('#otrosCheck').prop('checked')) {
            document.getElementById('descripcionOtros').disabled = false;
        } else {
            document.getElementById('descripcionOtros').disabled = true;
        }
    });

    

    $(".alergiasExpediente").on("change", function () {
        if (this.value == "ausentesAlergia") {
            document.getElementById('descripcionAlergia').setAttribute("disabled", "disabled");
        } else {
            document.getElementById("descripcionAlergia").removeAttribute("disabled");
        }
    });


 


    //descripcionVacuna
    //$(".vacunasExpediente").on("change", function () {
    //    if (this.value == "esquemaAlDia") {
    //        document.getElementById('descripcionAlergia').setAttribute("disabled", "disabled");
    //    } else {
    //        document.getElementById("descripcionAlergia").removeAttribute("disabled");
    //    }
    //});

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
