<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaConsultaPaciente.aspx.cs" Inherits="Pediatric_System.FichaConsultaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/consulta.js"></script>
    <link rel="stylesheet" href="CSS/consulta.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-11 col-auto">

        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Consulta Médica</h2>
        </div>

        <hr class="linea-divisoria-titulo " />

        <!-- Inicio del titulo de los Tabs !-->

        <form runat="server">

            <div class="margen-general-2-top">
                <div class="col-12">
                    <div class="form-row">
                        <div class="form-group col-lg-3 col-md-12 col-sm-12 col-xs-12">
                            <label class="info-paciente">Paciente: </label>
                            <label class="nombre-input">Fabian Jimenez Morales</label>
                        </div>

                        <div class="form-group col-lg-2 col-md-6 col-sm-6 col-xs-6">
                            <label class="info-paciente">Cédula: </label>
                            <label class="nombre-input"></label>
                        </div>

                        <div class="form-group col-lg-1 col-md-6 col-sm-6 col-xs-6">
                            <label class="info-paciente">Edad: </label>
                            <label class="nombre-input"></label>
                        </div>

                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                            <div class="alinearBtnExpFin">
                                <div class="form-group ubicacionBtn" runat="server" id="form_actualizar">
                                    <asp:Button type="button" runat="server" class="btn btn-neutro  btnsExpFin" Text="EXPEDIENTE" ID="Button1" />

                                    <asp:Button type="button" runat="server" class="btn btn-neutro  btnsExpFin" Text="FINALIZAR CONSULTA" ID="Button2" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="alinearFoto">
                                <asp:Image ID="imgPreview" Width="150" ImageUrl="~/images/foto_perfil_icono.jpg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Inicio del titulo de los Tabs !-->

            <div class="margen-general-3-top">
                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active nombre-input" id="primera-parte-tab" data-toggle="tab" href="#ef-primera-parte" role="tab" aria-controls="ef-primera-parte" aria-selected="true">I Parte Examen Físico</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="segunda-parte-tab" data-toggle="tab" href="#ef-segunda-parte" role="tab" aria-controls="ef-segunda-parte" aria-selected="false">II Parte Examen Físico</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="examen-laboratorio-tab" data-toggle="tab" href="#examen-laboratorio" role="tab" aria-controls="examen-laboratorio" aria-selected="false">Examen de Laboratorio</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="diagnostico-nutricional-tab" data-toggle="tab" href="#diagnostico-nutricional" role="tab" aria-controls="diagnostico-nutricional" aria-selected="false">Diagnóstico Nutricional</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="analisis-tab" data-toggle="tab" href="#consulta-analisis" role="tab" aria-controls="consulta-analisis" aria-selected="false">Análisis</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="diagnostico-tab" data-toggle="tab" href="#consulta-diagnostico" role="tab" aria-controls="consulta-diagnostico" aria-selected="false">Impresión Diagnóstica</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="plan-tab" data-toggle="tab" href="#consulta-plan" role="tab" aria-controls="consulta-plan" aria-selected="false">Plan</a>
                    </li>
                </ul>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio del contenido de los Tabs !-->

            <div class="tab-content" id="myTabContent">

                <!-- Inicio de la Primera Parte del Examen Fisico !-->

                <div class="tab-pane fade show active margen-general-1-bottom" id="ef-primera-parte" role="tabpanel" aria-labelledby="ef-primera-parte-tab">

                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Talla</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Peso</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Perímetro Cefálico</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Temperatura</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">SO2</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">IMC</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- --------------------------------------------------------------------- !-->

                <!-- Inicio de la Segunda Parte del Examen Fisico !-->

                <div class="tab-pane fade margen-general-1-bottom" id="ef-segunda-parte" role="tabpanel" aria-labelledby="ef-segunda-parte-tab">

                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Estado de alerta</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Estado de hidratación</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Ruidos cardíacos</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Campos pulmunares</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Abdomen</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Faringe</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Neurodesarrollo</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nariz</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Oídos</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">SNC</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Sistema Osteomuscular</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Piel</label>
                                        <input type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Otros hallazgos</label>
                                        <textarea class="form-control"></textarea>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row general-card padding-general-bottom">
                            <div class="form-group col-lg-6 col-md-6 col-sm-12 col-xs-12 margen-general-2-bottom">
                                <div class="card">
                                    <label class="card-header nombre-input">Padecimiento Actual</label>
                                    <div class="card-body padding-general-top padding-general-bottom">
                                        <div class="padding-general-label">
                                            <textarea class="form-control"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- --------------------------------------------------------------------- !-->

                <!-- Inicio agregar examen de laboratorio !-->

                <div class="tab-pane fade" id="examen-laboratorio" role="tabpanel" aria-labelledby="examen-laboratorio-tab">
                    <div class="col-12 border rounded">
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

                <div class="tab-pane fade margen-general-1-bottom" id="diagnostico-nutricional" role="tabpanel" aria-labelledby="diagnostico-nutricional-tab">
                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Peso-Edad en Niñas/Niños de 0 a 5 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Talla-Edad en Niñas/Niños de 0 a 5 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Perímetro Cefálico en Niñas/Niños de 0 a 3 años </label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Peso para Talla Niñas/Niños de 0 a 5 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">IMC en Niñas/Niños de 5 a 19 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Talla-Edad en niños/niñas de 5 a 19 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="padding-general-inicio-bottom">
                            <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                <div>
                                    <div class="form-group" runat="server">
                                        <asp:Button type="button" runat="server" class="btn btn-neutro form-control btnVerGenerarDiagnostico" Text="GENERAR DIAGNOSTICO" ID="verConsultas" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--<div class="form-row padding-general-inicio-bottom padding-general-label">
                            <div class="btnGenerarDiagnostico form-group col-lg-3 col-md-6 col-sm-6 col-xs-6">
                                <button type="submit" class="btn btn-info form-control">Generar Diagnostico</button>
                            </div>
                        </div>--%>
                    </div>
                </div>

                <!-- --------------------------------------------------------------------- !-->

                <!-- Inicio del Analisis !-->

                <div class="tab-pane fade margen-general-1-bottom" id="consulta-analisis" role="tabpanel" aria-labelledby="consulta-analisis-tab">
                    <div class="col-12 border rounded margen-general-1-bottom padding-general-inicio-top">
                        <div class="form-row margen-general-2-top padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="padding-general-label">
                                    <label class="nombre-input">Comentario</label>
                                    <textarea class="form-control" rows="4"></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- --------------------------------------------------------------------- !-->

                <!-- Inicio del Impresion Diagnostica !-->

                <div class="tab-pane fade margen-general-1-bottom" id="consulta-diagnostico" role="tabpanel" aria-labelledby="consulta-diagnostico-tab">
                    <div class="col-12 border rounded margen-general-1-bottom padding-general-inicio-top">
                        <div class="form-row margen-general-2-top padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="padding-general-label">
                                    <label class="nombre-input">Comentario</label>
                                    <textarea class="form-control" rows="4"></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- --------------------------------------------------------------------- !-->

                <!-- Inicio del Plan !-->

                <div class="tab-pane fade margen-general-1-bottom" id="consulta-plan" role="tabpanel" aria-labelledby="consulta-plan-tab">
                    <div class="col-12 border rounded margen-general-1-bottom padding-general-inicio-top">
                        <div class="form-row margen-general-2-top padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="padding-general-label">
                                    <label class="nombre-input">Plan</label>
                                    <textarea class="form-control" rows="4"></textarea>
                                </div>
                            </div>
                        </div>


                        <div class="form-row">
                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                <div class="padding-card padding-general-bottom">
                                    <div class="card">
                                        <label class="card-header nombre-input">Medicina Mixta</label>
                                        <div class="card-body padding-general-top">
                                            <div class="form-row">
                                                <div class="form-check">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <input class="form-check-input" type="checkbox" id="reporte-medicina-mixta" value="medicna-mixta">
                                                            <label class="form-check-label nombre-input" for="reporte-medicina-mixta">Reportar paciente a medicina mixta</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Inicio de reportar paciente a medicina mixta !-->

                                            <div class="datosReporteMedicinaMixta">
                                                <div class="form-row">
                                                    <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12 margen-1-radioB">
                                                        <label class="nombre-input padding-general-label">Frecuencia</label>
                                                    </div>
                                                </div>

                                                <!-- Tipos de frecuencia !-->

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input class="form-check-input" type="radio" name="frecuencia-medicina-mixta" id="primera-vez" value="primera">
                                                            <label class="form-check-label nombre-input" for="frecuencia-medicina-mixta">Primera vez</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Tipos de primera vez !-->

                                                <div class="opciones-primera-vez padding-general-label">
                                                    <div class="form-row">
                                                        <div class="form-check form-check-inline">
                                                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <input class="form-check-input" type="radio" name="opciones-primera-vez" id="opcion-vida" value="vida">
                                                                <label class="form-check-label nombre-input" for="opciones-primera-vez">Vida</label>
                                                            </div>
                                                        </div>

                                                        <div class="form-check form-check-inline">
                                                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <input class="form-check-input" type="radio" name="opciones-primera-vez" id="opcion-año" value="año">
                                                                <label class="form-check-label nombre-input" for="opciones-primera-vez">Año</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- ---------------------------------------------------------- !-->

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input class="form-check-input" type="radio" name="frecuencia-medicina-mixta" id="subsecuente" value="subsecuen">
                                                            <label class="form-check-label nombre-input" for="frecuencia-medicina-mixta">Subsecuente</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- ---------------------------------------------------------- !-->

                                                <!-- Tipos de referidos !-->

                                                <div class="form-row">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <label class="nombre-input padding-general-label">Referido a</label>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input class="form-check-input" type="radio" name="referido-a-medicina-mixta" id="especialista" value="refe-especialista">
                                                            <label class="form-check-label nombre-input" for="referido-a-medicina-mixta">Especialista</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input class="form-check-input" type="radio" name="referido-a-medicina-mixta" id="hospitalizacion" value="refe-hospitalizacion">
                                                            <label class="form-check-label nombre-input" for="referido-a-medicina-mixta">Hospitalización</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input class="form-check-input" type="radio" name="referido-a-medicina-mixta" id="otro-centro" value="refe-otro-centro">
                                                            <label class="form-check-label nombre-input" for="referido-a-medicina-mixta">Otro centro</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label padding-general-inicio-top">
                                                    <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-6">
                                                        <button type="submit" class="btn btn-info form-control">ENVIAR</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- ---------------------------------------------------------------------- !-->

                            <!-- Inicio de datos para referencia medica externa de consulta privada !-->

                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                <div class="padding-card padding-general-bottom">
                                    <div class="card">
                                        <label class="card-header nombre-input">Referencia Medica</label>
                                        <div class="card-body padding-general-top">
                                            <div class="form-row">
                                                <div class="form-check">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <input class="form-check-input" type="checkbox" id="referencia-consulta-privada" value="referencia-privada">
                                                            <label class="form-check-label nombre-input" for="referencia-consulta-privada">Generar referencia médica externa de consulta privada</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="datosReferenciaPrivada">
                                                <div class="form-row margen-general-2-top">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <label class="nombre-input">Especialidad a que se refiere</label>
                                                            <input type="text" class="form-control">
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row margen-general-2-top">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <label class="nombre-input">Motivo de la referencia</label>
                                                            <input type="text" class="form-control">
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label padding-general-inicio-top">
                                                    <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-6">
                                                        <button type="submit" class="btn btn-info form-control">GENERAR</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>

            </div>

            <div class="form-row alinearBtnGuardarCon">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtn" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar form-control" Text="REGRESAR" ID="regresar" />

                    <asp:Button type="button" runat="server" CssClass="btn btn-guardar form-control" Text="GUARDAR" ID="guardarConsulta" ValidationGroup="validarConsulta" />
                </div>
            </div>
        </form>
    </div>



</asp:Content>
