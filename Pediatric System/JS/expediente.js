
$(document).ready(function () {
    var direccionesEX;

    $.getJSON("Archivos/Direcciones.json", function (datos) {
        direccionesEX = datos.DIRECCIONES;

        var provincias = direccionesEX.map(function (provincia) {
            return provincia.NOMBRE_PROVINCIA;
        });

        var sorted = provincias.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#provinciasEX").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaProvinciasEX").on("change", function () {
        if (document.getElementById("cantonesEX").options.length > 0) {
            document.getElementById("cantonesEX").options.length = 0;
        }

        var provinciaSeleccionada = $("#provinciasEX").val();

        var direccionesEXPro= direccionesEX.filter(function (provinc) {
            return provinc.NOMBRE_PROVINCIA == provinciaSeleccionada;
        });

        var cantones = direccionesEXPro.map(function (canton) {
            return canton.NOMBRE_CANTON;
        });

        var sorted = cantones.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#cantonesEX").append('<option value="' + value + '">' + value + '</option>');
        });      
    });

    $(".listaCantonesEX").on("change", function () {
        if (document.getElementById("distritosEX").options.length > 0) {
            document.getElementById("distritosEX").options.length = 0;
        }

        var cantonSeleccionado = $("#cantonesEX").val();

        var direccionesEXCan = direccionesEX.filter(function (cant) {
            return cant.NOMBRE_CANTON == cantonSeleccionado;
        });

        var distritos = direccionesEXCan.map(function (distrito) {
            return distrito.NOMBRE_DISTRITO;
        });

        var sorted = distritos.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#distritosEX").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    var direccionesEN;

    $.getJSON("Archivos/Direcciones.json", function (datos) {
        direccionesEN = datos.DIRECCIONES;

        var provincias = direccionesEN.map(function (provincia) {
            return provincia.NOMBRE_PROVINCIA;
        });

        var sorted = provincias.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#provinciasEN").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaProvinciasEN").on("change", function () {
        if (document.getElementById("cantonesEN").options.length > 0) {
            document.getElementById("cantonesEN").options.length = 0;
        }

        var provinciaSeleccionada = $("#provinciasEN").val();

        var direccionesENPro = direccionesEN.filter(function (provinc) {
            return provinc.NOMBRE_PROVINCIA == provinciaSeleccionada;
        });

        var cantones = direccionesENPro.map(function (canton) {
            return canton.NOMBRE_CANTON;
        });

        var sorted = cantones.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#cantonesEN").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaCantonesEN").on("change", function () {
        if (document.getElementById("distritosEN").options.length > 0) {
            document.getElementById("distritosEN").options.length = 0;
        }

        var cantonSeleccionado = $("#cantonesEN").val();
                
        var direccionesENCan = direccionesEN.filter(function (cant) {
            return cant.NOMBRE_CANTON == cantonSeleccionado;
        });

        var distritos = direccionesENCan.map(function (distrito) {
            return distrito.NOMBRE_DISTRITO;
        });

        var sorted = distritos.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#distritosEN").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaDistritosEN").on("change", function () {
        if (document.getElementById("barriosEN").options.length > 0) {
            document.getElementById("barriosEN").options.length = 0;
        }

        var distritoSeleccionado = $("#distritosEN").val();

        var direccionesENBarr = direccionesEN.filter(function (cant) {
            return cant.NOMBRE_DISTRITO == distritoSeleccionado;
        });

        var barrios = direccionesENBarr.map(function (barrio) {
            return barrio.NOMBRE_BARRIO;
        });

        var sorted = barrios.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#barriosEN").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    var direccionesFA;

    $.getJSON("Archivos/Direcciones.json", function (datos) {
        direccionesFA = datos.DIRECCIONES;

        var provincias = direccionesFA.map(function (provincia) {
            return provincia.NOMBRE_PROVINCIA;
        });

        var sorted = provincias.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#provinciasFA").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaProvinciasFA").on("change", function () {
        if (document.getElementById("cantonesFA").options.length > 0) {
            document.getElementById("cantonesFA").options.length = 0;
        }

        var provinciaSeleccionada = $("#provinciasFA").val();

        var direccionesFAPro = direccionesFA.filter(function (provinc) {
            return provinc.NOMBRE_PROVINCIA == provinciaSeleccionada;
        });

        var cantones = direccionesFAPro.map(function (canton) {
            return canton.NOMBRE_CANTON;
        });

        var sorted = cantones.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#cantonesFA").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaCantonesFA").on("change", function () {
        if (document.getElementById("distritosFA").options.length > 0) {
            document.getElementById("distritosFA").options.length = 0;
        }

        var cantonSeleccionado = $("#cantonesFA").val();

        var direccionesFACan = direccionesFA.filter(function (cant) {
            return cant.NOMBRE_CANTON == cantonSeleccionado;
        });

        var distritos = direccionesFACan.map(function (distrito) {
            return distrito.NOMBRE_DISTRITO;
        });

        var sorted = distritos.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#distritosFA").append('<option value="' + value + '">' + value + '</option>');
        });
    });

    $(".listaDistritosFA").on("change", function () {
        if (document.getElementById("barriosFA").options.length > 0) {
            document.getElementById("barriosFA").options.length = 0;
        }

        var distritoSeleccionado = $("#distritosFA").val();

        var direccionesFABarr = direccionesFA.filter(function (cant) {
            return cant.NOMBRE_DISTRITO == distritoSeleccionado;
        });

        var barrios = direccionesFABarr.map(function (barrio) {
            return barrio.NOMBRE_BARRIO;
        });

        var sorted = barrios.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $.each(unique, function (key, value) {
            $("#barriosFA").append('<option value="' + value + '">' + value + '</option>');
        });
    });



    

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
