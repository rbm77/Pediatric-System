<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaConsultas.aspx.cs" Inherits="Pediatric_System.ListaConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/listaConsultas.js"></script>
    <link href="CSS/listaConsultas.css" rel="stylesheet" />

    <script type="text/javascript">
        $(function () {
            $('[id*=gridConsultas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid col-11 col-auto">

        <div class="page-header">
            <h3 class="text-info">Consultas</h3>
        </div>

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
                                <label class="info-paciente"><pre class="info-paciente">Paciente:   </pre></label>
                                <asp:Label ID="paciGeneral" runat="server" CssClass="nombre-input"></asp:Label>
                                <%--<label runat="server" id="paciGeneral" class="nombre-input"></label>--%>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente"><pre class="info-paciente">Cédula:  </pre></label>
                                <label id="cedGeneral" runat="server" class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente"><pre class="info-paciente">Edad:   </pre></label>
                                <label id="edaGeneral" runat="server" class="nombre-input"></label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

             <%-------------------------------------------------------------------------------------------%>

            <div class="col-12 margen-general-1-bottom paddingSidesCard" style="padding-top:10px">
                <div class="table-responsive">
                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Consultas</h5>
                        <div class="card-body"> 
                            <div>

                                <asp:GridView ID="gridConsultas" runat="server" CssClass="table" Style="text-align: center"
                                    AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%" 
                                    OnRowCommand="gridConsultas_RowCommand">
                                   
                                    

                                    <Columns>
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                        <asp:BoundField HeaderText="Médico" DataField="Doctor" />
                                        <asp:BoundField HeaderText="Estado" DataField="Estado" />                   
                                        <asp:ButtonField HeaderText="Acción" CommandName="seleccionar"
                                            ControlStyle-CssClass="btn btn-neutro fas fa-eye" runat="server" ControlStyle-Width="25%" />
                                    </Columns>
                                </asp:GridView>

                            </div>

                            <br />


                            <div class="alinearBtnNuevo">
                                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12 ubicacionBtnNuevo">
                                    <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevoExpediente" Text="NUEVA CONSULTA" ID="nuevaConsulta" OnClick="nuevoConsulta_Click" />
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

            <%-------------------------------------------------------------------------------------------%>



            <%--<div class="col-12 margen-general-1-bottom paddingSidesCard">
                <div>

                    <div class="table-responsive">

                        <div class="card">
                            <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Consultas</h5>
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
                             <%//Paciente ni administrador pueden crear una nueva consulta
                                 if (Session["Rol"].ToString() != ("Administrador") && Session["Rol"].ToString() != ("Paciente"))
                                {%>
                            <div class="alinearBtnNuevo">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnNuevo" runat="server">

                                    <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevaConsulta" Text="NUEVA CONSULTA" ID="nuevoConsulta" OnClick="nuevoConsulta_Click" />
                                </div>
                            </div>
                             <%}  %>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />
                </div>
            </div>--%>

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
