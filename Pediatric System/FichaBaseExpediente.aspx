<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaBaseExpediente.aspx.cs" Inherits="Pediatric_System.FichaBaseExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript" src="JS/expediente.js"></script>
    <%--<link rel="stylesheet" type="text/css" href="css/main.css" />--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Expediente</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <!-- Inicio del titulo de los Tabs !-->

        <div class="margen-general-2-top">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active tabs-fichas" id="info-personal-paciente-tab" data-toggle="tab" href="#info-personal-paciente" role="tab" aria-controls="info-personal-paciente" aria-selected="true">Información del Paciente</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link tabs-fichas" id="info-personal-encargado-tab" data-toggle="tab" href="#info-personal-encargado" role="tab" aria-controls="info-personal-encargado" aria-selected="false">Información del Encargado</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link tabs-fichas" id="info-personal-facturante-tab" data-toggle="tab" href="#info-personal-facturante" role="tab" aria-controls="info-personal-facturante" aria-selected="false">Información del Facturante</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link tabs-fichas" id="historia-clinica-tab" data-toggle="tab" href="#historia-clinica" role="tab" aria-controls="historia-clinica" aria-selected="false">Historia Clínica</a>
                </li>
            </ul>
        </div>



        <!-- ----------------------------------------------------------- !-->

        <!-- Incio del contenido de los Tabs !-->

        <div class="tab-content" id="myTabContent">

            <!-- Datos para la Informacion Personal del Paciente !-->

            <div class="tab-pane fade show active margen-general-1-top margen-general-1-botton" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab">

                <div class="col-12 border rounded margen-general-2-top">

                    <div class="form-row margen-general-1-top">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-label">Nombre</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-label">Primer Apellido</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-label">Segundo Apellido</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-label">Cédula</label>
                                <input type="text" class="form-control" placeholder="1-0234-0456">
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-label">Fecha de Nacimiento</label>
                                <input class="form-control" id="datepicker" placeholder="31/12/2018" />
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-label">Sexo</label>
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Seleccionar Sexo</option>
                                    <option value="Femenino">Femenino</option>
                                    <option value="Maculino">Masculino</option>
                                    <option value="Otro">Otro</option>
                                </select>
                            </div>
                        </div>
                    </div>



                    <div class="card margen-general-2-top margen-general-1-botton">

                        <label class="nombre-label card-header">Dirección</label>

                        <div class="form-row card-body">
                            <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                <div class="padding-general-label">
                                    <select class="browser-default custom-select">
                                        <option value="" disabled selected>Provincia</option>
                                    </select>
                                </div>
                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                <div class="padding-general-label">
                                    <select class="browser-default custom-select">
                                        <option value="" disabled selected>Cantón</option>
                                    </select>
                                </div>
                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                <div class="padding-general-label">
                                    <select class="browser-default custom-select">
                                        <option value="" disabled selected>Distrito</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card margen-general-2-top margen-general-1-botton">

                        <label class="card-header nombre-input">Otro</label>

                        <div class="card-body">
                            <div class="form-row ">
                                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Foto del Paciente</label>
                                        <div class="custom-file">
                                            <input type="file" class="custom-file-input" id="subirExamenFisico"
                                                aria-describedby="inputGroupFileAddon01">
                                            <label class="custom-file-label" for="inputGroupFile01" data-browse="Buscar">Seleccionar Archivo</label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Vincular expediente antiguo</label>
                                        <input type="text" class="form-control" placeholder="URL del expdiente antiguo">
                                    </div>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <a class="url" href="ListaConsultas.aspx" style="font-size: 16px; font-weight: bold; color: #56baed;">Ver consultas del paciente</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- ----------------------------------------------------------- !-->

            <!-- Datos para Informacion Personal del Encargado del Paciente !-->

            <div class="tab-pane fade margen-general-1-top margen-general-1-botton" id="info-personal-encargado" role="tabpanel" aria-labelledby="info-personal-encargado-tab">

                <div class="col-12 bg-light border border-info rounded margen-general-2-top">

                    <div class="form-row margen-general-2-top">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Nombre</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Primer Apellido</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Segundo Apellido</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Cédula</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Teléfono</label>
                            <input type="text" class="form-control" placeholder="12345678">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Correo Electrónico</label>
                            <input type="text" class="form-control" placeholder="ejm@gmail.com">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Parentezco</label>
                            <input type="text" class="form-control" placeholder="Padre, Madre, Encargado(a)...">
                        </div>
                    </div>
                </div>

                <div class="col-12 bg-light border border-info rounded margen-general-2-top">

                    <label class="margen-general-2-top nombre-input">Dirección</label>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Provincia</option>
                            </select>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Cantón</option>
                            </select>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Distrito</option>
                            </select>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Barrio</option>
                            </select>
                        </div>
                    </div>
                </div>

            </div>

            <!-- ----------------------------------------------------------- !-->

            <!-- Datos para Informacion Personal del Destinatario de la Factura !-->

            <div class="tab-pane fade margen-general-1-top margen-general-1-botton" id="info-personal-facturante" role="tabpanel" aria-labelledby="info-personal-facturante">

                <div class="col-12 bg-light border border-info rounded margen-general-2-top">

                    <div class="form-row margen-general-2-top">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Nombre</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Primer Apelido</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Segundo Apelido</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Cédula</label>
                            <input type="text" class="form-control" placeholder="1-0234-0456">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Teléfono</label>
                            <input type="text" class="form-control" placeholder="12345678">
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <label class="nombre-input">Correo Electrónico</label>
                            <input type="text" class="form-control" placeholder="ejm@gmail.com">
                        </div>
                    </div>
                </div>

                <div class="col-12 bg-light border border-info rounded margen-general-2-top">

                    <label class="nombre-input margen-general-2-top">Dirección</label>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Provincia</option>
                            </select>

                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Cantón</option>
                            </select>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Distrito</option>
                            </select>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <select class="browser-default custom-select">
                                <option value="" disabled selected>Barrio</option>
                            </select>
                        </div>
                    </div>
                </div>

            </div>

            <!-- ----------------------------------------------------------- !-->

            <!-- Datos para Historia Clinica Pediatrica !-->

            <div class="tab-pane fade margen-general-1-top" id="historia-clinica" role="tabpanel" aria-labelledby="historia-clinica-tab">

                <div class="col-12 bg-light border border-info rounded margen-general-2-top">

                    <div class="margen-general-2-top">
                        <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Perinatales</label>
                    </div>

                    <div class="col-12 border">
                        <div class="form-row margen-general-2-top">
                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Talla al nacer</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Peso al nacer</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Perímetro cefálico al nacer</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Calificación universal</label>
                                <select class="clasificacionUniversalOpciones browser-default custom-select margen-general-1-botton">
                                    <option value="termino" selected>Recién nacido de término</option>
                                    <option value="pretermino">Recién nacido de pretérmino</option>
                                    <option value="postermino">Recién nacido de postérmino</option>
                                </select>

                                <div>
                                    <div class="form-check-inline">
                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-pequeño" value="pequeño">
                                            <label class="form-check-label nombre-input" for="opciones-tamaño">Pequeño</label>
                                        </div>
                                    </div>

                                    <div class="form-check form-check-inline">
                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-adecuado" value="adecuado" checked>
                                            <label class="form-check-label nombre-input" for="opciones-tamaño">Adecuado</label>
                                        </div>
                                    </div>

                                    <div class="form-check form-check-inline">
                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-grande" value="grande">
                                            <label class="form-check-label nombre-input" for="opciones-tamaño">Grande</label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Calificación APGAR</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Edad gestacional</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Otras Complicaciones</label>
                                <select class="estadoPerinatal browser-default custom-select">
                                    <option value="ausentes" selected>Ausentes</option>
                                    <option value="presentes">Presentes</option>
                                </select>
                            </div>

                            <div class="complicacionPerinatal form-group form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Complicaciones</label>
                                <textarea class="form-control"></textarea>
                            </div>
                        </div>
                    </div>

                    <div class="form-row margen-general-2-top">
                        <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Patológicos</label>
                            <select class="antecedentePatologico browser-default custom-select margen-general-2-top">
                                <option value="ausentesPat" selected>Ausentes</option>
                                <option value="presentesPat">Presentes</option>
                            </select>
                            <div class="descripcionPatologicos margen-general-2-top">
                                <%--<div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">--%>
                                <label class="nombre-input">Descripción</label>
                                <textarea class="form-control"></textarea>
                                <%--</div>--%>
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Quirúrgicos</label>
                            <select class="antecedenteQuirurgico browser-default custom-select margen-general-2-top">
                                <option value="ausentesQui" selected>Ausentes</option>
                                <option value="presentesQui">Presentes</option>
                            </select>
                            <div class="descripcionQuirurgico margen-general-2-top">
                                <%--<div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">--%>
                                <label class="nombre-input">Descripción</label>
                                <textarea class="form-control"></textarea>
                                <%--</div>--%>
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Traumáticos</label>
                            <select class="antecedenteTraumatico browser-default custom-select margen-general-2-top">
                                <option value="ausentesTrau" selected>Ausentes</option>
                                <option value="presentesTrau">Presentes</option>
                            </select>
                            <div class="descripcionTraumatico margen-general-2-top">
                                <%--<div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">--%>
                                <label class="nombre-input">Descripcion</label>
                                <textarea class="form-control"></textarea>
                                <%--</div>--%>
                            </div>
                        </div>

                    </div>

                    <div style="margin-top: 15px;">
                        <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Heredo-Familiares</label>
                    </div>

                    <div class="border padding-general-top ">
                        <div class="form-row padding-general-checkB">
                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group ">
                                    <input class="form-check-input" type="checkbox" value="asma" id="asmaCheck">
                                    <label class="form-check-label nombre-input" for="asmaCheck">Asma</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="diabetes" id="diabetesCheck">
                                    <label class="form-check-label nombre-input" for="diabetesCheck">Diabetes</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="hipertension" id="hipertencionCheck">
                                    <label class="form-check-label nombre-input" for="hipertencionCheck">Hipertensión Arterial</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row padding-general-checkB">
                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group ">
                                    <input class="form-check-input" type="checkbox" value="displidemia" id="displidemiaCheck">
                                    <label class="form-check-label nombre-input" for="displidemiaCheck">Displidemia</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="epilepsia" id="epilepsiaCheck">
                                    <label class="form-check-label nombre-input" for="epilepsiaCheck">Epilepsia</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="cardiovascular" id="cardiovascularCheck">
                                    <label class="form-check-label nombre-input" for="cardiovascularCheck">Enfermedades Cardiovasculares</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row padding-general-checkB">
                            <div class="form-check col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group ">
                                    <input class="form-check-input" type="checkbox" value="otros" id="otrosCheck">
                                    <label class="form-check-label nombre-input" for="otrosCheck">Otros</label>
                                </div>
                            </div>
                        </div>

                        <div class="descripcionOtros form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label class="nombre-input">Descripción</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>
                    </div>

                    <div style="margin-top: 15px;">
                        <label style="font-size: 20px; font-weight: bold; color: dimgray">Alergias</label>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <select class="alergiasExpediente browser-default custom-select">
                                <option value="ausentesAlergia" selected>Ausentes</option>
                                <option value="presentesAlergia">Presentes</option>
                            </select>
                        </div>
                    </div>

                    <div class="descripcionAlergia form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label class="nombre-input">Descripción</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div style="margin-top: 15px;">
                        <label style="font-size: 20px; font-weight: bold; color: dimgray">Vacunas</label>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <select class="vacunasExpediente browser-default custom-select">
                                <option value="esquemaAlDia" selected>Al dia para la edad con esquema básico</option>
                                <option value="pendientes">Pendientes</option>
                            </select>
                        </div>
                    </div>

                    <div class="descripcionVacuna form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Descripción</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                </div>
            </div>
            <!-- Fin del fromulario para expediente !-->

        </div>

        <div style="text-align: right">
            <div class="ali" style="margin-top: 15px; margin-bottom: 15px;">
                <div class="btnGuardarExpediente form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                    <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>
                </div>
            </div>
        </div>

    </div>

    <script>
        $('#datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>
</asp:Content>
