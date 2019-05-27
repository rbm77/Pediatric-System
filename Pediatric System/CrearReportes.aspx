<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CrearReportes.aspx.cs" Inherits="Pediatric_System.CrearReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript" src="JS/reportes.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Reportes</h2>
        </div>

        <hr style="color: #0056b2;" />

        <!-- ---------------------------------------------------- !-->

        <form>
            <div class="col-12 bg-light border border-info rounded table-responsive">
                <div class="form-row" style="margin-top: 15px;">
                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Inicio</label>
                        <input id="datepickerInicio" placeholder="31/12/2018" />
                    </div>

                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Fin</label>
                        <input id="datepickerFin" placeholder="31/12/2018" />
                    </div>
                    <%--</div>--%>

                    <%--<div class="form-row">--%>
                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Seleccionar reporte</label>
                        <select class="seleccionReporte browser-default custom-select">
                            <option disabled selected></option>
                            <option value="medicinaMixta">Medicina Mixta</option>
                            <option value="ve02">Boleta VE-02</option>
                        </select>
                    </div>
                </div>


                <%--<div class="form-row col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin-top: 15px; text-align:center; display:inline-block">
                <br />
                <input class="btn btn-primary next" type="button" value="Aceptar" style="background-color: #56baed; border: none; padding: 10px 50px; margin-bottom: 45px;" />
            </div>--%>
            </div>

            <div class="visualizacionTitulo" style="margin-top: 25px;">
                <div class="row col-12">
                    <label style="font-size: 24px; font-weight: bold; color: dimgray">Resultado</label>
                </div>
            </div>

            <div class="card visualizacion-medicina-mixta">

                <div class="card-body">
                    <table class="table table-hover table-responsive-sm" >
                        <thead>
                            <tr>
                                <th scope="col" style="width: 50px;">Identificador de Expediente</th>
                                <th scope="col" style="width: 25px;">Frecuencia</th>
                                <th scope="col" style="width: 25px;">Referido a</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>6-0444-0297</td>
                                <td>Subsecuente</td>
                                <td>Hospitalizacion</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="card visualizacion-boleta-ve02">

                <div class="card-body">
                    <table class="table table-hover table-responsive-md">
                        <thead>
                            <tr>
                                <th scope="col">Fecha</th>
                                <th scope="col">Enfermedad</th>
                                <th scope="col">Sexo</th>
                                <th scope="col">Edad (Meses)</th>
                                <th scope="col">Dirección</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>27/05/2019</td>
                                <td>Escabisosis</td>
                                <td>Masculino</td>
                                <td>2</td>
                                <td>Buenos Aires, Palmares, Alajuela</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="btnGenerarReporte" style="margin-top: 25px; margin-bottom: 25px">
                <input class="btn btn-primary next" type="button" value="Generar PDF" style="background-color: #56baed; border: none; padding: 10px 50px;" />
            </div>

        </form>
    </div>

</asp:Content>
