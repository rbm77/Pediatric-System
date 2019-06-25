<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaExpedientes.aspx.cs" Inherits="Pediatric_System.InicioPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $('[id*=gridExpedientes]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Expedientes</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form runat="server">
        <br />

        <div class="container-fluid col-11 col-auto table-responsive">

            <div class="card">
                <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-table"></i>Lista de Expedientes</h5>
                <div class="card-body">
                    <div>                        

                        <asp:GridView ID="gridExpedientes" runat="server" CssClass="table table-hover"
                            AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                            HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%">

                            <Columns>
                                <asp:BoundField HeaderText="Paciente" DataField="Nombre" ControlStyle-Width="25%" />
                                <asp:BoundField HeaderText="Sexo" DataField="Sexo" ControlStyle-Width="25%" />
                            </Columns>
                        </asp:GridView>

                        <%--<table class="table table-hover" id="dataTable">
                            <thead>
                                <tr class="bg-light">
                                    <th scope="col" style="color: dimgray;">Nombre Completo</th>
                                    <th scope="col" style="color: dimgray;">Cédula</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Richard Bolaños Moya</td>
                                    <td>2-0785-0434</td>
                                </tr>
                                <tr>
                                    <td>Fabian Jimenez Morales</td>
                                    <td>2-0264-0478</td>
                                </tr>

                            </tbody>
                        </table>--%>
                    </div>

                    <hr style="color: #0056b2;" />
                    <br />

                    <div class="form-row" style="text-align: right; display: block">
                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12" style="display: inline-block">

                            <button type="submit" class="btn btn-neutro form-control">CREAR EXPEDIENTE</button>

                        </div>
                    </div>
                </div>
            </div>



            <!-- Modal >
            <div-- class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel" style="color: dimgray;">CUENTA DE USUARIO EXTERNO</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="card">
                                <div class="card-body">
                                    <p class="card-text col-lg-12 col-md-12 col-sm-12 col-xs-12" style="color: dimgray;">
                                        Se enviará un correo a la dirección ingresada, el cual contiene la contraseña
                                    de acceso al sistema.
                                    </p>
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <label style="color: dimgray;" for="correoElectronico">Correo Electrónico</label>
                                        <input type="email" class="form-control" id="correoElectronico" />
                                    </div>
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <button type="submit" class="btn btn-outline-primary form-control">ENVIAR</button>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div-->

        </div>

        <br />
        <br />

    </form>



</asp:Content>
