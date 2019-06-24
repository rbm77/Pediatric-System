<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaExpedientes.aspx.cs" Inherits="Pediatric_System.InicioPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="CSS/listaExpedientes.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />

    <div class="container-fluid col-11 col-auto">
        <div class="page-header">
            <h2 class="text-info">Expedientes</h2>
        </div>


        <hr class="linea-divisoria-titulo" />

        <form runat="server">
            <br />

            <div class="col-12 margen-general-1-bottom paddingSidesCard">
                <div class="table-responsive">

                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-table"></i> Lista de Expedientes</h5>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-hover" id="dataTable">
                                    <thead>
                                        <tr class="bg-light">
                                            <th scope="col" style="color: dimgray;">Paciente</th>
                                            <th scope="col" style="color: dimgray;">Cédula</th>
                                            <th scope="col" style="color: dimgray;">Edad</th>
                                            <th scope="col" style="color: dimgray;">Acción</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Richard Bolaños Moya</td>
                                            <td>2-0785-0434</td>
                                            <td>21</td>
                                            <td>Pendiente</td>
                                        </tr>
                                        <tr>
                                            <td>Fabian Jimenez Morales</td>
                                            <td>2-0264-0478</td>
                                            <td>21</td>
                                            <td>Pendiente</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <br />
                        </div>

                        <div class="alinearBtnNuevo">
                            <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnNuevo" runat="server">

                                <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevoExpediente" Text="NUEVO EXPEDIENTE" ID="nuevoExpediente" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" />
                </div>
            </div>

        </form>
    </div>



    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
    </div>
    </div>

    <br />
    <br />

    </form>



</asp:Content>
