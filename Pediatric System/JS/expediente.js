
$(document).ready(function () {

    //------------------------------------------Direccion de Expediente------------------------------------------//

    var direccionesEX;
    var proEXselec;
    var canEXselec;
    var disEXselec;

    //Para obtener el valor de la provincia, canton y distrito de expediente seleccionada en caso de que sea cargar un registro 
    proEXselec = $("#proEX").val();
    canEXselec = $("#canEX").val();
    disEXselec = $("#disEX").val();
    
    //Funcion para asignarle el valor a la variable proEXselected al input oculto donde se va a guardar la opcion de provincia seleccionada y asigna
    //function pasarVal() {
    //    $("#proEX").val($("#provinciasEX").val());
    //    proEXselec = $("#proEX").val();
    //}

    //Asignar el archivo JSON a una variable y cargar los datos del DropDownList de provincias
    $.getJSON("Archivos/Direcciones.json", function (datos) {
        direccionesEX = datos.DIRECCIONES;

        var provincias = direccionesEX.map(function (provincia) {
            return provincia.NOMBRE_PROVINCIA;
        });

        var sorted = provincias.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $("#provinciasEX").append(new Option("Provincia", "Provincia"));
        $.each(unique, function (key, value) {
            //$("#provinciasEX").append('<option value="' + value + '">' + value + '</option>');
            $("#provinciasEX").append(new Option(value, value));
        });
        $("#provinciasEX").val(proEXselec);

    }).done(function (data) {

        //En caso de que sea la opcion de cargar un expediente ya guardado en BD 
        if (proEXselec != "") {

            //Cargar el DropDownList de distritos con la lista de cantones de la provincia guardada
            var provinciaSeleccionada = proEXselec;

            var direccionesEXPro = direccionesEX.filter(function (provinc) {
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
                $("#cantonesEX").append(new Option(value, value));
            });
            $("#cantonesEX").val(canEXselec);

            //Cargar el DropDownList de distritos con la lista de distritos del canton guardado 
            var cantonSeleccionado = canEXselec;

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
                $("#distritosEX").append(new Option(value, value));
            });
            $("#distritosEX").val(disEXselec);
        } else {
            $("#cantonesEX").append(new Option("Cantón", "Cantón"));
            $("#distritosEX").append(new Option("Distrito", "Distrito"));
        }
    });

    $(".listaProvinciasEX").on("change", function () {
        $("#proEX").val($("#provinciasEX").val());

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

        $("#cantonesEX").append(new Option("Cantón", "Cantón"));
        $.each(unique, function (key, value) {
            $("#cantonesEX").append(new Option(value, value));
        });      
    });

    $(".listaCantonesEX").on("change", function () {
        $("#canEX").val($("#cantonesEX").val());

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

        $("#distritosEX").append(new Option("Distrito", "Distrito"));
        $.each(unique, function (key, value) {
            $("#distritosEX").append(new Option(value, value));
        });
    });

    $(".listaDistritosEX").on("change", function () {
        $("#disEX").val($("#distritosEX").val());
    });

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //------------------------------------------Direccion de Encargado------------------------------------------//

    var direccionesEN;
    var proENselec;
    var canENselec;
    var disENselec;
    var barENselec;

    proENselec = $("#proEN").val();
    canENselec = $("#canEN").val();
    disENselec = $("#disEN").val();
    barENselec = $("#barEN").val();

    $.getJSON("Archivos/Direcciones.json", function (datos) {
        direccionesEN = datos.DIRECCIONES;

        var provincias = direccionesEN.map(function (provincia) {
            return provincia.NOMBRE_PROVINCIA;
        });

        var sorted = provincias.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $("#provinciasEN").append(new Option("Provincia", "Provincia"));
        $.each(unique, function (key, value) {
            $("#provinciasEN").append(new Option(value, value));
            //$("#provinciasEN").append('<option value="' + value + '">' + value + '</option>');
        });
        $("#provinciasEN").val(proENselec);
    }).done(function (data) {

        //En caso de que sea la opcion de cargar un expediente ya guardado en BD 
        if (proENselec != "") {

            //Cargar el DropDownList de distritos con la lista de cantones de la provincia guardada
            var provinciaSeleccionada = proENselec;

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
                $("#cantonesEN").append(new Option(value, value));
            });
            $("#cantonesEN").val(canENselec);

            //Cargar el DropDownList de distritos con la lista de distritos del canton guardado 
            var cantonSeleccionado = canENselec;

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
                $("#distritosEN").append(new Option(value, value));
            });
            $("#distritosEN").val(disENselec);

            //Cargar el DropDownList de barrios con la lista de barrios del distrito guardado
            var distritoSeleccionado = disENselec;

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
                $("#barriosEN").append(new Option(value, value));
            });
            $("#barriosEN").val(barENselec);

        } else {
            $("#cantonesEN").append(new Option("Cantón", "Cantón"));
            $("#distritosEN").append(new Option("Distrito", "Distrito"));
            $("#barriosEN").append(new Option("Barrio", "Barrio"));
        }
    });

    $(".listaProvinciasEN").on("change", function () {
        $("#proEN").val($("#provinciasEN").val());
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

        $("#cantonesEN").append(new Option("Cantón", "Cantón"));
        $.each(unique, function (key, value) {
            $("#cantonesEN").append(new Option(value, value));
        });
    });

    $(".listaCantonesEN").on("change", function () {
        $("#canEN").val($("#cantonesEN").val());
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

        $("#distritosEN").append(new Option("Distrito", "Distrito"));
        $.each(unique, function (key, value) {
            $("#distritosEN").append(new Option(value, value));
        });
    });

    $(".listaDistritosEN").on("change", function () {
        $("#disEN").val($("#distritosEN").val());
        if (document.getElementById("barriosEN").options.length > 0) {
            document.getElementById("barriosEN").options.length = 0;
        }

        var distritoSeleccionado = $("#distritosEN").val();

        var direccionesENBar = direccionesEN.filter(function (cant) {
            return cant.NOMBRE_DISTRITO == distritoSeleccionado;
        });

        var barrios = direccionesENBar.map(function (barrio) {
            return barrio.NOMBRE_BARRIO;
        });

        var sorted = barrios.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $("#barriosEN").append(new Option("Barrio", "Barrio"));
        $.each(unique, function (key, value) {
            $("#barriosEN").append(new Option(value, value));
        });
    });

    $(".listaBarriosEN").on("change", function () {
        $("#barEN").val($("#barriosEN").val());
    });

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //------------------------------------------Direccion de Facturante------------------------------------------//


    var direccionesFA;
    var proFAselec;
    var canFAselec;
    var disFAselec;
    var barFAselec;

    proFAselec = $("#proFA").val();
    canFAselec = $("#canFA").val();
    disFAselec = $("#disFA").val();
    barFAselec = $("#barFA").val();

    $.getJSON("Archivos/Direcciones.json", function (datos) {
        direccionesFA = datos.DIRECCIONES;

        var provincias = direccionesFA.map(function (provincia) {
            return provincia.NOMBRE_PROVINCIA;
        });

        var sorted = provincias.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $("#provinciasFA").append(new Option("Provincia", "Provincia"));
        $.each(unique, function (key, value) {
            $("#provinciasFA").append(new Option(value, value));
        });
        $("#provinciasFA").val(proFAselec);
    }).done(function (data) {

        //En caso de que sea la opcion de cargar un expediente ya guardado en BD 
        if (proFAselec != "") {

            //Cargar el DropDownList de distritos con la lista de cantones de la provincia guardada
            var provinciaSeleccionada = proFAselec;

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
                $("#cantonesFA").append(new Option(value, value));
            });
            $("#cantonesFA").val(canFAselec);

            //Cargar el DropDownList de distritos con la lista de distritos del canton guardado 
            var cantonSeleccionado = canFAselec;

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
                $("#distritosFA").append(new Option(value, value));
            });
            $("#distritosFA").val(disENselec);

            //Cargar el DropDownList de barrios con la lista de barrios del distrito guardado
            var distritoSeleccionado = disFAselec;

            var direccionesFABarr = direccionesEN.filter(function (cant) {
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
                $("#barriosFA").append(new Option(value, value));
            });
            $("#barriosFA").val(barFAselec);

        } else {
            $("#cantonesFA").append(new Option("Cantón", "Cantón"));
            $("#distritosFA").append(new Option("Distrito", "Distrito"));
            $("#barriosFA").append(new Option("Barrio", "Barrio"));
        }
    });

    $(".listaProvinciasFA").on("change", function () {
        $("#proFA").val($("#provinciasFA").val());
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

        $("#cantonesFA").append(new Option("Cantón", "Cantón"));
        $.each(unique, function (key, value) {
            $("#cantonesFA").append(new Option(value, value));
        });
    });

    $(".listaCantonesFA").on("change", function () {
        $("#canFA").val($("#cantonesFA").val());
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

        $("#distritosFA").append(new Option("Distrito", "Distrito"));
        $.each(unique, function (key, value) {
            $("#distritosFA").append(new Option(value, value));
        });
    });

    $(".listaDistritosFA").on("change", function () {
        $("#disFA").val($("#distritosFA").val());
        if (document.getElementById("barriosFA").options.length > 0) {
            document.getElementById("barriosFA").options.length = 0;
        }

        var distritoSeleccionado = $("#distritosFA").val();

        var direccionesFABar = direccionesFA.filter(function (cant) {
            return cant.NOMBRE_DISTRITO == distritoSeleccionado;
        });

        var barrios = direccionesFABar.map(function (barrio) {
            return barrio.NOMBRE_BARRIO;
        });

        var sorted = barrios.sort();
        var unique = sorted.filter(function (value, index) {
            return value !== sorted[index + 1];
        })

        $("#barriosFA").append(new Option("Barrio", "Barrio"));
        $.each(unique, function (key, value) {
            $("#barriosFA").append(new Option(value, value));
        });
    });

    $(".listaBarriosFA").on("change", function () {
        $("#barFA").val($("#barriosFA").val());
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
            document.getElementById('descripcionOtros ').disabled = false;
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
