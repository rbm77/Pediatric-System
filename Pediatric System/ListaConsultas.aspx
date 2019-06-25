<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaConsultas.aspx.cs" Inherits="Pediatric_System.ListaConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/listaConsultas.js"></script>
    <link href="CSS/listaConsultas.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-11 col-auto">

        <div class="page-header">
            <h2 class="text-info">Consultas</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <!-- ---------------------------------------------------- !-->

        <form runat="server">

            <div class="margen-general-2-top" runat="server" id="informacionPaciente">
                <div class="col-12">
                    <div class="form-row">

                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="alinearFoto">
                                <asp:Image ID="imgPreview" Width="150" ImageUrl="~/images/foto_perfil_icono.jpg" runat="server" />
                            </div>
                        </div>

                        <div class="form-group col-lg-9 col-md-6 col-sm-6 col-xs-12">
                            <div class="form-row">
                                <label class="info-paciente">Paciente: </label>
                                <label class="nombre-input"></label>
                                <br />
                            </div>

                            <div class="form-row padding-info-exp">
                                <br />
                                <label class="info-paciente">Cédula: </label>
                                <label class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <br />
                                <label class="info-paciente">Edad: </label>
                                <label class="nombre-input"></label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="col-12 margen-general-1-bottom paddingSidesCard">
                <div>

                    <div class="table-responsive">

                        <div class="card">
                            <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-clipboard"></i>  Lista de Consultas</h5>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table class="table table-hover" id="dataTable">
                                        <thead>
                                            <tr class="bg-light">
                                                <th scope="col" style="color: dimgray;">Paciente</th>
                                                <th scope="col" style="color: dimgray;">Fecha</th>
                                                <th scope="col" style="color: dimgray;">Doctor</th>
                                                <th scope="col" style="color: dimgray;">Acción</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <br />
                            </div>

                            <div class="alinearBtnNuevo">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnNuevo" runat="server">

                                    <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevaConsulta" Text="NUEVA CONSULTA" ID="nuevoConsulta" OnClick="nuevoConsulta_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />
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
