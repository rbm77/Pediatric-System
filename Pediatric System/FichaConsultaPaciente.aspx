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

            <div class="margen-general-2-top" runat="server" id="informacionPaciente">
                <div class="col-12">
                    <div class="form-row">

                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="alinearFoto">
                                <asp:Image ID="imgPreview" Width="150" ImageUrl="~/images/foto_perfil_icono.jpg" runat="server" />
                            </div>
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <div class="form-row">
                                <label class="info-paciente">Paciente: </label>
                                <label id="paciGeneral" runat="server" class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente">Cédula: </label>
                                <label id="cedGeneral" runat="server" class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente">Edad: </label>
                                <label id="edaGeneral" runat="server" class="nombre-input"></label>
                            </div>
                        </div>

                        <div class="form-group col-lg-3 col-md-10 col-sm-12 col-xs-12">
                            <div class="alinearBtnExpFin">
                                <div class="form-group ubicacionBtn" runat="server" id="form_actualizar">
                                    <asp:Button type="button" runat="server" class="btn btn-neutro btnsExpFin" Text="FINALIZAR CONSULTA" ID="finalizarConsulta" OnClick="finalizarConsulta_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Inicio del titulo de los Tabs !-->

            <div>
                <ul class="nav nav-tabs" id="myTab" role="tablist" style="padding-top:10px">
                    <li class="nav-item">
                        <a class="nav-link active nombre-input" id="primera-parte-tab" data-toggle="tab" href="#ef-primera-parte" role="tab" aria-controls="ef-primera-parte" aria-selected="true">I Parte Examen Físico</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="segunda-parte-tab" data-toggle="tab" href="#ef-segunda-parte" role="tab" aria-controls="ef-segunda-parte" aria-selected="false">II Parte Examen Físico</a>
                    </li>

                    <%--<li class="nav-item">
                        <a class="nav-link nombre-input" id="diagnostico-nutricional-tab" data-toggle="tab" href="#diagnostico-nutricional" role="tab" aria-controls="diagnostico-nutricional" aria-selected="false">Diagnóstico Nutricional</a>
                    </li>--%>

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
                                        <input runat="server" id="tallaPac" type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Peso</label>
                                        <input runat="server" id="pesoPac" type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Perímetro Cefálico</label>
                                        <input runat="server" id="perimetroPac" type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Temperatura</label>
                                        <input runat="server" id="temperaturaPac" type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">SO2</label>
                                        <input runat="server" id="so2Pac" type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">IMC</label>
                                        <input runat="server" id="imcPac" type="text" class="form-control">
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
                                        <input runat="server" id="alertaPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Estado de hidratación</label>
                                        <input runat="server" id="hidratacionPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Ruidos cardíacos</label>
                                        <input runat="server" id="ruidosPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Campos pulmunares</label>
                                        <input runat="server" id="camposPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Abdomen</label>
                                        <input runat="server" id="abdomenPpac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Faringe</label>
                                        <input runat="server" id="faringePac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Neurodesarrollo</label>
                                        <input runat="server" id="neuroPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nariz</label>
                                        <input runat="server" id="narizPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Oídos</label>
                                        <input runat="server" id="oidosPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">SNC</label>
                                        <input runat="server" id="sncPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Sistema Osteomuscular</label>
                                        <input runat="server" id="osteomuscPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Piel</label>
                                        <input runat="server" id="pielPac" type="text" class="form-control" value="Normal">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Otros hallazgos</label>
                                        <textarea runat="server" id="otrosPac" class="form-control"></textarea>
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
                                            <textarea runat="server" id="padecimientoPac" class="form-control" rows="3"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- --------------------------------------------------------------------- !-->

                <%--<!-- Inicio del Diagnostico Nutricional !-->

                <div class="tab-pane fade margen-general-1-bottom" id="diagnostico-nutricional" role="tabpanel" aria-labelledby="diagnostico-nutricional-tab">
                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Peso/Edad de 0 a 5 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Talla/Edad de 0 a 5 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">P. Cefálico/Edad de 0 a 3 años </label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Peso/Talla de 0 a 5 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">IMC/Edad de 5 a 19 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Talla/Edad de 5 a 19 años</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="form-row padding-general-inicio-bottom padding-general-label">
                            <div class="btnGenerarDiagnostico form-group col-lg-3 col-md-6 col-sm-6 col-xs-6">
                                <button type="submit" class="btn btn-info form-control">Generar Diagnostico</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- --------------------------------------------------------------------- !-->--%>

                <!-- Inicio del Analisis !-->


                <div class="tab-pane fade margen-general-1-bottom" id="consulta-analisis" role="tabpanel" aria-labelledby="consulta-analisis-tab">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 paddingSidesCard">
                        <div class="card">
                            <label class="card-header nombre-input">Comentario</label>

                            <div class="card-body">
                                <div class="padding-general-label padding-general-inicio-bottom padding-general-inicio-top">
                                    <textarea runat="server" id="analisisPac" class="form-control" rows="4"></textarea>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>

                <!-- --------------------------------------------------------------------- !-->

                <!-- Inicio del Impresion Diagnostica !-->

                <div class="tab-pane fade margen-general-1-bottom" id="consulta-diagnostico" role="tabpanel" aria-labelledby="consulta-diagnostico-tab">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 paddingSidesCard">
                        <div class="card">
                            <label class="card-header nombre-input">Comentario</label>

                            <div class="card-body">
                                <div class="padding-general-label padding-general-inicio-bottom padding-general-inicio-top">
                                    <textarea runat="server" id="impresionPac" class="form-control" rows="4"></textarea>
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
                                    <textarea runat="server" id="planPac" class="form-control" rows="4"></textarea>
                                </div>
                            </div>
                        </div>


                        <!-- Inicio de reportar paciente a medicina mixta !-->

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
                                                            <input runat="server" ClientIDMode="Static" class="form-check-input" type="checkbox" id="reporte_medicina_mixta" value="medicna-mixta">
                                                            <label class="form-check-label nombre-input" for="reporte_medicina_mixta">Reportar paciente a medicina mixta</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                                                                        
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
                                                            <input runat="server" class="form-check-input" type="radio" name="frecuencia_medicina-_mixta" id="primera_vez" value="primera">
                                                            <label class="form-check-label nombre-input" for="frecuencia_medicina_mixta">Primera vez</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Tipos de primera vez !-->

                                                <div class="opciones-primera-vez padding-general-label">
                                                    <div class="form-row" style="padding-left: 10px">
                                                        <div class="form-check form-check-inline">
                                                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <input runat="server" class="form-check-input" type="radio" name="opciones_primera_vez" id="opcion_vida" value="vida">
                                                                <label class="form-check-label nombre-input" for="opciones_primera_vez">Vida</label>
                                                            </div>
                                                        </div>

                                                        <div class="form-check form-check-inline">
                                                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <input runat="server" class="form-check-input" type="radio" name="opciones_primera_vez" id="opcion_año" value="año">
                                                                <label class="form-check-label nombre-input" for="opciones_primera_vez">Año</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- ---------------------------------------------------------- !-->

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input runat="server" class="form-check-input" type="radio" name="frecuencia_medicina_mixta" id="subsecuente" value="subsecuen">
                                                            <label class="form-check-label nombre-input" for="frecuencia_medicina_mixta">Subsecuente</label>
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
                                                            <input runat="server" class="form-check-input" type="radio" name="referido_medicina_mixta" id="especialista" value="refe_especialista">
                                                            <label class="form-check-label nombre-input" for="referido_medicina_mixta">Especialista</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input runat="server" class="form-check-input" type="radio" name="referido_medicina_mixta" id="hospitalizacion" value="refe_hospitalizacion">
                                                            <label class="form-check-label nombre-input" for="referido_medicina_mixta">Hospitalización</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label">
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <input runat="server" class="form-check-input" type="radio" name="referido_medicina_mixta" id="otro_centro" value="refe_otro_centro">
                                                            <label class="form-check-label nombre-input" for="referido_medicina_mixta">Otro centro</label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label padding-general-inicio-top">
                                                    <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                        <button runat="server" type="submit" class="btn btn-info form-control">REPORTAR</button>
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
                                        <label class="card-header nombre-input">Referencia Médica</label>
                                        <div class="card-body padding-general-top">
                                            <div class="form-row">
                                                <div class="form-check">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <input runat="server" ClientIDMode="Static" class="form-check-input" type="checkbox" id="referencia_consulta_privada" value="referencia_privada">
                                                            <label class="form-check-label nombre-input" for="referencia_consulta_privada">Generar referencia médica externa de consulta privada</label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="datosReferenciaPrivada">
                                                <div class="form-row margen-general-2-top">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <label class="nombre-input">Especialidad</label>
                                                            <asp:TextBox ID="especialidad" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row margen-general-2-top">
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="padding-general-label">
                                                            <label class="nombre-input">Motivo de la referencia</label>
                                                            <textarea id="motivo" rows="2" runat="server" class="form-control"></textarea>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-row padding-general-label padding-general-inicio-top">
                                                    <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                        <asp:Button type="submit" CssClass="btn btn-neutro" runat="server" id="btnGenerarReferencia" OnClick="btnGenerarReferencia_Click" Text="GENERAR" />
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
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />

                    <asp:Button type="button" runat="server" CssClass="btn btn-guardar" Text="GUARDAR" ID="guardarConsulta" ValidationGroup="validarConsulta" OnClick="guardarConsulta_Click" />
                </div>
            </div>
        </form>
    </div>



</asp:Content>
