<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaBaseExpediente.aspx.cs" Inherits="Pediatric_System.FichaBaseExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript" src="JS/expediente.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Expediente</h2>
        </div>

        <hr style="color: #0056b2;" />

        <!-- Inicio del titulo de los Tabs !-->

        <div style="margin-top: 15px">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarExpediente()" class="nav-link active" id="info-personal-paciente-tab" data-toggle="tab" href="#info-personal-paciente" role="tab" aria-controls="info-personal-paciente" aria-selected="true">Información Personal del Paciente</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarExpediente()" class="nav-link" id="info-personal-encargado-tab" data-toggle="tab" href="#info-personal-encargado" role="tab" aria-controls="info-personal-encargado" aria-selected="false">Información Personal del Encargado del Paciente</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarExpediente()" class="nav-link" id="info-personal-facturante-tab" data-toggle="tab" href="#info-personal-facturante" role="tab" aria-controls="info-personal-facturante" aria-selected="false">Información Personal del Facturante</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarExpediente()" class="nav-link" id="historia-clinica-tab" data-toggle="tab" href="#historia-clinica" role="tab" aria-controls="historia-clinica" aria-selected="false">Historia Clinica del Paciente</a>
                </li>
            </ul>
        </div>

    

    <!-- ----------------------------------------------------------- !-->

    <!-- Incio del contenido de los Tabs !-->

        <div class="tab-content" id="myTabContent">

                <!-- Datos para la Informacion Personal del Paciente !-->

                <div class="tab-pane fade show active" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab" style="margin-bottom: 25px;">

                    <div class="col-12 bg-light border border-info rounded"; style="margin-top: 15px";>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Nombre</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Primer Apellido</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Segundo Apellido</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Cédula</label>
                                <input type="text" class="form-control" placeholder="1-0234-0456">
                            </div>

                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Nacimiento</label>
                                <input class="form-control" id="datepicker" placeholder="31/12/2018" />
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Sexo</label>
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Seleccionar Sexo</option>
                                    <option value="Femenino">Femenino</option>
                                    <option value="Maculino">Masculino</option>
                                    <option value="Otro">Otro</option>
                                </select>
                            </div>
                        </div>

                    </div>

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px;">

                        <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Dirección</label>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Provincia</option>
                                </select>
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Cantón</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Distrito</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px;">

                        <div class="form-row ">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px;">Foto del Paciente</label>
                                <div class="custom-file">
                                    <input type="file" class="custom-file-input" id="subirExamenFisico"
                                        aria-describedby="inputGroupFileAddon01">
                                    <label class="custom-file-label" for="inputGroupFile01" data-browse="Buscar">Seleccionar Archivo</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Vincular expediente antiguo</label>
                                <input type="text" class="form-control" placeholder="URL del expdiente antiguo">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <a class="url" href="ListaConsultas.aspx" style="font-size: 16px; font-weight: bold; color: #56baed;">Ver consultas del paciente</a>
                            </div>
                        </div>
                    </div>

                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para Informacion Personal del Encargado del Paciente !-->

                <div class="tab-pane fade" id="info-personal-encargado" role="tabpanel" aria-labelledby="info-personal-encargado-tab" style="margin-bottom: 25px;">

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Nombre</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Primer Apellido</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Segundo Apellido</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Cédula</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Teléfono</label>
                                <input type="text" class="form-control" placeholder="12345678">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Correo Electrónico</label>
                                <input type="text" class="form-control" placeholder="ejm@gmail.com">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Parentezco</label>
                                <input type="text" class="form-control" placeholder="Padre, Madre, Encargado(a)...">
                            </div>
                        </div>
                    </div>

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px;">

                        <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Dirección</label>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Provincia</option>
                                </select>

                            </div>
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Cantón</option>
                                </select>
                            </div>

                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Distrito</option>
                                </select>
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Barrio</option>
                                </select>
                            </div>
                        </div>
                    </div>

                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para Informacion Personal del Destinatario de la Factura !-->

                <div class="tab-pane fade" id="info-personal-facturante" role="tabpanel" aria-labelledby="info-personal-facturante" style="margin-bottom: 25px;">

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Nombre</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Primer Apelido</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Segundo Apelido</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Cédula</label>
                                <input type="text" class="form-control" placeholder="1-0234-0456">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Teléfono</label>
                                <input type="text" class="form-control" placeholder="12345678">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Correo Electrónico</label>
                                <input type="text" class="form-control" placeholder="ejm@gmail.com">
                            </div>
                        </div>
                    </div>

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px;">

                        <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Dirección</label>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Provincia</option>
                                </select>

                            </div>
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Cantón</option>
                                </select>
                            </div>

                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Distrito</option>
                                </select>
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="browser-default custom-select">
                                    <option value="" disabled selected>Barrio</option>
                                </select>
                            </div>
                        </div>
                    </div>


                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para Historia Clinica Pediatrica !-->

                <div class="tab-pane fade" id="historia-clinica" role="tabpanel" aria-labelledby="historia-clinica-tab" style="margin-bottom: 25px;">

                    <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                        <div style="margin-top: 15px;">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Perinatales</label>
                        </div>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Talla al nacer</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Peso al nacer</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Perímetro cefélico al nacer</label>
                                <input type="text" class="form-control">
                            </div>

                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Calificación APGAR</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Edad gestacional</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Calificación universal</label>
                                <select class="clasificacionUniversalOpciones browser-default custom-select">
                                    <option value="termino" selected>Recién nacido de término</option>
                                    <option value="pretermino">Recién nacido de pretérmino</option>
                                    <option value="postermino">Recién nacido de postérmino</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="clasificacionTamaño" style="margin-left: 10px;">
                                <div class="form-check form-check-inline">
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-pequeño" value="pequeño">
                                        <label class="form-check-label" for="opciones-tamaño" style="font-size: 16px; font-weight: bold; color: dimgray">Pequeño</label>
                                    </div>
                                </div>

                                <div class="form-check form-check-inline">
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-adecuado" value="adecuado" checked>
                                        <label class="form-check-label" for="opciones-tamaño" style="font-size: 16px; font-weight: bold; color: dimgray">Adecuado</label>
                                    </div>
                                </div>

                                <div class="form-check form-check-inline">
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-grande" value="grande">
                                        <label class="form-check-label" for="opciones-tamaño" style="font-size: 16px; font-weight: bold; color: dimgray">Grande</label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Otras Complicaciones</label>
                                <select class="estadoPerinatal browser-default custom-select">
                                    <option value="ausentes" selected>Ausentes</option>
                                    <option value="presentes">Presentes</option>
                                </select>
                            </div>
                        </div>

                        <div class="complicacionPerinatal form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Complicaciones</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div style="margin-top: 15px;">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Patológicos</label>
                        </div>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="antecedentePatologico browser-default custom-select">
                                    <option value="ausentesPat" selected>Ausentes</option>
                                    <option value="presentesPat">Presentes</option>
                                </select>
                            </div>
                        </div>

                        <div class="descripcionPatologicos form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Descripción</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div style="margin-top: 15px;">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Quirúrgicos</label>
                        </div>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="antecedenteQuirurgico browser-default custom-select">
                                    <option value="ausentesQui" selected>Ausentes</option>
                                    <option value="presentesQui">Presentes</option>
                                </select>
                            </div>
                        </div>

                        <div class="descripcionQuirurgico form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Descripción</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div style="margin-top: 15px;">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Traumáticos</label>
                        </div>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <select class="antecedenteTraumatico browser-default custom-select">
                                    <option value="ausentesTrau" selected>Ausentes</option>
                                    <option value="presentesTrau">Presentes</option>
                                </select>
                            </div>
                        </div>

                        <div class="descripcionTraumatico form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Descripcion</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>


                        <div style="margin-top: 15px;">
                            <label style="font-size: 20px; font-weight: bold; color: dimgray">Antecedentes Heredo-Familiares</label>
                        </div>

                        <div class="form-row">
                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group ">
                                    <input class="form-check-input" type="checkbox" value="asma" id="asmaCheck">
                                    <label class="form-check-label" for="asmaCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Asma</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="diabetes" id="diabetesCheck">
                                    <label class="form-check-label" for="diabetesCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Diabetes</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="hipertension" id="hipertencionCheck">
                                    <label class="form-check-label" for="hipertencionCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Hipertensión Arterial</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group ">
                                    <input class="form-check-input" type="checkbox" value="displidemia" id="displidemiaCheck">
                                    <label class="form-check-label" for="displidemiaCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Displidemia</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="epilepsia" id="epilepsiaCheck">
                                    <label class="form-check-label" for="epilepsiaCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Epilepsia</label>
                                </div>
                            </div>

                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group">
                                    <input class="form-check-input" type="checkbox" value="cardiovascular" id="cardiovascularCheck">
                                    <label class="form-check-label" for="cardiovascularCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Enfermedades Cardiovasculares</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-check col-lg-4 col-md-4 col-sm-12 col-xs-12" style="padding-left: 25px">
                                <div class="form-group ">
                                    <input class="form-check-input" type="checkbox" value="otros" id="otrosCheck">
                                    <label class="form-check-label" for="otrosCheck" style="font-size: 16px; font-weight: bold; color: dimgray">Otros</label>
                                </div>
                            </div>
                        </div>

                        <div class="descripcionOtros form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Descripción</label>
                                <input type="text" class="form-control">
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
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Descripción</label>
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

                     <div class="form-row" style="margin-top: 15px; margin-bottom: 15px;">
                        <div class="btnGuardarExpediente form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                            <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>
                        </div>
                    </div>
                </div>
            <!-- Fin del fromulario para expediente !-->

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
