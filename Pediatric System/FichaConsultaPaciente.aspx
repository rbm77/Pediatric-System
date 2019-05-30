<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaConsultaPaciente.aspx.cs" Inherits="Pediatric_System.FichaConsultaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/consulta.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Consulta Médica</h2>
        </div>

        <hr style="color: #0056b2;" />

        <!-- Inicio del titulo de los Tabs !-->

        <div style="margin-top: 15px">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarConsulta()" class="nav-link active" id="primera-parte-tab" data-toggle="tab" href="#ef-primera-parte" role="tab" aria-controls="ef-primera-parte" aria-selected="true">I Parte Examen Físico</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarConsulta()" class="nav-link" id="segunda-parte-tab" data-toggle="tab" href="#ef-segunda-parte" role="tab" aria-controls="ef-segunda-parte" aria-selected="false">II Parte Examen Físico</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarConsulta()" class="nav-link" id="examen-laboratorio-tab" data-toggle="tab" href="#examen-laboratorio" role="tab" aria-controls="examen-laboratorio" aria-selected="false">Examen de Laboratorio</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarConsulta()" class="nav-link" id="diagnostico-nutricional-tab" data-toggle="tab" href="#diagnostico-nutricional" role="tab" aria-controls="diagnostico-nutricional" aria-selected="false">Diagnóstico Nutricional</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarConsulta()" class="nav-link" id="analisis-tab" data-toggle="tab" href="#consulta-analisis" role="tab" aria-controls="consulta-analisis" aria-selected="false">Análisis</a>
                </li>

                <li class="nav-item">
                    <a onclick="ocultarBtnGuardarConsulta()" class="nav-link" id="diagnostico-tab" data-toggle="tab" href="#consulta-diagnostico" role="tab" aria-controls="consulta-diagnostico" aria-selected="false">Impresión Diagnóstica</a>
                </li>

                <li class="nav-item">
                    <a onclick="mostrarBtnGuardarConsulta()" class="nav-link" id="plan-tab" data-toggle="tab" href="#consulta-plan" role="tab" aria-controls="consulta-plan" aria-selected="false">Plan</a>
                </li>
            </ul>
        </div>

        <!-- --------------------------------------------------------------------- !-->

        <!-- Inicio del contenido de los Tabs !-->

        <div class="tab-content" id="myTabContent">

            <!-- Inicio de la Primera Parte del Examen Fisico !-->

            <div class="tab-pane fade show active" id="ef-primera-parte" role="tabpanel" aria-labelledby="ef-primera-parte-tab" style="margin-bottom: 25px;">
                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Talla</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Peso</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Perímetro Cefálico</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Temperatura</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">SO2</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">IMC</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>
                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio de la Segunda Parte del Examen Fisico !-->

            <div class="tab-pane fade" id="ef-segunda-parte" role="tabpanel" aria-labelledby="ef-segunda-parte-tab" style="margin-bottom: 25px;">
                <!-- Padecimiento Actual !-->

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">
                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Padecimiento Actual</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>
                </div>

                <!-- ------------------------------------------------------------ !-->

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Estado de alerta</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Estado de hidratación</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Ruidos cardíacos</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Campos pulmunares</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Abdomen</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Faringe</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Neurodesarrollo</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Nariz</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Oídos</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">SNC</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Sistema Osteomuscular</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Piel</label>
                            <input type="text" class="form-control" value="Normal">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Otros hallazgos</label>
                            <input type="text" class="form-control" value="No encontrados">
                        </div>
                    </div>
                </div>
            </div>
            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio agregar examen de laboratorio !-->

            <div class="tab-pane fade" id="examen-laboratorio" role="tabpanel" aria-labelledby="examen-laboratorio-tab" style="margin-bottom: 25px;">
                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Adjuntar Examenes de Laboratorio</label>

                    <div class="form-row ">
                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <div class="custom-file">
                                <input type="file" class="custom-file-input" id="subirExamenFisico" aria-describedby="inputGroupFileAddon01" multiple>
                                <label class="custom-file-label" for="inputGroupFile01" data-browse="Buscar">Seleccionar Archivo</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- -------------------------------------------------------------------- !-->

            <!-- Inicio del Diagnostico Nutricional !-->

            <div class="tab-pane fade" id="diagnostico-nutricional" role="tabpanel" aria-labelledby="diagnostico-nutricional-tab" style="margin-bottom: 25px;">
                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Peso-Edad en Niñas/Niños de 0 a 5 años</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Talla-Edad en Niñas/Niños de 0 a 5 años</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Perímetro Cefálico en Niñas/Niños de 0 a 3 años </label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Peso para Talla Niñas/Niños de 0 a 5 años</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">IMC en Niñas/Niños de 5 a 19 años</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Talla-Edad en niños/niñas de 5 a 19 años</label>
                            <input type="text" class="form-control">
                        </div>
                    </div>

                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio del Analisis !-->

            <div class="tab-pane fade" id="consulta-analisis" role="tabpanel" aria-labelledby="consulta-analisis-tab" style="margin-bottom: 25px;">
                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Comentario</label>

                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <textarea class="form-control" rows="4"></textarea>
                        </div>
                    </div>

                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio del Impresion Diagnostica !-->

            <div class="tab-pane fade" id="consulta-diagnostico" role="tabpanel" aria-labelledby="consulta-diagnostico-tab" style="margin-bottom: 25px;">
                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Comentario</label>

                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <textarea class="form-control" rows="4"></textarea>
                        </div>
                    </div>

                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio del Plan !-->

            <div class="tab-pane fade" id="consulta-plan" role="tabpanel" aria-labelledby="consulta-plan-tab" style="margin-bottom: 25px;">

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Plan</label>
                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <textarea class="form-control" rows="4"></textarea>
                        </div>
                    </div>
                </div>

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Referencia</label>
                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-check">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <input class="form-check-input" type="checkbox" id="reporte-medicina-mixta" value="medicna-mixta">
                                <label class="form-check-label" for="reporte-medicina-mixta" style="font-size: 16px; font-weight: bold; color: dimgray">
                                    Reportar paciente a medicina mixta
                                </label>
                            </div>
                        </div>
                    </div>

                    <!-- Inicio de reportar paciente a medicina mixta !-->

                    <div class="datosReporteMedicinaMixta">
                        <div class="form-row">
                            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="margin-left: 45px">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Frecuencia</label>
                            </div>
                        </div>

                        <!-- Tipos de frecuencia !-->

                        <div class="form-row" style="margin-left: 45px">
                            <div class="form-check">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <input class="form-check-input" type="radio" name="frecuencia-medicina-mixta" id="primera-vez" value="primera">
                                    <label class="form-check-label" for="frecuencia-medicina-mixta" style="font-size: 16px; font-weight: bold; color: dimgray">Primera vez</label>
                                </div>
                            </div>
                        </div>

                        <!-- Tipos de primera vez !-->

                        <div class="opciones-primera-vez" style="margin-left: 55px">
                            <div class="form-row">
                                <div class="form-check form-check-inline">
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <input class="form-check-input" type="radio" name="opciones-primera-vez" id="opcion-vida" value="vida">
                                        <label class="form-check-label" for="opciones-primera-vez" style="font-size: 16px; font-weight: bold; color: dimgray">Vida</label>
                                    </div>
                                </div>

                                <div class="form-check form-check-inline">
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <input class="form-check-input" type="radio" name="opciones-primera-vez" id="opcion-año" value="año">
                                        <label class="form-check-label" for="opciones-primera-vez" style="font-size: 16px; font-weight: bold; color: dimgray">Año</label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- ---------------------------------------------------------- !-->

                        <div class="form-row" style="margin-left: 45px">
                            <div class="form-check">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <input class="form-check-input" type="radio" name="frecuencia-medicina-mixta" id="subsecuente" value="subsecuen">
                                    <label class="form-check-label" for="frecuencia-medicina-mixta" style="font-size: 16px; font-weight: bold; color: dimgray">Subsecuente</label>
                                </div>
                            </div>
                        </div>

                        <!-- ---------------------------------------------------------- !-->

                        <!-- Tipos de referidos !-->

                        <div class="form-row">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-left: 45px">Referido a</label>
                            </div>
                        </div>

                        <div class="form-row" style="margin-left: 45px">
                            <div class="form-check">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <input class="form-check-input" type="radio" name="referido-a-medicina-mixta" id="especialista" value="refe-especialista">
                                    <label class="form-check-label" for="referido-a-medicina-mixta" style="font-size: 16px; font-weight: bold; color: dimgray">Especialista</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row" style="margin-left: 45px">
                            <div class="form-check">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <input class="form-check-input" type="radio" name="referido-a-medicina-mixta" id="hospitalizacion" value="refe-hospitalizacion">
                                    <label class="form-check-label" for="referido-a-medicina-mixta" style="font-size: 16px; font-weight: bold; color: dimgray">Hospitalización</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-row" style="margin-left: 45px">
                            <div class="form-check">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <input class="form-check-input" type="radio" name="referido-a-medicina-mixta" id="otro-centro" value="refe-otro-centro">
                                    <label class="form-check-label" for="referido-a-medicina-mixta" style="font-size: 16px; font-weight: bold; color: dimgray">Otro centro</label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6" style="margin-top: 15px; margin-bottom: 15px; padding-left:0px">
                            <input class="btn btn-outline-primary form-control" type="button" value="ENVIAR A REPORTE" />
                        </div>
                    </div>

                    <!-- ---------------------------------------------------------------------- !-->

                    <!-- Inicio de datos para referencia medica externa de consulta privada !-->

                    <div class="form-row" style="margin-top: 15px;">
                        <div class="form-check">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <input class="form-check-input" type="checkbox" id="referencia-consulta-privada" value="referencia-privada">
                                <label class="form-check-label" for="referencia-consulta-privada" style="font-size: 16px; font-weight: bold; color: dimgray">Generar referencia médica externa de consulta privada</label>
                            </div>
                        </div>
                    </div>

                    <div class="datosReferenciaPrivada">
                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Especialidad a que se refiere</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-row" style="margin-top: 15px;">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <label style="font-size: 16px; font-weight: bold; color: dimgray">Motivo de la referencia</label>
                                <input type="text" class="form-control">
                            </div>
                        </div>

                        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6" style="margin-top: 15px; margin-bottom: 15px; padding-left:0px">
                            <input class="btn btn-outline-primary form-control" type="button" value="GENERAR PDF" />
                        </div>
                    </div>

                </div>
            </div>
            <form>
                <div class="form-row" style="margin-top: 15px; margin-bottom: 15px;">
                    <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                        <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>
                    </div>
                    <div class="btnGuardarConsulta form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                        <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>
                    </div>                 
                </div>
            </form>
        </div>
    </div>



</asp:Content>
