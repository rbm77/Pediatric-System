<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaExpedientes.aspx.cs" Inherits="Pediatric_System.InicioPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $('[id*=gridExpediente]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });
    </script>

    <link href="CSS/listaExpedientes.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid col-11 col-auto">
        <div class="page-header margen-general-2-top">
            <h3 class="text-info">Expedientes</h3>
        </div>

        <hr class="linea-divisoria-titulo" />




        <form runat="server">

            <div class="col-12 margen-general-1-bottom paddingSidesCard">
                <div class="table-responsive">
                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Expedientes</h5>
                        <div class="card-body">
                           

                                <asp:GridView ID="gridExpedientes" runat="server" CssClass="table" Style="text-align: center"
                                    AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%" 
                                    OnRowCommand="gridExpedientes_RowCommand">
                                    

                                    <Columns>
                                        <asp:BoundField HeaderText="Paciente" DataField="Nombre" />
                                        <asp:BoundField HeaderText="Cédula" DataField="Cedula" />
                                        <asp:BoundField HeaderText="Sexo" DataField="Sexo" />
                                        <asp:ButtonField HeaderText="Acción" CommandName="seleccionar"
                                            ControlStyle-CssClass="btn btn-neutro fas fa-eye" runat="server" ControlStyle-Width="25%" />
                                        <asp:BoundField Visible="false" HeaderText="Codigo" DataField="Codigo" ></asp:BoundField>
                                    </Columns>
                                </asp:GridView>

                            

                            <br />
                            
                            <%//Paciente ni administrador pueden crear un nuevo expediente
                                if (Session["Rol"].ToString() != ("Administrador") && Session["Rol"].ToString() != ("Paciente"))
                                {%>
		 
	
                            <div class="alinearBtnNuevo">
                                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12 ubicacionBtnNuevo">
                                    <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevoExpediente" Text="NUEVO EXPEDIENTE" ID="nuevoExpediente" OnClick="nuevoExpediente_Click" />
                                </div>
                            </div>
                            <%}  %>
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

            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" />
                </div>
            </div>

        </form>
    </div>

</asp:Content>
