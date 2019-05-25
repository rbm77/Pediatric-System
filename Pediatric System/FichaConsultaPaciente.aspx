<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaConsultaPaciente.aspx.cs" Inherits="Pediatric_System.FichaConsultaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/consulta.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Consulta Medica</h2>
        </div>

        <hr style="color: #0056b2;" />


        <%--<div class="row col-12">
            <label style="font-size: 24px; font-weight: bold; color: dimgray">Padecimiento Actual</label>
        </div>--%>


        <!-- Fecha y Hora y Padecimiento Actual !-->

        <div class="col-12 bg-light border border-info rounded">
            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Padecimiento Actual</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha y Hora</label>
                    <%--<input type="text" class="form-control">--%>
                </div>
            </div>
        </div>

        <!-- ------------------------------------------------------------ !-->

        <!-- Inicio del titulo de los Tabs !-->

        <div style="margin-top: 15px">

            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="primera-parte-tab" data-toggle="tab" href="#ef-primera-parte" role="tab" aria-controls="ef-primera-parte" aria-selected="true">I Parte Examen Fisico</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" id="segunda-parte-tab" data-toggle="tab" href="#ef-segunda-parte" role="tab" aria-controls="ef-segunda-parte" aria-selected="false">II Parte Examen Fisico</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" id="analisis-tab" data-toggle="tab" href="#consulta-analisis" role="tab" aria-controls="consulta-analisis" aria-selected="false">Analisis</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" id="diagnostico-tab" data-toggle="tab" href="#consulta-diagnostico" role="tab" aria-controls="consulta-diagnostico" aria-selected="false">Impresion Diagnostica</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" id="plan-tab" data-toggle="tab" href="#consulta-plan" role="tab" aria-controls="consulta-plan" aria-selected="false">Plan</a>
                </li>
            </ul>

        </div>

        <!-- --------------------------------------------------------------------- !-->

        <!-- Inicio del contenido de los Tabs !-->

        <div class="tab-content" id="myTabContent">

            <!-- Inicio de la Primera Parte del Examen Fisico !-->

            <div class="tab-pane fade show active" id="ef-primera-parte" role="tabpanel" aria-labelledby="ef-primera-parte-tab">

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Primera Parte del Examen Fisico</label>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Talla</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Peso</label>
                            <input type="text" class="form-control">
                        </div>

                    </div>

                    <div class="form-row">

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Perimetro Cefalico</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Temperatura</label>
                            <input type="text" class="form-control">
                        </div>

                    </div>

                    <div class="form-row">

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">SO2</label>
                            <input type="text" class="form-control">
                        </div>

                    </div>
                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio de la Segunda Parte del Examen Fisico !-->

            <div class="tab-pane fade" id="ef-segunda-parte" role="tabpanel" aria-labelledby="ef-segunda-parte-tab">

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Segunda Parte del Examen Fisico</label>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Estado de alerta</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Estado de hidratacion</label>
                            <input type="text" class="form-control">
                        </div>

                    </div>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Ruidos cardiacos</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Campos pulmunares</label>
                            <input type="text" class="form-control">
                        </div>

                    </div>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Abdomen</label>
                            <input type="text" class="form-control">
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Faringe</label>
                            <input type="text" class="form-control">
                        </div>

                    </div>
                </div>
            </div>
            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio del Analisis !-->

            <div class="tab-pane fade" id="consulta-analisis" role="tabpanel" aria-labelledby="consulta-analisis-tab">

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Analisis</label>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Comentario</label>
                            <textarea class="form-control" rows="4"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

            <!-- Inicio del Analisis !-->

            <div class="tab-pane fade" id="consulta-diagnostico" role="tabpanel" aria-labelledby="consulta-diagnostico-tab">

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Impresion Diagnostica</label>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Comentario</label>
                            <textarea class="form-control" rows="4"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

             <!-- Inicio del Analisis !-->

            <div class="tab-pane fade" id="consulta-plan" role="tabpanel" aria-labelledby="consulta-plan-tab">

                <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

                    <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Plan</label>

                    <div class="form-row" style="margin-top: 15px;">

                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <label style="font-size: 16px; font-weight: bold; color: dimgray">Comentario</label>
                            <textarea class="form-control" rows="4"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <!-- --------------------------------------------------------------------- !-->

        </div>
    </div>

</asp:Content>
