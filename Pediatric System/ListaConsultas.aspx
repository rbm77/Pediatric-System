<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaConsultas.aspx.cs" Inherits="Pediatric_System.ListaConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/listaConsultas.js"></script>
    <link href="CSS/listaConsultas.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css">

    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-11 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Consultas</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <!-- ---------------------------------------------------- !-->

        <form runat="server">

            <div class="margen-general-2-top">
                <div class="col-12">
                    <div class="form-row">
                        <div class="form-group col-lg-3 col-md-12 col-sm-12 col-xs-12">
                            <label class="info-paciente">Paciente: </label>
                            <label class="nombre-input">Fabian Jimenez Morales</label>
                        </div>

                        <div class="form-group col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <label class="info-paciente">Cédula: </label>
                            <label class="nombre-input"></label>
                        </div>

                        <div class="form-group col-lg-1 col-md-4 col-sm-6 col-xs-6">
                            <label class="info-paciente">Edad: </label>
                            <label class="nombre-input"></label>
                        </div>

                        <%--<div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">
                            <div class="alinearBtnExpFin">
                                <div class="form-group ubicacionBtn" runat="server" id="form_actualizar">
                                    <asp:Button type="button" runat="server" class="btn btn-neutro  btnsExpFin" Text="EXPEDIENTE" ID="Button1" />

                                    <asp:Button type="button" runat="server" class="btn btn-neutro  btnsExpFin" Text="FINALIZAR CONSULTA" ID="Button2" />
                                </div>
                            </div>
                        </div>--%>

                        <div class="form-group col-lg-6 col-md-4 col-sm-12 col-xs-12">
                            <div class="alinearFoto">
                                <asp:Image ID="imgPreview" Width="150" ImageUrl="~/images/foto_perfil_icono.jpg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>




            <div class="col-12 margen-general-1-bottom">
                <div class="margen-general-2-top padding-general-bottom">
                    <div class="card">
                        <label class="card-header text-center nombre-input">Lista de Consultas</label>
                        <div class="card-body padding-general-top">
                            <div class="form-row">
                                <div class="form-group col-lg-5 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <asp:TextBox placeholder="Fecha de Inicio" runat="server" ID="fechaInicio" CssClass="form-control datepicker1"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-5 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <asp:TextBox placeholder="Fecha de Fin" runat="server" ID="fechaFin" CssClass="form-control datepicker2"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-2 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <asp:Button CssClass="btn btn-neutro" ID="buscarFechas" runat="server" Text="BUSCAR" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div>

                    <div class="card lista-resultados-columna" style="margin-top: 25px">

                        <div class="card-body">
                            <table class="table table-hover table-responsive-sm">
                                <thead>
                                    <tr>
                                        <th scope="col" style="width: 50px; font-size: 16px; font-weight: bold; color: dimgray">Fecha de Consulta</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>05/28/2019</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class="form-row" style="margin-bottom: 15px; margin-top: 15px">
                        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                            <button type="submit" class="btn btn-outline-primary form-control">CREAR NUEVA CONSULTA</button>
                        </div>
                        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                            <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>
                        </div>
                    </div>

                </div>
            </div>
        </form>
    </div>

    <script>

        $(document).ready(function () {
            $('#tablaConsultas').DataTable();
        });

        $('.datepicker1').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });

        $('.datepicker2').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>

</asp:Content>
