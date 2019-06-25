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
                        <input class="datepicker" placeholder="31/12/2018" />
                    </div>

                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Fin</label>
                        <input class="datepicker" placeholder="31/12/2018" />
                    </div>

                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Seleccionar reporte</label>
                        <select class="seleccionReporte browser-default custom-select">
                            <option disabled selected></option>
                            <option value="medicinaMixta">Medicina Mixta</option>
                            <option value="ve02">Boleta VE-02</option>
                        </select>
                    </div>
                </div>
            </div>

            <div class="visualizacionTitulo" style="margin-top: 25px;">
                <div class="row col-12">
                    <label style="font-size: 20px; font-weight: bold; color: dimgray">Resultado</label>
                </div>
            </div>

            <div class="card visualizacion-medicina-mixta">

                <div class="card-body">
                    <table class="table table-hover table-responsive-sm">
                        <thead>
                            <tr>
                                <th scope="col" style="width: 50px; font-size: 16px; font-weight: bold; color: dimgray">Identificador de Expediente</th>
                                <th scope="col" style="width: 25px; font-size: 16px; font-weight: bold; color: dimgray">Frecuencia</th>
                                <th scope="col" style="width: 25px; font-size: 16px; font-weight: bold; color: dimgray">Referido a</th>
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
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Fecha</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Enfermedad</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Sexo</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Edad (Meses)</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Dirección</th>
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

            <div class="form-row">
                <div class="btnGenerarReporte form-group col-lg-3 col-md-3 col-sm-3 col-xs-6" style="margin-top: 25px; margin-bottom: 25px">
                    <button type="submit" class="btn btn-outline-primary form-control">GENERAR PDF</button>
                </div>
                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6" style="margin-top: 25px; margin-bottom: 25px">
                    <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>
                </div>
            </div>
        </form>
    </div>


    <script>
        $('.datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>

</asp:Content>
